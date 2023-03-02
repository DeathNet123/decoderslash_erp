using decoderslash_erp.Data;
using decoderslash_erp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace decoderslash_erp.Models
{
    public class EmployeeRepository : IEmployeeRepo
    {
        private decoderslash_erpContext _context;

        public EmployeeRepository(decoderslash_erpContext context)
        {
            _context = context;
        }
        public EmployeeRepository()
        {

        }
        public void FillData(decoderslash_erpContext context, int id = 0)
        {
            _context = context;
            _context.UserId = id;
        }
        public Team GetTeamDetails(int? id)
        {
            Team team = _context.Teams.Include(t => t.project).FirstOrDefault(t => t.ID == id && (t.isActive ?? false) )!; //Eager loading
            //we are not checking for the null since the employee will have at least one team on his board infact exactly one team
            return team;
        }
        public Project GetProject(int id)
        {
            return new Project();
        }
        public Employee GetProjectManager(int id)
        {
            Employee emp = _context.Employees.FirstOrDefault(e => e.ID == id && (e.isActive ?? false))!;
            return emp;
        }

        public List<Tasks> GetAllTask(Employee emp)
        {
            emp.Tasks  = _context.Tasks.Where(t => t.EmployeeID == emp.ID && (t.isActive ?? false) && !t.isCompleted ).ToList();
            return emp.Tasks ?? new List<Tasks>();
        }

        public int Completeit(int id)
        {
            Tasks? ts = _context.Tasks.SingleOrDefault(t => t.ID == id && (t.isActive == true));

            if(ts == null)
            {
                return -86;
            }

            ts.isCompleted = true;
            _context.Tasks.Update(ts);
            _context.SaveChanges();
            return 1;
        }

        public void WriteIssue(Tasks task, Employee emp)
        {
            task.isIssue = true;
            Team team  = GetTeamDetails(emp.TeamID);
            task.ProjectID = team.ProjectID ?? 0;
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
    }
}
