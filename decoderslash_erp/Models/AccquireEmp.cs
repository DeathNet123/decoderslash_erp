using System.ComponentModel.DataAnnotations;

namespace decoderslash_erp.Models
{
    public class AccquireEmp
    {
        public List<Employee> emp { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int empid { get; set; }
    }

}
