using System;
using System.Collections.Generic;

namespace Control.Infrastructure.Repo.DBContext.Models;

public partial class Tax
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public decimal Value { get; set; }

    public virtual ICollection<InvoiceLine> InvoiceLines { get; } = new List<InvoiceLine>();
}
