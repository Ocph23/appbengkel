﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Barang
    {
        [ScaffoldColumn(false)]
        public int IdBarang { get; set; }

        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string Namabarang { get; set; }
    }
}