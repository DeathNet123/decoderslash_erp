namespace decoderslash_erp.Models
{
    public class Credentials
    {
		private String email;

		public String Email
		{
			get { return email; }
			set { email = value; }
		}

		private String password;

		public String Password
		{
			get { return password; }
			set { password = value; }
		}

		public Credentials()
		{
			email = "";
			password = "";
		}
	}
}
