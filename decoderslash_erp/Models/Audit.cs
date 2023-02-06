namespace decoderslash_erp.Models
{
    public class Audit
    {
        public int UserAdd { get; set; }
        public int UserDel { get; set; }
        public int UserMod { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
