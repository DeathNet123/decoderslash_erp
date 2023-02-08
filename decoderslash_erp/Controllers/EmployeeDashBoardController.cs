using decoderslash_erp.Data;
using decoderslash_erp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace decoderslash_erp.Controllers
{
    public class EmployeeDashBoardController : Controller
    {
        private readonly decoderslash_erpContext _context;

        public EmployeeDashBoardController(decoderslash_erpContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Cred") == null)
                return RedirectToAction("Index", "Login");
            String? cake = HttpContext.Session.GetString("Data");
            Employee emp = JsonSerializer.Deserialize<Employee>(cake!)!;

            DashBoard dashBoard = new DashBoard();
            dashBoard.employee = emp;

            List<CardSectionModel> AllSections = new List<CardSectionModel>();

            if (emp.Designation == "Admin")
            {
                AllSections = DashBoardRepository.MakeAdminSectionsList();
            }
            else if (emp.Designation == "Employee")
            {
                AllSections = DashBoardRepository.MakeEmployeeSectionsList();
            }
            else if (emp.Designation == "Project_Manager")
            {
                AllSections = DashBoardRepository.MakeProjectManagerSectionsList();
            }
            dashBoard.controls = AllSections;

            return View(dashBoard!);
        }
    }
}
