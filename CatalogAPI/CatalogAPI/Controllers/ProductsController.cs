using System.Collections.Generic;
using System.Linq;
using CatalogAPI.Context;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _context.Products.AsNoTracking().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _context.Products.AsNoTracking().FirstOrDefault(p => p.Id == id);
            return product ?? (ActionResult<Product>)NotFound();
        }
    }
}