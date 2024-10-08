USE [master]
GO
/****** Object:  Database [dbRoadRussia]    Script Date: 04.09.2024 12:52:46 ******/
CREATE DATABASE [dbRoadRussia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dbRoadRussia', FILENAME = N'D:\servermssqla\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbRoadRussia.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dbRoadRussia_log', FILENAME = N'D:\servermssqla\MSSQL16.MSSQLSERVER\MSSQL\DATA\dbRoadRussia_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dbRoadRussia] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dbRoadRussia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dbRoadRussia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dbRoadRussia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dbRoadRussia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dbRoadRussia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dbRoadRussia] SET ARITHABORT OFF 
GO
ALTER DATABASE [dbRoadRussia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dbRoadRussia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dbRoadRussia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dbRoadRussia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dbRoadRussia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dbRoadRussia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dbRoadRussia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dbRoadRussia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dbRoadRussia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dbRoadRussia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [dbRoadRussia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dbRoadRussia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dbRoadRussia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dbRoadRussia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dbRoadRussia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dbRoadRussia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dbRoadRussia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dbRoadRussia] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [dbRoadRussia] SET  MULTI_USER 
GO
ALTER DATABASE [dbRoadRussia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dbRoadRussia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dbRoadRussia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dbRoadRussia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dbRoadRussia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dbRoadRussia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [dbRoadRussia] SET QUERY_STORE = ON
GO
ALTER DATABASE [dbRoadRussia] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dbRoadRussia]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 04.09.2024 12:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] NOT NULL,
	[Photo] [varbinary](max) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NULL,
	[IdPosition] [int] NULL,
	[IdStructuralDivision] [int] NULL,
	[Login] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 04.09.2024 12:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StructuralDivision]    Script Date: 04.09.2024 12:52:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StructuralDivision](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StructuralDivision] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Employee] ([Id], [Photo], [Name], [Surname], [Patronymic], [IdPosition], [IdStructuralDivision], [Login], [Password]) VALUES (1, NULL, N'Мурад', N'Курбанов', N'Гаджиевич', 1, 1, N'murad', N'root')
INSERT [dbo].[Employee] ([Id], [Photo], [Name], [Surname], [Patronymic], [IdPosition], [IdStructuralDivision], [Login], [Password]) VALUES (2, NULL, N'Иван', N'Иванов', N'Иванович', 2, 2, N'ivan', N'123123')
INSERT [dbo].[Employee] ([Id], [Photo], [Name], [Surname], [Patronymic], [IdPosition], [IdStructuralDivision], [Login], [Password]) VALUES (3, NULL, N'Рамазан', N'Рамазанов', N'Раджабович', 1, 2, N'roma', N'111')
GO
INSERT [dbo].[Position] ([Id], [Title]) VALUES (1, N'Менеджер')
INSERT [dbo].[Position] ([Id], [Title]) VALUES (2, N'Уборшик')
GO
INSERT [dbo].[StructuralDivision] ([Id], [Title]) VALUES (1, N'Подразделение 1')
INSERT [dbo].[StructuralDivision] ([Id], [Title]) VALUES (2, N'Подразделение 2')
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Position] FOREIGN KEY([IdPosition])
REFERENCES [dbo].[Position] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Position]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_StructuralDivision] FOREIGN KEY([IdStructuralDivision])
REFERENCES [dbo].[StructuralDivision] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_StructuralDivision]
GO
USE [master]
GO
ALTER DATABASE [dbRoadRussia] SET  READ_WRITE 
GO
