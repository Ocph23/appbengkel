using MainWeb.DataAccess.Dto;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class BarangContext : IDataContext<Barang>
    {

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Barang> Get()
        {
            using (var db = new OcphDbContext())
            {
                var results = from a in db.Barang.Select()
                             
                              select new Barang
                              {
                                  IdBarang = a.IdBarang,
                                 
                                  KodeBarang = a.KodeBarang,
                                  Namabarang = a.NamaBarang
                              };
                return results;
            }
        }

        public Barang GetById(int Id)
        {
            using (var db = new OcphDbContext())
            {
                var results = from a in db.Barang.Where(x=>x.IdBarang==Id)
                              join b in db.Kategori.Select() on a.IdBarang equals b.IdKategori
                              select new Barang
                              {
                                  IdBarang = a.IdBarang,
                                  idKategori = b.IdKategori,
                                  Kategori = b,
                                  KodeBarang = a.KodeBarang,
                                  Namabarang = a.NamaBarang
                              };
                return results.FirstOrDefault();
            }
        }

        public Barang Insert(Barang item)
        {
            using (var db = new OcphDbContext())
            {
                item.IdBarang= db.Barang.InsertAndGetLastID(MapperData.Mapper.Map<BarangDto>(item));
                return item;
            }
        }

        public IEnumerable<Kategori> GetKategories()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var results = db.Kategori.Select().ToList();
                    return MapperData.Mapper.Map<List<Kategori>>(results);
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        public Barang Update(Barang item)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var data = MapperData.Mapper.Map<BarangDto>(item);
                    var results = db.Barang.Update(x => new { x.IdKategori, x.KodeBarang, x.NamaBarang }, data, x => x.IdBarang == item.IdBarang);
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