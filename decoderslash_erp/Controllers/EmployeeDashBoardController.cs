using Microsoft.AspNetCore.Mvc;

namespace decoderslash_erp.Controllers
{
    public class EmployeeDashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
