using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class TblEmployee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Salary { get; set; }

    public string? Gender { get; set; }

    public int? DepartmentId { get; set; }
}
