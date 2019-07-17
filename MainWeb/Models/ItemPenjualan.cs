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
        [TableName("DetailPenjualan")]
        public class ItemPenjualanDto
        {
            [PrimaryKey("IdDetailPenjualan")]
            [DbColumn("IdDetailPenjualan")]
            [ScaffoldColumn(false)]
            public int IdItem { get; set; }


            [DbColumn("IdPenjualan")]
            public int IdPenjualan { get; set; }


            [DbColumn("IdBarang")]
            public int IdBarang { get; set; }


            [DbColumn("IdMontir")]
            public int IdMontir { get; set; }


            [DbColumn("HargaJual")]
            [Required(ErrorMessage = "Tidak Boleh Kosong")]
            public double HargaJual { get; set; }


            [DbColumn("JenisPenjualan")]
            public JenisPenjualan TipePenjualan { get; set; }


            public BarangDto Barang { get; set; }

            public PenjualanDto Penjualan { get; set; }
            public MontirDto Montir { get; set; }
        }
    }
}