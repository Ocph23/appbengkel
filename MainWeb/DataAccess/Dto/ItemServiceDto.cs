using Ocph.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainWeb.DataAccess.Dto
{
    [TableName("service")]
    public class ItemServiceDto
    {
        [PrimaryKey("IdService")]
        [DbColumn("IdService")]
        public int IdItem { get; set; }

        [DbColumn("IdPenjualan")]
        public int IdPenjualan { get; set; }

        [DbColumn("IdMontir")]
        public int IdMontir { get; set; }

        [DbColumn("Perbaikan")]
        public string Perbaikan { get; set; }

        [DbColumn("Biaya")]
        public double Biaya { get; set; }

        [DbColumn("Keterangan")]
        public string Keterangan { get; set; }


        public MontirDto Montir { get; set; }
        public DateTime? Tanggal { get;  set; }
        public string NoFaktur { get; set; }
    }
}