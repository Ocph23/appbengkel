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
            throw new NotImplementedException();
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
                                     Data = db.DetailPembelian.Where(x => x.IdPembelian == a.IdPembelian).ToList()
                                 };
                                


                    if (result.Count()<=0)
                    {
                        throw new SystemException("Data Tidak Ditemukan");
                    }
                    return MapperData.Mapper.Map<List<Pembelian>>(result);
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
                    var result = db.Pembelian.Where(x => x.IdPembelian == Id).FirstOrDefault();
                    if(result==null)
                    {
                        throw new SystemException("Data Tidak Ditemukan");
                    }
                    return MapperData.Mapper.Map<Pembelian>(result);
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public Pembelian Insert(Pembelian item)
        {
            try
            {
                var data = MapperData.Mapper.Map<PembelianDto>(item);
                using (var db = new OcphDbContext())
                {
                    item.IdPembelian = db.Pembelian.InsertAndGetLastID(data);
                    return item;
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Pembelian Update(Pembelian item)
        {
            try
            {
                var dto = MapperData.Mapper.Map<PembelianDto>(item);

                using (var db = new OcphDbContext())
                {
                    var updated = db.Pembelian.Update(x => new { x.FakturPembelian, x.IdSupplier, x.TanggalBeli }, dto, x => x.IdPembelian == dto.IdPembelian);
                    if(updated)
                    {
                        foreach(var da in dto.Data)
                        {

                        }
                    }

                }

                return null;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}