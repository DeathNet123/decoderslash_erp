using decoderslash_erp.Data;
using decoderslash_erp.Interfaces;

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
        public Team GetTeamDetails(int id)
        {
            return new Team();
        }
        public Project GetProject(int id)
        {
            return new Project();
        }
        public Employee GetProjectManager(int id)
        {
            return new Employee();
        }
    }
}
