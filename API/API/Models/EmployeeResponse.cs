using API.Entities;

namespace API.Models
{
	public class EmployeeResponse
	{
		public int Id { get; set; }

		public byte[]? Photo { get; set; }

		public string Name { get; set; } = null!;

		public string Surname { get; set; } = null!;

		public string? Patronymic { get; set; }

		public string? Position { get; set; }

		public string? StructuralDivision { get; set; }
		public int? IdPosition {  get; set; }
		public int? IdStructuralDivision { get; set; }

		public string? Login { get; set; }

		public string? Password { get; set; }

		public EmployeeResponse(Employee employee)
		{
			Id = employee.Id;
			Photo = employee.Photo;
			Name = employee.Name;
			Surname = employee.Surname;
			Patronymic = employee.Patronymic;
			Position = employee.IdPositionNavigation?.Title;
			StructuralDivision = employee.IdStructuralDivisionNavigation?.Title;
			IdPosition = employee.IdPositionNavigation?.Id;
			IdStructuralDivision = employee.IdStructuralDivisionNavigation?.Id;
			Login = employee.Login;
			Password = employee.Password;
		}
	}
}
