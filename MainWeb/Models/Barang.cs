using MainWeb.DataAccess.Dto;
using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Barang
    {
        [PrimaryKey("IdBarang")]
        [ScaffoldColumn(false)]
        public int IdBarang { get; set; }

        [DbColumn("KodeBarang")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string KodeBarang { get; set; }

        [DbColumn("Namabarang")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string Namabarang { get; set; }

        [DbColumn("idKategori")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public int idKategori { get; set; }

        public KategoriDto Kategori { get; set; }
    }
}