using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Pelanggan
    {
        [ScaffoldColumn(false)]
        public int IdPelanggan { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaPelanggan { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string Alamat { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NoTelpon { get; set; }
    }
}