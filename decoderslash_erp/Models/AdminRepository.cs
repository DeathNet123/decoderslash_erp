using decoderslash_erp.Data;
using decoderslash_erp.Interfaces;
namespace decoderslash_erp.Models
{
    public class AdminRepository:IAdminRepo
    {
        private decoderslash_erpContext _context;

        public AdminRepository(decoderslash_erpContext context, int id)
        {
            _context = context;
            _context.UserId = id;
        }

        public AdminRepository()
        {

        }

        public void FillData(decoderslash_erpContext context, int id)
        {
            _context = context;
            context.UserId = id;
        }

        public void AddEmployee(SignUp sign)
        {
            _context.Credentials.Add(sign.Cred!);
            _context.SaveChanges();
            Credentials? creds = _context.Credentials.FirstOrDefault((Credentials cred) => cred.Email!.Equals(sign.Cred!.Email));
            sign.Emp.CredentialsID = creds!.ID;
            _context.Employees.Add(sign.Emp!);
            _context.SaveChanges();
        }

        public Employee? SearchEmployee(int id)
        {
            Employee? emp = _context.Employees.FirstOrDefault((Employee emp) => emp.ID.Equals(id));
            if (emp != null && emp.isActive == true)
            {
                return emp;
            }
            else
                return null;
        }
        public int DeleteEmployee(int id)
        {
            Employee? emp = _context.Employees.FirstOrDefault((Employee emp) => emp.ID.Equals(id));
            if (emp == null || emp.isActive == false)
            {
                return 0;
            }
            int cred_id = emp.CredentialsID;
            Credentials cred = _context.Credentials.FirstOrDefault((cred) => cred.ID == cred_id)!;
            _context.Employees.Remove(emp);
            _context.Credentials.Remove(cred);
            _context.SaveChanges();
            return 1;
        }

    }
}
