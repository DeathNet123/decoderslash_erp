using decoderslash_erp.Data;
using decoderslash_erp.Models;

namespace decoderslash_erp.Interfaces
{
    public interface IAdminRepo
    {
        public void AddEmployee(SignUp sign);

        public void FillData(decoderslash_erpContext context, int id);

        public Employee SearchEmployee(int id);
        public int DeleteEmployee(int id);
    }
}
