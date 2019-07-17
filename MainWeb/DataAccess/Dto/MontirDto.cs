using Ocph.DAL;
using System.ComponentModel.DataAnnotations;

namespace MainWeb.DataAccess.Dto
{

    [TableName("Montir")]
    public class MontirDto
    {
        [PrimaryKey("IdMontir")]
        [DbColumn("IdMontir")]
        public int IdMontir { get; set; }

        [DbColumn("NamaMontir")]

        public string NamaMontir { get; set; }

        [DbColumn("AlamatMontir")]

        public string Alamat { get; set; }

        [DbColumn("NoTelepon")]

        public string NoTelpon { get; set; }
    }
}