using decoderslash_erp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
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

            // !!!!!!!!!!!!!! We have to make changes here...................!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

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

            // !!!!!!!!!!!!!! We have to make changes here...................!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            return View(dashBoard!);
        }
    }
}
