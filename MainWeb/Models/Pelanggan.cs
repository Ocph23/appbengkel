using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    [TableName("Pelanggan")]
    public class Pelanggan
    {
        [PrimaryKey("IdPelanggan")]
        [ScaffoldColumn(false)]
        public int IdPelanggan { get; set; }

        [DbColumn("NamaPelanggan")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaPelanggan { get; set; }

        [DbColumn("Alamat")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string Alamat { get; set; }

        [DbColumn("NoTelpon")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NoTelpon { get; set; }
    }
}