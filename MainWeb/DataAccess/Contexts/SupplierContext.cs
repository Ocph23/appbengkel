using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MainWeb.Models;

namespace MainWeb.DataAccess.Contexts
{
    public class SupplierContext : IDataContext<Models.Supplier>
    {
        public bool Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> Get()
        {
            throw new NotImplementedException();
        }

        public Supplier GetById(object Id)
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