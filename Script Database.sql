USE [master]
GO
/****** Object:  Database [NewsServer]    Script Date: 8/17/2021 7:14:55 PM ******/
CREATE DATABASE [NewsServer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NewsServer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NewsServer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NewsServer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\NewsServer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NewsServer] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NewsServer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NewsServer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NewsServer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NewsServer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NewsServer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NewsServer] SET ARITHABORT OFF 
GO
ALTER DATABASE [NewsServer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [NewsServer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NewsServer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NewsServer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NewsServer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NewsServer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NewsServer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NewsServer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NewsServer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NewsServer] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NewsServer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NewsServer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NewsServer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NewsServer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NewsServer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NewsServer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NewsServer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NewsServer] SET RECOVERY FULL 
GO
ALTER DATABASE [NewsServer] SET  MULTI_USER 
GO
ALTER DATABASE [NewsServer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NewsServer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NewsServer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NewsServer] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NewsServer] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NewsServer] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'NewsServer', N'ON'
GO
ALTER DATABASE [NewsServer] SET QUERY_STORE = OFF
GO
USE [NewsServer]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 8/17/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[ArticleID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](255) NULL,
	[AuthorID] [int] NULL,
	[Description] [text] NULL,
	[Content] [text] NULL,
	[URLToArticle] [varchar](255) NULL,
	[URLToImage] [varchar](255) NULL,
	[publishedAt] [datetime] NULL,
	[Uptake] [int] NULL,
	[SourceID] [int] NULL,
	[CategoryID] [int] NULL,
	[CountryID] [int] NULL,
	[LanguageID] [int] NULL,
	[StateID] [int] NULL,
	[SortID] [int] NULL,
	[UserID] [int] NULL,
	[CreateDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ArticleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 8/17/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[LastName] [nvarchar](255) NULL,
	[StateID] [int] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 8/17/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[StateID] [int] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 8/17/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[CountryCode] [varchar](10) NULL,
	[Name] [nvarchar](250) NULL,
	[StateID] [int] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 8/17/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageCode] [varchar](8) NULL,
	[Name] [varchar](100) NULL,
	[StateID] [int] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SortBy]    Script Date: 8/17/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SortBy](
	[SortID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[StateID] [int] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SortID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sources]    Script Date: 8/17/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sources](
	[SourceID] [int] IDENTITY(1,1) NOT NULL,
	[SourceName] [varchar](30) NULL,
	[StateID] [int] NULL,
	[UserID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[States]    Script Date: 8/17/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[States](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/17/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NULL,
	[Password] [varchar](max) NULL,
	[StateID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (2, N'Kaseya ransomware attackers demand $70 million, claim they infected over a million devices', 1, N'Three days after ransomware attackers hijacked a managed services platform, recovery efforts continued.', N'<p>"Filed under:\r\nThe supply chain attack has reached over a thousand organizations.\r\nIllustration by Alex Castro / The Verge\r\nThree days after ransomware attackers started the holiday weekend by comprom&hellip; [+3376 chars]"</p>', N'https://www.theverge.com/2021/7/5/22564054/ransomware-revil-kaseya-coop', N'https://cdn.vox-cdn.com/thumbor/nk-drxT0WYuHTTAQw6MhPgi4LK8=/0x146:2040x1214/fit-in/1200x630/cdn.vox-cdn.com/uploads/chorus_asset/file/8792137/acastro_170629_1777_0008_v2.jpg', CAST(N'2021-07-15T14:12:00.000' AS DateTime), NULL, 1, 2, 1, 1, 1, NULL, NULL, NULL)
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (3, N'Gang behind huge cyber-attack demands $70m in Bitcoin', 2, N'The authors of a \"colossal\" ransomware attack demand the sum in Bitcoin in return for a key to unlock all files', N'<p>image copyrightGetty Images\r\nThe gang behind a \"colossal\" ransomware attack has demanded $70m (&pound;50.5m) paid in Bitcoin in return for a \"universal decryptor\" that it says will unlock the files of all &hellip; [+4140 chars]</p>', N'https://www.bbc.co.uk/news/technology-57719820', N'https://ichef.bbci.co.uk/news/1024/branded_news/4532/production/_119241771_gettyimages-645051326.jpg', CAST(N'2021-07-14T18:01:00.000' AS DateTime), NULL, 1, 7, 1, 3, 1, NULL, NULL, NULL)
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (4, N'How to Hide Nudes, Personal Data, and Pictures of Your Ex on an iPhone or iPad', 5, N'It’s possible you have a few photos on your iPhone or iPad that you’d rather not stumble upon—or have anyone else stumble upon, such as a picture of your ex, a troubling memory, or other, uh, unmentionables.', N'<p>Its possible you have a few photos on your iPhone or iPad that youd rather not stumble uponor have anyone else stumble upon, such as a picture of your ex, a troubling memory, or other, uh, unmentiona&hellip; [+4927 chars]</p>', N'https://lifehacker.com/how-to-hide-nudes-personal-data-and-pictures-of-your-1847288475', N'https://i.kinja-img.com/gawker-media/image/upload/c_fill,f_auto,fl_progressive,g_center,h_675,pg_1,q_80,w_1200/221564ec8bdf903ac7bbdbf18e1842f1.jpg', CAST(N'2021-07-07T18:45:00.000' AS DateTime), NULL, 8, 2, 1, 3, 1, NULL, NULL, NULL)
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (1005, N'kjdshfunvauhrfq', 1, N'stafvsrttwjkhjkdhferring', N'stridjfhurehyiufehrugnkjdfng', N'stringkjfuireuifhureh', N'string', CAST(N'2021-08-15T04:13:56.580' AS DateTime), NULL, 1, 3, 8, 5, 1, NULL, 1, CAST(N'2021-08-15T00:17:07.383' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (1006, N'kjdshfunvauhrfq', 1, N'stafvsrttwjkhjkdhferring', N'stridjfhurehyiufehrugnkjdfng', N'stringkjfuireuifhureh', N'string', CAST(N'2021-08-15T04:13:56.580' AS DateTime), NULL, 1, 3, 8, 5, 1, NULL, 1, CAST(N'2021-08-15T00:18:23.723' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (1008, N'strikkdjafenrferng', 1, N'stfjhvsiulihwuggring', N'strinkjvisfjgoiurgeg', N'stridkjlsfyhivugrrng', N'strikjligfgrrtgng', CAST(N'2021-08-15T04:51:24.417' AS DateTime), NULL, 2, 3, 6, 2, 1, NULL, 1, CAST(N'2021-08-15T00:53:06.040' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (1009, N'strdjnflrrhfiurehlging', 1, N'stsdlkjiufireuifregring', N'strinzkkldujvierhguhgg', N'strinsdkeuhviuheruihglg', N'strinckjvifhveegg', CAST(N'2021-08-15T04:55:00.163' AS DateTime), NULL, 1, 2, 1, 2, 1, NULL, 1, CAST(N'2021-08-15T00:55:45.087' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (1010, N'string', 2, N'string', N'string', N'string', N'string', CAST(N'2021-08-15T04:57:41.727' AS DateTime), NULL, 1, 2, 5, 2, 1, NULL, 1, CAST(N'2021-08-15T00:58:18.707' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (1011, N'string', 1, N'string', N'string', N'string', N'string', CAST(N'2021-08-15T05:06:26.307' AS DateTime), NULL, 1, 2, 1, 2, 1, NULL, 1, CAST(N'2021-08-15T01:06:58.107' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (1012, N'I am a title', 1, N'This is my description', N'string', N'string', N'string', CAST(N'2021-08-17T19:04:42.780' AS DateTime), NULL, 2, 3, 8, 1, 1, NULL, 1, CAST(N'2021-08-17T19:04:42.780' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (1013, N'string', 1, N'string', N'string', N'string', N'string', CAST(N'2021-08-15T05:24:41.363' AS DateTime), NULL, 2, 2, 5, 2, 1, NULL, 1, CAST(N'2021-08-15T01:25:15.197' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (1015, N'This Title', 3, N'This description', N'this content', N'this article', N'this image', CAST(N'2021-08-15T01:34:31.297' AS DateTime), NULL, 1, 4, 24, 1, 1, NULL, 1, CAST(N'2021-08-15T01:34:31.473' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (2003, N'Hello', 4, N'Hell', N'fghtwrhtr', N'ewrgwt', N'rwerg', CAST(N'2021-08-17T18:14:07.617' AS DateTime), NULL, 1, 4, 19, 4, 1, NULL, 1, CAST(N'2021-08-17T18:14:07.940' AS DateTime))
INSERT [dbo].[Articles] ([ArticleID], [Title], [AuthorID], [Description], [Content], [URLToArticle], [URLToImage], [publishedAt], [Uptake], [SourceID], [CategoryID], [CountryID], [LanguageID], [StateID], [SortID], [UserID], [CreateDate]) VALUES (2004, N'El titulo', 3, N'la descripcion', N'el contenido', N'', N'', CAST(N'2021-08-17T18:17:15.297' AS DateTime), NULL, 2, 3, 18, 3, 1, NULL, 1, CAST(N'2021-08-17T18:17:15.390' AS DateTime))
SET IDENTITY_INSERT [dbo].[Articles] OFF
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [StateID], [UserID]) VALUES (1, N'Maria', N'Rivera', 2, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [StateID], [UserID]) VALUES (2, N'Manuel', N'Santana', 2, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [StateID], [UserID]) VALUES (3, N'Joel', N'Mota', 1, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [StateID], [UserID]) VALUES (4, N'Lucas', N'Matney', NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [StateID], [UserID]) VALUES (5, N'Khamosh', N'Pathak', NULL, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [StateID], [UserID]) VALUES (1001, N'Maritza', N'Jimenez', 1, 1)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [StateID], [UserID]) VALUES (1002, N'Yore', N'Mejia', 2, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [StateID], [UserID]) VALUES (1003, N'Gian Luca', N'Samoa', 1, NULL)
INSERT [dbo].[Authors] ([AuthorID], [Name], [LastName], [StateID], [UserID]) VALUES (1004, N' Samuel', N'Santana', 1, NULL)
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [Name], [StateID], [UserID]) VALUES (1, N'NEGOCIO', 1, NULL)
INSERT [dbo].[Categories] ([CategoryID], [Name], [StateID], [UserID]) VALUES (2, N'ENTRETTENIMIENTO', 1, NULL)
INSERT [dbo].[Categories] ([CategoryID], [Name], [StateID], [UserID]) VALUES (3, N'GENERAL', 1, NULL)
INSERT [dbo].[Categories] ([CategoryID], [Name], [StateID], [UserID]) VALUES (4, N'SALUD', 1, NULL)
INSERT [dbo].[Categories] ([CategoryID], [Name], [StateID], [UserID]) VALUES (5, N'CIENCIAS', 1, NULL)
INSERT [dbo].[Categories] ([CategoryID], [Name], [StateID], [UserID]) VALUES (6, N'DEPORTES', 1, NULL)
INSERT [dbo].[Categories] ([CategoryID], [Name], [StateID], [UserID]) VALUES (7, N'TENOLOGIA', 1, NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (1, N'AF', N'Afganistán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (2, N'AX', N'Islas Gland', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (3, N'AL', N'Albania', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (4, N'DE', N'Alemania', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (5, N'AD', N'Andorra', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (6, N'AO', N'Angola', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (7, N'AI', N'Anguilla', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (8, N'AQ', N'Antártida', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (9, N'AG', N'Antigua y Barbuda', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (10, N'AN', N'Antillas Holandesas', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (11, N'SA', N'Arabia Saudí', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (12, N'DZ', N'Argelia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (13, N'AR', N'Argentina', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (14, N'AM', N'Armenia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (15, N'AW', N'Aruba', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (16, N'AU', N'Australia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (17, N'AT', N'Austria', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (18, N'AZ', N'Azerbaiyán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (19, N'BS', N'Bahamas', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (20, N'BH', N'Bahréin', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (21, N'BD', N'Bangladesh', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (22, N'BB', N'Barbados', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (23, N'BY', N'Bielorrusia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (24, N'BE', N'Bélgica', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (25, N'BZ', N'Belice', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (26, N'BJ', N'Benin', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (27, N'BM', N'Bermudas', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (28, N'BT', N'Bhután', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (29, N'BO', N'Bolivia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (30, N'BA', N'Bosnia y Herzegovina', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (31, N'BW', N'Botsuana', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (32, N'BV', N'Isla Bouvet', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (33, N'BR', N'Brasil', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (34, N'BN', N'Brunéi', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (35, N'BG', N'Bulgaria', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (36, N'BF', N'Burkina Faso', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (37, N'BI', N'Burundi', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (38, N'CV', N'Cabo Verde', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (39, N'KY', N'Islas Caimán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (40, N'KH', N'Camboya', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (41, N'CM', N'Camerún', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (42, N'CA', N'Canadá', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (43, N'CF', N'República Centroafricana', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (44, N'TD', N'Chad', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (45, N'CZ', N'República Checa', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (46, N'CL', N'Chile', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (47, N'CN', N'China', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (48, N'CY', N'Chipre', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (49, N'CX', N'Isla de Navidad', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (50, N'VA', N'Ciudad del Vaticano', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (51, N'CC', N'Islas Cocos', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (52, N'CO', N'Colombia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (53, N'KM', N'Comoras', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (54, N'CD', N'República Democrática del Congo', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (55, N'CG', N'Congo', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (56, N'CK', N'Islas Cook', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (57, N'KP', N'Corea del Norte', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (58, N'KR', N'Corea del Sur', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (59, N'CI', N'Costa de Marfil', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (60, N'CR', N'Costa Rica', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (61, N'HR', N'Croacia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (62, N'CU', N'Cuba', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (63, N'DK', N'Dinamarca', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (64, N'DM', N'Dominica', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (65, N'DO', N'República Dominicana', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (66, N'EC', N'Ecuador', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (67, N'EG', N'Egipto', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (68, N'SV', N'El Salvador', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (69, N'AE', N'Emiratos Árabes Unidos', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (70, N'ER', N'Eritrea', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (71, N'SK', N'Eslovaquia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (72, N'SI', N'Eslovenia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (73, N'ES', N'España', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (74, N'UM', N'Islas ultramarinas de States Unidos', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (75, N'US', N'Estados Unidos', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (76, N'EE', N'Estonia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (77, N'ET', N'Etiopía', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (78, N'FO', N'Islas Feroe', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (79, N'PH', N'Filipinas', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (80, N'FI', N'Finlandia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (81, N'FJ', N'Fiyi', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (82, N'FR', N'Francia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (83, N'GA', N'Gabón', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (84, N'GM', N'Gambia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (85, N'GE', N'Georgia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (86, N'GS', N'Islas Georgias del Sur y Sandwich del Sur', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (87, N'GH', N'Ghana', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (88, N'GI', N'Gibraltar', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (89, N'GD', N'Granada', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (90, N'GR', N'Grecia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (91, N'GL', N'Groenlandia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (92, N'GP', N'Guadalupe', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (93, N'GU', N'Guam', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (94, N'GT', N'Guatemala', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (95, N'GF', N'Guayana Francesa', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (96, N'GN', N'Guinea', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (97, N'GQ', N'Guinea Ecuatorial', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (98, N'GW', N'Guinea-Bissau', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (99, N'GY', N'Guyana', 1, NULL)
GO
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (100, N'HT', N'Haití', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (101, N'HM', N'Islas Heard y McDonald', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (102, N'HN', N'Honduras', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (103, N'HK', N'Hong Kong', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (104, N'HU', N'Hungría', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (105, N'IN', N'India', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (106, N'ID', N'Indonesia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (107, N'IR', N'Irán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (108, N'IQ', N'Iraq', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (109, N'IE', N'Irlanda', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (110, N'IS', N'Islandia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (111, N'IL', N'Israel', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (112, N'IT', N'Italia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (113, N'JM', N'Jamaica', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (114, N'JP', N'Japón', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (115, N'JO', N'Jordania', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (116, N'KZ', N'Kazajstán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (117, N'KE', N'Kenia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (118, N'KG', N'Kirguistán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (119, N'KI', N'Kiribati', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (120, N'KW', N'Kuwait', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (121, N'LA', N'Laos', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (122, N'LS', N'Lesotho', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (123, N'LV', N'Letonia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (124, N'LB', N'Líbano', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (125, N'LR', N'Liberia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (126, N'LY', N'Libia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (127, N'LI', N'Liechtenstein', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (128, N'LT', N'Lituania', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (129, N'LU', N'Luxemburgo', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (130, N'MO', N'Macao', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (131, N'MK', N'ARY Macedonia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (132, N'MG', N'Madagascar', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (133, N'MY', N'Malasia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (134, N'MW', N'Malawi', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (135, N'MV', N'Maldivas', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (136, N'ML', N'Malí', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (137, N'MT', N'Malta', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (138, N'FK', N'Islas Malvinas', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (139, N'MP', N'Islas Marianas del Norte', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (140, N'MA', N'Marruecos', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (141, N'MH', N'Islas Marshall', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (142, N'MQ', N'Martinica', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (143, N'MU', N'Mauricio', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (144, N'MR', N'Mauritania', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (145, N'YT', N'Mayotte', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (146, N'MX', N'México', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (147, N'FM', N'Micronesia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (148, N'MD', N'Moldavia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (149, N'MC', N'Mónaco', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (150, N'MN', N'Mongolia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (151, N'MS', N'Montserrat', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (152, N'MZ', N'Mozambique', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (153, N'MM', N'Myanmar', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (154, N'NA', N'Namibia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (155, N'NR', N'Nauru', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (156, N'NP', N'Nepal', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (157, N'NI', N'Nicaragua', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (158, N'NE', N'Níger', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (159, N'NG', N'Nigeria', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (160, N'NU', N'Niue', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (161, N'NF', N'Isla Norfolk', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (162, N'NO', N'Noruega', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (163, N'NC', N'Nueva Caledonia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (164, N'NZ', N'Nueva Zelanda', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (165, N'OM', N'Omán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (166, N'NL', N'Países Bajos', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (167, N'PK', N'Pakistán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (168, N'PW', N'Palau', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (169, N'PS', N'Palestina', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (170, N'PA', N'Panamá', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (171, N'PG', N'Papúa Nueva Guinea', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (172, N'PY', N'Paraguay', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (173, N'PE', N'Perú', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (174, N'PN', N'Islas Pitcairn', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (175, N'PF', N'Polinesia Francesa', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (176, N'PL', N'Polonia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (177, N'PT', N'Portugal', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (178, N'PR', N'Puerto Rico', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (179, N'QA', N'Qatar', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (180, N'GB', N'Reino Unido', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (181, N'RE', N'Reunión', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (182, N'RW', N'Ruanda', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (183, N'RO', N'Rumania', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (184, N'RU', N'Rusia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (185, N'EH', N'Sahara Occidental', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (186, N'SB', N'Islas Salomón', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (187, N'WS', N'Samoa', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (188, N'AS', N'Samoa Americana', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (189, N'KN', N'San Cristóbal y Nevis', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (190, N'SM', N'San Marino', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (191, N'PM', N'San Pedro y Miquelón', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (192, N'VC', N'San Vicente y las Granadinas', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (193, N'SH', N'Santa Helena', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (194, N'LC', N'Santa Lucía', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (195, N'ST', N'Santo Tomé y Príncipe', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (196, N'SN', N'Senegal', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (197, N'CS', N'Serbia y Montenegro', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (198, N'SC', N'Seychelles', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (199, N'SL', N'Sierra Leona', 1, NULL)
GO
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (200, N'SG', N'Singapur', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (201, N'SY', N'Siria', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (202, N'SO', N'Somalia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (203, N'LK', N'Sri Lanka', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (204, N'SZ', N'Suazilandia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (205, N'ZA', N'Sudáfrica', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (206, N'SD', N'Sudán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (207, N'SE', N'Suecia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (208, N'CH', N'Suiza', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (209, N'SR', N'Surinam', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (210, N'SJ', N'Svalbard y Jan Mayen', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (211, N'TH', N'Tailandia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (212, N'TW', N'Taiwán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (213, N'TZ', N'Tanzania', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (214, N'TJ', N'Tayikistán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (215, N'IO', N'Territorio Británico del Océano Índico', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (216, N'TF', N'Territorios Australes Franceses', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (217, N'TL', N'Timor Oriental', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (218, N'TG', N'Togo', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (219, N'TK', N'Tokelau', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (220, N'TO', N'Tonga', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (221, N'TT', N'Trinidad y Tobago', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (222, N'TN', N'Túnez', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (223, N'TC', N'Islas Turcas y Caicos', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (224, N'TM', N'Turkmenistán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (225, N'TR', N'Turquía', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (226, N'TV', N'Tuvalu', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (227, N'UA', N'Ucrania', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (228, N'UG', N'Uganda', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (229, N'UY', N'Uruguay', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (230, N'UZ', N'Uzbekistán', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (231, N'VU', N'Vanuatu', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (232, N'VE', N'Venezuela', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (233, N'VN', N'Vietnam', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (234, N'VG', N'Islas Vírgenes Británicas', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (235, N'VI', N'Islas Vírgenes de los States Unidos', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (236, N'WF', N'Wallis y Futuna', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (237, N'YE', N'Yemen', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (238, N'DJ', N'Yibuti', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (239, N'ZM', N'Zambia', 1, NULL)
INSERT [dbo].[Countries] ([CountryID], [CountryCode], [Name], [StateID], [UserID]) VALUES (240, N'ZW', N'Zimbabue', 1, NULL)
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([LanguageID], [LanguageCode], [Name], [StateID], [UserID]) VALUES (1, N'ar', N'árabe', 1, NULL)
INSERT [dbo].[Languages] ([LanguageID], [LanguageCode], [Name], [StateID], [UserID]) VALUES (2, N'de', N'alemán', 1, NULL)
INSERT [dbo].[Languages] ([LanguageID], [LanguageCode], [Name], [StateID], [UserID]) VALUES (3, N'en', N'inglés', 1, NULL)
INSERT [dbo].[Languages] ([LanguageID], [LanguageCode], [Name], [StateID], [UserID]) VALUES (4, N'es', N'español', 1, NULL)
INSERT [dbo].[Languages] ([LanguageID], [LanguageCode], [Name], [StateID], [UserID]) VALUES (5, N'fr', N'francés', 1, NULL)
INSERT [dbo].[Languages] ([LanguageID], [LanguageCode], [Name], [StateID], [UserID]) VALUES (6, N'it', N'italiano', 1, NULL)
INSERT [dbo].[Languages] ([LanguageID], [LanguageCode], [Name], [StateID], [UserID]) VALUES (7, N'ru', N'ruso', 1, NULL)
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[SortBy] ON 

INSERT [dbo].[SortBy] ([SortID], [Name], [StateID], [UserID]) VALUES (1, N'popularidad', NULL, NULL)
INSERT [dbo].[SortBy] ([SortID], [Name], [StateID], [UserID]) VALUES (2, N'fecha publicación', NULL, NULL)
SET IDENTITY_INSERT [dbo].[SortBy] OFF
GO
SET IDENTITY_INSERT [dbo].[Sources] ON 

INSERT [dbo].[Sources] ([SourceID], [SourceName], [StateID], [UserID]) VALUES (1, N'New York Times', NULL, NULL)
INSERT [dbo].[Sources] ([SourceID], [SourceName], [StateID], [UserID]) VALUES (2, N'Fox News', NULL, NULL)
INSERT [dbo].[Sources] ([SourceID], [SourceName], [StateID], [UserID]) VALUES (4, N'BuzzFeed News', NULL, NULL)
INSERT [dbo].[Sources] ([SourceID], [SourceName], [StateID], [UserID]) VALUES (5, N'Google News', NULL, NULL)
INSERT [dbo].[Sources] ([SourceID], [SourceName], [StateID], [UserID]) VALUES (6, N'The Verge', NULL, NULL)
INSERT [dbo].[Sources] ([SourceID], [SourceName], [StateID], [UserID]) VALUES (7, N'TechCrunch', NULL, NULL)
INSERT [dbo].[Sources] ([SourceID], [SourceName], [StateID], [UserID]) VALUES (8, N'Lifehacker.com', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Sources] OFF
GO
SET IDENTITY_INSERT [dbo].[States] ON 

INSERT [dbo].[States] ([StateID], [Name]) VALUES (1, N'Activo')
INSERT [dbo].[States] ([StateID], [Name]) VALUES (2, N'Eliminado')
SET IDENTITY_INSERT [dbo].[States] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [Name], [Password], [StateID]) VALUES (1, N'Admin', N'A4B88363A8336B6474D670C6F86D9CD13FDEDF531EC224C6949B84B5111AC84675F8BC2F525551AEE6EF690DAACDB05AB91548001370743021065929144E4FB9', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_ArSortID] FOREIGN KEY([SortID])
REFERENCES [dbo].[SortBy] ([SortID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_ArSortID]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_ArStateID] FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_ArStateID]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_ArUserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_ArUserID]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_AuthorID] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Authors] ([AuthorID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_AuthorID]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_CatgoriaID] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_CatgoriaID]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_CountryID] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([CountryID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_CountryID]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_LanguageID] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_LanguageID]
GO
ALTER TABLE [dbo].[Articles]  WITH CHECK ADD  CONSTRAINT [FK_SourceID] FOREIGN KEY([SourceID])
REFERENCES [dbo].[Sources] ([SourceID])
GO
ALTER TABLE [dbo].[Articles] CHECK CONSTRAINT [FK_SourceID]
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK_AStateID] FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK_AStateID]
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK_AUserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK_AUserID]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_CStateID] FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_CStateID]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_CUserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_CUserID]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_PStateID] FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_PStateID]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_PUserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_PUserID]
GO
ALTER TABLE [dbo].[Languages]  WITH CHECK ADD  CONSTRAINT [FK_IStateID] FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[Languages] CHECK CONSTRAINT [FK_IStateID]
GO
ALTER TABLE [dbo].[Languages]  WITH CHECK ADD  CONSTRAINT [FK_IUserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Languages] CHECK CONSTRAINT [FK_IUserID]
GO
ALTER TABLE [dbo].[SortBy]  WITH CHECK ADD  CONSTRAINT [FK_SortStateID] FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[SortBy] CHECK CONSTRAINT [FK_SortStateID]
GO
ALTER TABLE [dbo].[SortBy]  WITH CHECK ADD  CONSTRAINT [FK_SortUserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[SortBy] CHECK CONSTRAINT [FK_SortUserID]
GO
ALTER TABLE [dbo].[Sources]  WITH CHECK ADD  CONSTRAINT [FK_FStateID] FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[Sources] CHECK CONSTRAINT [FK_FStateID]
GO
ALTER TABLE [dbo].[Sources]  WITH CHECK ADD  CONSTRAINT [FK_FUserID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Sources] CHECK CONSTRAINT [FK_FUserID]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_UStateID] FOREIGN KEY([StateID])
REFERENCES [dbo].[States] ([StateID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_UStateID]
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 8/17/2021 7:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[InsertUser]
	@Name varchar(255),
	@Password varchar(max)
AS
BEGIN
	Set nocount on;
	set @password = convert(varchar(max), 
		HASHBYTES('SHA2_512',@password),2)

	Insert Users(Name, Password,StateID) values(@Name,@Password,1)
	set nocount off;
END
GO
/****** Object:  StoredProcedure [dbo].[ValidatingUser]    Script Date: 8/17/2021 7:14:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ValidatingUser]
	@name varchar(255),
	@password varchar(max)
AS BEGIN
	
	set @password = convert(varchar(max), 
		HASHBYTES('SHA2_512',@password),2)

	Select UserID,Name,Password,StateID
	from Users
	where name=@name and Password=@password

END
GO
USE [master]
GO
ALTER DATABASE [NewsServer] SET  READ_WRITE 
GO
