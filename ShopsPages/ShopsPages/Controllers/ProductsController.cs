using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopsPages.DAL;
using ShopsPages.Models;

namespace ShopsPages.Controllers
{
    public class ProductsController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [Route("products/id")]
        public IActionResult Index(int shopId)
        {
            var activeShop = this._unitOfWork.Shops.GetById(shopId);
            if (activeShop != null)
            {
                return View(activeShop);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            this._unitOfWork.Products.Add(product);
            this._unitOfWork.Complete();
            var activeShop = this._unitOfWork.Shops.GetById(product.ShopId);

            if (activeShop != null)
            {
                return PartialView("TableView", activeShop);
            }


            return NotFound();
        }

        [HttpDelete]
        [Route("products/remove/{productId?}")]
        public ActionResult Remove(int? productId)
        {
            if (this._unitOfWork.Products.Delete(productId))
            {
                this._unitOfWork.Complete();
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        public ActionResult Edit(Product newProduct)
        {
            if (this._unitOfWork.Products.Update(newProduct))
            {
                var activeShop = this._unitOfWork.Shops.GetById(newProduct.ShopId);
                this._unitOfWork.Complete();
                return PartialView("TableView", activeShop);
            }

            return NotFound();
        }
    }
}
