CREATE TABLE [dbo].[Roles]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(250) NULL,
    [CreatedAt] DATETIME NOT NULL DEFAULT getdate(), 
    [CreatedBy] NVARCHAR(50) NOT NULL DEFAULT suser_name(), 
    [ModifiedAt] DATETIME NULL, 
    [ModifiedBy] NVARCHAR(50) NULL, 
    [DisabledAt] DATETIME NULL, 
    [DisabledBy] NVARCHAR(50) NULL
)
GO

CREATE TRIGGER [tr_UpdateRole] ON [dbo].[Roles]
FOR UPDATE
AS
SET NOCOUNT ON
DECLARE @Fecha AS DATETIME
SET @Fecha = getdate()
UPDATE [dbo].[Roles]
SET ModifiedBy = suser_name()
	,ModifiedAt = @Fecha
FROM [dbo].[Compania] c
INNER JOIN Inserted i ON c.Id = i.Id
SET NOCOUNT OFF
GO
