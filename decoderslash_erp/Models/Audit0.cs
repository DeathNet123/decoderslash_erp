namespace decoderslash_erp.Models
{
    public interface Audit0
    {
        public int UserAdd { get; set; }
        public int? UserMod { get; set; }
        public bool? isActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? UserDel { get; set; }
    }
}
