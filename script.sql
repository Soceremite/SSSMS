USE [master]
GO
/****** Object:  Database [SSSMS]    Script Date: 2021/5/25 15:35:22 ******/
CREATE DATABASE [SSSMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SSSMS', FILENAME = N'D:\mysql\SSSMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SSSMS_log', FILENAME = N'D:\mysql\SSSMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 COLLATE Chinese_PRC_90_CI_AS
GO
ALTER DATABASE [SSSMS] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SSSMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SSSMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SSSMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SSSMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SSSMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SSSMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SSSMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SSSMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SSSMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SSSMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SSSMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SSSMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SSSMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SSSMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SSSMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SSSMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SSSMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SSSMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SSSMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SSSMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SSSMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SSSMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SSSMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SSSMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SSSMS] SET  MULTI_USER 
GO
ALTER DATABASE [SSSMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SSSMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SSSMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SSSMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SSSMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SSSMS] SET QUERY_STORE = OFF
GO
USE [SSSMS]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SSSMS]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 2021/5/25 15:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[create_date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Option]    Script Date: 2021/5/25 15:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Option](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
	[option_name] [varchar](max) COLLATE Chinese_PRC_90_CI_AS NOT NULL,
	[option_sort] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 2021/5/25 15:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NOT NULL,
	[question_type] [int] NOT NULL,
	[question_name] [varchar](max) COLLATE Chinese_PRC_90_CI_AS NOT NULL,
	[question_sort] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_Type]    Script Date: 2021/5/25 15:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Type](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) COLLATE Chinese_PRC_90_CI_AS NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sub_Answer]    Script Date: 2021/5/25 15:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sub_Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[answer_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
	[content] [varchar](max) COLLATE Chinese_PRC_90_CI_AS NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Survey]    Script Date: 2021/5/25 15:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Survey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](50) COLLATE Chinese_PRC_90_CI_AS NOT NULL,
	[description] [varchar](max) COLLATE Chinese_PRC_90_CI_AS NULL,
	[author_id] [int] NOT NULL,
	[create_date] [datetime] NOT NULL,
	[start_date] [datetime] NOT NULL,
	[end_date] [datetime] NOT NULL,
	[status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temp_Option]    Script Date: 2021/5/25 15:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Option](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
	[option_name] [varchar](max) COLLATE Chinese_PRC_90_CI_AS NOT NULL,
	[option_sort] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temp_Question]    Script Date: 2021/5/25 15:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temp_Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[survey_id] [int] NOT NULL,
	[question_type] [int] NOT NULL,
	[question_name] [varchar](max) COLLATE Chinese_PRC_90_CI_AS NOT NULL,
	[question_sort] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2021/5/25 15:35:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](20) COLLATE Chinese_PRC_90_CI_AS NOT NULL,
	[passwd] [varchar](20) COLLATE Chinese_PRC_90_CI_AS NOT NULL,
	[type] [int] NOT NULL,
	[stuid] [varchar](20) COLLATE Chinese_PRC_90_CI_AS NOT NULL,
	[img] [varchar](50) COLLATE Chinese_PRC_90_CI_AS NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([Id], [survey_id], [user_id], [create_date]) VALUES (4, 4010, 3, CAST(N'2021-05-25' AS Date))
INSERT [dbo].[Answer] ([Id], [survey_id], [user_id], [create_date]) VALUES (7, 2006, 3, CAST(N'2021-05-25' AS Date))
INSERT [dbo].[Answer] ([Id], [survey_id], [user_id], [create_date]) VALUES (8, 2005, 3, CAST(N'2021-05-25' AS Date))
INSERT [dbo].[Answer] ([Id], [survey_id], [user_id], [create_date]) VALUES (9, 5010, 3, CAST(N'2021-05-25' AS Date))
SET IDENTITY_INSERT [dbo].[Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Option] ON 

INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (1, 2005, 1, N'1-1A单选题', 1)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2, 2005, 1, N'1-1B单选题', 2)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (3, 2005, 1, N'1单选题C', 3)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (4, 2005, 2, N'2.A多选题', 1)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (5, 2005, 2, N'2.B多选题', 2)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (6, 2005, 2, N'2.C多选题', 3)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (7, 2006, 1, N'1-1A单选题 第二次测试', 1)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (8, 2006, 1, N'1-1B单选题 第二次测试', 2)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2007, 4009, 1, N'十分满意', 1)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2008, 4009, 1, N'比较满意', 2)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2009, 4009, 1, N'不满意', 3)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2010, 4009, 2, N'严谨负责', 1)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2011, 4009, 2, N'板书认真', 2)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2012, 4009, 2, N'计划有序', 3)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2013, 4009, 2, N'穿戴整洁', 4)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2014, 4009, 3, N'完全符合', 1)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2015, 4009, 3, N'比较符合', 2)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2016, 4009, 3, N'比较不符合', 3)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2017, 5010, 1, N'第一个', 1)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2018, 5010, 1, N'第二个', 2)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2019, 5010, 1, N'第三个', 3)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2020, 5010, 3, N'第三个', 1)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2021, 5010, 3, N'第二个', 2)
INSERT [dbo].[Option] ([Id], [survey_id], [question_id], [option_name], [option_sort]) VALUES (2022, 5010, 3, N'第一个', 3)
SET IDENTITY_INSERT [dbo].[Option] OFF
GO
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (1, 2005, 1, N'1-1单选题', 1)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (2, 2005, 2, N'1-2多选题', 2)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (3, 2006, 1, N'测试2的第一题', 1)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (2004, 4009, 1, N'是否满意', 1)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (2005, 4009, 2, N'教学过程', 2)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (2006, 4009, 1, N'课本吻合度', 3)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (2007, 4009, 3, N'对老师的意见和建议', 4)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (2008, 4010, 3, N'你叫什么名字', 1)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (3008, 5010, 1, N'选哪个', 1)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (3009, 5010, 3, N'你叫什么名字', 2)
INSERT [dbo].[Question] ([Id], [survey_id], [question_type], [question_name], [question_sort]) VALUES (3010, 5010, 1, N'现在选哪个', 3)
SET IDENTITY_INSERT [dbo].[Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Question_Type] ON 

