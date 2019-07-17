using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    [TableName("Montir")]
    public class Montir
    {
        [PrimaryKey("IdMontir")]
        [DbColumn("IdMontir")]
        [ScaffoldColumn(false)]
        public int IdMontir { get; set; }

        [DbColumn("NamaMontir")]
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string NamaMontir { get; set; }

        [DbColumn("AlamatMontir")]
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string Alamat { get; set; }

        [DbColumn("NoTelepon")]
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public string NoTelpon { get; set; }
    }
}