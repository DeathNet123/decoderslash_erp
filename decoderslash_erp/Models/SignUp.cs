using System.ComponentModel.DataAnnotations;

namespace decoderslash_erp.Models
{
    public class SignUp
    {
        public Credentials? Cred { get; set; }
        public Employee? Emp { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile? file { get; set; }
    }
}
