using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MainWeb.Models;

namespace MainWeb.DataAccess.Contexts
{
    public class PenjualanContext : IDataContext<Models.Penjualan>
    {
        private static List<Penjualan> list = new List<Penjualan>();
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Penjualan> Get()
        {
            return new List<Penjualan>();
        }

        public Penjualan GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Penjualan Insert(Penjualan item)
        {
            list.Add(item);
            return item;
        }

        public Penjualan Update(Penjualan item)
        {
            throw new NotImplementedException();
        }

    }
}