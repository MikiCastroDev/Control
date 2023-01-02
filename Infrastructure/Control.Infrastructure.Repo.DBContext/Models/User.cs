using System;
using System.Collections.Generic;

namespace Control.Infrastructure.Repo.DBContext.Models;

public partial class User
{
    public Guid? Id { get; set; }

    public string? Email { get; set; }

    public string? Name { get; set; }

    public Guid Fkrole { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime ModifiedAt { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime? EnabledAt { get; set; }

    public string? EnabledBy { get; set; }
}
