using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Kategori
    {
        [ScaffoldColumn(false)]
        public int IdKategori { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaKategori { get; set; }
    }
}