using Ocph.DAL;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MainWeb.Models
{
    [Bind(Exclude = "IdSupplier")]
    public class Supplier
    {
        [ScaffoldColumn(false)]
        public int IdSupplier { get; set; }

        [Required(ErrorMessage ="Nama Tidak Boleh Kosong")]
        public string NamaSupplier { get; set; }

        [Required(ErrorMessage = "Alamat Tidak Boleh Kosong")]
        public string Alamat { get; set; }

        [Required(ErrorMessage = "No.Telpon Tidak Boleh Kosong")]
        public string NoTelpon { get; set; }
    }
}