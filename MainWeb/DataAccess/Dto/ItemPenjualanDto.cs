using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Dto
{

    [TableName("DetailPenjualan")]
    public class ItemPenjualanDto
    {
        [PrimaryKey("IdDetailPenjualan")]
        [DbColumn("IdDetailPenjualan")]
        public int IdItem { get; set; }


        [DbColumn("IdPenjualan")]
        public int IdPenjualan { get; set; }


        [DbColumn("IdBarang")]
        public int IdBarang { get; set; }


        [DbColumn("IdMontir")]
        public int IdMontir { get; set; }


        [DbColumn("HargaJual")]
        public double HargaJual { get; set; }


        [DbColumn("JenisPenjualan")]
        public JenisPenjualan TipePenjualan { get; set; }
            

        public BarangDto Barang {get;set;}


        public MontirDto Montir { get; set; }

    }
}