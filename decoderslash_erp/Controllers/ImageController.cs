using decoderslash_erp.Data;
using decoderslash_erp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace decoderslash_erp.Controllers
{
    public class ImageController : Controller
    {
        private readonly decoderslash_erpContext _context;
        public ImageController(decoderslash_erpContext context)
        {
            _context = context;
        }
        public ActionResult Avatar()
        {
            if (HttpContext.Session.GetString("Cred") == null)
                return RedirectToAction("Index", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            String? AvatarPath = emp.AvatarPath;
            if(AvatarPath == null)
            {
                AvatarPath = "images.png";
            }
            String realPath = Path.Combine(Environment.GetEnvironmentVariable("Volume")!, AvatarPath!);
            FileStream fs = new FileStream(realPath, FileMode.Open, FileAccess.Read);
            return File(fs, "image/png");
        }

        public ActionResult Proposal(String name)
        {
            if (HttpContext.Session.GetString("Cred") == null)
                return RedirectToAction("Index", "Home");
            String realPath = Path.Combine(Environment.GetEnvironmentVariable("Volume")!, name);
            FileStream fs = new FileStream(realPath, FileMode.Open, FileAccess.Read);
            return File(fs, "document/pdf");
        }
    }
}
