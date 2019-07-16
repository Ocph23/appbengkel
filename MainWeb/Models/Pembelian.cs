using MainWeb.DataAccess.Dto;
using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    [TableName("Pembelian")]
    public class Pembelian
    {
        [PrimaryKey("IdPembelian")]
        [DbColumn("IdPembelian")]
        public int IdPembelian { get; set; }


        [DbColumn("TanggalBeli")]
        public DateTime TanggalBeli { get; set; }


        [DbColumn("IdSupplier")]
        public int IdSupplier { get; set; }

        [DbColumn("FakturPembelian ")]
        public string FakturPembelian { get; set; }

        [DbColumn("UserId")]
        public string UserId { get; set; }

        public SupplierDto Supplier { get; set; }
    }
}