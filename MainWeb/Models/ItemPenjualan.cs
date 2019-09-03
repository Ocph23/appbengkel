using MainWeb.DataAccess.Dto;
using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class ItemPenjualan
    {
        [ScaffoldColumn(false)]
        public int IdItem { get; set; }

        public int IdPenjualan { get; set; }

        public int IdBarang { get; set; }

        public double HargaJual { get; set; }

        public double HargaBeli { get; set; }

        public double Jumlah { get; set; }

        public Barang Barang { get; set; }

        public double Total
        {
            get
            {
                return Jumlah * HargaJual;
            }
        }

    }
}