using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _product;

        public ProductsController(IProductRepository product)
        {
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _product.GetAllProductAsync());
            }
            catch (Exception ex)
            {

                return StatusCode(500,$"Internal erro: {ex.Message}");
            }
        }

        [HttpGet("GetAllProductsWithCategory")]
        public async Task<IActionResult> GetAllProductsWithCategory()
        {
            try
            {
                return Ok(await _product.GetAllProductWithCategoryAsync());
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal erro: {ex.Message}");
            }
        }
    }
}
