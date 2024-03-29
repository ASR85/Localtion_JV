USE [master]
GO
/****** Object:  Database [Location]    Script Date: 22-12-22 20:45:21 ******/
CREATE DATABASE [Location]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Location', FILENAME = N'C:\Users\dehae\Location.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Location_log', FILENAME = N'C:\Users\dehae\Location_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Location] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Location].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Location] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Location] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Location] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Location] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Location] SET ARITHABORT OFF 
GO
ALTER DATABASE [Location] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Location] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Location] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Location] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Location] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Location] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Location] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Location] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Location] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Location] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Location] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Location] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Location] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Location] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Location] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Location] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Location] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Location] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Location] SET  MULTI_USER 
GO
ALTER DATABASE [Location] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Location] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Location] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Location] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Location] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Location] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Location] SET QUERY_STORE = OFF
GO
USE [Location]
GO
/****** Object:  Table [dbo].[Administrator]    Script Date: 22-12-22 20:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Administrator](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pseudo] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 22-12-22 20:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bookingDate] [datetime] NOT NULL,
	[loanDate] [datetime] NULL,
	[idPlayer] [int] NOT NULL,
	[idGame] [int] NOT NULL,
 CONSTRAINT [PK_Booking] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Copy]    Script Date: 22-12-22 20:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Copy](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idPlayer] [int] NOT NULL,
	[idGame] [int] NOT NULL,
 CONSTRAINT [PK_Copy] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Loan]    Script Date: 22-12-22 20:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loan](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[startDate] [datetime] NOT NULL,
	[endDate] [datetime] NOT NULL,
	[ongoing] [varchar](50) NOT NULL,
	[idBorrower] [int] NOT NULL,
	[idLender] [int] NOT NULL,
	[idCopy] [int] NOT NULL,
 CONSTRAINT [PK_Loan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Player]    Script Date: 22-12-22 20:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Player](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[pseudo] [varchar](20) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[credit] [int] NOT NULL,
	[registrationDate] [date] NOT NULL,
	[dateOfBirth] [date] NOT NULL,
	[lastAddedBonusDate] [date] NULL,
 CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 22-12-22 20:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VideoGame]    Script Date: 22-12-22 20:45:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VideoGame](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[creditCost] [int] NULL,
	[console] [varchar](50) NOT NULL,
 CONSTRAINT [PK_VideoGame] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Administrator] ON 

INSERT [dbo].[Administrator] ([id], [pseudo], [password]) VALUES (1, N'admin', N'admin')
SET IDENTITY_INSERT [dbo].[Administrator] OFF
GO
SET IDENTITY_INSERT [dbo].[Booking] ON 

INSERT [dbo].[Booking] ([id], [bookingDate], [loanDate], [idPlayer], [idGame]) VALUES (1, CAST(N'2021-12-12T00:00:00.000' AS DateTime), NULL, 1, 1)
INSERT [dbo].[Booking] ([id], [bookingDate], [loanDate], [idPlayer], [idGame]) VALUES (4, CAST(N'2022-12-12T00:00:00.000' AS DateTime), NULL, 2, 2)
INSERT [dbo].[Booking] ([id], [bookingDate], [loanDate], [idPlayer], [idGame]) VALUES (5, CAST(N'2022-12-12T00:00:00.000' AS DateTime), NULL, 2, 2)
INSERT [dbo].[Booking] ([id], [bookingDate], [loanDate], [idPlayer], [idGame]) VALUES (6, CAST(N'2022-12-12T00:00:00.000' AS DateTime), NULL, 1, 2)
INSERT [dbo].[Booking] ([id], [bookingDate], [loanDate], [idPlayer], [idGame]) VALUES (8, CAST(N'2022-12-12T00:00:00.000' AS DateTime), NULL, 1, 3002)
INSERT [dbo].[Booking] ([id], [bookingDate], [loanDate], [idPlayer], [idGame]) VALUES (9, CAST(N'2022-12-20T00:00:00.000' AS DateTime), CAST(N'2022-12-20T00:00:00.000' AS DateTime), 4015, 2002)
INSERT [dbo].[Booking] ([id], [bookingDate], [loanDate], [idPlayer], [idGame]) VALUES (10, CAST(N'2022-12-20T00:00:00.000' AS DateTime), CAST(N'2022-11-01T00:00:00.000' AS DateTime), 1003, 1)
INSERT [dbo].[Booking] ([id], [bookingDate], [loanDate], [idPlayer], [idGame]) VALUES (11, CAST(N'2022-12-20T00:00:00.000' AS DateTime), CAST(N'2022-12-31T00:00:00.000' AS DateTime), 1003, 1)
SET IDENTITY_INSERT [dbo].[Booking] OFF
GO
SET IDENTITY_INSERT [dbo].[Copy] ON 

INSERT [dbo].[Copy] ([id], [idPlayer], [idGame]) VALUES (1, 1, 1)
INSERT [dbo].[Copy] ([id], [idPlayer], [idGame]) VALUES (3, 1003, 9005)
SET IDENTITY_INSERT [dbo].[Copy] OFF
GO
SET IDENTITY_INSERT [dbo].[Loan] ON 

INSERT [dbo].[Loan] ([id], [startDate], [endDate], [ongoing], [idBorrower], [idLender], [idCopy]) VALUES (2, CAST(N'2022-12-12T00:00:00.000' AS DateTime), CAST(N'2022-12-12T00:00:00.000' AS DateTime), N'false', 1, 2, 1)
SET IDENTITY_INSERT [dbo].[Loan] OFF
GO
SET IDENTITY_INSERT [dbo].[Player] ON 

INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (1, N'user', N'user', 10, CAST(N'2020-12-12' AS Date), CAST(N'2020-12-12' AS Date), CAST(N'2022-01-06' AS Date))
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (2, N'Usul', N'U', 10, CAST(N'2022-02-12' AS Date), CAST(N'1999-01-06' AS Date), CAST(N'2022-01-06' AS Date))
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (3, N'Chewbacca', N'Chew', 10, CAST(N'2022-02-12' AS Date), CAST(N'2022-02-12' AS Date), CAST(N'2022-01-06' AS Date))
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (1003, N'1', N'1', 22, CAST(N'2022-07-12' AS Date), CAST(N'2022-07-12' AS Date), CAST(N'2022-12-20' AS Date))
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (2005, N'arnaud', N'arnaud', 10, CAST(N'2022-12-12' AS Date), CAST(N'2000-12-12' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (2007, N'arnaud', N'arnaud', 10, CAST(N'2022-12-12' AS Date), CAST(N'2000-12-12' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (2008, N'arnaud', N'arnaud', 10, CAST(N'2022-12-12' AS Date), CAST(N'2000-12-12' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (3003, N'U', N'U', 10, CAST(N'2022-12-12' AS Date), CAST(N'2022-12-12' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (3005, N'coco', N'coco', 10, CAST(N'2022-12-12' AS Date), CAST(N'2022-12-12' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (3011, N'q', N'z', 10, CAST(N'2002-12-12' AS Date), CAST(N'2022-12-12' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (3012, N'q', N'q', 10, CAST(N'2002-12-12' AS Date), CAST(N'2022-12-12' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (3016, N'c', N'd', 10, CAST(N'2022-12-15' AS Date), CAST(N'2000-12-12' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (4014, N'r', N'r', 10, CAST(N'2022-12-20' AS Date), CAST(N'2022-12-20' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (4015, N'qwz', N'123', 10, CAST(N'2022-12-20' AS Date), CAST(N'2000-08-01' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (4016, N'y', N'y', 10, CAST(N'2022-12-20' AS Date), CAST(N'2014-09-01' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (4017, N'yw', N'yw', 10, CAST(N'2022-12-20' AS Date), CAST(N'2014-09-01' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (4018, N'12', N'12', 10, CAST(N'2022-12-20' AS Date), CAST(N'2009-07-01' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (4019, N'123', N'123', 10, CAST(N'2022-12-20' AS Date), CAST(N'1900-01-01' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (4021, N'77', N'7', 10, CAST(N'2022-12-20' AS Date), CAST(N'2022-12-02' AS Date), NULL)
INSERT [dbo].[Player] ([id], [pseudo], [password], [credit], [registrationDate], [dateOfBirth], [lastAddedBonusDate]) VALUES (4022, N'1', N'2', 10, CAST(N'2022-12-20' AS Date), CAST(N'2022-11-07' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Player] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [username], [password]) VALUES (1, N'user', N'user')
INSERT [dbo].[Users] ([id], [username], [password]) VALUES (2, N'John', N'Doe')
INSERT [dbo].[Users] ([id], [username], [password]) VALUES (3, N'Corentin', N'Dehaene')
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[VideoGame] ON 

INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (1, N'Maximo', 5, N'ps2')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (2, N'Pokemon S/V', 3, N'Switch')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (3, N'CoD', 5, N'ps3')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (4, N'Fifa 22', 2, N'ps4')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (2002, N'Star wars', 4, N'ps4')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (3002, N'Luigi Mansion 3', 4, N'Switch')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (9002, N'12', 0, N'WiiU')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (9003, N'12', 0, N'PC')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (9004, N'43', 0, N'PS3')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (9005, N'Sly', 0, N'PS3')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (9006, N'Jak', 0, N'PS3')
INSERT [dbo].[VideoGame] ([id], [name], [creditCost], [console]) VALUES (9007, N'Jak', 0, N'PS3')
SET IDENTITY_INSERT [dbo].[VideoGame] OFF
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Game] FOREIGN KEY([idGame])
REFERENCES [dbo].[VideoGame] ([id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Game]
GO
ALTER TABLE [dbo].[Booking]  WITH CHECK ADD  CONSTRAINT [FK_Booking_Player] FOREIGN KEY([idPlayer])
REFERENCES [dbo].[Player] ([id])
GO
ALTER TABLE [dbo].[Booking] CHECK CONSTRAINT [FK_Booking_Player]
GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD  CONSTRAINT [FK_Copy_Player] FOREIGN KEY([idPlayer])
REFERENCES [dbo].[Player] ([id])
GO
ALTER TABLE [dbo].[Copy] CHECK CONSTRAINT [FK_Copy_Player]
GO
ALTER TABLE [dbo].[Copy]  WITH CHECK ADD  CONSTRAINT [FK_Copy_VideoGame] FOREIGN KEY([idGame])
REFERENCES [dbo].[VideoGame] ([id])
GO
ALTER TABLE [dbo].[Copy] CHECK CONSTRAINT [FK_Copy_VideoGame]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Borrower] FOREIGN KEY([idBorrower])
REFERENCES [dbo].[Player] ([id])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Borrower]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Copy] FOREIGN KEY([idCopy])
REFERENCES [dbo].[Copy] ([id])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Copy]
GO
ALTER TABLE [dbo].[Loan]  WITH CHECK ADD  CONSTRAINT [FK_Loan_Lender] FOREIGN KEY([idLender])
REFERENCES [dbo].[Player] ([id])
GO
ALTER TABLE [dbo].[Loan] CHECK CONSTRAINT [FK_Loan_Lender]
GO
USE [master]
GO
ALTER DATABASE [Location] SET  READ_WRITE 
GO
