USE [master]
GO
/****** Object:  Database [ProjectA]    Script Date: 5/3/2019 8:49:05 PM ******/
CREATE DATABASE [ProjectA]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjectA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProjectA.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjectA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ProjectA_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjectA] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjectA].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjectA] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjectA] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjectA] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjectA] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjectA] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjectA] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjectA] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjectA] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjectA] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjectA] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjectA] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjectA] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjectA] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjectA] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjectA] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjectA] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjectA] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjectA] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjectA] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjectA] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjectA] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjectA] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjectA] SET RECOVERY FULL 
GO
ALTER DATABASE [ProjectA] SET  MULTI_USER 
GO
ALTER DATABASE [ProjectA] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjectA] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjectA] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjectA] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProjectA] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProjectA', N'ON'
GO
USE [ProjectA]
GO
/****** Object:  Table [dbo].[Advisor]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Advisor](
	[Id] [int] NOT NULL,
	[Designation] [int] NOT NULL,
	[Salary] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Evaluation]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Evaluation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[TotalMarks] [int] NOT NULL,
	[TotalWeightage] [int] NOT NULL,
 CONSTRAINT [PK_Evaluation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Group]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Created_On] [date] NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupEvaluation]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupEvaluation](
	[GroupId] [int] NOT NULL,
	[EvaluationId] [int] NOT NULL,
	[ObtainedMarks] [int] NOT NULL,
	[EvaluationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupEvaluation] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[EvaluationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupProject]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupProject](
	[ProjectId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupProject] PRIMARY KEY CLUSTERED 
(
	[ProjectId] ASC,
	[GroupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupStudent]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupStudent](
	[GroupId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_GroupStudent] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC,
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lookup]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lookup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Value] [varchar](100) NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Lookup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Person]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](100) NULL,
	[Contact] [varchar](20) NULL,
	[Email] [varchar](30) NOT NULL,
	[DateOfBirth] [datetime] NULL,
	[Gender] [int] NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Project]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](max) NULL,
	[Title] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ProjectAdvisor]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectAdvisor](
	[AdvisorId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[AdvisorRole] [int] NOT NULL,
	[AssignmentDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ProjectAdvisor] PRIMARY KEY CLUSTERED 
(
	[AdvisorId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[Id] [int] NOT NULL,
	[RegistrationNo] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[Rop]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Rop] as
Select Email from Person
GO
/****** Object:  View [dbo].[Ropi]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Ropi] as
Select Email from Person
where Gender = 2
GO
/****** Object:  View [dbo].[Ropii]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Ropii] as
Select Email from Person join Student on Student.Id = Person.Id
where Gender = 2
GO
/****** Object:  View [dbo].[Ropiii]    Script Date: 5/3/2019 8:49:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create View [dbo].[Ropiii] as
Select Email,Gender from Person join Student on Student.Id = Person.Id
where Gender = 2
GO
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (2, 1, CAST(789 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (10, 9, CAST(98765 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (23, 9, CAST(7 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (29, 7, CAST(890 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (1071, 8, CAST(98776 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (1072, 10, CAST(8999 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3078, 9, CAST(990 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3084, 10, CAST(990 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3086, 10, CAST(9099 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3090, 9, CAST(99 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3096, 10, CAST(9 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3101, 9, CAST(9999 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3103, 8, CAST(908 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3108, 7, CAST(908 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3122, 10, CAST(90000 AS Decimal(18, 0)))
INSERT [dbo].[Advisor] ([Id], [Designation], [Salary]) VALUES (3123, 10, CAST(890000 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Evaluation] ON 

INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1, N'opo', 9, 6)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (2, N'opo', 9, 6)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (4, N'OPOssmm', 89, 70)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1005, N'pppp', 90, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1006, N'ppp', 89, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1007, N'ppp', 90, 90)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1008, N'pp', 90, 890)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1009, N'pp', 90, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1010, N'popj', 90, 90)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1011, N'ppp', 90, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1012, N'ppp', 90, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1013, N'ppp', 90, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1014, N'ppp', 90, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1015, N'pp', 90, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1016, N'plk', 67, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1017, N'plk', 67, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1018, N'plk', 67, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1019, N'plk', 67, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1020, N'plko', 67, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1021, N'plko', 670, 89)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1022, N'p', 90, 78)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1023, N'PLKIO', 10, 90)
INSERT [dbo].[Evaluation] ([Id], [Name], [TotalMarks], [TotalWeightage]) VALUES (1024, N'PLKop', 10, 90)
SET IDENTITY_INSERT [dbo].[Evaluation] OFF
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (2, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (4, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (5, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (6, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (7, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (8, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (9, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (10, CAST(N'2019-03-12' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1002, CAST(N'2019-03-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1003, CAST(N'2019-03-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1004, CAST(N'2019-03-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1005, CAST(N'2019-03-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1006, CAST(N'2019-03-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1007, CAST(N'2019-03-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1008, CAST(N'2019-03-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1009, CAST(N'2019-03-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1010, CAST(N'2019-03-13' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1011, CAST(N'2019-03-14' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1012, CAST(N'2019-03-14' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1013, CAST(N'2019-03-14' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1014, CAST(N'2019-03-14' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1015, CAST(N'2019-03-14' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1016, CAST(N'2019-03-14' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1017, CAST(N'2019-03-14' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1018, CAST(N'2019-03-15' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1020, CAST(N'2019-03-15' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1022, CAST(N'2019-03-15' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (1023, CAST(N'2019-03-15' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (2011, CAST(N'2019-03-22' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (2012, CAST(N'2019-03-22' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (2013, CAST(N'2019-03-22' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (2014, CAST(N'2019-03-22' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (2015, CAST(N'2019-03-22' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (2016, CAST(N'2019-03-22' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3011, CAST(N'2019-03-25' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3012, CAST(N'2019-03-25' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3013, CAST(N'2019-03-26' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3014, CAST(N'2019-03-26' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3015, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3016, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3017, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3018, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3019, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3020, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3021, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3022, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3023, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3024, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3025, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3026, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3027, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3028, CAST(N'2019-03-27' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3029, CAST(N'2019-03-30' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3030, CAST(N'2019-03-30' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3031, CAST(N'2019-03-31' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3033, CAST(N'2019-04-26' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3034, CAST(N'2019-04-26' AS Date))
INSERT [dbo].[Group] ([Id], [Created_On]) VALUES (3035, CAST(N'2019-04-26' AS Date))
SET IDENTITY_INSERT [dbo].[Group] OFF
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (10, 1008, 89, CAST(N'2019-03-31 15:42:17.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (10, 1009, 89, CAST(N'2019-03-31 15:42:21.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1002, 1006, 89, CAST(N'2019-03-30 18:26:56.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1005, 4, 89, CAST(N'2019-03-15 10:06:54.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1010, 1011, 89, CAST(N'2019-03-31 18:18:14.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1011, 1010, 90, CAST(N'2019-03-31 15:56:49.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1014, 1007, 90, CAST(N'2019-03-31 14:50:22.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1017, 1015, 90, CAST(N'2019-04-26 06:45:35.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1020, 1005, 89, CAST(N'2019-03-29 19:43:29.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1023, 1016, 56, CAST(N'2019-04-26 06:52:21.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1023, 1023, 9, CAST(N'2019-04-26 10:31:39.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (1023, 1024, 9, CAST(N'2019-04-26 10:31:53.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (2013, 1012, 89, CAST(N'2019-03-31 18:18:22.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (3017, 1021, 56, CAST(N'2019-04-26 06:52:53.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (3024, 1019, 56, CAST(N'2019-04-26 06:52:39.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (3024, 1020, 56, CAST(N'2019-04-26 06:52:43.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (3029, 1018, 56, CAST(N'2019-04-26 06:52:35.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (3031, 1013, 89, CAST(N'2019-03-31 18:18:26.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (3033, 1017, 56, CAST(N'2019-04-26 06:52:28.000' AS DateTime))
INSERT [dbo].[GroupEvaluation] ([GroupId], [EvaluationId], [ObtainedMarks], [EvaluationDate]) VALUES (3034, 1022, 90, CAST(N'2019-04-26 09:54:44.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (8, 1020, CAST(N'2019-03-15 10:35:21.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (11, 1022, CAST(N'2019-03-15 16:47:09.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (12, 1023, CAST(N'2019-03-22 21:35:15.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (13, 1023, CAST(N'2019-03-15 20:24:03.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (14, 2015, CAST(N'2019-03-22 22:01:17.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (1006, 2016, CAST(N'2019-03-25 09:33:46.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2006, 3012, CAST(N'2019-03-26 07:04:18.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2007, 3013, CAST(N'2019-03-26 07:04:35.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2008, 3014, CAST(N'2019-03-27 03:15:26.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2009, 3024, CAST(N'2019-03-27 03:35:21.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2010, 3025, CAST(N'2019-03-27 03:36:13.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2011, 3019, CAST(N'2019-03-27 03:28:36.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2012, 3026, CAST(N'2019-03-27 03:36:40.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2016, 3035, CAST(N'2019-04-26 09:53:52.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2017, 3027, CAST(N'2019-03-27 04:28:16.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2018, 3028, CAST(N'2019-03-27 16:02:00.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2019, 3029, CAST(N'2019-03-30 10:22:54.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2019, 3031, CAST(N'2019-03-31 16:19:42.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2022, 3030, CAST(N'2019-03-30 17:57:30.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2028, 3033, CAST(N'2019-04-26 06:44:18.000' AS DateTime))
INSERT [dbo].[GroupProject] ([ProjectId], [GroupId], [AssignmentDate]) VALUES (2030, 3034, CAST(N'2019-04-26 09:48:10.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (1023, 1067, 4, CAST(N'2019-03-22 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (1023, 3089, 4, CAST(N'2019-03-31 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (2015, 1075, 4, CAST(N'2019-03-22 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (2016, 2053, 4, CAST(N'2019-03-25 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (2016, 2054, 4, CAST(N'2019-03-25 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (2016, 3069, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (2016, 3070, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3012, 2056, 4, CAST(N'2019-03-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3012, 3081, 4, CAST(N'2019-03-31 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3012, 3088, 4, CAST(N'2019-03-31 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3013, 2057, 4, CAST(N'2019-03-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3014, 3053, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3014, 3054, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3014, 3055, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3014, 3056, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3014, 3057, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3019, 3058, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3019, 3059, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3019, 3060, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3019, 3061, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3024, 3062, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3024, 3063, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3025, 3064, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3026, 3065, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3026, 3066, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3028, 3071, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3028, 3072, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3028, 3073, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3028, 3074, 4, CAST(N'2019-03-27 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3029, 3075, 4, CAST(N'2019-03-30 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3029, 3076, 4, CAST(N'2019-03-30 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3029, 3077, 4, CAST(N'2019-03-30 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3030, 3079, 4, CAST(N'2019-03-30 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3030, 3082, 4, CAST(N'2019-03-30 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3031, 3087, 4, CAST(N'2019-03-31 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3033, 1052, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3033, 1061, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3033, 1065, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3033, 3095, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3034, 1069, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3034, 1070, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3034, 3097, 3, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3035, 3098, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3035, 3099, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3035, 3100, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
INSERT [dbo].[GroupStudent] ([GroupId], [StudentId], [Status], [AssignmentDate]) VALUES (3035, 3102, 4, CAST(N'2019-04-26 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Lookup] ON 

INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (1, N'Male', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (2, N'Female', N'GENDER')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (3, N'Active', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (4, N'InActive', N'STATUS')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (6, N'Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (7, N'Associate Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (8, N'Assisstant Professor', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (9, N'Lecturer', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (10, N'Industry Professional', N'DESIGNATION')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (11, N'Main Advisor', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (12, N'Co-Advisror', N'ADVISOR_ROLE')
INSERT [dbo].[Lookup] ([Id], [Value], [Category]) VALUES (14, N'Industry Advisor', N'ADVISOR_ROLE')
SET IDENTITY_INSERT [dbo].[Lookup] OFF
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1038, N'Z', N'A', N'8', N'hj', CAST(N'2019-03-28 13:23:35.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1039, N'Z', N'A', N'8', N'hj', CAST(N'2019-03-28 13:23:35.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1040, N'JKL', N'POI', N'87654', N'GHJKK', CAST(N'2019-03-12 20:45:54.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1041, N'FGH', N'Z', N'99999', N'HHHH', CAST(N'2019-02-24 20:47:16.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1042, N'FGH', N'Z', N'99999', N'HHHH', CAST(N'2019-02-24 20:47:16.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1052, N'P', N'OML', N'99999999999', N'u@gmail.com', CAST(N'2019-04-26 09:30:53.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1055, N'Km', N'L', N'88888888888', N'jk@gmail.com', CAST(N'2019-03-28 19:34:06.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1057, N'km', N'Lop', N'88888888888', N'HJK@GMAIL.com', CAST(N'2019-03-30 16:49:32.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1058, N'Zuhha', N'Zuhha', N'88888888888', N'jkl@gmai;.com', CAST(N'2019-03-31 08:38:43.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1059, N'hj', N'lk', N'99999999999', N'kkl@.com', CAST(N'2019-03-26 08:41:37.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1060, N'jk', N'lm', N'99999999999', N'kl@gmail.com', CAST(N'2019-03-31 08:42:32.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1061, N'kjh', N'olk', N'77777777777', N'uio@gmail.com', CAST(N'2019-03-24 08:46:36.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1063, N'Zuhhaa', N'Azhar', N'99999999999', N'g@gmail.com', CAST(N'2019-03-31 11:41:10.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1064, N'Z', N'A', N'99999999999', N'op@gmail.com', CAST(N'2019-03-12 13:14:49.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1065, N'U', N'l', N'99999999999', N'j@gmail.com', CAST(N'2019-03-25 14:17:19.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1066, N'Zuhha', N'GHJ', N'99999999999', N'90op@gmail.com', CAST(N'2019-03-25 14:20:17.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1067, N'C', N'V', N'99999999999', N'h@gmail.com', CAST(N'2019-03-27 14:25:40.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1068, N'Z', N'xc', N'88888888888', N'hjgb@gmail.com', CAST(N'2019-04-01 14:27:33.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1069, N'G', N'JKL', N'99999999998', N'H@NJUI.com', CAST(N'2019-03-20 14:29:16.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1070, N'POPO', N'KL', N'99999999999', N'k@gmail.com', CAST(N'2019-03-18 17:14:19.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1071, N'opo', N'klj', N'99999999999', N'km@gmail.com', CAST(N'2019-04-26 06:08:44.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1072, N'Z', N'H', N'89765434567', N'j@g.com', CAST(N'2019-04-06 17:47:11.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (1075, N'Zuhhaa', N'pops', N'98765434567', N'h@.com', CAST(N'2019-03-23 11:35:13.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (2053, N'JJJJ', N'PPP', N'90876545678', N'ju@gmail.com', CAST(N'2019-02-04 21:57:25.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (2054, N'JJJJ', N'PPPLM', N'90876545678', N'j@.com', CAST(N'2019-03-31 21:57:25.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (2055, N'JJJJ', N'PPPLMOP', N'90876545678', N'j@.com', CAST(N'2019-03-31 21:57:25.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (2056, N'sEERAT', N'fatima', N'03089765434', N'h@gmail.com', CAST(N'2019-03-31 11:33:49.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (2057, N'sEERAT', N'fatimaa', N'03089765434', N'h@gmail.com', CAST(N'2019-03-31 11:33:49.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3053, N'PLMK', N'K', N'09876543234', N'K@gmail.com', CAST(N'2019-03-31 07:00:44.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3054, N'PLMK', N'Kl', N'09876543234', N'K@gmail.com', CAST(N'2019-03-31 07:00:44.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3055, N'mnb', N'klj', N'09876543234', N'j@gmail.com', CAST(N'2019-03-31 03:12:40.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3056, N'mnb', N'kljl', N'09876543234', N'j@gmail.com', CAST(N'2019-03-31 03:12:40.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3057, N'mnb', N'kljlo', N'09876543234', N'j@gmail.com', CAST(N'2019-03-31 03:12:40.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3058, N'mnjh', N'fgty', N'98765434567', N'h@gmail.com', CAST(N'2019-03-31 03:14:34.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3059, N'olk', N'hgfr', N'87654321234', N'b@gmail.com', CAST(N'2019-03-31 03:17:12.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3060, N'olk', N'hgfrp', N'87654321234', N'b@gmail.com', CAST(N'2019-03-31 03:17:12.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3061, N'olk', N'hgf', N'87654321234', N'b@gmail.com', CAST(N'2019-03-31 03:17:12.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3062, N'olk', N'hgfjnbv', N'87654321234', N'b@gmail.com', CAST(N'2019-03-31 03:17:12.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3063, N'olkp', N'hgfjnbv', N'87654321234', N'b@gmail.com', CAST(N'2019-03-31 03:17:12.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3064, N'olkpop', N'hgfjnbv', N'87654321234', N'b@gmail.com', CAST(N'2019-03-31 03:17:12.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3065, N'LMKJ', N'HGHTY', N'98765678987', N'H@gmail.com', CAST(N'2019-01-27 03:25:02.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3066, N'LMKJ', N'HGHTY', N'98765678980', N'H@gmail.com', CAST(N'2019-01-27 03:25:02.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3069, N'LKJ', N'HHTY', N'08765678980', N'H@gmail.com', CAST(N'2019-01-27 03:25:02.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3070, N'mmm', N'nnnnnnn', N'98765434567', N'g@gmail.com', CAST(N'2019-02-17 04:31:17.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3071, N'mmm', N'nnnnn', N'98765434567', N'g@gmail.com', CAST(N'2019-02-17 04:31:17.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3072, N'mmm', N'nnnn', N'98765434567', N'g@gmail.com', CAST(N'2019-02-17 04:31:17.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3073, N'mm', N'nnnn', N'98765434567', N'g@gmail.com', CAST(N'2019-02-17 04:31:17.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3074, N'mm', N'nnnn', N'98760434567', N'g@gmail.com', CAST(N'2019-02-17 04:31:17.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3075, N'popk', N'plkj', N'98765678987', N'h@gmail.com', CAST(N'2019-03-18 15:59:48.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3076, N'popk', N'plkjki', N'98765678987', N'h@gmail.com', CAST(N'2019-03-18 15:59:48.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3077, N'pk', N'plkjki', N'98765678987', N'h@gmail.com', CAST(N'2019-03-18 15:59:48.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3078, N'pk', N'plkjk', N'98765678987', N'h@gmail.com', CAST(N'2019-03-18 15:59:48.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3079, N'p', N'o', N'09876545678', N'h@h.com', CAST(N'2019-03-10 16:43:35.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3080, N'p', N'o', N'09876543234', N'h@gmail.com', CAST(N'2019-02-24 16:50:45.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3081, N'p', N'p', N'09876545678', N'h@gmail.com', CAST(N'2019-02-24 16:56:03.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3082, N'p', N'p', N'89789878987', N'h@.com', CAST(N'2019-02-24 16:58:56.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3083, N'p', N'pp', N'89789878987', N'h@.com', CAST(N'2019-02-24 16:58:56.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3084, N'p', N'plk', N'98765678909', N'h@h.com', CAST(N'2019-03-03 17:01:52.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3085, N'p', N'po', N'90897898789', N'j@gmail.com', CAST(N'2019-02-24 17:06:25.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3086, N'p', N'pop', N'09876789786', N'h@.com', CAST(N'2019-01-27 17:14:42.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3087, N'p', N'popo', N'09876789786', N'h@.com', CAST(N'2019-01-27 17:14:42.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3088, N'p', N'plk', N'09876787675', N'o@gmail.com', CAST(N'2019-02-24 17:18:47.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3089, N'p', N'plko', N'09876787675', N'o@gmail.com', CAST(N'2019-02-24 17:18:47.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3090, N'p', N'pop', N'89786787678', N'h@.com', CAST(N'2019-02-24 17:24:30.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3091, N'p', N'popp', N'89786787678', N'h@.com', CAST(N'2019-02-24 17:24:30.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3092, N'p', N'opoo', N'98765678769', N'i@gmail.com', CAST(N'2019-02-24 18:23:05.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3093, N'p', N'opoop', N'98765678769', N'i@gmail.com', CAST(N'2019-02-24 18:23:05.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3094, N'p', N'pop', N'98789867543', N'j@gmail.com', CAST(N'2019-01-20 18:25:12.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3095, N'p', N'popk', N'98789867543', N'j@gmail.com', CAST(N'2019-01-20 18:25:12.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3096, N'p', N'pop', N'98765434567', N'k@gmail.com', CAST(N'2019-02-24 18:27:50.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3097, N'p', N'popo', N'98765434567', N'k@gmail.com', CAST(N'2019-02-24 18:27:50.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3098, N'p', N'po', N'98765434567', N'k@gmail.com', CAST(N'2019-02-24 18:27:50.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3099, N'Zuhha', N'Azhar', N'08767867547', N'u@h.com', CAST(N'2019-03-11 10:19:41.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3100, N'Zuhha', N'Azharo', N'08767867547', N'u@h.com', CAST(N'2019-03-11 10:19:41.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3101, N'iio', N'lll', N'09876545678', N'k@h.com', CAST(N'2019-02-24 15:36:14.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3102, N'llll', N'llll', N'09876567898', N'l2@.com', CAST(N'2019-03-19 15:37:58.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3103, N'Zuhhap', N'Azhar', N'09876789098', N'h@.com', CAST(N'2019-04-05 08:32:18.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3104, N'Zuhha', N'Azharp', N'09876789098', N'h@.com', CAST(N'2019-02-24 08:30:28.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3105, N'pop', N'pop', N'09876756453', N'k@.com', CAST(N'2019-02-25 10:32:56.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3106, N'opog', N'pop', N'09878978675', N'kkk@.com', CAST(N'2019-02-27 10:33:55.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3107, N'pops', N'popp', N'09897867564', N'o@.com', CAST(N'2019-03-12 10:38:13.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3108, N'pops', N'popps', N'09897867564', N'o@.com', CAST(N'2019-03-12 10:38:13.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3109, N'Z', N'A', N'09876789876', N'j@gmail.com', CAST(N'2019-02-24 15:38:38.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3110, N'ppp', N'ooo', N'09876789876', N'i@gmail.com', CAST(N'2019-03-09 16:32:55.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3111, N'iii', N'oop', N'09876789876', N'i@.com', CAST(N'2019-04-06 16:34:53.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3112, N'pp', N'oo', N'09876789876', N'k@.com', CAST(N'2019-03-31 16:37:17.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3113, N'C', N'P', N'09897867564', N'k@.com', CAST(N'2019-03-04 18:15:43.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3114, N'kl', N'kl', N'j@gmail.com', N'j@gmail.com', CAST(N'2019-04-22 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3115, N'Zuhha', N'Azhar', N'09876789876', N'f@gmail.com', CAST(N'2019-04-25 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3116, N'Z', N'A', N'09876756457', N'h@gmail.com', CAST(N'2019-04-07 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3117, N'D', N'G', N'09876545675', N'h@gmail.com', CAST(N'2019-04-07 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3118, N'Z', N'W', N'09876756453', N'G@GMAIL.COM', CAST(N'2019-04-28 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3119, N'Zuhha', N'Azhar', N'09879878675', N'h@gmail.com', CAST(N'2019-03-31 18:02:25.000' AS DateTime), 2)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3120, N'Po', N'PLK', N'09897867564', N'h@gmail.com', CAST(N'2019-03-31 09:26:11.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3121, N'Po', N'PLK', N'09897867560', N'h@gmail.com', CAST(N'2019-03-31 09:26:11.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3122, N'Po', N'PLKo', N'09897867560', N'h@gmail.com', CAST(N'2019-03-31 09:26:11.000' AS DateTime), 1)
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [Contact], [Email], [DateOfBirth], [Gender]) VALUES (3123, N'Zuhha', N'Sherazi', N'09876756453', N'h@gmail.com', CAST(N'2019-03-31 09:44:54.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Person] OFF
SET IDENTITY_INSERT [dbo].[Project] ON 

INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (8, N'kkkS', N'Thankss')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (10, N'pops', N'oops')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (11, N'o', N'o')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (12, N'olkjh', N'oplk')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (13, N'PLKJUI', N'OOOOOPL')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (14, N'KLM', N'POPKM')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (1006, N'M', N'OOPLKJ')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2006, N'b', N'mhnjb')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2007, N'p', N'mhnjbm')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2008, N'kjh', N'klmjh')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2009, N'LMKKJJ', N'POPGHJ')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2010, N'LMKKJJ', N'POPGHU')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2011, N'LMKKJJ', N'LLOO')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2012, N'LMKKJJ', N'LLKM')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2013, N'kmnh', N'opoo')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2014, N'kmnh', N'opoi')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2015, N'kmnh', N'lpoi')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2016, N'kmnh', N'lmoi')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2017, N'l', N'p')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2018, N'm', N'lkj')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2019, N'oo', N'oo')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2020, N'oo', N'oo')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2021, N'oo', N'oo')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2022, N'o', N'oop')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2023, N'MMMM', N'LMS')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2024, N'LLL', N'POOO')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2025, N'OO', N'PP')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2026, N'olk', N'ppo')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2027, N'PLKM', N'TYU')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2028, N'PLK', N'Pakistan')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2029, N'KLMN', N'POPS')
INSERT [dbo].[Project] ([Id], [Description], [Title]) VALUES (2030, N'IOP', N'ABC')
SET IDENTITY_INSERT [dbo].[Project] OFF
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (2, 12, 12, CAST(N'2019-03-25 09:46:01.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (2, 2011, 11, CAST(N'2019-03-28 14:26:22.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (2, 2016, 12, CAST(N'2019-04-26 09:32:56.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (2, 2019, 12, CAST(N'2019-04-26 09:43:34.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (2, 2023, 14, CAST(N'2019-02-10 15:23:12.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (2, 2029, 11, CAST(N'2019-04-26 09:32:33.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (23, 2023, 14, CAST(N'2019-02-24 15:25:26.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (29, 2008, 12, CAST(N'2019-03-28 13:04:16.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (1071, 13, 12, CAST(N'2019-03-23 11:35:39.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (1072, 2018, 11, CAST(N'2019-04-26 09:38:33.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (1072, 2028, 12, CAST(N'2019-04-26 09:36:54.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (3084, 2022, 12, CAST(N'2019-04-26 06:38:52.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (3084, 2023, 12, CAST(N'2019-04-26 10:33:29.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (3086, 2013, 11, CAST(N'2019-03-03 06:38:56.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (3090, 2018, 12, CAST(N'2019-04-07 06:26:18.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (3101, 2019, 11, CAST(N'2019-04-26 06:20:44.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (3101, 2029, 14, CAST(N'2019-04-26 09:34:46.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (3103, 2023, 11, CAST(N'2019-04-26 10:33:10.000' AS DateTime))
INSERT [dbo].[ProjectAdvisor] ([AdvisorId], [ProjectId], [AdvisorRole], [AssignmentDate]) VALUES (3123, 2030, 11, CAST(N'2019-04-26 09:47:50.000' AS DateTime))
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (1052, N'2016-CS-456')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (1061, N'90')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (1065, N'908h')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (1067, N'90kmnh')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (1069, N'o')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (1070, N'pl')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (1075, N'2016-XG-675')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (2053, N'2016-XG-678')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (2054, N'2013-XG-678')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (2056, N'2016-CS-786')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (2057, N'2016-CS-361')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3053, N'2016-CS-360')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3054, N'2016-fg-987')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3055, N'2016-fg-997')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3056, N'2016-fg-990')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3057, N'9876-uj-678')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3058, N'9876-bg-765')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3059, N'9876-bg-777')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3060, N'9876-bg-779')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3061, N'9876-bg-756')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3062, N'9876-bg-596')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3063, N'9876-ig-596')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3064, N'9876-JK-098')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3065, N'9876-JK-998')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3066, N'9876-oK-998')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3069, N'8976-hj-876')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3070, N'8996-hj-876')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3071, N'9996-hj-876')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3072, N'9996-ij-876')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3073, N'9990-ij-876')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3074, N'9867-hj-765')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3075, N'9887-hj-765')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3076, N'0887-hj-765')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3077, N'0888-hj-765')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3079, N'8978-hj-987')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3081, N'8978-ui-654')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3082, N'8978-ui-658')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3087, N'6787-ui-987')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3088, N'6787-ui-985')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3089, N'8978-iu-985')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3095, N'9090-ui-876')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3097, N'2016-CS-368')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3098, N'7898-op-098')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3099, N'7898-op-097')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3100, N'9098-ui-876')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3102, N'6787-oi-098')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3105, N'9088-kj-987')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3107, N'0978-op-098')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3109, N'8909-ui-098')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3110, N'9087-po-098')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3111, N'8909-op-987')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3112, N'0989-ui-098')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3113, N'0987-op-987')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3119, N'2016-CS-876')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3120, N'7867-yu-098')
INSERT [dbo].[Student] ([Id], [RegistrationNo]) VALUES (3121, N'7867-yu-987')
ALTER TABLE [dbo].[Advisor]  WITH CHECK ADD  CONSTRAINT [FK_Advisor_Lookup] FOREIGN KEY([Designation])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Advisor] CHECK CONSTRAINT [FK_Advisor_Lookup]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Evaluation] FOREIGN KEY([EvaluationId])
REFERENCES [dbo].[Evaluation] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Evaluation]
GO
ALTER TABLE [dbo].[GroupEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvaluation_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupEvaluation] CHECK CONSTRAINT [FK_GroupEvaluation_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Group]
GO
ALTER TABLE [dbo].[GroupProject]  WITH CHECK ADD  CONSTRAINT [FK_GroupProject_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[GroupProject] CHECK CONSTRAINT [FK_GroupProject_Project]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_GroupStudents_Lookup] FOREIGN KEY([Status])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_GroupStudents_Lookup]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Group] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Group]
GO
ALTER TABLE [dbo].[GroupStudent]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStudents_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO
ALTER TABLE [dbo].[GroupStudent] CHECK CONSTRAINT [FK_ProjectStudents_Student]
GO
ALTER TABLE [dbo].[Person]  WITH CHECK ADD  CONSTRAINT [FK_Person_Lookup] FOREIGN KEY([Gender])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[Person] CHECK CONSTRAINT [FK_Person_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Lookup] FOREIGN KEY([AdvisorRole])
REFERENCES [dbo].[Lookup] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Lookup]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectAdvisor_Project] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Project] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectAdvisor_Project]
GO
ALTER TABLE [dbo].[ProjectAdvisor]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTeachers_Teacher] FOREIGN KEY([AdvisorId])
REFERENCES [dbo].[Advisor] ([Id])
GO
ALTER TABLE [dbo].[ProjectAdvisor] CHECK CONSTRAINT [FK_ProjectTeachers_Teacher]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Person] FOREIGN KEY([Id])
REFERENCES [dbo].[Person] ([Id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Person]
GO
USE [master]
GO
ALTER DATABASE [ProjectA] SET  READ_WRITE 
GO
