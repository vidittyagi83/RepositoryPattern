using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Company
{
    public byte CompanyId { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
}
