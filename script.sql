USE [master]
GO
/****** Object:  Database [nr_VideoRental]    Script Date: 31/01/2021 10:48:05 PM ******/
CREATE DATABASE [nr_VideoRental]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'nr_VideoRental_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\nr_VideoRental.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'nr_VideoRental_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\nr_VideoRental.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [nr_VideoRental] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [nr_VideoRental].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [nr_VideoRental] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [nr_VideoRental] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [nr_VideoRental] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [nr_VideoRental] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [nr_VideoRental] SET ARITHABORT OFF 
GO
ALTER DATABASE [nr_VideoRental] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [nr_VideoRental] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [nr_VideoRental] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [nr_VideoRental] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [nr_VideoRental] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [nr_VideoRental] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [nr_VideoRental] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [nr_VideoRental] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [nr_VideoRental] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [nr_VideoRental] SET  DISABLE_BROKER 
GO
ALTER DATABASE [nr_VideoRental] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [nr_VideoRental] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [nr_VideoRental] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [nr_VideoRental] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [nr_VideoRental] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [nr_VideoRental] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [nr_VideoRental] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [nr_VideoRental] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [nr_VideoRental] SET  MULTI_USER 
GO
ALTER DATABASE [nr_VideoRental] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [nr_VideoRental] SET DB_CHAINING OFF 
GO
ALTER DATABASE [nr_VideoRental] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [nr_VideoRental] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [nr_VideoRental] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [nr_VideoRental] SET QUERY_STORE = OFF
GO
USE [nr_VideoRental]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 31/01/2021 10:48:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[ClientID] [int] NULL,
	[MovieID] [int] NULL,
	[BookingDate] [varchar](50) NULL,
	[ReturnDate] [varchar](50) NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[client]    Script Date: 31/01/2021 10:48:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[client](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[clName] [varchar](50) NULL,
	[clAddress] [varchar](50) NULL,
	[clContact] [varchar](50) NULL,
	[clEmail] [varchar](50) NULL,
	[clCountry] [varchar](50) NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 31/01/2021 10:48:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Mvtitle] [varchar](50) NULL,
	[MvRatting] [varchar](50) NULL,
	[MvYear] [varchar](50) NULL,
	[MvCost] [varchar](50) NULL,
	[MvCopies] [varchar](50) NULL,
	[MvGenre] [varchar](50) NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([BookID], [ClientID], [MovieID], [BookingDate], [ReturnDate]) VALUES (1, 1, 1, N'1/31/2021', N'Booked')
INSERT [dbo].[Booking] ([BookID], [ClientID], [MovieID], [BookingDate], [ReturnDate]) VALUES (2, 2, 1, N'1/31/2021', N'1/31/2021')
SET IDENTITY_INSERT [dbo].[Booking] OFF
SET IDENTITY_INSERT [dbo].[client] ON 

INSERT [dbo].[client] ([ID], [clName], [clAddress], [clContact], [clEmail], [clCountry]) VALUES (1, N'test', N'nz', N'123', N'as@gmail.com', N'nz')
SET IDENTITY_INSERT [dbo].[client] OFF
USE [master]
GO
ALTER DATABASE [nr_VideoRental] SET  READ_WRITE 
GO
