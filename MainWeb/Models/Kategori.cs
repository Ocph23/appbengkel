using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    [TableName("Kategori")]
    public class Kategori
    {
        [PrimaryKey("IdKategori")]
        [ScaffoldColumn(false)]
        public int IdKategori { get; set; }
        [DbColumn("NamaKategori")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaKategori { get; set; }
    }
}