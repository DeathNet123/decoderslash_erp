using decoderslash_erp.Models;

namespace decoderslash_erp.Interfaces
{
    public interface IEmployeeRepo
    {
        public Team GetTeamDetails(int? id);
        public Project GetProject(int id);
        public Employee GetProjectManager(int id);
    }
}
