using decoderslash_erp.Interfaces;
using Microsoft.Build.Framework;

namespace decoderslash_erp.Models
{
    public class Team : Audit
    {
        public int ID { get; set; }
        [Required]
        public string TeamName { get; set; }
        public int? ProjectID { get; set; }//
        public Project? project { get; set; }//
    }
}
