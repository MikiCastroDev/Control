using System;
using System.Collections.Generic;

namespace Control.Infrastructure.Repo.DBContext.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? DisabledAt { get; set; }

    public string? DisabledBy { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();

    public virtual ICollection<User> Users { get; } = new List<User>();
}
