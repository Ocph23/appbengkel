using Ocph.DAL;

namespace MainWeb.DataAccess.Dto
{

    [TableName("Supplier")]
    public class SupplierDTO
    {
        public int IdSupplier { get; set; }

        public string NamaSupplier { get; set; }

        public string Alamat { get; set; }

        public string NoTelpon { get; set; }
    }
}