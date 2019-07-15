using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Dto
{
    [TableName("")]
    public class SuplierDTO
    {
        public int IdSupplier { get; set; }
        public string NamaSupplier { get; set; }
        public string Alamat { get; set; }
        public string NoTelpon { get; set; }
    }
}