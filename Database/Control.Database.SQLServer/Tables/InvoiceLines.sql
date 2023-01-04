CREATE TABLE [dbo].[InvoiceLines]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Description] NVARCHAR(500) NOT NULL, 
    [NetPrice] DECIMAL(10, 2) NOT NULL, 
    [Quantity] INT NOT NULL,
    [FKTax] UNIQUEIDENTIFIER NOT NULL, 
    [FKInvoice] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_InvoiceLine_Invoices] FOREIGN KEY([FKInvoice]) REFERENCES [dbo].[Invoices] ([Id]),
    CONSTRAINT [FK_InvoiceLine_Tax] FOREIGN KEY([FKTax]) REFERENCES [dbo].[Taxs] ([Id])
)
