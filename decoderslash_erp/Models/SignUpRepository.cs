using decoderslash_erp.Data;

namespace decoderslash_erp.Models
{
    public class SignUpRepository
    {
        private readonly decoderslash_erpContext _context;

        public SignUpRepository(decoderslash_erpContext context)
        {
            _context = context;
        }

        public void AddEmployee(SignUp sign)
        {
            _context.Credentials.Add(sign.Cred!);

            _context.SaveChanges();
            Credentials? creds = _context.Credentials.FirstOrDefault((Credentials cred) => cred.Email!.Equals(sign.Cred!.Email));
            sign.Emp.CredentialsID = creds.ID;
            _context.Employees.Add(sign.Emp);
            _context.SaveChanges();
        }
    }
}
