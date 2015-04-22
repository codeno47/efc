
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/24/2015 17:20:54
-- Generated from EDMX file: E:\Projects\efc\trunk\dev\EFC.Framework\src\Experion.Components\Logging\Data\AuditModel.edmx
-- --------------------------------------------------

USE [master]
GO

/****** Object:  Database [EFCAudit]   Script Date: 24-02-2015 5.30.43 PM ******/
CREATE DATABASE [EFCAudit]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EFCAudit', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EFCAudit.mdf' , SIZE = 26624KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EFCAudit_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\EFCAudit.ldf' , SIZE = 102144KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [EFCAudit] SET COMPATIBILITY_LEVEL = 90
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EFCAudit] .[dbo].[sp_fulltext_database] @action = 'disable'
end
GO

ALTER DATABASE [EFCAudit]  SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EFCAudit]  SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EFCAudit]  SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EFCAudit]  SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EFCAudit]  SET ARITHABORT OFF 
GO

ALTER DATABASE [EFCAudit]  SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [EFCAudit]  SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [EFCAudit]  SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EFCAudit]  SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EFCAudit]  SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EFCAudit]  SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EFCAudit]  SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EFCAudit]  SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EFCAudit]  SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EFCAudit]  SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EFCAudit]  SET  DISABLE_BROKER 
GO

ALTER DATABASE [EFCAudit]  SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EFCAudit]  SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EFCAudit]  SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EFCAudit]  SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EFCAudit]  SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EFCAudit]  SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EFCAudit]  SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EFCAudit]  SET RECOVERY FULL 
GO

ALTER DATABASE [EFCAudit]  SET  MULTI_USER 
GO

ALTER DATABASE [EFCAudit]  SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EFCAudit]  SET DB_CHAINING OFF 
GO

ALTER DATABASE [EFCAudit]  SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EFCAudit]  SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [EFCAudit]  SET  READ_WRITE 
GO




SET QUOTED_IDENTIFIER OFF;
GO
USE [EFCAudit] ;
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

-- Creating table 'AuditLogs'
/****** Object:  Table [dbo].[AuditLogs]    Script Date: 05-03-2015 10.19.02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AuditLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Data] [nvarchar](max) NOT NULL,
	[Time] [datetime] NOT NULL,
 CONSTRAINT [PK_AuditLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO