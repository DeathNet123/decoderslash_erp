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
            return  _context.Projects.Where(p => p.ProjectManagerID == emp.ID && (p.isActive ?? false)).ToList();
        }
        public List<Team> GetTeams(int id)
        {
            List<Project> game = _context.Projects.Include(p => p.teams).Where(p => p.ProjectManagerID == id).ToList();
            List<Team> teams = new List<Team>();
            foreach (Project proj in game)
            {
                foreach(Team team in proj.teams)
                {
                    teams.Add(team);
                }
            }

            return teams;
        }


        public Project? GetProject(int id)
        {
            return _context.Projects.Include(p => p.task).Include(p => p.teams).SingleOrDefault(p => p.ID == id);
        }

        public List<Employee> FetchAllEmp()
        {
            return _context.Employees.Where(e => e.TeamID == null && (e.isActive ?? false)).ToList();
        }

        public void acqemp(int emid, int tid)
        {
            Employee? emp = _context.Employees.SingleOrDefault(e => e.ID == emid);
            if (null == emp) return;
            if (null == _context.Teams.SingleOrDefault(t => t.ID == tid)) return;
            emp.TeamID = tid;
            _context.Update(emp);
            _context.SaveChanges();
        }
    }
}
