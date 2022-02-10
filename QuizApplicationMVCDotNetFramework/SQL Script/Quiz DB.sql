USE [master]
GO
/****** Object:  Database [1st Database]    Script Date: 10-02-2022 18:01:21 ******/
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
/****** Object:  UserDefinedFunction [dbo].[Fn_GetEmail]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Student1]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  UserDefinedFunction [dbo].[Fn_GetStudent]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Branch]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[ChosenAnswer]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Duplicate]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Entry]    Script Date: 10-02-2022 18:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entry](
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entry2]    Script Date: 10-02-2022 18:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entry2](
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entry3]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[OnlineExam]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[People]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Product]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[ProductDescription]    Script Date: 10-02-2022 18:01:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDescription](
	[productId] [int] NULL,
	[productColor] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Table_1]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Table2]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Table3]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  Table [dbo].[Usertable]    Script Date: 10-02-2022 18:01:22 ******/
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
ALTER TABLE [dbo].[ChosenAnswer]  WITH CHECK ADD FOREIGN KEY([Userid])
REFERENCES [dbo].[Usertable] ([Userid])
GO
ALTER TABLE [dbo].[ChosenAnswer]  WITH CHECK ADD FOREIGN KEY([Qid])
REFERENCES [dbo].[OnlineExam] ([Qid])
GO
ALTER TABLE [dbo].[Student1]  WITH CHECK ADD FOREIGN KEY([BranchId])
REFERENCES [dbo].[Branch] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[CreateStudent]    Script Date: 10-02-2022 18:01:22 ******/
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
/****** Object:  StoredProcedure [dbo].[GetName]    Script Date: 10-02-2022 18:01:22 ******/
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
