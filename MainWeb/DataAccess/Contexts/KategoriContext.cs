using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class KategoriContext : IDataContext<Kategori>
    {
        private static List<Kategori> list = new List<Kategori>();
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kategori> Get()
        {
            return list;
        }

        public Kategori GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Kategori Insert(Kategori item)
        {
            throw new NotImplementedException();
        }

        public Kategori Update(Kategori item)
        {
            throw new NotImplementedException();
        }
    }
}