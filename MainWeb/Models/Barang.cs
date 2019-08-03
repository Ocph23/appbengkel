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
        [ScaffoldColumn(false)]
        public int IdBarang { get; set; }

        [Display(Name ="Kode Barang")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string KodeBarang { get; set; }

        [Display(Name = "Nama Barang")]
        [Required(ErrorMessage ="Tidak Boleh Kosong")]
        public string NamaBarang { get; set; }

        [Display(Name = "Harga Beli")]
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public double HargaBeli { get; set; }

        [Display(Name = "Harga Jual")]
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public double HargaJual { get; set; }

        [Display(Name = "Stok")]
        public double Stok { get; set; }

        [Display(Name = "idKategori")]
        [Required(ErrorMessage = "Tidak Boleh Kosong")]
        public int IdKategori { get; set; }

        public Kategori Kategori { get; set; }
    }
}