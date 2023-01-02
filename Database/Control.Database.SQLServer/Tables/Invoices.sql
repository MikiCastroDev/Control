CREATE TABLE [dbo].[Invoices]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Ref] NVARCHAR(300) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [FKClient] UNIQUEIDENTIFIER NOT NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT suser_name(), 
    [ModifiedAt] DATETIME NULL, 
    [ModifiedBy] NVARCHAR(50) NULL, 
    [DisabledAt] DATETIME NULL, 
    [DisabledBy] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Invoices_Clients] FOREIGN KEY([FKClient]) REFERENCES [dbo].[Clients] ([Id]),
)
GO

CREATE TRIGGER [tr_UpdateInvoice] ON [dbo].[Invoices]
FOR UPDATE
AS
SET NOCOUNT ON
DECLARE @Fecha AS DATETIME
SET @Fecha = getdate()
UPDATE [dbo].[Clients]
SET ModifiedBy = suser_name()
	,ModifiedAt = @Fecha
FROM [dbo].[Invoices] c
INNER JOIN Inserted i ON c.Id = i.Id
SET NOCOUNT OFF
GO
