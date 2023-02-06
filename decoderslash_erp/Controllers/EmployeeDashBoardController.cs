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
            Employee? emp = JsonSerializer.Deserialize<Employee>(cake!);

            DashBoard dashBoard = new DashBoard();
            dashBoard.employee = emp;

            List<CardSectionModel> AllSections = new List<CardSectionModel>();

            if (emp.Designation == "Admin")
            {
                AllSections = DashBoardRepository.MakeAdminSectionsList();
            }
            else if(emp.Designation == "Employee")
            {
                AllSections = DashBoardRepository.MakeEmployeeSectionsList();
            }
            else if (emp.Designation == "Finance")
            {
                AllSections = DashBoardRepository.MakeFinanceSectionsList();
            }
            dashBoard.controls = AllSections;

            return View(dashBoard!);
        }

        [HttpGet]
        public IActionResult SearchEmployee()
        {
            return View("search_by_id_form");
        }

        [HttpGet]
        public IActionResult DeleteEmployee()
        {
            return View("delete_by_id_form");
        }

        [HttpPost]
        public IActionResult SearchEmployee(int id)
        {
            DashBoardRepository repo = new DashBoardRepository(_context);
            Employee emp = repo.SearchEmployee(id);
            return View("ShowEmployee", emp);
        }
        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            DashBoardRepository repo = new DashBoardRepository(_context);
            int ans = repo.DeleteEmployee(id);
            if (ans == 0)
            {
                ViewData["response"] = "Employee with given ID does not exist";
                return View("delete_by_id_form");
            }
            ViewData["response"] = "Employee with given ID does not exist";
            return View("delete_by_id_form");
        }
    }
}
