using Ocph.DAL;
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

        [Display(Name="Nama Kategori")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaKategori { get; set; }
    }
}