using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Entitise;
using Talabat.Core.Repositories.Contrect;

namespace Talabat.Controllers
{
  
    public class ProductsController : BaseApiController 
    {
        private readonly IGenericRepositorty<Product> _productRepo;

        public ProductsController(IGenericRepositorty<Product> productRepo)
        {
          _productRepo = productRepo;
        }

        //BaseUrl /api/Prodect
        [HttpGet]
        public async Task < ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products =await _productRepo.GetAllAsync();
            return  Ok(products);
        }

        // //BaseUrl /api/Prodect/1
        [HttpGet("{id}")]
        public async Task <ActionResult <Product>> GetProduct(int id)
        {
            var product =await _productRepo.GetAsync(id);
            if (product == null) 
            {
                return NotFound(new {massage ="Not Found", StatusCode=404});
            }
            return Ok(product);
        } 

    }
}
