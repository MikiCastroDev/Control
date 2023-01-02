BEGIN

	IF NOT EXISTS (SELECT * FROM [dbo].[Roles])
			BEGIN
				INSERT INTO [dbo].[Roles] ([Id], [Name], [Description])
				VALUES (0, 'ADMIN', 'ROLE: Admin'),
						(1, 'USER', 'ROLE: User'),
						(2, 'CLIENT', 'ROLE: Client')
				SELECT 'admin', 'admin@control.app'
			END

	IF NOT EXISTS (SELECT * FROM [dbo].[Users])
			BEGIN
				INSERT INTO [dbo].[Users] ([Name], [Email])
				VALUES ('admin', 'admin@role.app')
			END

END