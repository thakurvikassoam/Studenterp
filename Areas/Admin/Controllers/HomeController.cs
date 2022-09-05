using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace SVSU.Student.ERP.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("Admin/Home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
