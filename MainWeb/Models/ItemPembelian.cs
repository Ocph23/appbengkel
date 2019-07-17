namespace MainWeb.Models
{
    public class ItemPembelian
    {
        public int IdItem { get; set; }


        public int IdPembelian { get; set; }


        public int IdBarang { get; set; }


        public double HargaBeli { get; set; }


        public double HargaJual { get; set; }


        public JenisPenjualan TipePenjualan { get; set; }


        public Barang Barang { get; set; }

    }
}