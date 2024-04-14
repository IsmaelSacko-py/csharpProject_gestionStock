
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/29/2024 01:46:38
-- Generated from EDMX file: C:\Users\DELL\Desktop\Mes donnees\Documents\COURS DE PYTHON\Mes Projets 2.0\csharpProject_gestionStock\csharpProject_gestionStock\Model\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BdKireneEntities];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Approvisionnement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Approvisionnement];
GO
IF OBJECT_ID(N'[dbo].[Categorie]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorie];
GO
IF OBJECT_ID(N'[dbo].[Facture]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Facture];
GO
IF OBJECT_ID(N'[dbo].[Produit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produit];
GO
IF OBJECT_ID(N'[dbo].[Profil]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profil];
GO
IF OBJECT_ID(N'[dbo].[Utilisateur]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Utilisateur];
GO
IF OBJECT_ID(N'[BdKireneModelStoreContainer].[VRechercheProduit]', 'U') IS NOT NULL
    DROP TABLE [BdKireneModelStoreContainer].[VRechercheProduit];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Categorie'
CREATE TABLE [dbo].[Categorie] (
    [IdCategorie] int IDENTITY(1,1) NOT NULL,
    [CodeCategorie] nchar(4)  NULL,
    [LibelleCategorie] nchar(100)  NULL
);
GO

-- Creating table 'Produit'
CREATE TABLE [dbo].[Produit] (
    [idProduit] int IDENTITY(1,1) NOT NULL,
    [CodeProduit] nvarchar(5)  NULL,
    [DesignationProduit] nvarchar(200)  NULL,
    [PrixUnitaire] float  NULL,
    [QuantiteMinimale] int  NULL,
    [QuantiteMaximale] int  NULL,
    [CodeCategorie] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'VRechercheProduit'
CREATE TABLE [dbo].[VRechercheProduit] (
    [CodeCategorie] nchar(4)  NULL,
    [LibelleCategorie] nchar(100)  NULL,
    [CodeProduit] nvarchar(5)  NULL,
    [DesignationProduit] nvarchar(200)  NULL,
    [PrixUnitaire] float  NULL,
    [QuantiteMinimale] int  NULL,
    [QuantiteMaximale] int  NULL,
    [idProduit] int  NOT NULL
);
GO

-- Creating table 'Approvisionnement'
CREATE TABLE [dbo].[Approvisionnement] (
    [id] int IDENTITY(1,1) NOT NULL,
    [CodeProduit] nvarchar(5)  NULL,
    [QuantiteAppro] int  NULL,
    [QuantiteRestante] int  NULL,
    [DatePeremption] datetime  NULL,
    [DateAppro] nchar(10)  NULL
);
GO

-- Creating table 'Profil'
CREATE TABLE [dbo].[Profil] (
    [idProfil] int IDENTITY(1,1) NOT NULL,
    [CodeProfil] nvarchar(20)  NULL,
    [LibelleProfil] nvarchar(150)  NULL
);
GO

-- Creating table 'Utilisateur'
CREATE TABLE [dbo].[Utilisateur] (
    [idUtilisateur] int IDENTITY(1,1) NOT NULL,
    [IdentifiantUtilisateur] nvarchar(50)  NULL,
    [MotDePasse] nvarchar(250)  NULL,
    [CodeProfil] nvarchar(20)  NULL,
    [Email] nvarchar(50)  NULL,
    [Nom] nvarchar(50)  NULL,
    [Prenom] nvarchar(50)  NULL
);
GO

-- Creating table 'Facture'
CREATE TABLE [dbo].[Facture] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CodeProduit] nvarchar(5)  NULL,
    [NomClient] nvarchar(50)  NULL,
    [PrenomClient] nvarchar(50)  NULL,
    [TelephoneClient] nvarchar(50)  NULL,
    [Quantite] int  NULL,
    [Prix] int  NULL,
    [Total] int  NULL,
    [IdentifiantUtilisateur] nvarchar(50)  NULL,
    [dateVente] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCategorie] in table 'Categorie'
ALTER TABLE [dbo].[Categorie]
ADD CONSTRAINT [PK_Categorie]
    PRIMARY KEY CLUSTERED ([IdCategorie] ASC);
GO

-- Creating primary key on [idProduit] in table 'Produit'
ALTER TABLE [dbo].[Produit]
ADD CONSTRAINT [PK_Produit]
    PRIMARY KEY CLUSTERED ([idProduit] ASC);
GO

-- Creating primary key on [idProduit] in table 'VRechercheProduit'
ALTER TABLE [dbo].[VRechercheProduit]
ADD CONSTRAINT [PK_VRechercheProduit]
    PRIMARY KEY CLUSTERED ([idProduit] ASC);
GO

-- Creating primary key on [id] in table 'Approvisionnement'
ALTER TABLE [dbo].[Approvisionnement]
ADD CONSTRAINT [PK_Approvisionnement]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [idProfil] in table 'Profil'
ALTER TABLE [dbo].[Profil]
ADD CONSTRAINT [PK_Profil]
    PRIMARY KEY CLUSTERED ([idProfil] ASC);
GO

-- Creating primary key on [idUtilisateur] in table 'Utilisateur'
ALTER TABLE [dbo].[Utilisateur]
ADD CONSTRAINT [PK_Utilisateur]
    PRIMARY KEY CLUSTERED ([idUtilisateur] ASC);
GO

-- Creating primary key on [Id] in table 'Facture'
ALTER TABLE [dbo].[Facture]
ADD CONSTRAINT [PK_Facture]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------