namespace COREWebApiJWTAuthentication.Models
{
	public class UserInfo
	{
		public int UserID { get; set; }	
		public string? UserName { get; set; }
		public string? UsereEmail { get; set; }

		public string? Password { get; set; }
		public DateTime? createdDate { get; set; }
	}
}
