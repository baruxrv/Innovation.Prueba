
using AutoMapper;


namespace Innovation.DGT.WebApi.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<Innovation.DGT.Entities.Driver, Innovation.DGT.DBContext.Entities.Driver>();

            CreateMap<Innovation.DGT.Entities.Vehicle, Innovation.DGT.DBContext.Entities.Vehicle>();

            CreateMap<Innovation.DGT.Entities.Infringement, Innovation.DGT.DBContext.Entities.Infringement>();

        }
    }
}