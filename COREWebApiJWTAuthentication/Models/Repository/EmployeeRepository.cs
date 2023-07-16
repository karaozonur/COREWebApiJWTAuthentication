using COREWebApiJWTAuthentication.Models.Entity;
using COREWebApiJWTAuthentication.Models.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace COREWebApiJWTAuthentication.Models.Repository
{
	public class EmployeeRepository : IEmployees
	{
		readonly DatabaseContext _dbcontext = new ();

		public EmployeeRepository(DatabaseContext dbcontext)
		{
			_dbcontext=dbcontext;
		}

		public void AddEmployees(Employee employee)
		{
			_dbcontext.Employees.Add(employee);
			_dbcontext.SaveChanges();
		}

		public bool CheckEmployee(int employee)
		{
			return _dbcontext.Employees.Any(e => e.EmployeeID == employee);
		}

		public List<Employee> Employees()
		{
			return _dbcontext.Employees.ToList();
		}

		public Employee GetEmployeeDetails(int id)
		{
			Employee? employee = _dbcontext.Employees.Find(id);
			if (employee != null)
			{
				return employee;
			}
			else
			{
				throw new ArgumentNullException();
			}
		}

		public Employee RemoveEmployees(int id)
		{
			Employee? employee = _dbcontext.Employees.Find(id);
			if (employee !=null)
			{
				_dbcontext.Employees.Remove(employee);
				_dbcontext.SaveChanges();
				return employee;
			}
			else
			{
				throw new ArgumentNullException();
			}
		}

		public void UpdateEmployee(Employee employee)
		{
			_dbcontext.Entry(employee).State= EntityState.Modified;	
			_dbcontext.SaveChanges();
		}
	}
}
