namespace ApiParaDB.Controllers
{
    using ApiParaDB.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _context.Products.ToList();
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Post(Product produto)
        {
            _context.Products.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }
    }

}
