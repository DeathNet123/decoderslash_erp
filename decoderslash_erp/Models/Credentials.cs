using System.ComponentModel.DataAnnotations;

namespace decoderslash_erp.Models
{
    public class Credentials
    {
		public int ID { get; set; }
		[Required(ErrorMessage ="You must Enter Email")]
		[EmailAddress]
		public String? Email { get; set; }
		[Required(ErrorMessage = "The Password Field Cannot be Left Empty")]
        [DataType(DataType.Password)]
        public String? Password { get; set; }

	}
}
