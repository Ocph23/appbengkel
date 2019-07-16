using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MainWeb.Models;

namespace MainWeb.DataAccess.Contexts
{
    public class MontirContext : IDataContext<Models.Montir>
    {
        private static List<Montir> list = new List<Montir>();
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Montir> Get()
        {
            return new List<Montir>();
        }

        public Montir GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Montir Insert(Montir item)
        {
            throw new NotImplementedException();
        }

        public Montir Update(Montir item)
        {
            throw new NotImplementedException();
        }
    }
}