using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class BarangContext : IDataContext<Barang>
    {
        public static List<Barang> list = new List<Barang>();

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Barang> Get()
        {
            return list;
        }

        public Barang GetById(int Id)
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