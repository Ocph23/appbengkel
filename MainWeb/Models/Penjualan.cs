using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Penjualan
    {
        [ScaffoldColumn(false)]
        public int IdPenjualan { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NoNota { get; set; }

        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string NamaPelanggan { get; set; }

        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string TanggalJual { get; set; }

        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string NamaBarang { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaMontir { get; set; }

        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string HargaJual { get; set; }
    }
}