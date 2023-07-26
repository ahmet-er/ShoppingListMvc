using Microsoft.AspNetCore.Mvc;

namespace Bitirme_Projesi.Controllers
{
    public class ShoppingListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
