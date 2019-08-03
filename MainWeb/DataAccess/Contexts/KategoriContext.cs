using MainWeb.DataAccess.Dto;
using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class KategoriContext : IDataContext<Kategori>
    {
        public bool Delete(int Id)
        {
            try
            {
                using (var db = new OcphDbContext())
                {
                    return db.Kategori.Delete(x => x.IdKategori == Id);
                }
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public IEnumerable<Kategori> Get()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var results = from a in db.Kategori.Select()
                                  select a;
                    return MapperData.Map<List<Kategori>>(results.ToList());
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }

        public Kategori GetById(int Id)
        {
            using (var db = new OcphDbContext())
            {
                var results = db.Kategori.Where(x => x.IdKategori== Id).FirstOrDefault();
                return MapperData.Map<Kategori>(results);
            }
        }

        public Kategori Insert(Kategori item)
        {
            using (var db = new OcphDbContext())
            {
                item.IdKategori = db.Kategori.InsertAndGetLastID(MapperData.Map<KategoriDto>(item));
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
                    return MapperData.Map<List<Kategori>>(results);
                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }

        public Kategori Update(Kategori item, int idKategori)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var data = MapperData.Map<KategoriDto>(item);
                    var results = db.Kategori.Update(x => new { x.NamaKategori}, data, x => x.IdKategori== idKategori);
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