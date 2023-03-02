using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace decoderslash_erp.Models
{
    public class Employee:Audit
    {
        public int ID { get; set; }
        public String? AvatarPath { get; set; }
        [Required]
        public String? FirstName{ get; set; }
        [Required]
        public String? LastName{ get; set; }
        [Required]
        public String? Address { get; set; }
        [Required]
        public String? PhoneNo { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public String? Designation { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public Decimal BasicSalary { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public Decimal FuelAllowence { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public Decimal Housing{ get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 4)")]
        public Decimal OverTimeHourlyRate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JoiningDate { get; set; }

        public int CredentialsID { get; set; }
        public Credentials? Credential { get; set; }

        public List<Project>? Projects { get; set; }//Collection Navigation

        public List<Tasks> Tasks { get; set; }
        public int? TeamID { get; set; }
        public Team? team { get; set; }
    }
}
