using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return View();
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
                ViewData["State"] = true;
            }
            else
            {
                ViewData["State"] = false;
            }
            return View("Index");
        }
        private bool CredentialsExists(Credentials user_cred)
        {
            return (_context.Credentials.Any((Credentials cred) => cred.Email.Equals(user_cred.Email) && cred.Password.Equals(user_cred.Password)));
        }
    }
}
