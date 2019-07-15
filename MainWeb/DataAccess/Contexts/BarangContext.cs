using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class BarangContext : IDataContext<Barang>
    {
        public bool Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Barang> Get()
        {
            throw new NotImplementedException();
        }

        public Barang GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public Barang Insert(Barang item)
        {
            throw new NotImplementedException();
        }

        public Barang Update(Barang item)
        {
            throw new NotImplementedException();
        }
    }
}