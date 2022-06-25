using Microsoft.AspNetCore.Mvc;

namespace Virtual_Housing.Controllers
{
    public class ListingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
