using Ocph.DAL;
using System.ComponentModel.DataAnnotations;

namespace MainWeb.DataAccess.Dto
{

    [TableName("Barang")]
    public class BarangDto
    {
        [PrimaryKey("IdBarang")] 
        [DbColumn("IdBarang")]
        public int IdBarang { get; set; }

        [DbColumn("KodeBarang")]
        public string KodeBarang { get; set; }

        [DbColumn("NamaBarang")]
        public string NamaBarang { get; set; }


        [DbColumn("HargaBeli")]
        public double HargaBeli { get; set; }

        [DbColumn("HargaJual")]
        public double HargaJual { get; set; }

        [DbColumn("Stok")]
        public double Stok { get; set; }

        [DbColumn("IdKategori")]
        public int IdKategori { get; set; }

        public KategoriDto Kategori { get; set; }
    }
}