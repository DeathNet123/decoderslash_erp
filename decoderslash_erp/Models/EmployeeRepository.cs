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
            _context.Entry(emp).Collection(e => e.Tasks).Load();
            return emp.Tasks ?? new List<Tasks>();
        }
    }
}
