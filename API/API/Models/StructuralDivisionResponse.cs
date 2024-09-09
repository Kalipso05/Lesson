using API.Entities;

namespace API.Models
{
	public class StructuralDivisionResponse
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public StructuralDivisionResponse(StructuralDivision structuralDivision)
		{
			Id = structuralDivision.Id;
			Title = structuralDivision.Title;
		}
	}
}
