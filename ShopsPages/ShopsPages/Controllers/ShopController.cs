using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsPages.DAL;
using ShopsPages.Models;

namespace ShopsPages.Controllers
{
    public class ShopController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ShopController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: ShopController
        public ActionResult Index()
        {
            return View(this._unitOfWork.Shops.GetAll().ToList());
        }
    }
}
