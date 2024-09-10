using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
	public class ViewEmployeeModel
	{
		public int Id { get; set; }
		public byte[] Photo { get; set; }
		public string Name { get; set; } 

		public string Surname { get; set; } 

		public string Patronymic { get; set; }

		public string Position { get; set; }

		public string StructuralDivision { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public int IdPosition { get; set; }
		public int IdStructuralDivision { get; set; }
	}
}
