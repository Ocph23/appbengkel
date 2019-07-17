using Ocph.DAL;
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
        public string TanggalJual { get; set; }

        public PelangganDto Pelanggan { get; set; }

        public List<ItemPenjualanDto> DataPenjualan { get; set; }
    }
}