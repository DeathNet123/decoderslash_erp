using decoderslash_erp.Data;
using decoderslash_erp.Models;
using Microsoft.EntityFrameworkCore;

namespace decoderslash_erp.Interfaces
{
    public interface IProjectManagerRepo
    {
        public void AddTask(Tasks task);
        public void AssignTask(Tasks task);
        public Project? GetProject(int id);
        public List<Project> GetProjects(Employee emp);
        public List<Team> GetTeams(int id);

        public void FillData(decoderslash_erpContext context, int id);
        public List<Employee> FetchAllEmp();

        public void acqemp(int emid, int tid);
    }
}
