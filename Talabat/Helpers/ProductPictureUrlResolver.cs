using AutoMapper;
using Talabat.Core.Entitise;
using Talabat.DTOs;

namespace Talabat.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver( IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
        if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $" {_configuration["ApiBaseUrl"]}/{source.PictureUrl}";
            }
        return string.Empty;
        }
    }
}
