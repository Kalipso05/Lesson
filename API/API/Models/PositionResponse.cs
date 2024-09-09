using API.Entities;

namespace API.Models
{
	public class PositionResponse
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public PositionResponse(Position position)
		{
			Id = position.Id;
			Title = position.Title;
		}
	}
}
