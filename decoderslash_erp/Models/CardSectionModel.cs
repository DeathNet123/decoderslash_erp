using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace decoderslash_erp.Models
{
    public class CardSectionModel
    {
        public String? SectionId { get; set; }
        public String? Head { get; set; }
        public String? Tag { get; set; }
        public int Rows { get; set; }
        public List<List<CardModelLeft>>? Data { get; set; }
    }
}
