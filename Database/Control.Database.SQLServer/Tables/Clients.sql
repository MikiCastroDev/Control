CREATE TABLE [dbo].[Clients]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Name] NVARCHAR(100) NULL, 
    [BusinessName] NVARCHAR(100) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Telephone] NVARCHAR(10) NOT NULL, 
    [Prefix] NVARCHAR(5) NOT NULL, 
    [VarNumber] NVARCHAR(20) NOT NULL, 
    [Street] NVARCHAR(50) NULL, 
    [City] NVARCHAR(50) NULL, 
    [PostalCode] NVARCHAR(50) NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT suser_name(), 
    [ModifiedAt] DATETIME NULL, 
    [ModifiedBy] NVARCHAR(50) NULL, 
    [DisabledAt] DATETIME NULL, 
    [DisabledBy] NVARCHAR(50) NULL, 
    [FKRole] INT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Clients_Roles] FOREIGN KEY([FKRole]) REFERENCES [dbo].[Roles] ([Id]),
)
GO

CREATE TRIGGER [tr_UpdateClient] ON [dbo].[Clients]
FOR UPDATE
AS
SET NOCOUNT ON
DECLARE @Fecha AS DATETIME
SET @Fecha = getdate()
UPDATE [dbo].[Clients]
SET ModifiedBy = suser_name()
	,ModifiedAt = @Fecha
FROM [dbo].[Compania] c
INNER JOIN Inserted i ON c.Id = i.Id
SET NOCOUNT OFF
GO
