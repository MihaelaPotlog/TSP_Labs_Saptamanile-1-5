
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/11/2020 20:23:21
-- Generated from EDMX file: C:\Users\mihaela\source\repos\.NetFramework-Labs\ModelDesignFirst_L1\ModelDesignFirst_L1\ModelManyToMany.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Albums'
CREATE TABLE [dbo].[Albums] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Artists'
CREATE TABLE [dbo].[Artists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AlbumArtist'
CREATE TABLE [dbo].[AlbumArtist] (
    [Albums_Id] int  NOT NULL,
    [Artists_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [PK_Albums]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Artists'
ALTER TABLE [dbo].[Artists]
ADD CONSTRAINT [PK_Artists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Albums_Id], [Artists_Id] in table 'AlbumArtist'
ALTER TABLE [dbo].[AlbumArtist]
ADD CONSTRAINT [PK_AlbumArtist]
    PRIMARY KEY CLUSTERED ([Albums_Id], [Artists_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Albums_Id] in table 'AlbumArtist'
ALTER TABLE [dbo].[AlbumArtist]
ADD CONSTRAINT [FK_AlbumArtist_Album]
    FOREIGN KEY ([Albums_Id])
    REFERENCES [dbo].[Albums]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Artists_Id] in table 'AlbumArtist'
ALTER TABLE [dbo].[AlbumArtist]
ADD CONSTRAINT [FK_AlbumArtist_Artist]
    FOREIGN KEY ([Artists_Id])
    REFERENCES [dbo].[Artists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlbumArtist_Artist'
CREATE INDEX [IX_FK_AlbumArtist_Artist]
ON [dbo].[AlbumArtist]
    ([Artists_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------