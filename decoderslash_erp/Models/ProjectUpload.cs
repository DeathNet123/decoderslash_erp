using System.ComponentModel.DataAnnotations;

namespace decoderslash_erp.Models
{
    public class ProjectUpload
    {
        public Project project{ get; set; }       
        [DataType(DataType.Upload)]
        public IFormFile file { get; set; }
    }
}
