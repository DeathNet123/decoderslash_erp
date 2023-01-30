using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace decoderslash_erp.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public String? FirstName{ get; set; }
        public String? LastName{ get; set; }
        public String? Address { get; set; }
        public String? PhoneNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }

        public String? Designation { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public Decimal BasicSalary { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public Decimal FuelAllowence { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public Decimal Housing{ get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public Decimal OverTimeHourlyRate { get; set; }
        public DateTime JoiningDate { get; set; }
        [ForeignKey("Credentials")]
        public int CredentialsID { get; set; }
        public Credentials cred { get; set; }
    }
}
