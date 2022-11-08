using AutoMapper;
using Shin.Megami.Tensei.Data.Model;
using Shin.Megami.Tensei.DTOs.Encounters;
using Shin.Megami.Tensei.DTOs.Products;

namespace Shin.Megami.Tensei.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Encounter, EncounterDTO>().ReverseMap();
        }
    }
}
