namespace COREWebApiJWTAuthentication.Models.Interface
{
	public interface IEmployees
	{
		public List<Employee> Employees();
		public Employee GetEmployeeDetails(int id);
		public void AddEmployees(Employee employee);
		public Employee RemoveEmployees(int id);
		public void UpdateEmployee(Employee employee);
		public bool CheckEmployee(int employee);
	}
}
