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
            try
            {
                using (var db = new OcphDbContext())
                {
                    if (db.Barang.Delete(x => x.IdBarang == Id))
                        return true;
                    throw new SystemException("Data Tidak terhapus");
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public IEnumerable<Barang> Get()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var results = from a in db.Barang.Select()
                                  join b in db.Kategori.Select() on a.IdKategori equals b.IdKategori
                                  select new Barang
                                  {
                                      IdBarang = a.IdBarang,
                                      IdKategori = a.IdKategori,
                                      Kategori = MapperData.Map<Kategori>(b),
                                      KodeBarang = a.KodeBarang, HargaBeli=a.HargaBeli, HargaJual=a.HargaJual, Stok=a.Stok,
                                      NamaBarang = a.NamaBarang
                                  };
                    return results;
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        public Barang GetById(int Id)
        {
            using (var db = new OcphDbContext())
            {
                var results = from a in db.Barang.Where(x=>x.IdBarang==Id)
                              join b in db.Kategori.Select() on a.IdKategori equals b.IdKategori
                              select new Barang
                              {
                                  IdBarang = a.IdBarang,
                                  IdKategori = b.IdKategori,
                                  Kategori = MapperData.Map<Kategori>(b),
                                  KodeBarang = a.KodeBarang,
                                  HargaBeli = a.HargaBeli,
                                  HargaJual = a.HargaJual,
                                  Stok = a.Stok,
                                  NamaBarang = a.NamaBarang
                              };
                return results.FirstOrDefault();
            }
        }

        public Barang Insert(Barang item)
        {
            try
            {
                if(item.HargaJual <= item.HargaBeli)
                {
                    throw new SystemException("Harga Jual Harus Lebih Besar Dari Harga Beli");
                }

                using (var db = new OcphDbContext())
                {
                    int lasId = 0;
                    var data = db.Barang.Where(x => x.IdKategori == item.IdKategori).LastOrDefault();
                    if(data!=null)
                    {
                        Int32.TryParse(data.KodeBarang.Substring(3, data.KodeBarang.Length-3), out lasId);
                        
                    }

                    item.KodeBarang = $"{(item.IdKategori):D3}{(lasId + 1):D5}";
                    item.IdBarang = db.Barang.InsertAndGetLastID(MapperData.Map<BarangDto>(item));
                    return item;
                }
            }
            catch (Exception ex)
            {

                throw new SystemException(ex.Message);
            }
        }

        public IEnumerable<Kategori> GetKategories()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var results = db.Kategori.Select().ToList();
                    return MapperData.Map<List<Kategori>>(results);
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        public Barang Update(Barang item, int Id)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var data = MapperData.Map<BarangDto>(item);
                    var results = db.Barang.Update(x => new { x.IdKategori, x.KodeBarang, x.NamaBarang, x.HargaJual,x.HargaBeli }, data, x => x.IdBarang == Id);
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