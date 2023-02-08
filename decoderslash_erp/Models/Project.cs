using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace decoderslash_erp.Models
{
    public class Project : Audit
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [ForeignKey("Employee")]
        public int ProjectManagerID { get; set; }
        [Required]
        public int TeamID { get; set; } // <----------- To be handled ----------->
    }
}
