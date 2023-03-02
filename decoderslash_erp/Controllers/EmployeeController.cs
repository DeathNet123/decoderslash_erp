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
        public IActionResult TeamDetails()
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            if(emp.TeamID == null)
            {
                HttpContext.Session.SetString("ErrorHead", "Woah you are free");
                HttpContext.Session.SetString("ErrorPara", "Woah you are free ask the Employer to Assign you to work");
                return RedirectToAction("Error", "Home");

            }
            Team teams = _repo.GetTeamDetails(emp.TeamID);
            Employee manager = _repo.GetProjectManager(teams.project.ProjectManagerID);
            return View(new TeamDetails { team = teams, ProjectManager = manager});
        }

        public IActionResult GetTasks()
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            return View(_repo.GetAllTask(emp));
        }

        public IActionResult CompleteTask(int id)
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            _repo.FillData(_context, emp.ID);
            int result  = _repo.Completeit(id);
            if(result == -86)
            {
                HttpContext.Session.SetString("ErrorHead", "We love you tried");
                HttpContext.Session.SetString("ErrorPara", "We admire your hacking skills but we got ourseleves covered");
                return RedirectToAction("Error", "Home");
            }
            return RedirectToAction("GetTasks");
        }

        [HttpGet]
        public IActionResult RaiseIssue()
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            return View();
        }
        public IActionResult RaiseIssue(Tasks task)
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            _repo.FillData(_context, emp.ID);
            _repo.WriteIssue(task, emp);
            return RedirectToAction("RaiseIssue");
        }
    }
}
