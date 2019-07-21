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
                    var result = db.Penjualan.Select();
                    return MapperData.Mapper.Map<List<Penjualan>>(result);
                }
            }catch (Exception ex)
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
                    var result = db.Penjualan.Where(x => x.IdPenjualan == Id).FirstOrDefault();
                    if (result != null)
                        return MapperData.Mapper.Map<Penjualan>(result);
                    throw new SystemException("Data Tidak Ditemukan");
                }
            }
            catch(Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public Penjualan Insert(Penjualan item)
        {
            try
            {
                using (var db= new OcphDbContext())
                {
                    var data = MapperData.Mapper.Map<PenjualanDto>(item);
                    item.IdPenjualan = db.Penjualan.InsertAndGetLastID(data);
                    if (item.IdPenjualan > 0)
                        return item;
                    throw new SystemException();
                }
            }catch (Exception ex)
            {
                throw new SystemException("Data Tidak Tersimpan");
            }
        }

        public Penjualan Update(Penjualan item)
        {
           try
            {
                using (var db = new OcphDbContext())
                {
                    var data = MapperData.Mapper.Map<PenjualanDto>(item);
                    var updated = db.Penjualan.Update(x=> new { x.FakturPenjualan, x.TanggalJual }, data, x=>x.IdPenjualan == item.IdPenjualan);
                    if (updated)
                        return item;
                    throw new SystemException();
                }
            }
            catch (Exception ex)
            {
                throw new SystemException("Data Tidak Tersimpan");
            }
        }
    }
}