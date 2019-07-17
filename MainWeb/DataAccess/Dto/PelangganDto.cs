using Ocph.DAL;
using System.ComponentModel.DataAnnotations;

namespace MainWeb.DataAccess.Dto
{
    [TableName("Pelanggan")]
    public class PelangganDto
    {
        [PrimaryKey("IdPelanggan")]
        [DbColumn("IdPelanggan")]
        public int IdPelanggan { get; set; }

        [DbColumn("NamaPelanggan")]
        public string NamaPelanggan { get; set; }

        [DbColumn("Alamat")]
        public string Alamat { get; set; }

        [DbColumn("NoTelepon")]
        public string NoTelpon { get; set; }
    }
}