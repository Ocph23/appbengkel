using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class PembelianContext : IDataContext<Pembelian>
    {
        private static List<Pembelian> list = new List<Pembelian>();
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pembelian> Get()
        {
            return list;
        }

        public Pembelian GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Pembelian Insert(Pembelian item)
        {
            throw new NotImplementedException();
        }

        public Pembelian Update(Pembelian item)
        {
            throw new NotImplementedException();
        }
    }
}