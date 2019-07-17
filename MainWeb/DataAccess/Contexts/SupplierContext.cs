using System;
using System.Collections.Generic;
using System.Linq;
using MainWeb.DataAccess.Dto;
using MainWeb.Models;

namespace MainWeb.DataAccess.Contexts
{
    public class SupplierContext : IDataContext<Models.Supplier>
    {
        private static List<Supplier> list = new List<Supplier>();

        public bool Delete(int Id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var deleted = db.Supplier.Delete(x => x.IdSupplier == Id);
                    if(deleted)
                    {
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex )
            {
                throw new SystemException(ex.Message);
            }
        }

        public IEnumerable<Supplier> Get()
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var results = db.Supplier.Select();
                    return MapperData.Mapper.Map<List<Supplier>>(results);
                }
            }
            catch (Exception ex )
            {
                throw new SystemException(ex.Message);
            }
        }

        public Supplier GetById(int Id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var results = db.Supplier.Where(x=>x.IdSupplier==Id).FirstOrDefault();
                    if(results!=null)
                         return MapperData.Mapper.Map<Supplier>(results);
                    throw new SystemException("Data Tidak Ditemukan");
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Supplier Insert(Supplier item)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var data = MapperData.Mapper.Map<SupplierDto>(item);
                    item.IdSupplier = db.Supplier.InsertAndGetLastID(data);
                    if (item.IdSupplier > 0)
                        return item;
                    throw new SystemException();
                }
            }
            catch (Exception ex)
            {
                throw new SystemException("Data Tidak Tersimpan");
            }
        }

        public Supplier Update(Supplier item)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var data = MapperData.Mapper.Map<SupplierDto>(item);
                    var updated = db.Supplier.Update(x=> new {  x.Alamat,x.NamaSupplier,x.NoTelpon}, data, x=>x.IdSupplier==item.IdSupplier);
                    if (updated)
                        return item;
                    throw new SystemException();
                }
            }
            catch (Exception)
            {
                throw new SystemException("Data Tidak Tersimpan");
            }
        }
    }
}