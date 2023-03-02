using decoderslash_erp.Data;
using decoderslash_erp.Models;

namespace decoderslash_erp.Interfaces
{
    public interface IEmployeeRepo
    {
        public void WriteIssue(Tasks task, Employee emp);
        public Team GetTeamDetails(int? id);
        public Project GetProject(int id);
        public Employee GetProjectManager(int id);
        public int Completeit(int id);
        public void FillData(decoderslash_erpContext context, int id);

        public List<Tasks> GetAllTask(Employee emp);
    }
}
