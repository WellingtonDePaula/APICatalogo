using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("{id:int}", Name = "GetProduto")]
        public ActionResult<Product> Get(int id) {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) {
                return NotFound("Produto não encontrado");
            }
            return product;
        }

        [HttpPost]
        public ActionResult Post(Product product) {
            if (product is null) {
                return BadRequest();
            }

            context.Products.Add(product);
            context.SaveChanges();

            return new CreatedAtRouteResult("GetProduto", new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Product product) {
            if (id != product.Id) {
                return BadRequest();
            }

            context.Entry(product).State = EntityState.Modified;
            context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {
            var product = context.Products.FirstOrDefault(p => p.Id == id);
            if (product is null) {
                return NotFound("Produto não encontrado");
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return Ok(product);
        }
    }
}
