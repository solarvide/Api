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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
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
        [PhotoUrl] nvarchar(max) NULL,
        [TwoFactory] bit NULL,
        [TwoFactorySecret] nvarchar(max) NULL,
        [PinCode] nvarchar(max) NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Users_UserTypes_UserTypeId] FOREIGN KEY ([UserTypeId]) REFERENCES [UserTypes] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    CREATE TABLE [CodeValidations] (
        [Id] bigint NOT NULL IDENTITY,
        [ValidationCode] nvarchar(25) NOT NULL,
        [ExpirationDate] datetime2 NOT NULL,
        [CodeType] nvarchar(max) NOT NULL,
        [UserId] bigint NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        CONSTRAINT [PK_CodeValidations] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_CodeValidations_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Tag', N'Value') AND [object_id] = OBJECT_ID(N'[ConfigurationTags]'))
        SET IDENTITY_INSERT [ConfigurationTags] ON;
    EXEC(N'INSERT INTO [ConfigurationTags] ([Id], [Description], [Tag], [Value])
    VALUES (CAST(1 AS bigint), N''default_user_type_id'', N''default_user_type_id'', N''1''),
    (CAST(2 AS bigint), N''default_user_type_abreviations'', N''default_user_type_abreviations'', N''MB'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Tag', N'Value') AND [object_id] = OBJECT_ID(N'[ConfigurationTags]'))
        SET IDENTITY_INSERT [ConfigurationTags] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([Id], [Abbreviation], [Deleted], [Name], [PhonePrefix])
    VALUES (CAST(1 AS bigint), N''BR'', CAST(0 AS bit), N''Brazil'', 1),
    (CAST(2 AS bigint), N''AF'', CAST(0 AS bit), N''Afghanistan'', 1),
    (CAST(3 AS bigint), N''AL'', CAST(0 AS bit), N''Albania'', 1),
    (CAST(4 AS bigint), N''DZ'', CAST(0 AS bit), N''Algeria'', 1),
    (CAST(5 AS bigint), N''AS'', CAST(0 AS bit), N''American Samoa'', 1),
    (CAST(6 AS bigint), N''AD'', CAST(0 AS bit), N''Andorra'', 1),
    (CAST(7 AS bigint), N''AO'', CAST(0 AS bit), N''Angola'', 1),
    (CAST(8 AS bigint), N''AI'', CAST(0 AS bit), N''Anguilla'', 1),
    (CAST(9 AS bigint), N''AQ'', CAST(0 AS bit), N''Antarctica'', 1),
    (CAST(10 AS bigint), N''AG'', CAST(0 AS bit), N''Antigua and Barbuda'', 1),
    (CAST(11 AS bigint), N''AR'', CAST(0 AS bit), N''Argentina'', 1),
    (CAST(12 AS bigint), N''AM'', CAST(0 AS bit), N''Armenia'', 1),
    (CAST(13 AS bigint), N''AW'', CAST(0 AS bit), N''Aruba'', 1),
    (CAST(14 AS bigint), N''AU'', CAST(0 AS bit), N''Australia'', 1),
    (CAST(15 AS bigint), N''AT'', CAST(0 AS bit), N''Austria'', 1),
    (CAST(16 AS bigint), N''AZ'', CAST(0 AS bit), N''Azerbaijan'', 1),
    (CAST(17 AS bigint), N''BS'', CAST(0 AS bit), N''Bahamas'', 1),
    (CAST(18 AS bigint), N''BH'', CAST(0 AS bit), N''Bahrain'', 1),
    (CAST(19 AS bigint), N''BD'', CAST(0 AS bit), N''Bangladesh'', 1),
    (CAST(20 AS bigint), N''BB'', CAST(0 AS bit), N''Barbados'', 1),
    (CAST(21 AS bigint), N''BY'', CAST(0 AS bit), N''Belarus'', 1),
    (CAST(22 AS bigint), N''BE'', CAST(0 AS bit), N''Belgium'', 1),
    (CAST(23 AS bigint), N''BZ'', CAST(0 AS bit), N''Belize'', 1),
    (CAST(24 AS bigint), N''BJ'', CAST(0 AS bit), N''Benin'', 1),
    (CAST(25 AS bigint), N''BM'', CAST(0 AS bit), N''Bermuda'', 1),
    (CAST(26 AS bigint), N''BT'', CAST(0 AS bit), N''Bhutan'', 1),
    (CAST(27 AS bigint), N''BO'', CAST(0 AS bit), N''Bolivia'', 1),
    (CAST(28 AS bigint), N''BA'', CAST(0 AS bit), N''Bosnia and Herzegowina'', 1),
    (CAST(29 AS bigint), N''BW'', CAST(0 AS bit), N''Botswana'', 1),
    (CAST(30 AS bigint), N''BV'', CAST(0 AS bit), N''Bouvet Island'', 1),
    (CAST(31 AS bigint), N''IO'', CAST(0 AS bit), N''British Indian Ocean Territory'', 1),
    (CAST(32 AS bigint), N''BN'', CAST(0 AS bit), N''Brunei Darussalam'', 1),
    (CAST(33 AS bigint), N''BG'', CAST(0 AS bit), N''Bulgaria'', 1),
    (CAST(34 AS bigint), N''BF'', CAST(0 AS bit), N''Burkina Faso'', 1),
    (CAST(35 AS bigint), N''BI'', CAST(0 AS bit), N''Burundi'', 1),
    (CAST(36 AS bigint), N''KH'', CAST(0 AS bit), N''Cambodia'', 1),
    (CAST(37 AS bigint), N''CM'', CAST(0 AS bit), N''Cameroon'', 1),
    (CAST(38 AS bigint), N''CA'', CAST(0 AS bit), N''Canada'', 1),
    (CAST(39 AS bigint), N''CV'', CAST(0 AS bit), N''Cape Verde'', 1),
    (CAST(40 AS bigint), N''KY'', CAST(0 AS bit), N''Cayman Islands'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([Id], [Abbreviation], [Deleted], [Name], [PhonePrefix])
    VALUES (CAST(41 AS bigint), N''CF'', CAST(0 AS bit), N''Central African Republic'', 1),
    (CAST(42 AS bigint), N''TD'', CAST(0 AS bit), N''Chad'', 1),
    (CAST(43 AS bigint), N''CL'', CAST(0 AS bit), N''Chile'', 1),
    (CAST(44 AS bigint), N''CN'', CAST(0 AS bit), N''China'', 1),
    (CAST(45 AS bigint), N''CX'', CAST(0 AS bit), N''Christmas Island'', 1),
    (CAST(46 AS bigint), N''CC'', CAST(0 AS bit), N''Cocos (Keeling) Islands'', 1),
    (CAST(47 AS bigint), N''CO'', CAST(0 AS bit), N''Colombia'', 1),
    (CAST(48 AS bigint), N''KM'', CAST(0 AS bit), N''Comoros'', 1),
    (CAST(49 AS bigint), N''CG'', CAST(0 AS bit), N''Congo'', 1),
    (CAST(50 AS bigint), N''CD'', CAST(0 AS bit), N''Congo, the Democratic Republic of the'', 1),
    (CAST(51 AS bigint), N''CK'', CAST(0 AS bit), N''Cook Islands'', 1),
    (CAST(52 AS bigint), N''CR'', CAST(0 AS bit), N''Costa Rica'', 1),
    (CAST(53 AS bigint), N''CI'', CAST(0 AS bit), N''Cote dIvoire'', 1),
    (CAST(54 AS bigint), N''HR'', CAST(0 AS bit), N''Croatia (Hrvatska)'', 1),
    (CAST(55 AS bigint), N''CU'', CAST(0 AS bit), N''Cuba'', 1),
    (CAST(56 AS bigint), N''CY'', CAST(0 AS bit), N''Cyprus'', 1),
    (CAST(57 AS bigint), N''CZ'', CAST(0 AS bit), N''Czech Republic'', 1),
    (CAST(58 AS bigint), N''DK'', CAST(0 AS bit), N''Denmark'', 1),
    (CAST(59 AS bigint), N''DJ'', CAST(0 AS bit), N''Djibouti'', 1),
    (CAST(60 AS bigint), N''DM'', CAST(0 AS bit), N''Dominica'', 1),
    (CAST(61 AS bigint), N''DO'', CAST(0 AS bit), N''Dominican Republic'', 1),
    (CAST(62 AS bigint), N''TL'', CAST(0 AS bit), N''East Timor'', 1),
    (CAST(63 AS bigint), N''EC'', CAST(0 AS bit), N''Ecuador'', 1),
    (CAST(64 AS bigint), N''EG'', CAST(0 AS bit), N''Egypt'', 1),
    (CAST(65 AS bigint), N''SV'', CAST(0 AS bit), N''El Salvador'', 1),
    (CAST(66 AS bigint), N''GQ'', CAST(0 AS bit), N''Equatorial Guinea'', 1),
    (CAST(67 AS bigint), N''ER'', CAST(0 AS bit), N''Eritrea'', 1),
    (CAST(68 AS bigint), N''EE'', CAST(0 AS bit), N''Estonia'', 1),
    (CAST(69 AS bigint), N''ET'', CAST(0 AS bit), N''Ethiopia'', 1),
    (CAST(70 AS bigint), N''FK'', CAST(0 AS bit), N''Falkland Islands (Malvinas)'', 1),
    (CAST(71 AS bigint), N''FO'', CAST(0 AS bit), N''Faroe Islands'', 1),
    (CAST(72 AS bigint), N''FJ'', CAST(0 AS bit), N''Fiji'', 1),
    (CAST(73 AS bigint), N''FI'', CAST(0 AS bit), N''Finland'', 1),
    (CAST(74 AS bigint), N''FR'', CAST(0 AS bit), N''France'', 1),
    (CAST(75 AS bigint), N''GF'', CAST(0 AS bit), N''French Guiana'', 1),
    (CAST(76 AS bigint), N''PF'', CAST(0 AS bit), N''French Polynesia'', 1),
    (CAST(77 AS bigint), N''TF'', CAST(0 AS bit), N''French Southern Territories'', 1),
    (CAST(78 AS bigint), N''GA'', CAST(0 AS bit), N''Gabon'', 1),
    (CAST(79 AS bigint), N''GM'', CAST(0 AS bit), N''Gambia'', 1),
    (CAST(80 AS bigint), N''GE'', CAST(0 AS bit), N''Georgia'', 1),
    (CAST(81 AS bigint), N''DE'', CAST(0 AS bit), N''Germany'', 1),
    (CAST(82 AS bigint), N''GH'', CAST(0 AS bit), N''Ghana'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([Id], [Abbreviation], [Deleted], [Name], [PhonePrefix])
    VALUES (CAST(83 AS bigint), N''GI'', CAST(0 AS bit), N''Gibraltar'', 1),
    (CAST(84 AS bigint), N''GR'', CAST(0 AS bit), N''Greece'', 1),
    (CAST(85 AS bigint), N''GL'', CAST(0 AS bit), N''Greenland'', 1),
    (CAST(86 AS bigint), N''GD'', CAST(0 AS bit), N''Grenada'', 1),
    (CAST(87 AS bigint), N''GP'', CAST(0 AS bit), N''Guadeloupe'', 1),
    (CAST(88 AS bigint), N''GU'', CAST(0 AS bit), N''Guam'', 1),
    (CAST(89 AS bigint), N''GT'', CAST(0 AS bit), N''Guatemala'', 1),
    (CAST(90 AS bigint), N''GN'', CAST(0 AS bit), N''Guinea'', 1),
    (CAST(91 AS bigint), N''GW'', CAST(0 AS bit), N''Guinea-Bissau'', 1),
    (CAST(92 AS bigint), N''GY'', CAST(0 AS bit), N''Guyana'', 1),
    (CAST(93 AS bigint), N''HT'', CAST(0 AS bit), N''Haiti'', 1),
    (CAST(94 AS bigint), N''HM'', CAST(0 AS bit), N''Heard and Mc Donald Islands'', 1),
    (CAST(95 AS bigint), N''VA'', CAST(0 AS bit), N''Holy See (Vatican City State)'', 1),
    (CAST(96 AS bigint), N''HN'', CAST(0 AS bit), N''Honduras'', 1),
    (CAST(97 AS bigint), N''HK'', CAST(0 AS bit), N''Hong Kong'', 1),
    (CAST(98 AS bigint), N''HU'', CAST(0 AS bit), N''Hungary'', 1),
    (CAST(99 AS bigint), N''IS'', CAST(0 AS bit), N''Iceland'', 1),
    (CAST(100 AS bigint), N''IN'', CAST(0 AS bit), N''India'', 1),
    (CAST(101 AS bigint), N''ID'', CAST(0 AS bit), N''Indonesia'', 1),
    (CAST(102 AS bigint), N''IR'', CAST(0 AS bit), N''Iran (Islamic Republic of)'', 1),
    (CAST(103 AS bigint), N''IQ'', CAST(0 AS bit), N''Iraq'', 1),
    (CAST(104 AS bigint), N''IE'', CAST(0 AS bit), N''Ireland'', 1),
    (CAST(105 AS bigint), N''IL'', CAST(0 AS bit), N''Israel'', 1),
    (CAST(106 AS bigint), N''IT'', CAST(0 AS bit), N''Italy'', 1),
    (CAST(107 AS bigint), N''JM'', CAST(0 AS bit), N''Jamaica'', 1),
    (CAST(108 AS bigint), N''JP'', CAST(0 AS bit), N''Japan'', 1),
    (CAST(109 AS bigint), N''JO'', CAST(0 AS bit), N''Jordan'', 1),
    (CAST(110 AS bigint), N''KZ'', CAST(0 AS bit), N''Kazakhstan'', 1),
    (CAST(111 AS bigint), N''KE'', CAST(0 AS bit), N''Kenya'', 1),
    (CAST(112 AS bigint), N''KI'', CAST(0 AS bit), N''Kiribati'', 1),
    (CAST(113 AS bigint), N''KP'', CAST(0 AS bit), N''Korea, Democratic Peoples Republic of'', 1),
    (CAST(114 AS bigint), N''KR'', CAST(0 AS bit), N''Korea, Republic of'', 1),
    (CAST(115 AS bigint), N''KW'', CAST(0 AS bit), N''Kuwait'', 1),
    (CAST(116 AS bigint), N''KG'', CAST(0 AS bit), N''Kyrgyzstan'', 1),
    (CAST(117 AS bigint), N''LA'', CAST(0 AS bit), N''Lao Peoples Democratic Republic'', 1),
    (CAST(118 AS bigint), N''LV'', CAST(0 AS bit), N''Latvia'', 1),
    (CAST(119 AS bigint), N''LB'', CAST(0 AS bit), N''Lebanon'', 1),
    (CAST(120 AS bigint), N''LS'', CAST(0 AS bit), N''Lesotho'', 1),
    (CAST(121 AS bigint), N''LR'', CAST(0 AS bit), N''Liberia'', 1),
    (CAST(122 AS bigint), N''LY'', CAST(0 AS bit), N''Libyan Arab Jamahiriya'', 1),
    (CAST(123 AS bigint), N''LI'', CAST(0 AS bit), N''Liechtenstein'', 1),
    (CAST(124 AS bigint), N''LT'', CAST(0 AS bit), N''Lithuania'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([Id], [Abbreviation], [Deleted], [Name], [PhonePrefix])
    VALUES (CAST(125 AS bigint), N''LU'', CAST(0 AS bit), N''Luxembourg'', 1),
    (CAST(126 AS bigint), N''MO'', CAST(0 AS bit), N''Macau'', 1),
    (CAST(127 AS bigint), N''MK'', CAST(0 AS bit), N''North Macedonia'', 1),
    (CAST(128 AS bigint), N''MG'', CAST(0 AS bit), N''Madagascar'', 1),
    (CAST(129 AS bigint), N''MW'', CAST(0 AS bit), N''Malawi'', 1),
    (CAST(130 AS bigint), N''MY'', CAST(0 AS bit), N''Malaysia'', 1),
    (CAST(131 AS bigint), N''MV'', CAST(0 AS bit), N''Maldives'', 1),
    (CAST(132 AS bigint), N''ML'', CAST(0 AS bit), N''Mali'', 1),
    (CAST(133 AS bigint), N''MT'', CAST(0 AS bit), N''Malta'', 1),
    (CAST(134 AS bigint), N''MH'', CAST(0 AS bit), N''Marshall Islands'', 1),
    (CAST(135 AS bigint), N''MQ'', CAST(0 AS bit), N''Martinique'', 1),
    (CAST(136 AS bigint), N''MR'', CAST(0 AS bit), N''Mauritania'', 1),
    (CAST(137 AS bigint), N''MU'', CAST(0 AS bit), N''Mauritius'', 1),
    (CAST(138 AS bigint), N''YT'', CAST(0 AS bit), N''Mayotte'', 1),
    (CAST(139 AS bigint), N''MX'', CAST(0 AS bit), N''Mexico'', 1),
    (CAST(140 AS bigint), N''FM'', CAST(0 AS bit), N''Micronesia, Federated States of'', 1),
    (CAST(141 AS bigint), N''MD'', CAST(0 AS bit), N''Moldova, Republic of'', 1),
    (CAST(142 AS bigint), N''MC'', CAST(0 AS bit), N''Monaco'', 1),
    (CAST(143 AS bigint), N''MN'', CAST(0 AS bit), N''Mongolia'', 1),
    (CAST(144 AS bigint), N''MS'', CAST(0 AS bit), N''Montserrat'', 1),
    (CAST(145 AS bigint), N''MA'', CAST(0 AS bit), N''Morocco'', 1),
    (CAST(146 AS bigint), N''MZ'', CAST(0 AS bit), N''Mozambique'', 1),
    (CAST(147 AS bigint), N''MM'', CAST(0 AS bit), N''Myanmar'', 1),
    (CAST(148 AS bigint), N''NA'', CAST(0 AS bit), N''Namibia'', 1),
    (CAST(149 AS bigint), N''NR'', CAST(0 AS bit), N''Nauru'', 1),
    (CAST(150 AS bigint), N''NP'', CAST(0 AS bit), N''Nepal'', 1),
    (CAST(151 AS bigint), N''NL'', CAST(0 AS bit), N''Netherlands'', 1),
    (CAST(152 AS bigint), N''NC'', CAST(0 AS bit), N''Caledonia'', 1),
    (CAST(153 AS bigint), N''NZ'', CAST(0 AS bit), N''New Zealand'', 1),
    (CAST(154 AS bigint), N''NI'', CAST(0 AS bit), N''Nicaragua'', 1),
    (CAST(155 AS bigint), N''NE'', CAST(0 AS bit), N''Niger'', 1),
    (CAST(156 AS bigint), N''NG'', CAST(0 AS bit), N''Nigeria'', 1),
    (CAST(157 AS bigint), N''NU'', CAST(0 AS bit), N''Niue'', 1),
    (CAST(158 AS bigint), N''NF'', CAST(0 AS bit), N''Norfolk Island'', 1),
    (CAST(159 AS bigint), N''MP'', CAST(0 AS bit), N''Northern Mariana Islands'', 1),
    (CAST(160 AS bigint), N''NO'', CAST(0 AS bit), N''Norway'', 1),
    (CAST(161 AS bigint), N''OM'', CAST(0 AS bit), N''Oman'', 1),
    (CAST(162 AS bigint), N''PK'', CAST(0 AS bit), N''Pakistan'', 1),
    (CAST(163 AS bigint), N''PW'', CAST(0 AS bit), N''Palau'', 1),
    (CAST(164 AS bigint), N''PA'', CAST(0 AS bit), N''Panama'', 1),
    (CAST(165 AS bigint), N''PG'', CAST(0 AS bit), N''Papua new Guinea'', 1),
    (CAST(166 AS bigint), N''PY'', CAST(0 AS bit), N''Paraguay'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([Id], [Abbreviation], [Deleted], [Name], [PhonePrefix])
    VALUES (CAST(167 AS bigint), N''PE'', CAST(0 AS bit), N''Peru'', 1),
    (CAST(168 AS bigint), N''PH'', CAST(0 AS bit), N''Philippines'', 1),
    (CAST(169 AS bigint), N''PN'', CAST(0 AS bit), N''Pitcairn'', 1),
    (CAST(170 AS bigint), N''PL'', CAST(0 AS bit), N''Poland'', 1),
    (CAST(171 AS bigint), N''PT'', CAST(0 AS bit), N''Portugal'', 1),
    (CAST(172 AS bigint), N''PR'', CAST(0 AS bit), N''Puerto Rico'', 1),
    (CAST(173 AS bigint), N''QA'', CAST(0 AS bit), N''Qatar'', 1),
    (CAST(174 AS bigint), N''RE'', CAST(0 AS bit), N''Reunion'', 1),
    (CAST(175 AS bigint), N''RO'', CAST(0 AS bit), N''Romania'', 1),
    (CAST(176 AS bigint), N''RU'', CAST(0 AS bit), N''Russian Federation'', 1),
    (CAST(177 AS bigint), N''RW'', CAST(0 AS bit), N''Rwanda'', 1),
    (CAST(178 AS bigint), N''KN'', CAST(0 AS bit), N''Saint Kitts and Nevis'', 1),
    (CAST(179 AS bigint), N''LC'', CAST(0 AS bit), N''Saint LUCIA'', 1),
    (CAST(180 AS bigint), N''VC'', CAST(0 AS bit), N''Saint Vincent and the Grenadines'', 1),
    (CAST(181 AS bigint), N''WS'', CAST(0 AS bit), N''Samoa'', 1),
    (CAST(182 AS bigint), N''SM'', CAST(0 AS bit), N''San Marino'', 1),
    (CAST(183 AS bigint), N''ST'', CAST(0 AS bit), N''Sao Tome and Principe'', 1),
    (CAST(184 AS bigint), N''SA'', CAST(0 AS bit), N''Saudi Arabia'', 1),
    (CAST(185 AS bigint), N''SN'', CAST(0 AS bit), N''Senegal'', 1),
    (CAST(186 AS bigint), N''SC'', CAST(0 AS bit), N''Seychelles'', 1),
    (CAST(187 AS bigint), N''SL'', CAST(0 AS bit), N''Sierra Leone'', 1),
    (CAST(188 AS bigint), N''SG'', CAST(0 AS bit), N''Singapore'', 1),
    (CAST(189 AS bigint), N''SK'', CAST(0 AS bit), N''Slovakia (Slovak Republic)'', 1),
    (CAST(190 AS bigint), N''SI'', CAST(0 AS bit), N''Slovenia'', 1),
    (CAST(191 AS bigint), N''SB'', CAST(0 AS bit), N''Solomon Islands'', 1),
    (CAST(192 AS bigint), N''SO'', CAST(0 AS bit), N''Somalia'', 1),
    (CAST(193 AS bigint), N''ZA'', CAST(0 AS bit), N''South Africa'', 1),
    (CAST(194 AS bigint), N''GS'', CAST(0 AS bit), N''South Georgia and the South Sandwich Islands'', 1),
    (CAST(195 AS bigint), N''ES'', CAST(0 AS bit), N''Spain'', 1),
    (CAST(196 AS bigint), N''LK'', CAST(0 AS bit), N''Sri Lanka'', 1),
    (CAST(197 AS bigint), N''SH'', CAST(0 AS bit), N''St. Helena'', 1),
    (CAST(198 AS bigint), N''PM'', CAST(0 AS bit), N''St. Pierre and Miquelon'', 1),
    (CAST(199 AS bigint), N''SD'', CAST(0 AS bit), N''Sudan'', 1),
    (CAST(200 AS bigint), N''SR'', CAST(0 AS bit), N''Suriname'', 1),
    (CAST(201 AS bigint), N''SJ'', CAST(0 AS bit), N''Svalbard and Jan Mayen Islands'', 1),
    (CAST(202 AS bigint), N''SZ'', CAST(0 AS bit), N''Swaziland'', 1),
    (CAST(203 AS bigint), N''SE'', CAST(0 AS bit), N''Sweden'', 1),
    (CAST(204 AS bigint), N''CH'', CAST(0 AS bit), N''Switzerland'', 1),
    (CAST(205 AS bigint), N''SY'', CAST(0 AS bit), N''Syrian Arab Republic'', 1),
    (CAST(206 AS bigint), N''TW'', CAST(0 AS bit), N''Taiwan, Province of China'', 1),
    (CAST(207 AS bigint), N''TJ'', CAST(0 AS bit), N''Tajikistan'', 1),
    (CAST(208 AS bigint), N''TZ'', CAST(0 AS bit), N''Tanzania, United Republic of'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([Id], [Abbreviation], [Deleted], [Name], [PhonePrefix])
    VALUES (CAST(209 AS bigint), N''TH'', CAST(0 AS bit), N''Thailand'', 1),
    (CAST(210 AS bigint), N''TG'', CAST(0 AS bit), N''Togo'', 1),
    (CAST(211 AS bigint), N''TK'', CAST(0 AS bit), N''Tokelau'', 1),
    (CAST(212 AS bigint), N''TO'', CAST(0 AS bit), N''Tonga'', 1),
    (CAST(213 AS bigint), N''TT'', CAST(0 AS bit), N''Trinidad and Tobago'', 1),
    (CAST(214 AS bigint), N''TN'', CAST(0 AS bit), N''Tunisia'', 1),
    (CAST(215 AS bigint), N''TR'', CAST(0 AS bit), N''Turkey'', 1),
    (CAST(216 AS bigint), N''TM'', CAST(0 AS bit), N''Turkmenistan'', 1),
    (CAST(217 AS bigint), N''TC'', CAST(0 AS bit), N''Turks and Caicos Islands'', 1),
    (CAST(218 AS bigint), N''TV'', CAST(0 AS bit), N''Tuvalu'', 1),
    (CAST(219 AS bigint), N''UG'', CAST(0 AS bit), N''Uganda'', 1),
    (CAST(220 AS bigint), N''UA'', CAST(0 AS bit), N''Ukraine'', 1),
    (CAST(221 AS bigint), N''AE'', CAST(0 AS bit), N''United Arab Emirates'', 1),
    (CAST(222 AS bigint), N''GB'', CAST(0 AS bit), N''United Kingdom'', 1),
    (CAST(223 AS bigint), N''US'', CAST(0 AS bit), N''United States'', 1),
    (CAST(224 AS bigint), N''UM'', CAST(0 AS bit), N''United States Minor Outlying Islands'', 1),
    (CAST(225 AS bigint), N''UY'', CAST(0 AS bit), N''Uruguay'', 1),
    (CAST(226 AS bigint), N''UZ'', CAST(0 AS bit), N''Uzbekistan'', 1),
    (CAST(227 AS bigint), N''VU'', CAST(0 AS bit), N''Vanuatu'', 1),
    (CAST(228 AS bigint), N''VE'', CAST(0 AS bit), N''Venezuela'', 1),
    (CAST(229 AS bigint), N''VN'', CAST(0 AS bit), N''Viet Nam'', 1),
    (CAST(230 AS bigint), N''VG'', CAST(0 AS bit), N''Virgin Islands (British)'', 1),
    (CAST(231 AS bigint), N''VI'', CAST(0 AS bit), N''Virgin Islands (U.S.)'', 1),
    (CAST(232 AS bigint), N''WF'', CAST(0 AS bit), N''Wallis and Futuna Islands'', 1),
    (CAST(233 AS bigint), N''EH'', CAST(0 AS bit), N''Western Sahara'', 1),
    (CAST(234 AS bigint), N''YE'', CAST(0 AS bit), N''Yemen'', 1),
    (CAST(235 AS bigint), N''YU'', CAST(0 AS bit), N''Yugoslavia'', 1),
    (CAST(236 AS bigint), N''ZM'', CAST(0 AS bit), N''Zambia'', 1),
    (CAST(237 AS bigint), N''ZW'', CAST(0 AS bit), N''Zimbabwe'', 1),
    (CAST(238 AS bigint), N''GG'', CAST(0 AS bit), N''Bailiwick of Guernsey'', 1),
    (CAST(239 AS bigint), N''JE'', CAST(0 AS bit), N''Bailiwick of Jersey'', 1),
    (CAST(240 AS bigint), N''IM'', CAST(0 AS bit), N''Isle of Man'', 1),
    (CAST(241 AS bigint), N''ME'', CAST(0 AS bit), N''Crna Gora (Montenegro)'', 1),
    (CAST(242 AS bigint), N''RS'', CAST(0 AS bit), N''SÉRVIA'', 1),
    (CAST(243 AS bigint), N''SS'', CAST(0 AS bit), N''Republic of South Sudan'', 1),
    (CAST(244 AS bigint), N''N'', CAST(0 AS bit), N''Zona del Canal de Panamá'', 1),
    (CAST(245 AS bigint), N''PS'', CAST(0 AS bit), N''Dawlat Filas?in'', 1),
    (CAST(246 AS bigint), N''AX'', CAST(0 AS bit), N''Åland Islands'', 1),
    (CAST(247 AS bigint), N''CW'', CAST(0 AS bit), N''Curaçao'', 1),
    (CAST(248 AS bigint), N''SM'', CAST(0 AS bit), N''Saint Martin'', 1),
    (CAST(249 AS bigint), N''AN'', CAST(0 AS bit), N''Bonaire'', 1),
    (CAST(250 AS bigint), N''AQ'', CAST(0 AS bit), N''Antartica'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] ON;
    EXEC(N'INSERT INTO [Countries] ([Id], [Abbreviation], [Deleted], [Name], [PhonePrefix])
    VALUES (CAST(251 AS bigint), N''AU'', CAST(0 AS bit), N''Heard Island and McDonald Islands'', 1),
    (CAST(252 AS bigint), N''FR'', CAST(0 AS bit), N''Saint-Barthélemy'', 1),
    (CAST(253 AS bigint), N''SM'', CAST(0 AS bit), N''Saint Martin'', 1),
    (CAST(254 AS bigint), N''TF'', CAST(0 AS bit), N''Terres Australes et Antarctiques Françaises'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'Deleted', N'Name', N'PhonePrefix') AND [object_id] = OBJECT_ID(N'[Countries]'))
        SET IDENTITY_INSERT [Countries] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'CreatedOn', N'Deleted', N'Name', N'UpdatedOn') AND [object_id] = OBJECT_ID(N'[UserTypes]'))
        SET IDENTITY_INSERT [UserTypes] ON;
    EXEC(N'INSERT INTO [UserTypes] ([Id], [Abbreviation], [CreatedOn], [Deleted], [Name], [UpdatedOn])
    VALUES (CAST(1 AS bigint), N''MB'', ''2023-01-17T19:13:08.2429148-03:00'', CAST(0 AS bit), N''Membro'', ''0001-01-01T00:00:00.0000000''),
    (CAST(2 AS bigint), N''ADM'', ''2023-01-17T19:13:08.2429151-03:00'', CAST(0 AS bit), N''Adminitrator'', ''0001-01-01T00:00:00.0000000'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Abbreviation', N'CreatedOn', N'Deleted', N'Name', N'UpdatedOn') AND [object_id] = OBJECT_ID(N'[UserTypes]'))
        SET IDENTITY_INSERT [UserTypes] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    CREATE INDEX [IX_CodeValidations_UserId] ON [CodeValidations] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    CREATE INDEX [IX_PushNotificationKeys_UserId] ON [PushNotificationKeys] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    CREATE INDEX [IX_Users_UserTypeId] ON [Users] ([UserTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117221308_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230117221308_initial', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117224556_configurationTag')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Tag', N'Value') AND [object_id] = OBJECT_ID(N'[ConfigurationTags]'))
        SET IDENTITY_INSERT [ConfigurationTags] ON;
    EXEC(N'INSERT INTO [ConfigurationTags] ([Id], [Description], [Tag], [Value])
    VALUES (CAST(3 AS bigint), N''default_percent_compress'', N''default_percent_compress'', N''60'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Description', N'Tag', N'Value') AND [object_id] = OBJECT_ID(N'[ConfigurationTags]'))
        SET IDENTITY_INSERT [ConfigurationTags] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117224556_configurationTag')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-01-17T19:45:56.0377474-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117224556_configurationTag')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-01-17T19:45:56.0377476-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230117224556_configurationTag')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230117224556_configurationTag', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230406034634_proposal')
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230406034634_proposal')
BEGIN
    CREATE TABLE [ProposalHistoricEletrics] (
        [Id] bigint NOT NULL IDENTITY,
        [proposalId] bigint NOT NULL,
        [Month] nvarchar(max) NOT NULL,
        [Value] nvarchar(4000) NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [UpdatedOn] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_ProposalHistoricEletrics] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_ProposalHistoricEletrics_Proposal_proposalId] FOREIGN KEY ([proposalId]) REFERENCES [Proposal] ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230406034634_proposal')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-04-06T00:46:34.3169883-03:00''
    WHERE [Id] = CAST(1 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230406034634_proposal')
BEGIN
    EXEC(N'UPDATE [UserTypes] SET [CreatedOn] = ''2023-04-06T00:46:34.3169885-03:00''
    WHERE [Id] = CAST(2 AS bigint);
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230406034634_proposal')
BEGIN
    CREATE INDEX [IX_ProposalHistoricEletrics_proposalId] ON [ProposalHistoricEletrics] ([proposalId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230406034634_proposal')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230406034634_proposal', N'6.0.5');
END;
GO

COMMIT;
GO

