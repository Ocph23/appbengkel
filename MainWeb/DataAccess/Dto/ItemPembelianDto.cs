using Ocph.DAL;

namespace MainWeb.DataAccess.Dto
{

    [TableName("DetailPembelian")]
    public class ItemPembelianDto
    {
        [PrimaryKey("IdDetailPembelian")]
        [DbColumn("IdDetailPembelian")]
        public int IdItem { get; set; }


        [DbColumn("IdPembelian")]
        public int IdPembelian { get; set; }


        [DbColumn("IdBarang")]
        public int IdBarang { get; set; }


        [DbColumn("HargaBeli")]
        public double HargaBeli { get; set; }


        [DbColumn("HargaJual")]
        public double HargaJual { get; set; }


        [DbColumn("Jumlah")]
        public JenisPenjualan TipePenjualan { get; set; }
            

        public BarangDto Barang {get;set;}


    }
}