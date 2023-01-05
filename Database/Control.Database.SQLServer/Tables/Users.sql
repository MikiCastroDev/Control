CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [CreatedAt] DATETIME NOT NULL DEFAULT getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT suser_name(), 
    [ModifiedAt] DATETIME NULL, 
    [ModifiedBy] NVARCHAR(50) NULL, 
    [DisabledAt] DATETIME NULL, 
    [DisabledBy] NVARCHAR(50) NULL, 
    [FKRole] INT NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY([FKRole]) REFERENCES [dbo].[Roles] ([Id]),
)
GO

CREATE TRIGGER [tr_UpdateUser] ON [dbo].[Users]
FOR UPDATE
AS
SET NOCOUNT ON
DECLARE @Fecha AS DATETIME
SET @Fecha = getdate()
UPDATE [dbo].[Users]
SET ModifiedBy = suser_name()
	,ModifiedAt = @Fecha
FROM [dbo].[Compania] c
INNER JOIN Inserted i ON c.Id = i.Id
SET NOCOUNT OFF
GO


