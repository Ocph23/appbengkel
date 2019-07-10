using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MainWeb.Models
{
    public class Pelanggan
    {
        public int IdPelanggan { get; set; }
        public string NamaPelanggan { get; set; }
        public string Alamat { get; set; }
        public string NoTelpon { get; set; }
    }
}