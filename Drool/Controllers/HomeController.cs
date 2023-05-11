using Drool.Data;
using Drool.Models;
using Drool.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Drool.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            IEnumerable<Product> Product = await _context.Products.Include(m => m.ProductImages).ToListAsync();

            HomeVM home = new()
            {
                Products = Product
            };

            return View(home);
        }
    }
}
