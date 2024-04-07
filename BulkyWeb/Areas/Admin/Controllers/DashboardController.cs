using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public DashboardController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
