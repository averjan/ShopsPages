using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsPages.Models;

namespace ShopsPages.Controllers
{
    public class ShopController : Controller
    {
        private ShopsContext _db;

        public ShopController(ShopsContext context)
        {
            this._db = context;
        }

        // GET: ShopController
        public ActionResult Index()
        {
            return View(this._db.Shops?.ToList());
        }
    }
}
