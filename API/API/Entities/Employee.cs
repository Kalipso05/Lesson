using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public byte[]? Photo { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string? Patronymic { get; set; }

    public int? IdPosition { get; set; }

    public int? IdStructuralDivision { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual Position? IdPositionNavigation { get; set; }

    public virtual StructuralDivision? IdStructuralDivisionNavigation { get; set; }
}
