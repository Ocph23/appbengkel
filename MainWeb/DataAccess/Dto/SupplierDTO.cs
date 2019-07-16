using Ocph.DAL;
using System.ComponentModel.DataAnnotations;

namespace MainWeb.DataAccess.Dto
{
    [TableName("Supplier")]
    public class SupplierDto
    {
        [PrimaryKey("IdKategori")]
        [DbColumn("IdSupplier")]
        public int IdSupplier { get; set; }

        [DbColumn("NamaSupplier")]
        public string NamaSupplier { get; set; }

        [DbColumn("Alamat")]
        public string Alamat { get; set; }

        [DbColumn("NoTelepon")]
        public string NoTelpon { get; set; }
    }
}