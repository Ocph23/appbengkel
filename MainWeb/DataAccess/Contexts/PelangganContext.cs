﻿using MainWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Contexts
{
    public class PelangganContext : IDataContext<Pelanggan>
    {
        private static List<Pelanggan> list = new List<Pelanggan>();
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pelanggan> Get()
        {
            return new List<Pelanggan>();
        }

        public Pelanggan GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Pelanggan Insert(Pelanggan item)
        {
            throw new NotImplementedException();
        }

        public Pelanggan Update(Pelanggan item)
        {
            throw new NotImplementedException();
        }
    }
}