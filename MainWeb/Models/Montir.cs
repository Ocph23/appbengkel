﻿using System;
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

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaMontir { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string Alamat { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NoTelpon { get; set; }
    }
}