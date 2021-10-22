using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopsPages.Models;

namespace ShopsPages.Controllers
{
    public class ProductsController : Controller
    {
        private ShopsContext _db;

        public ProductsController(ShopsContext context)
        {
            this._db = context;
        }

        [Route("products/id")]
        public IActionResult Index(int shopId)
        {
            var shops = this._db.Shops.Include(s => s.Products);
            var activeShop = shops.FirstOrDefault(s => s.ShopId == shopId);
            if (activeShop != null)
            {
                
                return View(activeShop);
            }

            return NotFound();
        }
    }
}
