using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Laporan
    {
        public DateTime Tanggal { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaBarang { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaPelanggan { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string HargaSatuan { get; set; }

        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string TotalBayar { get; set; }

    }
}
