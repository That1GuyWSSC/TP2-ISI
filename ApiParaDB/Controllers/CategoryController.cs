namespace testebasic2swagger.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using testebasic2swagger.Models;

        [ApiController]
        [Route("api/[controller]")]
        public class CategoryController : ControllerBase
        {
            private readonly AppDbContext _context;

            public CategoryController(AppDbContext context)
            {
                _context = context;
            }

            // GET: api/category
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
            {
                return await _context.Categories.ToListAsync();
            }

            // GET: api/category/5
            [HttpGet("{id}")]
            public async Task<ActionResult<Category>> GetCategory(long id)
            {
                var category = await _context.Categories.FindAsync(id);

                if (category == null)
                    return NotFound();

                return category;
            }

            // POST: api/category
            [HttpPost]
            public async Task<ActionResult<Category>> CreateCategory(Category category)
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
            }

            // PUT: api/category/5
            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateCategory(long id, Category category)
            {
                if (id != category.Id)
                    return BadRequest();

                _context.Entry(category).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(id))
                        return NotFound();
                    else
                        throw;
                }

                return NoContent();
            }

            // DELETE: api/category/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCategory(long id)
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null)
                    return NotFound();

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return NoContent();
            }

            private bool CategoryExists(long id)
            {
                return _context.Categories.Any(e => e.Id == id);
            }
        }
    }


