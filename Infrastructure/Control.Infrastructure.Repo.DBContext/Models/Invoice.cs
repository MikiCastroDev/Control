using System;
using System.Collections.Generic;

namespace Control.Infrastructure.Repo.DBContext.Models;

public partial class Invoice
{
    public Guid Id { get; set; }

    public string Ref { get; set; } = null!;

    public DateTime Date { get; set; }

    public Guid Fkclient { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? DisabledAt { get; set; }

    public string? DisabledBy { get; set; }

    public virtual Client FkclientNavigation { get; set; } = null!;

    public virtual ICollection<InvoiceLine> InvoiceLines { get; } = new List<InvoiceLine>();
}
