using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Dto
{

    [TableName("Kategori")]
    public class KategoriDto
    {
        [PrimaryKey("IdKategori")]
        [DbColumn("IdKategori")]
        public int IdKategori { get; set; }

        [DbColumn("NamaKategori")]
        public string NamaKategori { get; set; }
    }
}