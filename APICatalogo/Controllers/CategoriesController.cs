using APICatalogo.Context;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase {
        private readonly AppDbContext context;

        public CategoriesController(AppDbContext context) {
            this.context = context;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetCategoriesProducts() {
            var categories = context.Categories.Include(c => c.Products).AsNoTracking().ToList();
            if (categories is null) {
                return NotFound("Categorias não encontradas");
            }
            return categories;
        }

        [HttpGet("products/{id:int}")]
        public ActionResult<IEnumerable<Category>> GetCategoryProducts(int id) {
            var categories = context.Categories.Include(c => c.Products).Where(c => c.Id == id).AsNoTracking().ToList();
            if(categories is null) {
                return NotFound("Categoria não encontrada");
            }

            return categories;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get() {
            try {
                //throw new DataMisalignedException();
                return context.Categories.AsNoTracking().ToList();
            } catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}", Name="GetCategory")]
        public ActionResult<Category> Get(int id) {
            var category = context.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
            if (category is null) {
                return NotFound("Categoria não encontrada");
            }

            return category;
        }

        [HttpPost]
        public ActionResult Post(Category category) {
            if(category is null) {
                return BadRequest();
            }
            context.Categories.Add(category);
            context.SaveChanges();

            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category) {
            if(category.Id != id) {
                return BadRequest();
            }

            context.Entry(category).State = EntityState.Modified;
            context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {
            var category = context.Categories.FirstOrDefault(c => c.Id == id);
            if(category is null) {
                return NotFound("Categoria não encontrada");
            }
            context.Categories.Remove(category);
            context.SaveChanges();
            return Ok(category);
        }
    }
}
