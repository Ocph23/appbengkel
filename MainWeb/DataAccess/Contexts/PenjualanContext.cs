using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MainWeb.DataAccess.Dto;
using MainWeb.Models;

namespace MainWeb.DataAccess.Contexts
{
    public class PenjualanContext : IDataContext<Penjualan>
    {
        private static List<Penjualan> list = new List<Penjualan>();
        public bool Delete(int Id)
        {
           try
            {
                using (var db = new OcphDbContext())
                {
                    var deleted = db.Penjualan.Delete(x => x.IdPenjualan == Id);
                    if(deleted)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public IEnumerable<Penjualan> Get()
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var result = from a in db.Penjualan.Select()
                                 join b in db.Pelanggan.Select() on a.IdPelanggan equals b.IdPelanggan
                                 select new PenjualanDto
                                 {
                                     FakturPenjualan  = a.FakturPenjualan,
                                     IdPenjualan = a.IdPenjualan,
                                     IdPelanggan= a.IdPelanggan,
                                     Customer = b,
                                     TanggalJual = a.TanggalJual,
                                     UserId = a.UserId,
                                     Items = (from d in db.DetailPenjualan.Where(x => x.IdPenjualan == a.IdPenjualan)
                                              join br in db.Barang.Select() on d.IdBarang equals br.IdBarang
                                              select new ItemPenjualanDto
                                              {
                                                  Barang = br,
                                                  HargaJual = d.HargaJual,
                                                  IdBarang = d.IdBarang,
                                                  IdItem = d.IdItem,
                                                  IdPenjualan = d.IdPenjualan,
                                                  Jumlah = d.Jumlah, HargaBeli=d.HargaBeli
                                              }
                                              ).ToList(),
                                     Services = (from s in db.Services.Where(x => x.IdPenjualan == a.IdPenjualan)
                                                 join m in db.Montir.Select() on s.IdMontir equals m.IdMontir
                                                 select new ItemServiceDto
                                                 {
                                                     Biaya = s.Biaya,
                                                     IdItem = s.IdItem,
                                                     IdMontir = s.IdMontir,
                                                     IdPenjualan = s.IdPenjualan,
                                                     Keterangan = s.Keterangan,
                                                     Perbaikan = s.Perbaikan,
                                                     Montir = m
                                                 }).ToList()
                                 };
                    return MapperData.Map<List<Penjualan>>(result);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Penjualan GetById(int Id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var result = (from a in db.Penjualan.Where(x=>x.IdPenjualan==Id)
                                 join b in db.Pelanggan.Select() on a.IdPelanggan equals b.IdPelanggan
                                 select new PenjualanDto
                                 {
                                     FakturPenjualan = a.FakturPenjualan,
                                     IdPenjualan = a.IdPenjualan,
                                     IdPelanggan = a.IdPelanggan,
                                     Customer = b,
                                     TanggalJual = a.TanggalJual,
                                     UserId = a.UserId,
                                     Items = (from d in db.DetailPenjualan.Where(x => x.IdPenjualan == a.IdPenjualan)
                                              join br in db.Barang.Select() on d.IdBarang equals br.IdBarang
                                              select new ItemPenjualanDto { HargaBeli=d.HargaBeli, Barang=br, HargaJual=d.HargaJual, IdBarang=d.IdBarang, IdItem=d.IdItem,
                                                  IdPenjualan =d.IdPenjualan, Jumlah=d.Jumlah }
                                              ).ToList(),
                                     Services = (from s in db.Services.Where(x => x.IdPenjualan == a.IdPenjualan)
                                                join m in db.Montir.Select() on s.IdMontir equals m.IdMontir
                                                select new ItemServiceDto { Biaya=s.Biaya, IdItem=s.IdItem, IdMontir=s.IdMontir,
                                                 IdPenjualan=s.IdPenjualan, Keterangan=s.Keterangan, Perbaikan=s.Perbaikan,Montir=m}).ToList()
                                 }).FirstOrDefault();
                    return MapperData.Map<Penjualan>(result);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Penjualan Insert(Penjualan itemx)
        {
            var data = MapperData.Map<PenjualanDto>(itemx);
            using (var db = new OcphDbContext())
            {
                var trans = db.BeginTransaction();
                try
                {
                    if(data.IdPelanggan==null && data.Customer!=null)
                    {
                        var pelangganId = db.Pelanggan.InsertAndGetLastID(MapperData.Map<PelangganDto>(data.Customer));
                        if (pelangganId <= 0)
                            throw new SystemException("Data Pelanggan Tidak Tersimpan");
                        data.IdPelanggan = pelangganId;
                    }

                    if (data.IdPenjualan <= 0)
                    {
                        data.IdPenjualan = db.Penjualan.InsertAndGetLastID(data);
                        if (data.IdPenjualan<= 0)
                            throw new SystemException("Data Tidak Tersimpan");
                        else
                        {
                            foreach (var barang in data.Items)
                            {
                                barang.IdPenjualan = data.IdPenjualan;
                                if (!db.DetailPenjualan.Insert(barang))
                                    throw new SystemException("Data Tidak Tersimpan");

                                if (!db.Barang.RemoveStock(barang.IdBarang, barang.Jumlah))
                                    throw new SystemException("Data Stok Tidak Tersimpan");
                            }

                            foreach(var service in data.Services)
                            {
                                if (service.Montir != null)
                                    service.IdMontir = service.Montir.IdMontir;
                                service.IdPenjualan = data.IdPenjualan;
                                if (!db.Services.Insert(service))
                                    throw new SystemException("Data Tidak Tersimpan");
                            }
                        }
                    }
                    else
                    {
                        var updated = db.Penjualan.Update(x => new { x.FakturPenjualan, x.IdPelanggan, x.Pembayaran, x.TanggalJual},
                           MapperData.Map<PenjualanDto>(data), x => x.IdPenjualan== data.IdPenjualan);
                        if (!updated)
                            throw new SystemException("Data Tidak Tersimpan");
                        else
                        {
                            var UpdateOldStock = false;
                            foreach (var barang in data.Items)
                            {
                                var oldData = db.DetailPenjualan.Where(x => x.IdItem == barang.IdItem).FirstOrDefault();
                                if (oldData != null)
                                {
                                    UpdateOldStock = true;
                                    if (!db.DetailPenjualan.Update(x => new { x.Jumlah, x.HargaJual},
                                        barang, x => x.IdItem == barang.IdItem))
                                        throw new SystemException("Item Pembelian Gagal Diubah");
                                }
                                else
                                {
                                    barang.IdPenjualan= data.IdPenjualan;
                                    if (!db.DetailPenjualan.Insert(barang))
                                        throw new SystemException("Data Tidak Tersimpan");
                                    if (!UpdateOldStock)
                                    {
                                        if (!db.Barang.AddStock(barang.IdBarang, barang.Jumlah))
                                            throw new SystemException("Data Stok Tidak Tersimpan");
                                    }
                                }
                            }

                            //Remove Item
                            foreach (var barang in db.DetailPenjualan.Where(x => x.IdPenjualan == data.IdPenjualan))
                            {
                                if (data.Items.Where(x => x.IdItem == barang.IdItem).Count() <= 0)
                                {
                                    if (!db.DetailPembelian.Delete(x => x.IdItem == barang.IdItem))
                                        throw new SystemException("Data Tidak Tersimpan");

                                    UpdateOldStock = true;
                                }
                            }

                            //service
                            foreach (var service in data.Services)
                            {
                                var oldData = db.Services.Where(x => x.IdItem == service.IdItem).FirstOrDefault();
                                if (oldData != null)
                                {
                                    if (service.Montir != null)
                                        service.IdMontir = service.Montir.IdMontir;
                                    if (!db.Services.Update(x => new { x.Biaya, x.Keterangan,x.Perbaikan },
                                        service, x => x.IdItem == service.IdItem))
                                        throw new SystemException("Item Service Gagal Diubah");
                                }
                                else
                                {
                                    if (service.Montir != null)
                                        service.IdMontir = service.Montir.IdMontir;
                                    service.IdPenjualan = data.IdPenjualan;
                                    if (!db.Services.Insert(service))
                                        throw new SystemException("Data Tidak Tersimpan");
                                }
                            }

                            //Remove Service Item
                            foreach (var service in db.Services.Where(x => x.IdPenjualan == data.IdPenjualan))
                            {
                                if (data.Items.Where(x => x.IdItem == service.IdItem).Count() <= 0)
                                {
                                    if (!db.Services.Delete(x => x.IdItem == service.IdItem))
                                        throw new SystemException("Data Tidak Tersimpan");
                                }
                            }

                            if (UpdateOldStock)
                            {
                                if (!db.RecoveryStock())
                                    throw new SystemException("Data Tidak Tersimpan");
                            }
                        }
                    }

                    trans.Commit();
                    var result = MapperData.Map<Penjualan>(data);
                    return result;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new SystemException(ex.Message);
                }
            }
        }

        public Penjualan Update(Penjualan item, int Id)
        {
           try
            {
                using (var db = new OcphDbContext())
                {
                    var data = MapperData.Map<PenjualanDto>(item);
                    var updated = db.Penjualan.Update(x=> new { x.FakturPenjualan, x.TanggalJual }, data, x=>x.IdPenjualan == Id);
                    if (updated)
                        return item;
                    throw new SystemException("Data Tidak Tersimpan");
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }
    }
}