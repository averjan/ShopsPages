using Microsoft.AspNetCore.Mvc;
using ShopsPages.DAL;

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

       
        [Route("Shop/Error/{statusCode?}")]
        public ActionResult Error(int? statusCode = 500)
        {
            ViewBag.StatusCode = statusCode.ToString();
            return View("Error");
        }
    }
}
