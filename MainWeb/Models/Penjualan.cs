using MainWeb.DataAccess.Dto;
using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    [TableName("Penjualan")]
    public class Penjualan
    {
        [PrimaryKey("IdPenjualan")]
        [DbColumn("IdPenjualan")]
        [ScaffoldColumn(false)]
        public int IdPenjualan { get; set; }

        [DbColumn("FakturPenjualan")]
        public string FakturPenjualan { get; set; }

        [DbColumn("IdPelanggan")]
        public int? IdPelanggan { get; set; }

        [DbColumn("TanggalJual")]
        public string TanggalJual { get; set; }

        public PelangganDto Pelanggan { get; set; }

        public List<ItemPenjualanDto> DataPenjualan { get; set; }
    }
}