using MainWeb.DataAccess.Dto;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainWeb.DataAccess.Contexts
{
    public class PembelianContext : IDataContext<Pembelian>
    {
        public bool Delete(int Id)
        {
            using (var db = new OcphDbContext())
            {
                var trans = db.BeginTransaction();
                try
                {
                    var pembelian = this.GetById(Id);
                    if (pembelian != null && db.DetailPembelian.Delete(x => x.IdPembelian == pembelian.IdPembelian) &&
                        db.Pembelian.Delete(x => x.IdPembelian == Id))
                    {
                        trans.Commit();
                        return true;
                    }

                    throw new SystemException("Data Tidak tersimpan");
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new SystemException(ex.Message);
                }
            }
        }

        public IEnumerable<Pembelian> Get()
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var result = from a in db.Pembelian.Select()
                                 join b in db.Supplier.Select() on a.IdSupplier equals b.IdSupplier
                                 select new PembelianDto
                                 { FakturPembelian=a.FakturPembelian, IdPembelian=a.IdPembelian, IdSupplier=a.IdSupplier,
                                     Supplier = b, TanggalBeli=a.TanggalBeli, UserId=a.UserId,
                                     Items = db.DetailPembelian.Where(x => x.IdPembelian == a.IdPembelian).ToList()
                                 };
                                


                    return MapperData.Map<List<Pembelian>>(result);
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Pembelian GetById(int Id)
        {
            try
            {
                using (var db =new OcphDbContext())
                {
                    var result = from a in db.Pembelian.Where(x => x.IdPembelian == Id)
                                 join c in db.Supplier.Select() on a.IdSupplier equals c.IdSupplier

                                 select new Pembelian { TanggalBeli=a.TanggalBeli, IdSupplier=a.IdSupplier,
                                     Supplier = MapperData.Map<Supplier>(c), FakturPembelian = a.FakturPembelian,
                                     IdPembelian = a.IdPembelian,
                                     Items = (from b in db.DetailPembelian.Where(x=>x.IdPembelian == a.IdPembelian)
                                   join br in db.Barang.Select() on b.IdBarang equals br.IdBarang
                                   select new ItemPembelian { HargaBeli=b.HargaBeli, IdPembelian =b.IdPembelian,
                                        IdBarang=b.IdBarang, IdItem=b.IdItem, Jumlah=b.Jumlah, Barang = MapperData.Map<Barang>(br) }).ToList()


                                 };
                    
                    if(result==null)
                    {
                        throw new SystemException("Data Tidak Ditemukan");
                    }
                    return result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Pembelian Insert(Pembelian itemx)
        {
            var data = MapperData.Map<PembelianDto>(itemx);
            using (var db = new OcphDbContext())
            {
                var trans = db.BeginTransaction();
                try
                {
                    if(data.IdPembelian<=0)
                    {
                        data.IdPembelian = db.Pembelian.InsertAndGetLastID(data);
                        if (data.IdPembelian <= 0)
                            throw new SystemException("Data Tidak Tersimpan");
                        else
                        {
                            foreach (var barang in data.Items)
                            {
                                barang.IdPembelian = data.IdPembelian;
                                if (!db.DetailPembelian.Insert(barang))
                                    throw new SystemException("Data Tidak Tersimpan");

                                if(!db.Barang.AddStock(barang.IdBarang, barang.Jumlah))
                                    throw new SystemException("Data Stok Tidak Tersimpan");
                            }
                        }
                    }
                    else
                    {
                        var updated = db.Pembelian.Update(x=> new { x.FakturPembelian,x.IdSupplier,x.Pembayaran,x.TanggalBeli},
                           MapperData.Map<PembelianDto>(data),x=>x.IdPembelian== data.IdPembelian);
                        if (!updated)
                            throw new SystemException("Data Tidak Tersimpan");
                        else
                        {
                            var UpdateOldStock = false;
                            foreach (var barang in data.Items)
                            {
                                var oldData = db.DetailPembelian.Where(x => x.IdItem == barang.IdItem).FirstOrDefault();
                                if(oldData!=null)
                                {
                                    UpdateOldStock = true;
                                    if (!db.DetailPembelian.Update(x => new { x.Jumlah, x.HargaBeli }, barang, x => x.IdItem == barang.IdItem))
                                        throw new SystemException("Item Pembelian Gagal Diubah");
                                }
                                else
                                {
                                    barang.IdPembelian = data.IdPembelian;
                                    if (!db.DetailPembelian.Insert(barang))
                                        throw new SystemException("Data Tidak Tersimpan");
                                    if(!UpdateOldStock)
                                    {
                                        if (!db.Barang.AddStock(barang.IdBarang, barang.Jumlah))
                                            throw new SystemException("Data Stok Tidak Tersimpan");
                                    }
                                }
                            }

                            //Remove Item
                            foreach (var barang in db.DetailPembelian.Where(x=>x.IdPembelian== data.IdPembelian))
                            {
                                if(data.Items.Where(x => x.IdItem == barang.IdItem).Count() <= 0 )
                                {
                                    if(!db.DetailPembelian.Delete(x=>x.IdItem==barang.IdItem))
                                        throw new SystemException("Data Tidak Tersimpan");

                                    UpdateOldStock = true;
                                }
                            }

                            if(UpdateOldStock)
                            {
                                if(!db.RecoveryStock())
                                    throw new SystemException("Data Tidak Tersimpan");
                            }
                        }
                    }

                    trans.Commit();
                    return MapperData.Map<Pembelian>(data);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new SystemException(ex.Message);
                }
            }
        }

        public Pembelian Update(Pembelian item, int id)
        {
            var dto = MapperData.Map<PembelianDto>(item);

            using (var db = new OcphDbContext())
            {
                var trans = db.BeginTransaction();
                try
                {
                    var updated = db.Pembelian.Update(x => new { x.FakturPembelian, x.IdSupplier, x.TanggalBeli },
                        dto, x => x.IdPembelian == id);
                    if (updated)
                    {
                        foreach (var data in dto.Items)
                        {
                            db.DetailPembelian.Insert(MapperData.Map<ItemPembelianDto>(data));
                        }
                    }

                    trans.Commit();
                    return item;
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }
    }
}