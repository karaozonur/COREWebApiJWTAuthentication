using COREWebApiJWTAuthentication.Models;
using COREWebApiJWTAuthentication.Models.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COREWebApiJWTAuthentication.Controllers
{
	[Route("api/employee")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployees _employees;

		public EmployeeController(IEmployees employees)
		{
			_employees= employees;	
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Employee>>> Get()
		{
			return await Task.FromResult(_employees.Employees());
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Employee>> Get(int id)
		{
			var emp = await Task.FromResult(_employees.GetEmployeeDetails(id));
			if (emp==null)
			{
				return NotFound();
			}
			return emp;
		}

		[HttpPost]
		public async Task<ActionResult<Employee>> Post(Employee emp)
		{
			_employees.AddEmployees(emp);
			return await Task.FromResult(emp);
		}

		[HttpPut]
		public async Task<ActionResult<Employee>> Put(int id,Employee emp)
		{
			if (id != emp.EmployeeID)
			{
				return BadRequest();
			}
			try
			{
				_employees.UpdateEmployee(emp);
			}
			catch (DbUpdateConcurrencyException)
			{

				if (!EmployeeExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
	
			return await Task.FromResult(emp);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<Employee>> Delete(int id)
		{
			var emp = _employees.RemoveEmployees(id);

			return await Task.FromResult(emp);
		}

		private bool EmployeeExists(int id)
		{
			return _employees.CheckEmployee(id);
		}
	}
}
