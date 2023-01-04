BEGIN

	IF NOT EXISTS (SELECT * FROM [dbo].[Roles] WHERE [Name] = 'ADMIN')
		INSERT INTO [dbo].[Roles] ([Id], [Name], [Description])
		VALUES (0, 'ADMIN', 'ROLE: Admin');

	IF NOT EXISTS (SELECT * FROM [dbo].[Roles] WHERE [Name] = 'USER')
		INSERT INTO [dbo].[Roles] ([Id], [Name], [Description])
		VALUES (1, 'USER', 'ROLE: User');

	IF NOT EXISTS (SELECT * FROM [dbo].[Roles] WHERE [Name] = 'CLIENT')
		INSERT INTO [dbo].[Roles] ([Id], [Name], [Description])
		VALUES (2, 'CLIENT', 'ROLE: Client')

	IF NOT EXISTS (SELECT * FROM [dbo].[Users] WHERE [Name] = 'admin')
		INSERT INTO [dbo].[Users] ([Name], [Email])
		VALUES ('admin', 'admin@role.app');

	IF NOT EXISTS (SELECT * FROM [dbo].[Taxs] WHERE [Description] = 'Superreducido')
		INSERT INTO [dbo].[Taxs] ([Description], [Value])
		VALUES ('Superreducido', 4);

	IF NOT EXISTS (SELECT * FROM [dbo].[Taxs] WHERE [Description] = 'Reducido')
		INSERT INTO [dbo].[Taxs] ([Description], [Value])
		VALUES ('Reducido', 10);

	IF NOT EXISTS (SELECT * FROM [dbo].[Taxs] WHERE [Description] = 'General')
		INSERT INTO [dbo].[Taxs] ([Description], [Value])
		VALUES ('General', 21);

END