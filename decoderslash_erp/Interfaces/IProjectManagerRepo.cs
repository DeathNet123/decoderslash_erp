using decoderslash_erp.Data;
using decoderslash_erp.Models;
namespace decoderslash_erp.Interfaces
{
    public interface IProjectManagerRepo
    {
        public void AddTask(Tasks task);
        public void AssignTask(Tasks task);
        public List<Project> GetProjects(Employee emp);
        public List<Team> GetTeams(int id);

        public void FillData(decoderslash_erpContext context, int id);
    }
}