INSERT [dbo].[Question_Type] ([Id], [name]) VALUES (1, N'单选题')
INSERT [dbo].[Question_Type] ([Id], [name]) VALUES (2, N'多选题')
INSERT [dbo].[Question_Type] ([Id], [name]) VALUES (3, N'简答题')
SET IDENTITY_INSERT [dbo].[Question_Type] OFF
GO
SET IDENTITY_INSERT [dbo].[Sub_Answer] ON 

INSERT [dbo].[Sub_Answer] ([Id], [answer_id], [question_id], [content]) VALUES (5, 4, 1, N'王孜垚')
INSERT [dbo].[Sub_Answer] ([Id], [answer_id], [question_id], [content]) VALUES (11, 7, 1, N'1')
INSERT [dbo].[Sub_Answer] ([Id], [answer_id], [question_id], [content]) VALUES (12, 8, 1, N'1')
INSERT [dbo].[Sub_Answer] ([Id], [answer_id], [question_id], [content]) VALUES (13, 8, 2, N'1,2,3')
INSERT [dbo].[Sub_Answer] ([Id], [answer_id], [question_id], [content]) VALUES (14, 9, 1, N'1')
INSERT [dbo].[Sub_Answer] ([Id], [answer_id], [question_id], [content]) VALUES (15, 9, 2, N'鲁豫航')
INSERT [dbo].[Sub_Answer] ([Id], [answer_id], [question_id], [content]) VALUES (16, 9, 3, N'1')
SET IDENTITY_INSERT [dbo].[Sub_Answer] OFF
GO
SET IDENTITY_INSERT [dbo].[Survey] ON 

INSERT [dbo].[Survey] ([Id], [title], [description], [author_id], [create_date], [start_date], [end_date], [status]) VALUES (2005, N'测试用例', N'这是第N次测试', 1, CAST(N'2021-05-10T17:50:23.000' AS DateTime), CAST(N'2021-05-10T17:23:00.000' AS DateTime), CAST(N'2021-06-22T17:23:00.000' AS DateTime), 1)
INSERT [dbo].[Survey] ([Id], [title], [description], [author_id], [create_date], [start_date], [end_date], [status]) VALUES (2006, N'测试2 修改3', N'这是一次测试 修改', 1, CAST(N'2021-05-11T17:23:11.000' AS DateTime), CAST(N'2021-05-05T20:58:00.000' AS DateTime), CAST(N'2021-06-06T20:58:00.000' AS DateTime), 1)
INSERT [dbo].[Survey] ([Id], [title], [description], [author_id], [create_date], [start_date], [end_date], [status]) VALUES (4009, N'教学评估', N'这是一次教学评估测试', 1, CAST(N'2021-05-13T19:21:24.000' AS DateTime), CAST(N'2021-05-13T20:55:00.000' AS DateTime), CAST(N'2021-06-13T20:55:00.000' AS DateTime), 0)
INSERT [dbo].[Survey] ([Id], [title], [description], [author_id], [create_date], [start_date], [end_date], [status]) VALUES (4010, N'测试3 修改1', N'无', 3, CAST(N'2021-05-21T21:07:26.000' AS DateTime), CAST(N'2021-05-21T21:07:00.000' AS DateTime), CAST(N'2021-06-21T21:07:00.000' AS DateTime), 1)
INSERT [dbo].[Survey] ([Id], [title], [description], [author_id], [create_date], [start_date], [end_date], [status]) VALUES (5010, N'测试4', N'嘿嘿', 3, CAST(N'2021-05-23T20:55:26.000' AS DateTime), CAST(N'2021-05-23T20:55:00.000' AS DateTime), CAST(N'2021-06-23T20:55:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Survey] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [username], [passwd], [type], [stuid], [img]) VALUES (1, N'liu', N'000', 0, N'161830127', NULL)
INSERT [dbo].[User] ([Id], [username], [passwd], [type], [stuid], [img]) VALUES (2, N'cai', N'000', 0, N'161830101', NULL)
INSERT [dbo].[User] ([Id], [username], [passwd], [type], [stuid], [img]) VALUES (3, N'wang', N'000', 0, N'161830128', NULL)
INSERT [dbo].[User] ([Id], [username], [passwd], [type], [stuid], [img]) VALUES (4, N'lu', N'000', 0, N'161830114', NULL)
INSERT [dbo].[User] ([Id], [username], [passwd], [type], [stuid], [img]) VALUES (5, N'zhang', N'000', 1, N'161800101', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Survey] ADD  CONSTRAINT [DF_Survey_status]  DEFAULT ((0)) FOR [status]
GO
USE [master]
GO
ALTER DATABASE [SSSMS] SET  READ_WRITE 
GO
