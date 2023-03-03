using decoderslash_erp.Data;
using decoderslash_erp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using decoderslash_erp.Interfaces;

namespace decoderslash_erp.Controllers
{
    public class ProjectManagerController : Controller
    {
        private readonly decoderslash_erpContext _context;
        private readonly IProjectManagerRepo _repo;
        public ProjectManagerController(decoderslash_erpContext context, IProjectManagerRepo repo)
        {
            _context = context;
            _repo = repo;
        }

        public IActionResult GetProject()
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            return View(_repo.GetProjects(emp));
        }

        public IActionResult AccquireEmp()
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            return View(new AccquireEmp {emp =  _repo.FetchAllEmp() });
        }

        public bool CheckAccess()
        {
            String emp = HttpContext.Session.GetString("Designation")!;
            if (!emp!.Equals("Project_Manager"))
            {
                HttpContext.Session.SetString("ErrorHead", "Access Denied");
                HttpContext.Session.SetString("ErrorPara", "Looks you are trying to Access something which you should not be Accessing Be Carefull");
                return false;
            }
            return true;
        }

        public IActionResult GetProjDetails(int id)
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Project? proj = _repo.GetProject(id);
            if (proj == null)
            {

                HttpContext.Session.SetString("ErrorHead", "We love you tried");
                HttpContext.Session.SetString("ErrorPara", "We admire your hacking skills but we got ourseleves covered");
                return RedirectToAction("Error", "Home");

            }
            return View(new ProjectDetcs { proj = proj!});
        }
        [HttpPost]
        public IActionResult AddTask(ProjectDetcs det)
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            _repo.FillData(_context, emp.ID);
            det.task.ProjectID = det.Kc;
            _repo.AddTask(det.task);

            return RedirectToAction("GetProjDetails", new { id = det.Kc });
        }


        public bool CheckSession()
        {
			if (HttpContext.Session.GetString("Cred") == null)
			{
				return false;
			}
            return true;
		}

        public IActionResult GetTeam()
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Employee emp = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            return View(_repo.GetTeams(emp.ID));
        }

        [HttpPost]
        public IActionResult AccquireEmp(AccquireEmp emp)
        {
            if (!CheckSession())
                return RedirectToAction("Login", "Login");
            if (!CheckAccess())
                return RedirectToAction("Error", "Home");
            Employee emps = JsonSerializer.Deserialize<Employee>(HttpContext.Session.GetString("Data")!)!;
            _repo.FillData(_context, emps.ID);
            _repo.acqemp(emp.empid, emp.TeamId);
            return View(new AccquireEmp { emp = _repo.FetchAllEmp()});
        }
    }
}
