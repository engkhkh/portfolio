USE [master]
GO
/****** Object:  Database [MyfolioB ]    Script Date: 2021-08-16 5:00:56 PM ******/
CREATE DATABASE [MyfolioB ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyfolioB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyfolioB .mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyfolioB _log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MyfolioB _log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MyfolioB ] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyfolioB ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyfolioB ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyfolioB ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyfolioB ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyfolioB ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyfolioB ] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyfolioB ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MyfolioB ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyfolioB ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyfolioB ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyfolioB ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyfolioB ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyfolioB ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyfolioB ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyfolioB ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyfolioB ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MyfolioB ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyfolioB ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyfolioB ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyfolioB ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyfolioB ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyfolioB ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MyfolioB ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyfolioB ] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyfolioB ] SET  MULTI_USER 
GO
ALTER DATABASE [MyfolioB ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyfolioB ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyfolioB ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyfolioB ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyfolioB ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyfolioB ] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyfolioB ] SET QUERY_STORE = OFF
GO
USE [MyfolioB ]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2021-08-16 5:00:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nchar](300) NOT NULL,
	[ProductVersion] [nvarchar](64) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2021-08-16 5:00:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [uniqueidentifier] NOT NULL,
	[Street] [nvarchar](max) NOT NULL,
	[City] [nvarchar](max) NOT NULL,
	[Number] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Owner]    Script Date: 2021-08-16 5:00:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Owner](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](max) NULL,
	[Profil] [nvarchar](max) NULL,
	[Avatar] [nvarchar](max) NULL,
	[AddressId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Owner] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[portfolioitems]    Script Date: 2021-08-16 5:00:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[portfolioitems](
	[Id] [uniqueidentifier] NOT NULL,
	[ProjectName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[vedioUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_portfolioitems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20201214105643_intialCreate                                                                                                                                                                                                                                                                                 ', N'5.0.1
')
GO
INSERT [dbo].[Owner] ([Id], [FullName], [Profil], [Avatar], [AddressId]) VALUES (N'3c4e3966-08f2-4676-9dbf-0205543598e6', N'ITECH-CONSULTANTS', N'Software Program/Maintenance And Network Surveillance Cameras/Mobile Applications/Cloud Management', N'avatar.jpg', NULL)
GO
INSERT [dbo].[portfolioitems] ([Id], [ProjectName], [Description], [ImageUrl], [vedioUrl]) VALUES (N'35938ee1-2210-4217-b1f1-7e48cb1409dd', N'POS', N'Point of sale and cashier program. The program is specially designed to manage all shops, supermarkets and pharmacies. Be it small or large, and at the right price for your business.', N'instagram.png', N'pos.mp4')
GO
USE [master]
GO
ALTER DATABASE [MyfolioB ] SET  READ_WRITE 
GO
