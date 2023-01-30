using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace decoderslash_erp.Models
{
    public class CardSectionModel
    {
        public String? SectionId { get; set; }
        public int Rows { get; set; }
        public int Cards { get; set; }
        public String? Heading { get; set; }
        public String? Tagline { get; set; }

    }
}
