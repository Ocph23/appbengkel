using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class ItemPenjualanContext : IDataContext<ItemPenjualan>
    {
        private static List<ItemPenjualan> list = new List<ItemPenjualan>();
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ItemPenjualan> Get()
        {
            return list;
        }

        public ItemPenjualan GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public ItemPenjualan Insert(ItemPenjualan item)
        {
            throw new NotImplementedException();
        }

        public ItemPenjualan Update(ItemPenjualan item)
        {
            throw new NotImplementedException();
        }
    }
}