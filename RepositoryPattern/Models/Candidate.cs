using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Candidate
{
    public byte CandidateId { get; set; }

    public string? FullName { get; set; }

    public byte? CompanyId { get; set; }

    public virtual Company? Company { get; set; }
}
