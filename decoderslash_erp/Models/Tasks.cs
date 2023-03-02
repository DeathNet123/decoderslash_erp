using Microsoft.Build.Framework;

namespace decoderslash_erp.Models
{
    public class Tasks : Audit
    {
        public int ID { get; set; }
        [Required]
        public int ProjectID { get; set; }
        [Required]
        public String TaskName { get; set; }
        public bool isIssue { get; set; }
        public bool isAssigned { get; set; }
        public Project project { get; set; }
        public int? EmployeeID { get; set; }
        public Employee? employee { get; set; }
        public bool isCompleted { get; set; }

    }
}
