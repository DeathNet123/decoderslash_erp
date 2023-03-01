using decoderslash_erp.Interfaces;

namespace decoderslash_erp.Models
{
    public class Team : Audit
    {
        public int ID { get; set; }
        public string TeamName { get; set; }
        public int ProjectID { get; set; }
        public Project project { get; set; }
    }
}
