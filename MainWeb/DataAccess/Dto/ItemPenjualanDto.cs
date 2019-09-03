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


        [DbColumn("Jumlah")]
        public double Jumlah { get; set; }


        [DbColumn("HargaJual")]
        public double HargaJual { get; set; }

        [DbColumn("HargaBeli")]
        public double HargaBeli{ get; set; }

        public BarangDto Barang {get;set;}



    }
}