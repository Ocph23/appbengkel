using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Montir
    {
        [ScaffoldColumn(false)]
        public int IdMontir { get; set; }

        [Display(Name="Nama Montir")]
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string NamaMontir { get; set; }

        [Display(Name="Alamat")]
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string Alamat { get; set; }


        [Display(Name="Telepon")]
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string NoTelpon { get; set; }
    }
}