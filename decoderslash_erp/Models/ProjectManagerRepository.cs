using decoderslash_erp.Data;
using decoderslash_erp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace decoderslash_erp.Models
{
    public class ProjectManagerRepository: IProjectManagerRepo
    {
        private decoderslash_erpContext _context;

        public ProjectManagerRepository(decoderslash_erpContext context)
        {
            _context = context;
        }

        public ProjectManagerRepository()
        {

        }

        public void FillData(decoderslash_erpContext context, int id)
        {
            _context = context;
            _context.UserId = id;
        }

        public void AddTask(Tasks task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        public void AssignTask(Tasks task)
        {

        }
        public List<Project> GetProjects(Employee emp)
        {
            return new List<Project>();
        }
        public List<Team> GetTeams(int id)
        {
            return new List<Team>();
        }


    }
}
