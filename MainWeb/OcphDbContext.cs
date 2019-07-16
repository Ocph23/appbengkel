using MainWeb.DataAccess.Dto;
using Ocph.DAL.Provider.MySql;
using Ocph.DAL.Repository;
using System.Configuration;

namespace MainWeb
{
    public class OcphDbContext :MySqlDbConnection
    {
        public OcphDbContext()
        {
             ConnectionString= ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }


        public IRepository<SupplierDto> Supplier { get { return new Repository<SupplierDto>(this); } }

    }
}