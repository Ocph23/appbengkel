using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Dto
{
    [TableName("")]
    public class BarangDTO
    {
        public int IdBarang { get; set; }
        public string Namabarang { get; set; }
    }
}