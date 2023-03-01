using decoderslash_erp.Data;
using decoderslash_erp.Interfaces;
using decoderslash_erp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace decoderslash_erp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly decoderslash_erpContext _context;
        private readonly IEmployeeRepo _repo;
        public EmployeeController(decoderslash_erpContext context, IEmployeeRepo repo)
        {
            _context = context;
            _repo = repo;
        }
        public bool CheckAccess()
        {
            String emp = HttpContext.Session.GetString("Designation")!;
            if (!emp!.Equals("Employee"))
            {
                HttpContext.Session.SetString("ErrorHead", "Access Denied");
                HttpContext.Session.SetString("ErrorPara", "Looks you are trying to Access something which you should not be Accessing Be Carefull");
                return false;
            }
            return true;
        }
        public bool CheckSession()
        {
            if (HttpContext.Session.GetString("Cred") == null)
            {
                return false;
            }
            return true;
        }

        public IActionResult ShowDetails()
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            return View(emp);
        }
    }
}
