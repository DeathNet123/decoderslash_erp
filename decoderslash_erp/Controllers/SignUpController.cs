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
using decoderslash_erp.Interfaces;

namespace decoderslash_erp.Controllers
{
    public class SignUpController : Controller
    {
        private readonly decoderslash_erpContext _context;
        private readonly IAdminRepo _signRepo;

        public SignUpController(decoderslash_erpContext context, IAdminRepo signRepo)
        {
            _context = context;
            _signRepo = signRepo;
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
            if(sign.file != null)
            {
                IFormFile file = sign.file;
                String random = Path.GetRandomFileName();
                sign.Emp!.AvatarPath = random;
                String? location = System.Environment.GetEnvironmentVariable("Volume");
                Console.WriteLine($" Here is the Location{location}");
                String realPath = Path.Combine(location!, random);
                FileStream fs = new FileStream(realPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.None);
                file.CopyTo(fs);
                fs.Close();
            }

            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            _signRepo.FillData(_context, emp.ID);
            
            _signRepo.AddEmployee(sign);
            return RedirectToAction("Index", "EmployeeDashBoard");
        }
    }
}
