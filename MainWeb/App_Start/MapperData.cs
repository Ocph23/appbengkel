using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Configuration;
using MainWeb.DataAccess.Dto;
using MainWeb.Models;

namespace MainWeb
{
    public class MapperData
    {
        private static Mapper mapper;

        // private static MapperConfiguration _config;

        public static MapperConfiguration Create()
        {

            var cfg = new MapperConfigurationExpression();
            cfg.CreateMap<Supplier,SupplierDto>();
            cfg.CreateMap<SupplierDto, Supplier>();

            cfg.CreateMap<Kategori, KategoriDto>();
            cfg.CreateMap<KategoriDto, Kategori>();

            cfg.CreateMap<Barang,BarangDto>();
            cfg.CreateMap<BarangDto, Barang>();

            cfg.CreateMap<Pelanggan, PelangganDto>();
            cfg.CreateMap<PelangganDto, Pelanggan>();

            cfg.CreateMap<Montir, MontirDto>();
            cfg.CreateMap<MontirDto, Montir>();

            cfg.CreateMap<Pembelian, PembelianDto>();
            cfg.CreateMap<PembelianDto, Pembelian>();

            cfg.CreateMap<ItemPembelian, ItemPembelianDto>();
            cfg.CreateMap<ItemPembelianDto, ItemPembelian>();

            cfg.CreateMap<Penjualan, PenjualanDto>().ForSourceMember(des => des.UserId, source=>source.DoNotValidate()); ;
            cfg.CreateMap<PenjualanDto, Penjualan>();

            cfg.CreateMap<ItemPenjualan, ItemPenjualanDto>();
            cfg.CreateMap<ItemPenjualanDto, ItemPenjualan>();

            cfg.CreateMap<ItemService, ItemServiceDto>();
            cfg.CreateMap<ItemServiceDto, ItemService>();


            cfg.CreateMap<Pelanggan, PelangganDto>();
            cfg.CreateMap<PelangganDto, Pelanggan>();


            var mapperConfig = new MapperConfiguration(cfg);
            mapper = new Mapper(mapperConfig);
            return mapperConfig;
        }

        public static TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }

        private static IMapper Mapper
        {
            get
            {
                
                if (mapper == null)
                    Create();
                return mapper;
            }
        }

    }
}