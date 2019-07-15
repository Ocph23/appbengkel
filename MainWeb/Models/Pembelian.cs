using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Pembelian
    {
        [ScaffoldColumn(false)]
        public int idPembelian { get; set; }

        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string NoFaktur { get; set; }

        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string TanggalBeli { get; set; }
        
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string Namabarang { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string HargaBeli { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string HargaJual { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string MyProperty { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaSupplier { get; set; }


    }
}