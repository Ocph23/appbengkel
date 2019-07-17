using Ocph.DAL;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MainWeb.Models
{
    [Bind(Exclude = "IdSupplier")]
    [TableName("Supplier")]
    public class Supplier
    {
        [PrimaryKey("IdSupplier")]
        [ScaffoldColumn(false)]
        public int IdSupplier { get; set; }
        [DbColumn("NamaSuplier")]
        [Required(ErrorMessage ="Nama Tidak Boleh Kosong")]
        public string NamaSupplier { get; set; }
        [DbColumn("Alamat")]
        [Required(ErrorMessage = "Alamat Tidak Boleh Kosong")]
        public string Alamat { get; set; }
        [DbColumn("NoTelpon")]
        [Required(ErrorMessage = "No.Telpon Tidak Boleh Kosong")]
        public string NoTelpon { get; set; }
    }
}