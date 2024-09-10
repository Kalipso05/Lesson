using API.Entities;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		[HttpGet("EmployeeGet")]
		public List<EmployeeResponse> GetEmployees()
		{
			using (var db = new DbRoadRussiaContext())
			{
				var employeeList = db.Employees.Include(p => p.IdStructuralDivisionNavigation).Include(p => p.IdPositionNavigation).ToList().ConvertAll(p => new EmployeeResponse(p));

				return employeeList;
			}
		}

		[HttpPost("EmployeAdd")]
		public void PostEmployee([FromBody] EmployeeRequest employee)
		{
			using (var db = new DbRoadRussiaContext())
			{
				var employeeAdd = new Employee()
				{
					Id = employee.Id,
					Name = employee.Name,
					Surname = employee.Surname,
					Patronymic = employee.Patronymic ?? null,
					Photo = employee.Photo ?? null,
					IdPosition = employee.IdPosition ?? null,
					IdStructuralDivision = employee.IdStructuralDivision ?? null,
					Login = employee.Login ?? null,
					Password = employee.Password ?? null,
				};

				db.Employees.Add(employeeAdd);
				db.SaveChanges();
		
			}
		}

		[HttpPut("EmployeePut")]
		public void PutEmployee([FromBody] EmployeeRequest employee)
		{
			using(var db = new DbRoadRussiaContext())
			{
				var existingEmployee = db.Employees.FirstOrDefault(e => e.Id == employee.Id);

				if (existingEmployee != null)
				{
					var updatedEmployee = new EmployeeRequest()
					{
						Id = employee.Id,
						Name = employee.Name,
						Surname= employee.Surname,
						IdPosition= employee.IdPosition ?? null,
						IdStructuralDivision= employee.IdStructuralDivision ?? null,
						Login = employee.Login ?? null,
						Password= employee.Password ?? null,
						Patronymic = employee.Patronymic ?? null,
						Photo = employee.Photo ?? null
					};

					db.Entry(existingEmployee).CurrentValues.SetValues(updatedEmployee);
					db.SaveChanges();
				}
			}
		}

		[HttpDelete("EmployeeDelete/{id}")]
		public void DeleteEmployee(int id)
		{
			using(var db = new DbRoadRussiaContext())
			{
				var employee = db.Employees.FirstOrDefault(p =>  p.Id == id);
				if (employee != null)
				{
					db.Employees.Remove(employee);
					db.SaveChanges(true);
				}
			}
		}
	}

	
}
