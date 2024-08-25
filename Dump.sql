USE [master]
GO
/****** Object:  Database [Paradigmi]    Script Date: 12/08/2024 19:48:36 ******/
CREATE DATABASE [Paradigmi]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Paradigmi', FILENAME = N'C:\Program Files\SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Paradigmi.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Paradigmi_log', FILENAME = N'C:\Program Files\SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Paradigmi_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Paradigmi] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Paradigmi].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Paradigmi] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Paradigmi] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Paradigmi] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Paradigmi] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Paradigmi] SET ARITHABORT OFF 
GO
ALTER DATABASE [Paradigmi] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Paradigmi] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Paradigmi] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Paradigmi] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Paradigmi] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Paradigmi] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Paradigmi] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Paradigmi] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Paradigmi] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Paradigmi] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Paradigmi] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Paradigmi] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Paradigmi] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Paradigmi] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Paradigmi] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Paradigmi] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Paradigmi] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Paradigmi] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Paradigmi] SET  MULTI_USER 
GO
ALTER DATABASE [Paradigmi] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Paradigmi] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Paradigmi] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Paradigmi] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Paradigmi] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Paradigmi] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Paradigmi] SET QUERY_STORE = ON
GO
ALTER DATABASE [Paradigmi] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Paradigmi]
GO
/****** Object:  User [paradigmi]    Script Date: 12/08/2024 19:48:36 ******/
CREATE USER [paradigmi] FOR LOGIN [paradigmi] WITH DEFAULT_SCHEMA=[paradigmi]
GO
ALTER ROLE [db_owner] ADD MEMBER [paradigmi]
GO
/****** Object:  Schema [paradigmi]    Script Date: 12/08/2024 19:48:36 ******/
CREATE SCHEMA [paradigmi]
GO
/****** Object:  Table [dbo].[Ordini]    Script Date: 12/08/2024 19:48:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ordini](
	[numero] [int] IDENTITY(1,1) NOT NULL,
	[emailUtente] [varchar](50) NULL,
	[data] [datetime] NULL,
	[indirizzo] [varchar](50) NULL,
 CONSTRAINT [PK_Ordini] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Portate]    Script Date: 12/08/2024 19:48:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Portate](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nome] [varchar](50) NULL,
	[prezzo] [decimal](5, 2) NULL,
	[tipologia] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PortateOrdine]    Script Date: 12/08/2024 19:48:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortateOrdine](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPortata] [int] NOT NULL,
	[numeroOrdine] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utenti]    Script Date: 12/08/2024 19:48:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utenti](
	[email] [varchar](50) NOT NULL,
	[nome] [varchar](50) NOT NULL,
	[cognome] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[ruolo] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Portate] ON 

INSERT [dbo].[Portate] ([id], [nome], [prezzo], [tipologia]) VALUES (1, N'Spaghetti al pomodoro', CAST(13.00 AS Decimal(5, 2)), 0)
INSERT [dbo].[Portate] ([id], [nome], [prezzo], [tipologia]) VALUES (2, N'Penne al pesto', CAST(14.00 AS Decimal(5, 2)), 0)
INSERT [dbo].[Portate] ([id], [nome], [prezzo], [tipologia]) VALUES (3, N'Tagliata di manzo', CAST(20.00 AS Decimal(5, 2)), 1)
INSERT [dbo].[Portate] ([id], [nome], [prezzo], [tipologia]) VALUES (4, N'Filetto di salmone', CAST(18.00 AS Decimal(5, 2)), 1)
INSERT [dbo].[Portate] ([id], [nome], [prezzo], [tipologia]) VALUES (5, N'Insalata mista', CAST(4.00 AS Decimal(5, 2)), 2)
INSERT [dbo].[Portate] ([id], [nome], [prezzo], [tipologia]) VALUES (6, N'Patate arrosto', CAST(5.00 AS Decimal(5, 2)), 2)
INSERT [dbo].[Portate] ([id], [nome], [prezzo], [tipologia]) VALUES (7, N'Tiramisù', CAST(5.00 AS Decimal(5, 2)), 3)
INSERT [dbo].[Portate] ([id], [nome], [prezzo], [tipologia]) VALUES (8, N'Cantucci con vino cotto', CAST(6.00 AS Decimal(5, 2)), 3)
SET IDENTITY_INSERT [dbo].[Portate] OFF
GO
INSERT [dbo].[Utenti] ([email], [nome], [cognome], [password], [ruolo]) VALUES (N'admin@mail.com', N'admin', N'administrator', N'?gB??\v???U?g?6#????E??x??F?', 1)
GO
USE [master]
GO
ALTER DATABASE [Paradigmi] SET  READ_WRITE 
GO
