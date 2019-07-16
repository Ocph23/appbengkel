using Ocph.DAL;
using System.ComponentModel.DataAnnotations;

namespace MainWeb.DataAccess.Dto
{

    [TableName("")]
    public class BarangDto
    {
        [PrimaryKey("IdBarang")] 
        [DbColumn("IdBarang")]
        public int IdBarang { get; set; }

        [DbColumn("KodeBarang")]
        public string KodeBarang { get; set; }

        [DbColumn("NamaBarang")]
        public string NamaBarang { get; set; }

        [DbColumn("IdKategori")]
        public string IdKategori { get; set; }

        public KategoriDto Kategori { get; set; }
    }
}