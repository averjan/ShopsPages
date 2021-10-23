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

        [HttpPost]
        public ActionResult Add(Product product)
        {
            this._db.Products?.Add(product);
            var shops = this._db.Shops.Include(s => s.Products);
            var activeShop = shops.FirstOrDefault(s => s.ShopId == product.ShopId);

            if (activeShop != null)
            {
                this._db.SaveChanges();
                return PartialView("TableView", activeShop);
            }


            return NotFound();
        }

        [HttpDelete]
        [Route("products/remove/{productId?}")]
        public ActionResult Remove(int? productId)
        {
            var removeElement = this._db.Products?.FirstOrDefault(p => p.ProductId == productId);
            if (removeElement != null)
            {
                this._db.Products?.Remove(removeElement);
                this._db.SaveChanges();
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        public ActionResult Edit(Product newProduct)
        {
            var entity = this._db.Products?.FirstOrDefault(p => p.ProductId == newProduct.ProductId);
            if (entity == null)
            {
                return NotFound();
            }

            this._db.Entry(entity).CurrentValues.SetValues(newProduct);

            var shops = this._db.Shops.Include(s => s.Products);
            var activeShop = shops.FirstOrDefault(s => s.ShopId == newProduct.ShopId);

            if (activeShop != null)
            {
                this._db.SaveChanges();
                return PartialView("TableView", activeShop);
            }

            return NotFound();
        }
    }
}
