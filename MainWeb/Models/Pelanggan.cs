using Ocph.DAL;
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

        [Display(Name = "Nama Pelanggan")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaPelanggan { get; set; }

        [Display(Name = "Alamat")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string Alamat { get; set; }

        [Display(Name = "Nomor Telepon")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NoTelpon { get; set; }
    }
}