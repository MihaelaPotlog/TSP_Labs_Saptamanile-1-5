
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/27/2020 11:18:45
-- Generated from EDMX file: C:\Users\mihaela\source\repos\.NetFramework\EntityFrameworkFirstProject\EntityFrameworkFirstProject\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyPhotos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Photos'
CREATE TABLE [dbo].[Photos] (
    [Id] uniqueidentifier  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Type] bit  NOT NULL
);
GO

-- Creating table 'Characteristics'
CREATE TABLE [dbo].[Characteristics] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'People'
CREATE TABLE [dbo].[People] (
    [Id] uniqueidentifier  NOT NULL,
    [Firstname] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Eveniments'
CREATE TABLE [dbo].[Eveniments] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PhotoCharacteristic'
CREATE TABLE [dbo].[PhotoCharacteristic] (
    [Photos_Id] uniqueidentifier  NOT NULL,
    [Characteristics_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PhotoPerson'
CREATE TABLE [dbo].[PhotoPerson] (
    [Photos_Id] uniqueidentifier  NOT NULL,
    [People_Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'PhotoEveniment'
CREATE TABLE [dbo].[PhotoEveniment] (
    [Photos_Id] uniqueidentifier  NOT NULL,
    [Eveniments_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Photos'
ALTER TABLE [dbo].[Photos]
ADD CONSTRAINT [PK_Photos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Characteristics'
ALTER TABLE [dbo].[Characteristics]
ADD CONSTRAINT [PK_Characteristics]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'People'
ALTER TABLE [dbo].[People]
ADD CONSTRAINT [PK_People]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Eveniments'
ALTER TABLE [dbo].[Eveniments]
ADD CONSTRAINT [PK_Eveniments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Photos_Id], [Characteristics_Id] in table 'PhotoCharacteristic'
ALTER TABLE [dbo].[PhotoCharacteristic]
ADD CONSTRAINT [PK_PhotoCharacteristic]
    PRIMARY KEY CLUSTERED ([Photos_Id], [Characteristics_Id] ASC);
GO

-- Creating primary key on [Photos_Id], [People_Id] in table 'PhotoPerson'
ALTER TABLE [dbo].[PhotoPerson]
ADD CONSTRAINT [PK_PhotoPerson]
    PRIMARY KEY CLUSTERED ([Photos_Id], [People_Id] ASC);
GO

-- Creating primary key on [Photos_Id], [Eveniments_Id] in table 'PhotoEveniment'
ALTER TABLE [dbo].[PhotoEveniment]
ADD CONSTRAINT [PK_PhotoEveniment]
    PRIMARY KEY CLUSTERED ([Photos_Id], [Eveniments_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Photos_Id] in table 'PhotoCharacteristic'
ALTER TABLE [dbo].[PhotoCharacteristic]
ADD CONSTRAINT [FK_PhotoCharacteristic_Photo]
    FOREIGN KEY ([Photos_Id])
    REFERENCES [dbo].[Photos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Characteristics_Id] in table 'PhotoCharacteristic'
ALTER TABLE [dbo].[PhotoCharacteristic]
ADD CONSTRAINT [FK_PhotoCharacteristic_Characteristic]
    FOREIGN KEY ([Characteristics_Id])
    REFERENCES [dbo].[Characteristics]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoCharacteristic_Characteristic'
CREATE INDEX [IX_FK_PhotoCharacteristic_Characteristic]
ON [dbo].[PhotoCharacteristic]
    ([Characteristics_Id]);
GO

-- Creating foreign key on [Photos_Id] in table 'PhotoPerson'
ALTER TABLE [dbo].[PhotoPerson]
ADD CONSTRAINT [FK_PhotoPerson_Photo]
    FOREIGN KEY ([Photos_Id])
    REFERENCES [dbo].[Photos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [People_Id] in table 'PhotoPerson'
ALTER TABLE [dbo].[PhotoPerson]
ADD CONSTRAINT [FK_PhotoPerson_Person]
    FOREIGN KEY ([People_Id])
    REFERENCES [dbo].[People]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoPerson_Person'
CREATE INDEX [IX_FK_PhotoPerson_Person]
ON [dbo].[PhotoPerson]
    ([People_Id]);
GO

-- Creating foreign key on [Photos_Id] in table 'PhotoEveniment'
ALTER TABLE [dbo].[PhotoEveniment]
ADD CONSTRAINT [FK_PhotoEveniment_Photo]
    FOREIGN KEY ([Photos_Id])
    REFERENCES [dbo].[Photos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Eveniments_Id] in table 'PhotoEveniment'
ALTER TABLE [dbo].[PhotoEveniment]
ADD CONSTRAINT [FK_PhotoEveniment_Eveniment]
    FOREIGN KEY ([Eveniments_Id])
    REFERENCES [dbo].[Eveniments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhotoEveniment_Eveniment'
CREATE INDEX [IX_FK_PhotoEveniment_Eveniment]
ON [dbo].[PhotoEveniment]
    ([Eveniments_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------