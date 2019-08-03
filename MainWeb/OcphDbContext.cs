using MainWeb.DataAccess.Dto;
using Ocph.DAL.Provider.MySql;
using Ocph.DAL.Repository;
using System.Configuration;

namespace MainWeb
{
    public class OcphDbContext :MySqlDbConnection
    {
        public OcphDbContext()
        {
             ConnectionString= ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public IRepository<SupplierDto> Supplier { get { return new Repository<SupplierDto>(this); } }

        public IRepository<ItemPembelianDto> DetailPembelian { get { return new Repository<ItemPembelianDto>(this); } }

        public IRepository<PembelianDto> Pembelian { get { return new Repository<PembelianDto>(this); } }

        public IRepository<PenjualanDto> Penjualan { get { return new Repository<PenjualanDto>(this); } }

        public IRepository<PelangganDto> Pelanggan { get { return new Repository<PelangganDto>(this); } }

        public IRepository<BarangDto> Barang { get { return new Repository<BarangDto>(this); } }

        public IRepository<KategoriDto> Kategori { get { return new Repository<KategoriDto>(this); } }

        public IRepository<MontirDto> Montir { get { return new Repository<MontirDto>(this); } }
    }
}