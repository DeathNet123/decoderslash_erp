using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using decoderslash_erp.Data;
using decoderslash_erp.Models;

namespace decoderslash_erp.Controllers
{
    public class SignUpController : Controller
    {
        private readonly decoderslash_erpContext _context;

        public SignUpController(decoderslash_erpContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("Cred") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            String? emp = HttpContext.Session.GetString("Designation");
            if(emp!.Equals("Admin"))    
                return View();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult SignUp(SignUp sign)
        {
            if(!ModelState.IsValid)
                return View("Index");
            SignUpRepository repo = new SignUpRepository(_context);
            repo.AddEmployee(sign);
            return RedirectToAction("Index", "EmployeeDashBoard");
        }
    }
}
