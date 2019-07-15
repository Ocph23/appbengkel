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
            cfg.CreateMap<Supplier,SupplierDTO1>();
            cfg.CreateMap<SupplierDTO1, Supplier>();




            var mapperConfig = new MapperConfiguration(cfg);
            mapper = new Mapper(mapperConfig);
            return mapperConfig;
        }



        public static IMapper Mapper
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