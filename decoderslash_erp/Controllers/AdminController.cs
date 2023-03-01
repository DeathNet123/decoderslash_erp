using decoderslash_erp.Data;
using decoderslash_erp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using decoderslash_erp.Interfaces;

namespace decoderslash_erp.Controllers
{
    /// <summary>
    /// Only the Signup Controller is seperate because of the file uploading functionality which is weird choice without any doubt...
    /// </summary>
    public class AdminController : Controller
    {
        private readonly decoderslash_erpContext _context;
        private readonly IAdminRepo _repo;
        public AdminController(decoderslash_erpContext context, IAdminRepo repo) 
        {
            _context = context;
            _repo = repo;
        }

        public bool CheckAccess()
        {
            String emp = HttpContext.Session.GetString("Designation")!;
            if (!emp!.Equals("Admin"))
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

        [HttpGet]
        public IActionResult SearchEmployee()
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if(!CheckAccess())
                return RedirectToAction("Error", "Home");
            return View();
        }

        [HttpGet]
        public IActionResult DeleteEmployee()
        {
			if (!CheckSession())
				return RedirectToAction("Login", "Login");
			if (CheckAccess())
				return View();
			return RedirectToAction("Error", "Home");
		}

        [HttpPost]
        public IActionResult SearchEmployee(int id)
        {
			if (!CheckSession())
				return RedirectToAction("Login", "Login");
			if (!CheckAccess())
			    return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            _repo.FillData(_context, emp.ID);
            Employee? emps = _repo.SearchEmployee(id);
            if (emps == null)
            {
                ViewData["response"] = "Employee with given ID does not exist";
                return View();
            }
            return View("ShowEmployee", emps);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
			if (!CheckSession())
				return RedirectToAction("Login", "Login");
			if (!CheckAccess())
				return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            _repo.FillData(_context, emp.ID);            
            int ans = _repo.DeleteEmployee(id);
            if (ans == 0)
            {
                ViewData["response"] = "Employee with given ID does not exist";
                return View();
            }
            ViewData["response"] = "Employee deleted successfully";
            return View();
        }
    }
}
