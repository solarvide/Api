IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [Blogs] (
        [Id] bigint NOT NULL IDENTITY,
        [ImageURL] nvarchar(max) NOT NULL,
        [Title] nvarchar(500) NOT NULL,
        [Text] nvarchar(max) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Blogs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [Cities] (
        [Id] bigint NOT NULL IDENTITY,
        [City] nvarchar(max) NOT NULL,
        [Distributor] nvarchar(max) NOT NULL,
        [Irradiation] decimal(18,3) NOT NULL,
        [LevelIrradiation] nvarchar(max) NOT NULL,
        [Coordinates] nvarchar(max) NOT NULL,
        [RatekWh] int NOT NULL,
        [UF] nvarchar(max) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Cities] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [ConfigurationTags] (
        [Id] bigint NOT NULL IDENTITY,
        [Tag] nvarchar(50) NOT NULL,
        [Description] nvarchar(4000) NOT NULL,
        [Value] nvarchar(4000) NOT NULL,
        CONSTRAINT [PK_ConfigurationTags] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [Countries] (
        [Id] bigint NOT NULL IDENTITY,
        [Abbreviation] nvarchar(10) NOT NULL,
        [Name] nvarchar(255) NOT NULL,
        [PhonePrefix] int NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Countries] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [FAQs] (
        [Id] bigint NOT NULL IDENTITY,
        [Question] ntext NOT NULL,
        [Answer] ntext NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_FAQs] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [LanguageTags] (
        [Id] bigint NOT NULL IDENTITY,
        [Tag] nvarchar(max) NOT NULL,
        [Text] nvarchar(max) NOT NULL,
        [Lang] nvarchar(max) NOT NULL,
        [IsHtml] bit NOT NULL,
        [Usage] nvarchar(max) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        CONSTRAINT [PK_LanguageTags] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [NetworkEnergies] (
        [Id] bigint NOT NULL IDENTITY,
        [InstalationType] nvarchar(max) NOT NULL,
        [MinimalkWh] int NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_NetworkEnergies] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [Proposal] (
        [Id] bigint NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [WhatsApp] nvarchar(max) NOT NULL,
        [Average] decimal(18,2) NOT NULL,
        [Archive] nvarchar(max) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Proposal] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [UserTypes] (
        [Id] bigint NOT NULL IDENTITY,
        [Abbreviation] nvarchar(20) NOT NULL,
        [Name] nvarchar(1000) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_UserTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [ProposalHistoricEletrics] (
        [Id] bigint NOT NULL IDENTITY,
        [proposalId] bigint NOT NULL,
        [Month] nvarchar(max) NOT NULL,
        [Value] decimal(18,2) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_ProposalHistoricEletrics] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProposalHistoricEletrics_Proposal_proposalId] FOREIGN KEY ([proposalId]) REFERENCES [Proposal] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [CodeValidations] (
        [Id] bigint NOT NULL IDENTITY,
        [ValidationCode] nvarchar(25) NOT NULL,
        [ExpirationDate] datetime2 NOT NULL,
        [CodeType] nvarchar(max) NOT NULL,
        [UserId] bigint NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        CONSTRAINT [PK_CodeValidations] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [Companies] (
        [Id] bigint NOT NULL IDENTITY,
        [CompanyName] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Number] nvarchar(max) NOT NULL,
        [Distric] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [State] nvarchar(max) NOT NULL,
        [UF] nvarchar(max) NOT NULL,
        [UserId] bigint NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [Users] (
        [Id] bigint NOT NULL IDENTITY,
        [Name] nvarchar(255) NOT NULL,
        [SurName] nvarchar(255) NULL,
        [DocNumber] nvarchar(20) NULL,
        [Birthday] datetime2 NULL,
        [Phone] nvarchar(20) NULL,
        [Email] nvarchar(100) NOT NULL,
        [Password] nvarchar(500) NOT NULL,
        [EmailValidated] bit NULL,
        [UserTypeId] bigint NOT NULL,
        [CompanyId] bigint NOT NULL,
        [Status] int NOT NULL,
        [PhotoUrl] nvarchar(max) NULL,
        [TwoFactory] bit NULL,
        [TwoFactorySecret] nvarchar(max) NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]),
        CONSTRAINT [FK_Users_UserTypes_UserTypeId] FOREIGN KEY ([UserTypeId]) REFERENCES [UserTypes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [Hierarchies] (
        [Id] bigint NOT NULL IDENTITY,
        [ManagerId] bigint NOT NULL,
        [ExecutiveId] bigint NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Hierarchies] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Hierarchies_Users_ExecutiveId] FOREIGN KEY ([ExecutiveId]) REFERENCES [Users] ([Id]),
        CONSTRAINT [FK_Hierarchies_Users_ManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [Users] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [Notications] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [Mensage] nvarchar(max) NOT NULL,
        [Read] bit NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Notications] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Notications_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [PushNotificationKeys] (
        [Id] bigint NOT NULL IDENTITY,
        [PushKey] nvarchar(max) NOT NULL,
        [PublicIP] nvarchar(max) NOT NULL,
        [UserId] bigint NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_PushNotificationKeys] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PushNotificationKeys_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE TABLE [Schedulers] (
        [Id] bigint NOT NULL IDENTITY,
        [CompanyId] bigint NOT NULL,
        [UserId] bigint NOT NULL,
        [DateInitial] datetime2 NOT NULL,
        [DateEnd] datetime2 NOT NULL,
        [Subject] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [Contact] nvarchar(max) NOT NULL,
        [PhoneContact] nvarchar(max) NOT NULL,
        [Address] nvarchar(max) NOT NULL,
        [Number] nvarchar(max) NOT NULL,
        [Distric] nvarchar(max) NOT NULL,
        [City] nvarchar(max) NOT NULL,
        [State] nvarchar(max) NOT NULL,
        [UF] nvarchar(max) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Schedulers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Schedulers_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]),
        CONSTRAINT [FK_Schedulers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Tag', N'Value') AND [object_id] = OBJECT_ID(N'[ConfigurationTags]'))
        SET IDENTITY_INSERT [ConfigurationTags] ON;
    EXEC(N'INSERT INTO [ConfigurationTags] ([Id], [Description], [Tag], [Value])
    VALUES (CAST(1 AS bigint), N''default_user_type_id'', N''default_user_type_id'', N''2''),
    (CAST(2 AS bigint), N''default_user_type_abreviations'', N''default_user_type_abreviations'', N''RP''),
    (CAST(3 AS bigint), N''default_percent_compress'', N''default_percent_compress'', N''60'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Tag', N'Value') AND [object_id] = OBJECT_ID(N'[ConfigurationTags]'))
        SET IDENTITY_INSERT [ConfigurationTags] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([Id], [Abbreviation], [Deleted], [Name], [PhonePrefix])
    VALUES (CAST(1 AS bigint), N''BR'', CAST(0 AS bit), N''Brazil'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOn', N'Deleted', N'InstalationType', N'MinimalkWh', N'UpdatedOn') AND [object_id] = OBJECT_ID(N'[NetworkEnergies]'))
        SET IDENTITY_INSERT [NetworkEnergies] ON;
    EXEC(N'INSERT INTO [NetworkEnergies] ([Id], [CreatedOn], [Deleted], [InstalationType], [MinimalkWh], [UpdatedOn])
    VALUES (CAST(1 AS bigint), ''2023-06-17T15:56:33.9727399-03:00'', CAST(0 AS bit), N''Monofásico'', 30, ''0001-01-01T00:00:00.0000000''),
    (CAST(2 AS bigint), ''2023-06-17T15:56:33.9727401-03:00'', CAST(0 AS bit), N''Bifásico'', 50, ''0001-01-01T00:00:00.0000000''),
    (CAST(3 AS bigint), ''2023-06-17T15:56:33.9727402-03:00'', CAST(0 AS bit), N''Trifásico'', 100, ''0001-01-01T00:00:00.0000000''),
    (CAST(4 AS bigint), ''2023-06-17T15:56:33.9727403-03:00'', CAST(0 AS bit), N''A4'', 0, ''0001-01-01T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedOn', N'Deleted', N'InstalationType', N'MinimalkWh', N'UpdatedOn') AND [object_id] = OBJECT_ID(N'[NetworkEnergies]'))
        SET IDENTITY_INSERT [NetworkEnergies] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'CreatedOn', N'Deleted', N'Name', N'UpdatedOn') AND [object_id] = OBJECT_ID(N'[UserTypes]'))
        SET IDENTITY_INSERT [UserTypes] ON;
    EXEC(N'INSERT INTO [UserTypes] ([Id], [Abbreviation], [CreatedOn], [Deleted], [Name], [UpdatedOn])
    VALUES (CAST(1 AS bigint), N''SADM'', ''2023-06-17T15:56:33.9727361-03:00'', CAST(0 AS bit), N''Super Admin'', ''0001-01-01T00:00:00.0000000''),
    (CAST(2 AS bigint), N''RP'', ''2023-06-17T15:56:33.9727364-03:00'', CAST(0 AS bit), N''Representante'', ''0001-01-01T00:00:00.0000000''),
    (CAST(3 AS bigint), N''ADMF'', ''2023-06-17T15:56:33.9727365-03:00'', CAST(0 AS bit), N''Administrador Filial'', ''0001-01-01T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'CreatedOn', N'Deleted', N'Name', N'UpdatedOn') AND [object_id] = OBJECT_ID(N'[UserTypes]'))
        SET IDENTITY_INSERT [UserTypes] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_CodeValidations_UserId] ON [CodeValidations] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_Companies_UserId] ON [Companies] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_Hierarchies_ExecutiveId] ON [Hierarchies] ([ExecutiveId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_Hierarchies_ManagerId] ON [Hierarchies] ([ManagerId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_Notications_UserId] ON [Notications] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_ProposalHistoricEletrics_proposalId] ON [ProposalHistoricEletrics] ([proposalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_PushNotificationKeys_UserId] ON [PushNotificationKeys] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_Schedulers_CompanyId] ON [Schedulers] ([CompanyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_Schedulers_UserId] ON [Schedulers] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_Users_CompanyId] ON [Users] ([CompanyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    CREATE INDEX [IX_Users_UserTypeId] ON [Users] ([UserTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    ALTER TABLE [CodeValidations] ADD CONSTRAINT [FK_CodeValidations_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    ALTER TABLE [Companies] ADD CONSTRAINT [FK_Companies_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617185634_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230617185634_initial', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    CREATE TABLE [BlogUserReads] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [BlogId] bigint NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_BlogUserReads] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BlogUserReads_Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [Blogs] ([Id]),
        CONSTRAINT [FK_BlogUserReads_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    CREATE TABLE [CategoriesBlog] (
        [Id] bigint NOT NULL IDENTITY,
        [Description] nvarchar(max) NOT NULL,
        [status] bit NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_CategoriesBlog] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:02:08.4176448-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:02:08.4176450-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:02:08.4176451-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:02:08.4176452-03:00''
    WHERE [Id] = CAST(4 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:02:08.4176378-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:02:08.4176382-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:02:08.4176383-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    CREATE INDEX [IX_BlogUserReads_BlogId] ON [BlogUserReads] ([BlogId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    CREATE INDEX [IX_BlogUserReads_UserId] ON [BlogUserReads] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190208_blogsRead')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230617190208_blogsRead', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    ALTER TABLE [Blogs] ADD [CategoryBlogId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:02:41.8785888-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:02:41.8785889-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:02:41.8785890-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:02:41.8785890-03:00''
    WHERE [Id] = CAST(4 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:02:41.8785849-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:02:41.8785851-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:02:41.8785852-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    CREATE INDEX [IX_Blogs_CategoryBlogId] ON [Blogs] ([CategoryBlogId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    ALTER TABLE [Blogs] ADD CONSTRAINT [FK_Blogs_CategoriesBlog_CategoryBlogId] FOREIGN KEY ([CategoryBlogId]) REFERENCES [CategoriesBlog] ([Id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190242_category')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230617190242_category', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190519_default')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:05:19.1514104-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190519_default')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:05:19.1514105-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190519_default')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:05:19.1514106-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190519_default')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:05:19.1514107-03:00''
    WHERE [Id] = CAST(4 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190519_default')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:05:19.1514071-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190519_default')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:05:19.1514073-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190519_default')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:05:19.1514074-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190519_default')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230617190519_default', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190613_default2')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Cities]') AND [c].[name] = N'RatekWh');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Cities] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Cities] DROP COLUMN [RatekWh];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190613_default2')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:06:12.7501733-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190613_default2')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:06:12.7501734-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190613_default2')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:06:12.7501735-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190613_default2')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-17T16:06:12.7501736-03:00''
    WHERE [Id] = CAST(4 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190613_default2')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:06:12.7501691-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190613_default2')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:06:12.7501693-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190613_default2')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-17T16:06:12.7501696-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230617190613_default2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230617190613_default2', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    CREATE TABLE [Notifications] (
        [Id] bigint NOT NULL IDENTITY,
        [Text] nvarchar(max) NOT NULL,
        [Title] nvarchar(max) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Notifications] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    CREATE TABLE [NotificationUsers] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [NotificationId] bigint NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_NotificationUsers] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_NotificationUsers_Notifications_NotificationId] FOREIGN KEY ([NotificationId]) REFERENCES [Notifications] ([Id]),
        CONSTRAINT [FK_NotificationUsers_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-18T01:33:07.8836976-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-18T01:33:07.8836978-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-18T01:33:07.8836978-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    EXEC(N'UPDATE [NetworkEnergies] SET [CreatedOn] = ''2023-06-18T01:33:07.8836979-03:00''
    WHERE [Id] = CAST(4 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-18T01:33:07.8836937-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-18T01:33:07.8836943-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-06-18T01:33:07.8836944-03:00''
    WHERE [Id] = CAST(3 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    CREATE INDEX [IX_NotificationUsers_NotificationId] ON [NotificationUsers] ([NotificationId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    CREATE INDEX [IX_NotificationUsers_UserId] ON [NotificationUsers] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230618043308_notification')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230618043308_notification', N'6.0.5');
END;
GO

COMMIT;
GO

