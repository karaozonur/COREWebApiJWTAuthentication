namespace COREWebApiJWTAuthentication.Models
{
	public class Employee
	{
		public int EmployeeID { get; set; }
		public string JobTitle { get; set; }
		public string? EmployeeName { get; set; }

		public string? EmployeeDepertment { get; set; }
		public DateTime? createDate { get; set; }	
	}
}
