using AutoMapper;
using Talabat.Core.Entitise;
using Talabat.DTOs;
using static System.Net.WebRequestMethods;

namespace Talabat.Helpers
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.brand, o => o.MapFrom(s => s.brand.Name))
                .ForMember(d => d.category, o => o.MapFrom(s => s.category.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());

            //CreateMap<ProductBrand,ProductDTO>().ReverseMap();
            //CreateMap<ProductCategory,ProductDTO>().ReverseMap();
        }
    }
}
