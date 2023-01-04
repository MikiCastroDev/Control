using System;
using System.Collections.Generic;

namespace Control.Infrastructure.Repo.DBContext.Models;

public partial class Client
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? BusinessName { get; set; }

    public string? Email { get; set; }

    public string Telephone { get; set; } = null!;

    public string Prefix { get; set; } = null!;

    public string VarNumber { get; set; } = null!;

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? PostalCode { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? DisabledAt { get; set; }

    public string? DisabledBy { get; set; }

    public int Fkrole { get; set; }

    public virtual Role FkroleNavigation { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();
}
