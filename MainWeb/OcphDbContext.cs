using MainWeb.DataAccess.Dto;
using Ocph.DAL.Provider.MySql;
using Ocph.DAL.Repository;
using System;
using System.Configuration;
using System.Linq;

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

        public IRepository<ItemPenjualanDto> DetailPenjualan { get { return new Repository<ItemPenjualanDto>(this); } }

        public IRepository<PelangganDto> Pelanggan { get { return new Repository<PelangganDto>(this); } }

        public IRepository<BarangDto> Barang { get { return new Repository<BarangDto>(this); } }

        public IRepository<KategoriDto> Kategori { get { return new Repository<KategoriDto>(this); } }

        public IRepository<MontirDto> Montir { get { return new Repository<MontirDto>(this); } }
        public IRepository<ItemServiceDto> Services { get { return new Repository<ItemServiceDto>(this); } }

    }

    public static class DBExtention
    {
        public static bool AddStock(this IRepository<BarangDto> context, int barangId, double value)
        {
            try
            {
                var barang = context.Where(x => x.IdBarang == barangId).FirstOrDefault();
                if(barang!=null)
                {
                    double newData = barang.Stok += value;
                    if (context.Update(x => new { x.Stok }, new BarangDto { Stok = newData, IdBarang = barangId }, x => x.IdBarang == barangId))
                    {
                        return true;
                    }
                }
                throw new SystemException();
            }
            catch (System.Exception)
            {
                throw new SystemException("Stok Tidak Berhasil Diubah");
            }
        }

        public static bool RemoveStock(this IRepository<BarangDto> context, int barangId, double value)
        {
            try
            {
                var barang = context.Where(x => x.IdBarang == barangId).FirstOrDefault();
                if (barang != null)
                {
                    double newData = barang.Stok -= value;
                    if (context.Update(x => new { x.Stok }, new BarangDto { Stok =newData, IdBarang = barangId }, x => x.IdBarang == barangId))
                    {
                        return true;
                    }
                }
                throw new SystemException();
            }
            catch (System.Exception)
            {
                throw new SystemException("Stok Tidak Berhasil Diubah");
            }
        }

        public static bool RecoveryStock(this OcphDbContext context)
        {
            try
            {
               foreach(var barang in context.Barang.Select())
                {
                    var dataPembelian = context.DetailPembelian.Where(x => x.IdBarang == barang.IdBarang).Sum(x => x.Jumlah);
                    var dataPenjualan = context.DetailPenjualan.Where(x => x.IdBarang == barang.IdBarang).Sum(x => x.Jumlah);
                    barang.Stok = dataPembelian - dataPenjualan;
                    if (!context.Barang.Update(x => new { x.Stok }, barang, x => x.IdBarang == barang.IdBarang))
                        throw new SystemException();
                }
                return true;
            }
            catch (System.Exception)
            {
                throw new SystemException("Stok Tidak Berhasil Diubah");
            }
        }

    }
}