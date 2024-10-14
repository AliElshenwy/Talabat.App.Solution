using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entitise;
using Talabat.Core.Repositories.Contrect;
using Talabat.Core.Specifications;
using Talabat.Core.Specifications.ProductSpecifications;
using Talabat.DTOs;

namespace Talabat.Controllers
{
  
    public class ProductsController : BaseApiController 
    {
        private readonly IGenericRepositorty<Product> _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepositorty<Product> productRepo,  IMapper mapper)
        {
          _productRepo = productRepo;
          _mapper = mapper;
        }


        //BaseUrl /api/Prodect
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var spec = new ProductWithBrandAndCategorySpecifications();
            var proDucts =await _productRepo.GetAsyncWithSpecAsync(spec);

            return Ok(_mapper.Map<Product,ProductDTO>(proDucts));
        }




        // //BaseUrl /api/Prodect/1
        [HttpGet("{id}")]
        public async Task <ActionResult<ProductDTO>> GetProductById(int id)
        {
            var spec = new ProductWithBrandAndCategorySpecifications(id);

            var product =await _productRepo.GetAllWithSpecAsync(spec);

            if (product == null)   
            {
                return NotFound(new {massage ="Not Found", StatusCode=404});
            }
            return Ok(_mapper.Map<IEnumerable< Product>, IEnumerable<ProductDTO>>(product));
        } 

    }
}
