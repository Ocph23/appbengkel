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
        public bool Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public List<Penjualan> Get()
        {
            return list;
        }

        public Penjualan GetById(object Id)
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