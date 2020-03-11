
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/11/2020 21:43:54
-- Generated from EDMX file: C:\Users\mihaela\source\repos\.NetFramework-Labs\ModelDesignFirst_L1\ModelDesignFirst_L1\DoctorPacientModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [C:\USERS\MIHAELA\DOCUMENTS\TESTPERSON.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DoctorPacient_Doctor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoctorPacients] DROP CONSTRAINT [FK_DoctorPacient_Doctor];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorPacient_Pacient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DoctorPacients] DROP CONSTRAINT [FK_DoctorPacient_Pacient];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[DoctorPacients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DoctorPacients];
GO
IF OBJECT_ID(N'[dbo].[Doctors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doctors];
GO
IF OBJECT_ID(N'[dbo].[Pacients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pacients];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'DoctorPacients'
CREATE TABLE [dbo].[DoctorPacients] (
    [Doctors_Id] int  NOT NULL,
    [Pacients_Id] int  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'Doctors'
CREATE TABLE [dbo].[Doctors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Specialty] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pacients'
CREATE TABLE [dbo].[Pacients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Doctors_Id], [Pacients_Id] in table 'DoctorPacients'
ALTER TABLE [dbo].[DoctorPacients]
ADD CONSTRAINT [PK_DoctorPacients]
    PRIMARY KEY CLUSTERED ([Doctors_Id], [Pacients_Id] ASC);
GO

-- Creating primary key on [Id] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [PK_Doctors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pacients'
ALTER TABLE [dbo].[Pacients]
ADD CONSTRAINT [PK_Pacients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Doctors_Id] in table 'DoctorPacients'
ALTER TABLE [dbo].[DoctorPacients]
ADD CONSTRAINT [FK_DoctorPacient_Doctor]
    FOREIGN KEY ([Doctors_Id])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Pacients_Id] in table 'DoctorPacients'
ALTER TABLE [dbo].[DoctorPacients]
ADD CONSTRAINT [FK_DoctorPacient_Pacient]
    FOREIGN KEY ([Pacients_Id])
    REFERENCES [dbo].[Pacients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorPacient_Pacient'
CREATE INDEX [IX_FK_DoctorPacient_Pacient]
ON [dbo].[DoctorPacients]
    ([Pacients_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------