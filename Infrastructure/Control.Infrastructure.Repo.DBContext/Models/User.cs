using System;
using System.Collections.Generic;

namespace Control.Infrastructure.Repo.DBContext.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? DisabledAt { get; set; }

    public string? DisabledBy { get; set; }

    public int Fkrole { get; set; }

    public virtual Role FkroleNavigation { get; set; } = null!;
}
