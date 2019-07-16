﻿using System;
using System.Collections.Generic;
using MainWeb.Models;

namespace MainWeb.DataAccess.Contexts
{
    public class SupplierContext : IDataContext<Supplier>
    {
        private static List<Supplier> list = new List<Supplier>();

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> Get()
        {
            return list;
        }

        public Supplier GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Supplier Insert(Supplier item)
        {
            throw new NotImplementedException();
        }

        public Supplier Update(Supplier item)
        {
            throw new NotImplementedException();
        }
    }
}