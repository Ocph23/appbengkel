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
        public int IdPembelian { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Tanggal Beli")]
        [Required(ErrorMessage = "Tanggal Tidak Boleh Kosong")]
        public DateTime? TanggalBeli { get; set; }

      
        public int IdSupplier { get; set; }

        [Display(Name = "Nomor Faktur")]
        [Required(ErrorMessage = "Nomor Faktur Tidak Boleh Kosong")]
        public string FakturPembelian { get; set; }

        public string UserId { get; set; }


        [Display(Name = "Nama Supplier")]
        [Required(ErrorMessage = "Supplier Tidak Boleh Kosong")]
        public Supplier Supplier { get; set; }

        [Display(Name = "Total")]
        [Required(ErrorMessage = "Supplier Tidak Boleh Kosong")]
        public double Total {
            get {
               return Items.Sum(x => x.HargaBeli * x.Jumlah);
            }
        }


        public string Pembayaran { get; set; }

        public List<Models.ItemPembelian> Items { get; set; } = new List<ItemPembelian>();
    }
}