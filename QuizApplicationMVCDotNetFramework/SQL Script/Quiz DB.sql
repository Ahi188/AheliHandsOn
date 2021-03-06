USE [master]
GO
/****** Object:  Database [1st Database]    Script Date: 10-02-2022 19:09:23 ******/
CREATE DATABASE [1st Database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'1st Database', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\1st Database.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'1st Database_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\1st Database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [1st Database] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [1st Database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [1st Database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [1st Database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [1st Database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [1st Database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [1st Database] SET ARITHABORT OFF 
GO
ALTER DATABASE [1st Database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [1st Database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [1st Database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [1st Database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [1st Database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [1st Database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [1st Database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [1st Database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [1st Database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [1st Database] SET  DISABLE_BROKER 
GO
ALTER DATABASE [1st Database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [1st Database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [1st Database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [1st Database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [1st Database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [1st Database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [1st Database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [1st Database] SET RECOVERY FULL 
GO
ALTER DATABASE [1st Database] SET  MULTI_USER 
GO
ALTER DATABASE [1st Database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [1st Database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [1st Database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [1st Database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [1st Database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [1st Database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'1st Database', N'ON'
GO
ALTER DATABASE [1st Database] SET QUERY_STORE = OFF
GO
USE [1st Database]
GO
/****** Object:  UserDefinedFunction [dbo].[Fn_GetEmail]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Fn_GetEmail]
(
	@Fn varchar(100),
	@Ln varchar (100)
)
RETURNS varchar (100)
AS
BEGIN
declare @Email varchar(10) = '@athora.com'
	declare @splitter varchar(10) = '-'
	RETURN (@Fn + @splitter +@Ln + @Email)

END
GO
/****** Object:  Table [dbo].[Student1]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student1](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[First_name] [nvarchar](20) NULL,
	[Last_name] [varchar](20) NULL,
	[Roll_number] [int] NULL,
	[Marks] [decimal](10, 2) NULL,
	[Date_of_Birth] [datetime] NULL,
	[BranchId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[Fn_GetStudent]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[Fn_GetStudent]
(	
	)
RETURNS TABLE 
AS
RETURN 
(
	SELECT * from [dbo].[Student1] 
)
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChosenAnswer]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChosenAnswer](
	[Ansid] [int] IDENTITY(1,1) NOT NULL,
	[Answer] [nvarchar](max) NULL,
	[Qid] [int] NULL,
	[Userid] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ansid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Duplicate]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Duplicate](
	[id] [int] NULL,
	[FirstName] [nvarchar](50) NULL,
	[Department] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] NULL,
	[EmpName] [varchar](50) NULL,
	[Country_code] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entry]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entry](
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entry2]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entry2](
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entry3]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entry3](
	[series_reference] [nvarchar](50) NULL,
	[units] [nvarchar](50) NULL,
	[subjects] [nvarchar](50) NULL,
	[groups] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OnlineExam]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OnlineExam](
	[Qid] [int] IDENTITY(1,1) NOT NULL,
	[Question] [nvarchar](200) NULL,
	[Option1] [nvarchar](200) NULL,
	[Option2] [nvarchar](200) NULL,
	[Option3] [nvarchar](200) NULL,
	[Option4] [nvarchar](200) NULL,
	[CorrectAns] [nvarchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[Qid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[People]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[People](
	[ID] [int] NULL,
	[Name] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[Country_code] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[productId] [int] NULL,
	[productName] [varchar](50) NULL,
	[productPrice] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDescription]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDescription](
	[productId] [int] NULL,
	[productColor] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[First_name] [nvarchar](20) NULL,
	[Last_name] [varchar](20) NULL,
	[Roll_number] [int] NULL,
	[Marks] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_1](
	[ID] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[PhoneNumber] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table2]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table2](
	[id] [int] NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[countryCode] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Table2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Table3]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table3](
	[id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[countryCode] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usertable]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usertable](
	[Userid] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [char](100) NULL,
	[LastName] [char](100) NULL,
	[Email] [varchar](100) NULL,
	[Marks] [int] NULL,
	[Userguid] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Branch] ON 

INSERT [dbo].[Branch] ([Id], [Name]) VALUES (1, N'CSE')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (2, N'IT')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (3, N'EEE')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (4, N'Civil')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (5, N'ME')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (6, N'2')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (7, N'EE')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (8, N'ECE')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (9, N'ECE')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (10, N'ME')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (11, N'CSE')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (12, N'IT')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (13, N'IT')
INSERT [dbo].[Branch] ([Id], [Name]) VALUES (14, N'IT')
SET IDENTITY_INSERT [dbo].[Branch] OFF
GO
SET IDENTITY_INSERT [dbo].[ChosenAnswer] ON 

INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (1, N'1', 1, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (2, N'4', 2, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (3, N'4', 3, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (4, N'Asia', 4, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (5, N'4', 5, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (6, NULL, 1, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (7, NULL, 2, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (8, NULL, 3, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (9, NULL, 4, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (10, NULL, 5, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (11, NULL, 1, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (12, NULL, 2, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (13, NULL, 3, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (14, NULL, 4, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (15, NULL, 5, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (16, N'7', 1, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (17, N'7', 1, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (18, N'4', 2, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (19, N'4', 2, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (20, NULL, 3, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (21, NULL, 4, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (22, NULL, 3, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (23, N'7', 1, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (24, NULL, 2, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (25, N'7', 1, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (26, N'7', 1, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (27, N'7', 1, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (28, N'4', 2, NULL)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (29, N'7', 1, 30)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (30, NULL, 1, 31)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (31, NULL, 1, 31)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (32, NULL, 1, 32)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (40, N'8', 1, 33)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (41, N'4', 2, 33)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (42, N'4', 3, 33)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (43, N'Asia', 4, 33)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (44, N'4', 5, 33)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (45, NULL, 1, 34)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (46, NULL, 2, 34)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (47, NULL, 1, 34)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (48, NULL, 2, 34)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (49, NULL, 3, 34)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (50, NULL, 4, 34)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (51, NULL, 5, 34)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (54, N'7', 1, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (55, N'4', 2, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (56, N'4', 3, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (57, N'Asia', 4, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (58, N'4', 5, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (59, NULL, 4, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (60, NULL, 3, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (61, NULL, 4, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (62, NULL, 5, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (63, NULL, 4, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (64, NULL, 5, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (65, NULL, 4, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (66, NULL, 5, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (67, NULL, 4, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (68, NULL, 5, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (69, NULL, 4, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (70, NULL, 5, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (71, NULL, 4, 35)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (72, N'7', 1, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (73, N'4', 2, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (74, N'4', 3, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (75, N'Asia', 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (76, N'4', 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (77, N'Asia', 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (78, N'4', 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (79, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (80, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (81, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (82, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (83, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (84, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (85, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (86, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (87, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (88, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (89, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (90, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (91, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (92, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (93, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (94, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (95, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (96, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (97, N'Africa', 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (98, N'4', 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (99, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (100, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (101, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (102, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (103, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (104, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (105, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (106, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (107, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (108, NULL, 5, 36)
GO
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (109, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (110, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (111, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (112, NULL, 3, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (113, NULL, 2, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (114, NULL, 1, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (115, NULL, 2, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (116, NULL, 3, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (117, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (118, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (119, NULL, 4, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (120, NULL, 5, 36)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (121, N'7', 1, 37)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (122, N'4', 2, 37)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (123, N'4', 3, 37)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (124, N'Asia', 4, 37)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (125, N'4', 5, 37)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (127, N'7', 1, 38)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (128, N'4', 2, 38)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (129, N'4', 3, 38)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (130, N'Asia', 4, 38)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (131, N'4', 5, 38)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (132, NULL, 4, 38)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (133, N'4', 5, 38)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (134, N'7', 1, 39)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (135, N'4', 2, 39)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (136, N'4', 3, 39)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (137, N'Asia', 4, 39)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (138, N'4', 5, 39)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (139, N'7', 1, 40)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (140, N'4', 2, 40)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (141, N'4', 3, 40)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (142, N'Asia', 4, 40)
INSERT [dbo].[ChosenAnswer] ([Ansid], [Answer], [Qid], [Userid]) VALUES (143, N'4', 5, 40)
SET IDENTITY_INSERT [dbo].[ChosenAnswer] OFF
GO
INSERT [dbo].[Duplicate] ([id], [FirstName], [Department]) VALUES (1, N'A', N'C')
INSERT [dbo].[Duplicate] ([id], [FirstName], [Department]) VALUES (2, N'B', N'C')
INSERT [dbo].[Duplicate] ([id], [FirstName], [Department]) VALUES (3, N'C', N'G')
INSERT [dbo].[Duplicate] ([id], [FirstName], [Department]) VALUES (4, N'B', N'C')
INSERT [dbo].[Duplicate] ([id], [FirstName], [Department]) VALUES (5, N'F', N'G')
INSERT [dbo].[Duplicate] ([id], [FirstName], [Department]) VALUES (6, N'A', N'C')
GO
INSERT [dbo].[Employee] ([ID], [EmpName], [Country_code]) VALUES (1, N'A', 12)
INSERT [dbo].[Employee] ([ID], [EmpName], [Country_code]) VALUES (2, N'B', 23)
INSERT [dbo].[Employee] ([ID], [EmpName], [Country_code]) VALUES (3, N'C', 24)
INSERT [dbo].[Employee] ([ID], [EmpName], [Country_code]) VALUES (4, N'D', 25)
INSERT [dbo].[Employee] ([ID], [EmpName], [Country_code]) VALUES (5, N'E', 26)
INSERT [dbo].[Employee] ([ID], [EmpName], [Country_code]) VALUES (6, N'F', 27)
INSERT [dbo].[Employee] ([ID], [EmpName], [Country_code]) VALUES (7, N'G', 28)
GO
INSERT [dbo].[Entry3] ([series_reference], [units], [subjects], [groups]) VALUES (N'series_reference', N'units', N'subjects', N'groups')
INSERT [dbo].[Entry3] ([series_reference], [units], [subjects], [groups]) VALUES (N'
A', N'B', N'C', N'D')
INSERT [dbo].[Entry3] ([series_reference], [units], [subjects], [groups]) VALUES (N'
E', N'F', N'G', N'H')
GO
SET IDENTITY_INSERT [dbo].[OnlineExam] ON 

INSERT [dbo].[OnlineExam] ([Qid], [Question], [Option1], [Option2], [Option3], [Option4], [CorrectAns]) VALUES (1, N'How many continents are there?', N'1', N'2', N'8', N'7', N'7')
INSERT [dbo].[OnlineExam] ([Qid], [Question], [Option1], [Option2], [Option3], [Option4], [CorrectAns]) VALUES (2, N'How many limbs do cats have?', N'1', N'2', N'3', N'4', N'4')
INSERT [dbo].[OnlineExam] ([Qid], [Question], [Option1], [Option2], [Option3], [Option4], [CorrectAns]) VALUES (3, N'How many limbs do dogs have?', N'1', N'2', N'3', N'4', N'4')
INSERT [dbo].[OnlineExam] ([Qid], [Question], [Option1], [Option2], [Option3], [Option4], [CorrectAns]) VALUES (4, N'What is the largest continent?', N'Asia', N'Africa', N'Europe', N'Australia', N'Asia')
INSERT [dbo].[OnlineExam] ([Qid], [Question], [Option1], [Option2], [Option3], [Option4], [CorrectAns]) VALUES (5, N'What is 2+2?', N'1', N'2', N'3', N'4', N'4')
SET IDENTITY_INSERT [dbo].[OnlineExam] OFF
GO
INSERT [dbo].[People] ([ID], [Name], [Address], [Country], [Country_code]) VALUES (1, N'AG', N'jhgf', N'India', 12)
INSERT [dbo].[People] ([ID], [Name], [Address], [Country], [Country_code]) VALUES (2, N'BG', N'dfgh', N'USA', 23)
INSERT [dbo].[People] ([ID], [Name], [Address], [Country], [Country_code]) VALUES (2, N'BG', N'dfgh', N'Austria', 23)
INSERT [dbo].[People] ([ID], [Name], [Address], [Country], [Country_code]) VALUES (3, N'CG', N'oiuy', N'Alabama', 24)
INSERT [dbo].[People] ([ID], [Name], [Address], [Country], [Country_code]) VALUES (4, N'DG', N'fgh', N'Argentina', 25)
INSERT [dbo].[People] ([ID], [Name], [Address], [Country], [Country_code]) VALUES (5, N'EG', N'dfg', N'Brazil', 26)
INSERT [dbo].[People] ([ID], [Name], [Address], [Country], [Country_code]) VALUES (6, N'FG', N'dgh', N'Canada', 27)
INSERT [dbo].[People] ([ID], [Name], [Address], [Country], [Country_code]) VALUES (7, N'GG', N'fgh', N'Egypt', 28)
GO
INSERT [dbo].[Product] ([productId], [productName], [productPrice]) VALUES (101, N'CarI', 1000)
INSERT [dbo].[Product] ([productId], [productName], [productPrice]) VALUES (102, N'CarII', 2000)
INSERT [dbo].[Product] ([productId], [productName], [productPrice]) VALUES (103, N'CarIII', 3000)
INSERT [dbo].[Product] ([productId], [productName], [productPrice]) VALUES (104, N'CarIV', 4000)
INSERT [dbo].[Product] ([productId], [productName], [productPrice]) VALUES (105, N'CarV', 5000)
GO
INSERT [dbo].[ProductDescription] ([productId], [productColor]) VALUES (101, N'Red')
INSERT [dbo].[ProductDescription] ([productId], [productColor]) VALUES (102, N'Blue')
INSERT [dbo].[ProductDescription] ([productId], [productColor]) VALUES (103, N'White')
INSERT [dbo].[ProductDescription] ([productId], [productColor]) VALUES (104, N'Black')
INSERT [dbo].[ProductDescription] ([productId], [productColor]) VALUES (105, N'Grey')
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([Id], [First_name], [Last_name], [Roll_number], [Marks]) VALUES (1, N'A', N'B', 1, CAST(100.12 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[Student1] ON 

INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1, N'Aheli', N'Ghosh', 1, CAST(100.12 AS Decimal(10, 2)), CAST(N'1999-08-18T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (2, N'Sangbida', N'Roy', 2, CAST(90.13 AS Decimal(10, 2)), CAST(N'1998-01-01T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (3, N'Mayurakshi', N'Paul', 3, CAST(88.14 AS Decimal(10, 2)), CAST(N'1999-03-03T00:00:00.000' AS DateTime), 3)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (5, N'Thevan', N'Thavamani', 5, CAST(80.62 AS Decimal(10, 2)), CAST(N'1999-08-15T00:00:00.000' AS DateTime), 5)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (6, N'Kaushik', N'Biswas', 61, CAST(79.72 AS Decimal(10, 2)), CAST(N'1998-02-14T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (7, N'Umesh', N'Behera', 71, CAST(99.18 AS Decimal(10, 2)), CAST(N'1999-04-17T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1058, N'Soumyadip', N'Bhattacharjee', 156, CAST(100.00 AS Decimal(10, 2)), CAST(N'2022-01-13T02:50:00.000' AS DateTime), 5)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1062, N'Ally', N'Jain', 123, CAST(88.99 AS Decimal(10, 2)), CAST(N'1999-08-10T00:00:00.000' AS DateTime), 4)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1063, N'Random', N'Man', 234, CAST(88.99 AS Decimal(10, 2)), NULL, 5)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1064, N'Random ', N'Man2', 345, CAST(88.99 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1067, N'Roma', N'Dey', 1001, CAST(88.99 AS Decimal(10, 2)), NULL, 14)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1068, N'Man', N'Wol', 200, CAST(88.90 AS Decimal(10, 2)), NULL, 7)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1069, N'Bruno', N'Mars', 101, CAST(88.98 AS Decimal(10, 2)), NULL, 8)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1070, N'Lord', N'Vold', 122, CAST(100.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1072, N'Bruno', N'Mars', 199, CAST(99.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1073, N'Harley', N'Quinn', 7, CAST(100.00 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1074, N'Mary', N'Jane', 111, CAST(111.00 AS Decimal(10, 2)), CAST(N'1998-04-18T02:56:00.000' AS DateTime), 13)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1075, N'Man1', N'Surname1', 100, CAST(100.00 AS Decimal(10, 2)), CAST(N'2022-01-12T11:35:00.000' AS DateTime), 1)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1076, N'Harley', N'Jane', 1, CAST(88.98 AS Decimal(10, 2)), NULL, 1)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1077, N'Harley', N'Jane', 1, CAST(100.00 AS Decimal(10, 2)), CAST(N'1999-08-18T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1078, N'Harley', N'Surname1', 10, CAST(100.00 AS Decimal(10, 2)), CAST(N'1999-08-18T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1079, N'Harley', N'Surname1', 10, CAST(100.00 AS Decimal(10, 2)), CAST(N'1999-08-18T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1080, N'Mary', N'Quinn', 100, CAST(5410.00 AS Decimal(10, 2)), CAST(N'1999-08-18T00:00:00.000' AS DateTime), 2)
INSERT [dbo].[Student1] ([Id], [First_name], [Last_name], [Roll_number], [Marks], [Date_of_Birth], [BranchId]) VALUES (1081, N'Harley', N'Jane', 10, CAST(100.00 AS Decimal(10, 2)), CAST(N'1999-08-18T00:00:00.000' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Student1] OFF
GO
SET IDENTITY_INSERT [dbo].[Usertable] ON 

INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (2, N'Sangbida                                                                                            ', N'Roy                                                                                                 ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (3, N'Mayurakshi                                                                                          ', N'Paul                                                                                                ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (4, N'Mayurakshi                                                                                          ', N'Paul                                                                                                ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (5, N'Man5                                                                                                ', N'Surname 5                                                                                           ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (6, N'Mary                                                                                                ', N'Jane                                                                                                ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (7, N'Man1                                                                                                ', N'man2                                                                                                ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (8, N'Man 1                                                                                               ', N'Man 2                                                                                               ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (9, N'M                                                                                                   ', N'N                                                                                                   ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (11, N'A                                                                                                   ', N'B                                                                                                   ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (14, N'Man 1                                                                                               ', N'Man2                                                                                                ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (15, N'MAN                                                                                                 ', N'Man                                                                                                 ', N'188aheli@gmail.com', NULL, NULL)
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (16, N'Ran                                                                                                 ', N'dom                                                                                                 ', N'188aheli@gmail.com', NULL, N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (20, N'A                                                                                                   ', N'G                                                                                                   ', N'188aheli@gmail.com', NULL, N'00000000-0000-0000-0000-000000000000')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (28, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'381a99e3-75a5-46a6-95fe-3acc33a33707')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (29, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'c1de46dd-443f-4474-a5ad-930240f6c208')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (30, N'Man5                                                                                                ', N'Mna                                                                                                 ', N'188aheli@gmail.com', NULL, N'7783ebaf-ade9-4413-93bc-e69721ee637e')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (31, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'140de860-26ab-4b7c-9684-96ace1248f4c')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (32, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'a5a810d0-5c34-4fed-bd09-fd975127ec61')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (33, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'7047f01b-5aea-42db-9707-d9759c75bff1')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (34, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'c90cd0b6-6375-47a0-8de9-8dea8a945b52')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (35, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'55cbab9b-0d82-4f13-b828-c427a073abac')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (36, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'd06ed302-57ad-4df5-87ad-f3bfeac972df')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (37, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'c81f8327-0730-4386-87dc-1aa1a6c95042')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (38, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'662ddda7-3a6b-4726-b7b3-661f409d117d')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (39, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'509e9c05-1a97-41f6-8e5d-a5d9ebe56d67')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (40, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'37c5a785-ab03-4a23-825c-a7c7fd94386a')
INSERT [dbo].[Usertable] ([Userid], [FirstName], [LastName], [Email], [Marks], [Userguid]) VALUES (41, N'Aheli                                                                                               ', N'Ghosh                                                                                               ', N'188aheli@gmail.com', NULL, N'1a189d94-ef5d-4e73-8a81-1135e5c784cb')
SET IDENTITY_INSERT [dbo].[Usertable] OFF
GO
ALTER TABLE [dbo].[ChosenAnswer]  WITH CHECK ADD FOREIGN KEY([Userid])
REFERENCES [dbo].[Usertable] ([Userid])
GO
ALTER TABLE [dbo].[ChosenAnswer]  WITH CHECK ADD FOREIGN KEY([Qid])
REFERENCES [dbo].[OnlineExam] ([Qid])
GO
ALTER TABLE [dbo].[Student1]  WITH CHECK ADD FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branch] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[CreateStudent]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--stored procedure--
create procedure [dbo].[CreateStudent](
@firstname nvarchar (50),
@lastname varchar (50),
@rollno int,
@marks decimal(18,2))
as
begin

insert Student1(First_name,Last_name,Roll_number,Marks)
values(@firstname,@lastname,@rollno,@marks);
select SCOPE_IDENTITY() Id;
end

Select * from Student1;
GO
/****** Object:  StoredProcedure [dbo].[GetName]    Script Date: 10-02-2022 19:09:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetName] (@name varchar(50))
AS
BEGIN 
	Select * from  Product Where ProductName=@name;
	END
exec GetName @name='CarI';
GO
USE [master]
GO
ALTER DATABASE [1st Database] SET  READ_WRITE 
GO
