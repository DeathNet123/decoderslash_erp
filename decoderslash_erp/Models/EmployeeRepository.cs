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
        public void FillData(decoderslash_erpContext context)
        {
            _context = context;
        }
        public Team GetTeamDetails(int? id)
        {
            Team team = _context.Teams.Include(t => t.project).FirstOrDefault(t => t.ID == id)!; //Eager loading
            return team;
        }
        public Project GetProject(int id)
        {
            return new Project();
        }
        public Employee GetProjectManager(int id)
        {
            Employee emp = _context.Employees.FirstOrDefault(e => e.ID == id)!;
            return emp;
        }
    }
}
