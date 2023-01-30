using decoderslash_erp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace decoderslash_erp.Controllers
{
    public class EmployeeDashBoardController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Cred") == null)
                return RedirectToAction("Index", "Login");
            String? cake = HttpContext.Session.GetString("Data");
            Employee? emp = JsonSerializer.Deserialize<Employee>(cake!);
            return View(emp!);
        }
    }
}
