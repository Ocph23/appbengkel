using MainWeb.DataAccess.Dto;
using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Penjualan
    {
        [ScaffoldColumn(false)]
        public int IdPenjualan { get; set; }

        [Display(Name="Nomor Faktur")]
        public string FakturPenjualan { get; set; }

        [ScaffoldColumn(false)]
        public int? IdPelanggan { get; set; }

        [Display(Name="Tanggal Jual")]
        public DateTime? TanggalJual { get; set; }

        public string Pembayaran { get; set; }

        public Pelanggan Customer { get; set; } = new Pelanggan();

        public List<ItemPenjualan> Items { get; set; }
        public List<ItemService> Services { get; set; }

        public double TotalPenjualan
        {
            get
            {
                if(Items!=null)
                    return Items.Sum(x => x.HargaJual * x.Jumlah);
                return 0;
            }
        }

        public double TotalService
        {
            get
            {
                if (Services != null)
                    return Services.Sum(x => x.Biaya);
                return 0;
            }
        }

        public double TotalHargaBeli
        {
            get
            {
                if (Services != null)
                    return Items.Sum(x => x.HargaBeli * x.Jumlah);
                return 0;
            }
        }

        public double Total
        {
            get
            {
                return TotalService+TotalPenjualan;
            }
        }

        public string UserId { get; set; }


    }
}