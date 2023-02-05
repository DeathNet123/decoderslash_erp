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
    public class LoginController : Controller
    {
        private readonly decoderslash_erpContext _context;

        public LoginController(decoderslash_erpContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetString("Cred") != null)
            {
                return RedirectToAction("Index", "EmployeeDashBoard");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Cred") != null)
            {
                return RedirectToAction("Index", "EmployeeDashBoard"); // It can be any dashboard not employee specifically
            }
            return View("Index");
        }

        ///<summary>
        ///If you know then we used the cred which is pun for remembering the cred struct in linux kernel....
        ///</summary>
        [HttpPost]
        public IActionResult Login(Credentials cred)
        {
            if (!ModelState.IsValid)
                return View("Index");
            bool check = CredentialsExists(cred);
            if(check)
            {
                return RedirectToAction("Index", "EmployeeDashBoard");
            }
            ViewData["Valid"] = false;
            return View("Index");
        }
        private bool CredentialsExists(Credentials user_cred)
        {
            Credentials? cred = _context.Credentials.FirstOrDefault((Credentials creds) => creds.Email == user_cred.Email && creds.Password == user_cred.Password);
            if(cred != null)
            {
                Console.WriteLine("found");
                Employee? data = _context.Employees.FirstOrDefault((Employee emp) => emp.CredentialsID == cred.ID);
                MakeSession(cred, data!);
                return true;
            }
            return false;
        }

        private bool MakeSession(Credentials cred, Employee Data )
        {
            HttpContext.Session.SetString("Cred", JsonSerializer.Serialize<Credentials>(cred));
            HttpContext.Session.SetString("Data", JsonSerializer.Serialize<Employee>(Data));
            HttpContext.Session.SetString("Designation", Data.Designation ??= "Intruder");
            return true;
        }
    }
}
