using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase {
        private readonly AppDbContext context;

        public ProductsController(AppDbContext context) {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() {
            var products = context.Products.ToList();
            if (products is null) {
                return NotFound("Produtos não encontrados");
            }
            return products;
        }
        [HttpGet("{id:int}")]
        public ActionResult<Product> Get(int id) {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if(product is null) {
                return NotFound("Produto não encontrado");
            }
            return product;
        }
    }
}
