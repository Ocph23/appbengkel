﻿using Ocph.DAL;

namespace MainWeb.DataAccess.Dto
{
    [TableName("Supplier")]
    public class SupplierDto
    {
        [PrimaryKey("IdKategori")]
        [DbColumn("IdSupplier")]
        public int IdSupplier { get; set; }

        [DbColumn("NamaSupplier")]
        public string NamaSupplier { get; set; }

        [DbColumn("AlamatSupplier")]
        public string Alamat { get; set; }

        [DbColumn("NoTelpon")]
        public string NoTelpon { get; set; }
    }
}