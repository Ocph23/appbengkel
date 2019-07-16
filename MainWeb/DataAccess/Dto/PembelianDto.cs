using Ocph.DAL;
using System;

namespace MainWeb.DataAccess.Dto
{

    [TableName("Pembelian")]
    public class PembelianDto
    {

        [PrimaryKey("IdPembelian")]
        [DbColumn("IdPembelian")]
        public int IdPembelian { get; set; }


        [DbColumn("TanggalBeli")]
        public DateTime TanggalBeli { get; set; }


        [DbColumn("IdSupplier")]
        public int IdSupplier { get; set; }

        [DbColumn("FakturPembelian ")]
        public string FakturPembelian { get; set; }

        [DbColumn("UserId")]
        public string UserId { get; set; }

        public SupplierDto Supplier { get; set; }

    }
}