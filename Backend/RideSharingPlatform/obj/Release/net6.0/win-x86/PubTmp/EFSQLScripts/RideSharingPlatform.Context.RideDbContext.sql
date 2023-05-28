﻿IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [Companies] (
        [Id] int NOT NULL IDENTITY,
        [CompanyName] nvarchar(max) NOT NULL,
        [BuildingName] nvarchar(max) NOT NULL,
        [SecurityInChargeName] nvarchar(max) NOT NULL,
        [SecurityHelpDeskNumber] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Companies] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [IncidentTypes] (
        [Id] int NOT NULL IDENTITY,
        [Types] nvarchar(max) NOT NULL,
        [ExpectedSLAInDays] int NOT NULL,
        CONSTRAINT [PK_IncidentTypes] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [Roles] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [VehicleDetails] (
        [RegistrationNo] nvarchar(10) NOT NULL,
        [RTOName] nvarchar(10) NOT NULL,
        [RegistrationDate] datetime2 NOT NULL,
        [RegistrationExpiresOn] datetime2 NOT NULL,
        [RCDocURL] nvarchar(100) NOT NULL,
        [InsuranceCompanyName] nvarchar(50) NOT NULL,
        [InsuranceNo] nvarchar(10) NOT NULL,
        [InsurancedOn] datetime2 NOT NULL,
        [InsuranceExpiresOn] datetime2 NOT NULL,
        [InsuranceCertificateDOCURL] nvarchar(100) NOT NULL,
        [PUCCertificateNo] int NOT NULL,
        [PUCIssuedOn] datetime2 NOT NULL,
        [PUCValidUntil] datetime2 NOT NULL,
        [PUCDOCURL] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_VehicleDetails] PRIMARY KEY ([RegistrationNo])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [VehicleTypes] (
        [ID] int NOT NULL IDENTITY,
        [Type] nvarchar(10) NOT NULL,
        [MaxPassengersAllowed] int NOT NULL,
        [FarePerKM] int NOT NULL,
        CONSTRAINT [PK_VehicleTypes] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [Incidents] (
        [IncidentID] nvarchar(450) NOT NULL,
        [IncidentDate] datetime2 NOT NULL,
        [ReportDate] datetime2 NOT NULL,
        [IncidentReportedByUserId] int NOT NULL,
        [ResolutionETA] datetime2 NOT NULL,
        [InvestigatedByUserId] int NOT NULL,
        [IncidentSummary] nvarchar(max) NOT NULL,
        [IncidentDetails] nvarchar(max) NOT NULL,
        [BookingId] int NOT NULL,
        [Status] nvarchar(max) NOT NULL,
        [IncidentTypeId] int NOT NULL,
        CONSTRAINT [PK_Incidents] PRIMARY KEY ([IncidentID]),
        CONSTRAINT [FK_Incidents_IncidentTypes_IncidentTypeId] FOREIGN KEY ([IncidentTypeId]) REFERENCES [IncidentTypes] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [AuthUser] (
        [Id] int NOT NULL IDENTITY,
        [UserName] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Phone] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        [RoleId] int NOT NULL,
        CONSTRAINT [PK_AuthUser] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_AuthUser_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [UserApplications] (
        [UserId] int NOT NULL IDENTITY,
        [Username] nvarchar(max) NOT NULL,
        [OfficialEmail] nvarchar(max) NOT NULL,
        [PhoneNumber] nvarchar(max) NOT NULL,
        [Designation] nvarchar(max) NOT NULL,
        [RoleId] int NOT NULL,
        [EmployeeeId] nvarchar(max) NOT NULL,
        [AadharNumber] nvarchar(max) NOT NULL,
        [ApplicationStatus] nvarchar(max) NOT NULL,
        [CompanyId] int NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_UserApplications] PRIMARY KEY ([UserId]),
        CONSTRAINT [FK_UserApplications_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserApplications_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [Vehicles] (
        [RegistrationNo] nvarchar(10) NOT NULL,
        [BelongsToUserId] int NOT NULL,
        [VehicleTypeId] int NOT NULL,
        [InspectionStatus] nvarchar(10) NOT NULL,
        [InspectionByUserId] int NULL,
        [InspectedOn] datetime2 NULL,
        CONSTRAINT [PK_Vehicles] PRIMARY KEY ([RegistrationNo]),
        CONSTRAINT [FK_Vehicles_VehicleTypes_VehicleTypeId] FOREIGN KEY ([VehicleTypeId]) REFERENCES [VehicleTypes] ([ID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [InvestigationDetails] (
        [Id] int NOT NULL IDENTITY,
        [Finding] nvarchar(max) NOT NULL,
        [Suggestions] nvarchar(max) NOT NULL,
        [InverstigationDate] datetime2 NOT NULL,
        [IncidentsIncidentId] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_InvestigationDetails] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_InvestigationDetails_Incidents_IncidentsIncidentId] FOREIGN KEY ([IncidentsIncidentId]) REFERENCES [Incidents] ([IncidentID]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE TABLE [DrivingLicenses] (
        [Id] int NOT NULL IDENTITY,
        [LicenseNo] nvarchar(max) NOT NULL,
        [ExpirationDate] datetime2 NOT NULL,
        [RTA] nvarchar(max) NOT NULL,
        [AlowedVehicles] nvarchar(max) NOT NULL,
        [UserId] int NOT NULL,
        CONSTRAINT [PK_DrivingLicenses] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_DrivingLicenses_UserApplications_UserId] FOREIGN KEY ([UserId]) REFERENCES [UserApplications] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BuildingName', N'CompanyName', N'SecurityHelpDeskNumber', N'SecurityInChargeName') AND [object_id] = OBJECT_ID(N'[Companies]'))
        SET IDENTITY_INSERT [Companies] ON;
    EXEC(N'INSERT INTO [Companies] ([Id], [BuildingName], [CompanyName], [SecurityHelpDeskNumber], [SecurityInChargeName])
    VALUES (1, N''Unitech'', N''Cognizant'', N''92123456789'', N''Amit Sau'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'BuildingName', N'CompanyName', N'SecurityHelpDeskNumber', N'SecurityInChargeName') AND [object_id] = OBJECT_ID(N'[Companies]'))
        SET IDENTITY_INSERT [Companies] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ExpectedSLAInDays', N'Types') AND [object_id] = OBJECT_ID(N'[IncidentTypes]'))
        SET IDENTITY_INSERT [IncidentTypes] ON;
    EXEC(N'INSERT INTO [IncidentTypes] ([Id], [ExpectedSLAInDays], [Types])
    VALUES (1, 1, N''Accident''),
    (2, 2, N''Theft''),
    (3, 1, N''Driver Misbehave'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ExpectedSLAInDays', N'Types') AND [object_id] = OBJECT_ID(N'[IncidentTypes]'))
        SET IDENTITY_INSERT [IncidentTypes] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] ON;
    EXEC(N'INSERT INTO [Roles] ([Id], [Name])
    VALUES (1, N''Motorist''),
    (2, N''Rider''),
    (3, N''SecurityHead'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
        SET IDENTITY_INSERT [Roles] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'FarePerKM', N'MaxPassengersAllowed', N'Type') AND [object_id] = OBJECT_ID(N'[VehicleTypes]'))
        SET IDENTITY_INSERT [VehicleTypes] ON;
    EXEC(N'INSERT INTO [VehicleTypes] ([ID], [FarePerKM], [MaxPassengersAllowed], [Type])
    VALUES (1, 13, 7, N''SUV''),
    (2, 12, 4, N''Sedan''),
    (3, 9, 1, N''2Wheeler'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'FarePerKM', N'MaxPassengersAllowed', N'Type') AND [object_id] = OBJECT_ID(N'[VehicleTypes]'))
        SET IDENTITY_INSERT [VehicleTypes] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Password', N'Phone', N'RoleId', N'UserName') AND [object_id] = OBJECT_ID(N'[AuthUser]'))
        SET IDENTITY_INSERT [AuthUser] ON;
    EXEC(N'INSERT INTO [AuthUser] ([Id], [Email], [Password], [Phone], [RoleId], [UserName])
    VALUES (1, N''amit@cts.com'', N''Amit@123'', N''92123456789'', 3, N''Amit Sau'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'Password', N'Phone', N'RoleId', N'UserName') AND [object_id] = OBJECT_ID(N'[AuthUser]'))
        SET IDENTITY_INSERT [AuthUser] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'AadharNumber', N'ApplicationStatus', N'CompanyId', N'Designation', N'EmployeeeId', N'OfficialEmail', N'Password', N'PhoneNumber', N'RoleId', N'Username') AND [object_id] = OBJECT_ID(N'[UserApplications]'))
        SET IDENTITY_INSERT [UserApplications] ON;
    EXEC(N'INSERT INTO [UserApplications] ([UserId], [AadharNumber], [ApplicationStatus], [CompanyId], [Designation], [EmployeeeId], [OfficialEmail], [Password], [PhoneNumber], [RoleId], [Username])
    VALUES (1, N''786556784567'', N''New'', 1, N''Intern'', N''345678'', N''niladri@cts.com'', N''Niladri@123'', N''9123456789'', 1, N''Niladri'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'UserId', N'AadharNumber', N'ApplicationStatus', N'CompanyId', N'Designation', N'EmployeeeId', N'OfficialEmail', N'Password', N'PhoneNumber', N'RoleId', N'Username') AND [object_id] = OBJECT_ID(N'[UserApplications]'))
        SET IDENTITY_INSERT [UserApplications] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlowedVehicles', N'ExpirationDate', N'LicenseNo', N'RTA', N'UserId') AND [object_id] = OBJECT_ID(N'[DrivingLicenses]'))
        SET IDENTITY_INSERT [DrivingLicenses] ON;
    EXEC(N'INSERT INTO [DrivingLicenses] ([Id], [AlowedVehicles], [ExpirationDate], [LicenseNo], [RTA], [UserId])
    VALUES (1, N''Bike'', ''2023-07-19T00:00:00.0000000'', N''FER6578HYU'', N''Beltala'', 1)');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AlowedVehicles', N'ExpirationDate', N'LicenseNo', N'RTA', N'UserId') AND [object_id] = OBJECT_ID(N'[DrivingLicenses]'))
        SET IDENTITY_INSERT [DrivingLicenses] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE INDEX [IX_AuthUser_RoleId] ON [AuthUser] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE INDEX [IX_DrivingLicenses_UserId] ON [DrivingLicenses] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE INDEX [IX_Incidents_IncidentTypeId] ON [Incidents] ([IncidentTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE INDEX [IX_InvestigationDetails_IncidentsIncidentId] ON [InvestigationDetails] ([IncidentsIncidentId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE INDEX [IX_UserApplications_CompanyId] ON [UserApplications] ([CompanyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE INDEX [IX_UserApplications_RoleId] ON [UserApplications] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    CREATE INDEX [IX_Vehicles_VehicleTypeId] ON [Vehicles] ([VehicleTypeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230509084414_initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230509084414_initial', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230525094925_up')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleDetails]') AND [c].[name] = N'InsuranceCertificateDOCURL');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [VehicleDetails] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [VehicleDetails] DROP COLUMN [InsuranceCertificateDOCURL];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230525094925_up')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleDetails]') AND [c].[name] = N'PUCDOCURL');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [VehicleDetails] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [VehicleDetails] DROP COLUMN [PUCDOCURL];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230525094925_up')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[VehicleDetails]') AND [c].[name] = N'RCDocURL');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [VehicleDetails] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [VehicleDetails] DROP COLUMN [RCDocURL];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230525094925_up')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230525094925_up', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527031816_added_ride_managent')
BEGIN
    CREATE TABLE [Bookings] (
        [BookingID] int NOT NULL IDENTITY,
        [BookedOn] int NOT NULL,
        [RiderUserId] int NOT NULL,
        [NoOfSeats] int NOT NULL,
        [TotalAmount] int NOT NULL,
        [PaymentMode] nvarchar(max) NOT NULL,
        [RideSchedulesID] int NOT NULL,
        CONSTRAINT [PK_Bookings] PRIMARY KEY ([BookingID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527031816_added_ride_managent')
BEGIN
    CREATE TABLE [Distances] (
        [ID] int NOT NULL IDENTITY,
        [From] nvarchar(max) NOT NULL,
        [To] nvarchar(max) NOT NULL,
        [DistanceInKMS] int NOT NULL,
        CONSTRAINT [PK_Distances] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527031816_added_ride_managent')
BEGIN
    CREATE TABLE [RideSchedules] (
        [ID] int NOT NULL IDENTITY,
        [RideFrom] nvarchar(max) NOT NULL,
        [RideTo] nvarchar(max) NOT NULL,
        [RideStartsOn] datetime2 NOT NULL,
        [RideTime] datetime2 NOT NULL,
        [RideFare] int NOT NULL,
        [VehicleRegistrationNo] nvarchar(max) NOT NULL,
        [MotoristUserId] int NOT NULL,
        [NoOfSeatsAvailable] int NOT NULL,
        CONSTRAINT [PK_RideSchedules] PRIMARY KEY ([ID])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527031816_added_ride_managent')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'DistanceInKMS', N'From', N'To') AND [object_id] = OBJECT_ID(N'[Distances]'))
        SET IDENTITY_INSERT [Distances] ON;
    EXEC(N'INSERT INTO [Distances] ([ID], [DistanceInKMS], [From], [To])
    VALUES (1, 10, N''Unitech'', N''Dunlop'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'DistanceInKMS', N'From', N'To') AND [object_id] = OBJECT_ID(N'[Distances]'))
        SET IDENTITY_INSERT [Distances] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527031816_added_ride_managent')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'DistanceInKMS', N'From', N'To') AND [object_id] = OBJECT_ID(N'[Distances]'))
        SET IDENTITY_INSERT [Distances] ON;
    EXEC(N'INSERT INTO [Distances] ([ID], [DistanceInKMS], [From], [To])
    VALUES (2, 5, N''Unitech'', N''SlatLake'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ID', N'DistanceInKMS', N'From', N'To') AND [object_id] = OBJECT_ID(N'[Distances]'))
        SET IDENTITY_INSERT [Distances] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527031816_added_ride_managent')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230527031816_added_ride_managent', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527145858_ifany')
BEGIN
    EXEC sp_rename N'[Bookings].[BookedOn]', N'RideScheduleID', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527145858_ifany')
BEGIN
    CREATE INDEX [IX_Bookings_RideScheduleID] ON [Bookings] ([RideScheduleID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527145858_ifany')
BEGIN
    ALTER TABLE [Bookings] ADD CONSTRAINT [FK_Bookings_RideSchedules_RideScheduleID] FOREIGN KEY ([RideScheduleID]) REFERENCES [RideSchedules] ([ID]) ON DELETE CASCADE;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527145858_ifany')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230527145858_ifany', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527150008_ifany1')
BEGIN
    ALTER TABLE [Bookings] ADD [BookedOn] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230527150008_ifany1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230527150008_ifany1', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230528155521_at')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RideSchedules]') AND [c].[name] = N'RideTime');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [RideSchedules] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [RideSchedules] ALTER COLUMN [RideTime] time NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230528155521_at')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230528155521_at', N'6.0.13');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230528161225_at1')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[RideSchedules]') AND [c].[name] = N'RideTime');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [RideSchedules] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [RideSchedules] ALTER COLUMN [RideTime] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230528161225_at1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230528161225_at1', N'6.0.13');
END;
GO

COMMIT;
GO

