using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Pembelian
    {

        public int IdPembelian { get; set; }


        public DateTime TanggalBeli { get; set; }


        public int IdSupplier { get; set; }

        public string FakturPembelian { get; set; }

        public string UserId { get; set; }

        public Supplier Supplier { get; set; }

        public List<Models.ItemPembelian> Data { get; set; }
    }
}