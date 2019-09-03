using Ocph.DAL;
using System;
using System.Collections.Generic;

namespace MainWeb.DataAccess.Dto
{
    [TableName("Penjualan")]
    public class PenjualanDto
    {
        [PrimaryKey("IdPenjualan")]
        [DbColumn("IdPenjualan")]
        public int IdPenjualan { get; set; }

        [DbColumn("FakturPenjualan")]
        public string FakturPenjualan { get; set; }

        [DbColumn("IdPelanggan")]
        public int? IdPelanggan { get; set; }

        [DbColumn("TanggalJual")]
        public DateTime? TanggalJual { get; set; }

        [DbColumn("Pembayaran")]
        public string Pembayaran { get; set; }

        [DbColumn("UserId")]
        public string UserId { get; set; }

        public PelangganDto Customer { get; set; }

        public List<ItemPenjualanDto> Items { get; set; }

        public List<ItemServiceDto> Services { get; set; }
    }
}