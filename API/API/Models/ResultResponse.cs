namespace API.Models
{
	public class ResultResponse
	{
		public string? Token { get; set; }
		public bool? Success { get; set; }
		public List<string>? Errors { get; set; }
	}
}
