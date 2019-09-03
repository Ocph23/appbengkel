using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class ItemService
    {
        [ScaffoldColumn(false)]
        public int IdItem { get; set; }

        [ScaffoldColumn(false)]
        public int IdPenjualan { get; set; }

        [ScaffoldColumn(false)]
        public int IdMontir { get; set; }

        public string Perbaikan { get; set; }

        public double Biaya { get; set; }

        public string Keterangan { get; set; }

        public Montir Montir { get; set; }

        public DateTime? Tanggal { get; set; }

        public string NoFaktur { get; set; }
    }
}