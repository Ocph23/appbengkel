using MainWeb.DataAccess.Dto;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class PelangganContext : IDataContext<Pelanggan>
    {
        private static List<Pelanggan> list = new List<Pelanggan>();
        public bool Delete(int Id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var deleted = db.Pelanggan.Delete(x => x.IdPelanggan == Id);
                    if(deleted)
                    {
                        return true;
                    }
                    return false;
                }
            }catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public IEnumerable<Pelanggan> Get()
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.Pelanggan.Select().ToList();
                    var res= MapperData.Map<IEnumerable<Pelanggan>>(result);
                    return res;
                }
            }catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Pelanggan GetById(int Id)
        {
           try
            {
                using (var db = new OcphDbContext())
                {
                    var result = db.Pelanggan.Where(x=>x.IdPelanggan == Id).FirstOrDefault();
                    if (result != null)
                        return MapperData.Map<Pelanggan>(result);
                    throw new SystemException("Data Tidak Ditemukan");
                }
            }catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Pelanggan Insert(Pelanggan item)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var data = MapperData.Map<PelangganDto>(item);
                    item.IdPelanggan = db.Pelanggan.InsertAndGetLastID(data);
                    if (item.IdPelanggan > 0)
                        return item;
                    throw new SystemException();
                }
            }catch (Exception ex)
            {
                throw new SystemException("Data Tidak Tersimpan");
            }
        }

        public Pelanggan Update(Pelanggan item, int Id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    var data = MapperData.Map<PelangganDto>(item);
                    var updated = db.Pelanggan.Update(x => new { x.NamaPelanggan, x.Alamat, x.NoTelpon }, data, x => x.IdPelanggan == Id);
                    if (updated)
                        return item;
                    throw new SystemException();
                }
            }catch (Exception ex)
            {
                throw new SystemException("Data Tidak Tersimpan");
            }
        }
    }
}