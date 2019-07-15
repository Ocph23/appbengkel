using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MainWeb.DataAccess.Dto;
using MainWeb.Models;

namespace MainWeb.DataAccess.Contexts
{
    public class SupplierContext : IDataContext<Models.Supplier>
    {

        private IEnumerable<Supplier> SupplierData {get;set;}

        public bool Delete(object Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> Get()
        {
            if(SupplierData==null)
            {
                using (var db = new OcphDbContext())
                {
                    /*   var result = db.Supplier.Select().ToList();
                       SupplierData = MapperData.Mapper.Map<List<Supplier>>(result);*/

                    SupplierData = new List<Supplier>();
                }
            }
            return SupplierData;
        }

        public Supplier GetById(object Id)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.Supplier.Where(x=>x.Id== Id).FirstOrDefault();
                return MapperData.Mapper.Map<Supplier>(result);
            }
        }

        public Supplier Insert(Supplier item)
        {
            using (var db = new OcphDbContext())
            {
                item.IdSupplier= db.Supplier.InsertAndGetLastID(MapperData.Mapper.Map<SupplierDTO1>(item));
                if (item.IdSupplier == 0)
                    throw new SystemException("Data Tidak Tersimpan");
                else
                    return item;
            }
        }

        public Supplier Update(Supplier item)
        {
            using (var db = new OcphDbContext())
            {
                var result = db.Supplier.Delete(x => x.Id == item.IdSupplier as object);
                return MapperData.Mapper.Map<Supplier>(result);
            }
        }
    }
}