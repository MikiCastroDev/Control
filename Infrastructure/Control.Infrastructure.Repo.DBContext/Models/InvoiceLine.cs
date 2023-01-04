using System;
using System.Collections.Generic;

namespace Control.Infrastructure.Repo.DBContext.Models;

public partial class InvoiceLine
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public decimal NetPrice { get; set; }

    public int Quantity { get; set; }

    public Guid Fktax { get; set; }

    public Guid Fkinvoice { get; set; }

    public virtual Invoice FkinvoiceNavigation { get; set; } = null!;

    public virtual Tax FktaxNavigation { get; set; } = null!;
}
