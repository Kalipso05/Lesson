using API.Entities;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DataController : ControllerBase
	{
		[HttpGet("position")]
		public List<PositionResponse> GetPositions()
		{
			using (var db = new DbRoadRussiaContext())
			{
				var data = db.Positions.ToList().ConvertAll(p => new PositionResponse(p));
				return data;
			}
		}

		[HttpGet("division")]
		public List<StructuralDivisionResponse> GetDivision()
		{
			using (var db = new DbRoadRussiaContext())
			{
				var data = db.StructuralDivisions.ToList().ConvertAll(p => new StructuralDivisionResponse(p));
				return data;
			}
		}
	}
}
