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
		[HttpGet("Employee")]
		public List<EmployeeResponse> GetEmployees()
		{
			using (var db = new DbRoadRussiaContext())
			{
				var employeeList = db.Employees.Include(p => p.IdStructuralDivisionNavigation).Include(p => p.IdPositionNavigation).ToList().ConvertAll(p => new EmployeeResponse(p));

				return employeeList;
			}
		}
	}
}
