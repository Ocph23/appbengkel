﻿using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class BarangContext : IDataContext<Barang>
    {
        public static List<Barang> list = new List<Barang>();
        public bool Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public List<Barang> Get()
        {
            return list;
        }

        public Barang GetById(object Id)
        {
            throw new NotImplementedException();
        }

        public Barang Insert(Barang item)
        {
            list.Add(item);
            return item;
        }

        public Barang Update(Barang item)
        {
            throw new NotImplementedException();
        }
    }
}