using System.Net; 
using Microsoft.AspNetCore.Mvc;
using ProductsServices.Model;

namespace ProductsServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet] 
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get()
        {

            var result = ProductList.Products();
            if (result.Count() == 0)
            {
                return NotFound("Product not found in database!!!");
            }
            return Ok(result);
        } 

        [HttpGet("find/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(int id)
        {
            var productList = ProductList.Products();
            var result = productList?.FirstOrDefault(p => p.Id == id)!;
            if (result == null)
            {
               return NotFound("Product id not found!!!");
            }
            return Ok(result);
        }
    }
}
