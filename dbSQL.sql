USE [master]
GO
/****** Object:  Database [TaskMasterDB]    Script Date: 5/31/2023 8:01:25 PM ******/
DROP DATABASE [TaskMasterDB]

CREATE DATABASE [TaskMasterDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskMasterDB', FILENAME = N'C:\Users\ahmed\TaskMasterDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaskMasterDB_log', FILENAME = N'C:\Users\ahmed\TaskMasterDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TaskMasterDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskMasterDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaskMasterDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaskMasterDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaskMasterDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaskMasterDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaskMasterDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaskMasterDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaskMasterDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaskMasterDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaskMasterDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaskMasterDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaskMasterDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaskMasterDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaskMasterDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaskMasterDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaskMasterDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaskMasterDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaskMasterDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaskMasterDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaskMasterDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaskMasterDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaskMasterDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaskMasterDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaskMasterDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TaskMasterDB] SET  MULTI_USER 
GO
ALTER DATABASE [TaskMasterDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaskMasterDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaskMasterDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaskMasterDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TaskMasterDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TaskMasterDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TaskMasterDB] SET QUERY_STORE = OFF
GO
USE [TaskMasterDB]
GO
/****** Object:  Table [dbo].[proj_ActionLogs]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_ActionLogs](
	[logID] [int] IDENTITY(1,1) NOT NULL,
	[source] [nvarchar](50) NOT NULL,
	[date] [date] NOT NULL,
	[message] [nvarchar](50) NOT NULL,
	[originalValue] [nvarchar](50) NOT NULL,
	[currentValue] [nvarchar](50) NOT NULL,
	[userID] [int] NULL,
 CONSTRAINT [PK_ActionLogs] PRIMARY KEY CLUSTERED 
(
	[logID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proj_Comment]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_Comment](
	[commentID] [int] IDENTITY(1,1) NOT NULL,
	[commentDate] [date] NOT NULL,
	[commentText] [nvarchar](50) NOT NULL,
	[userID] [int] NULL,
	[taskID] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[commentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proj_Document]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_Document](
	[documentID] [int] IDENTITY(1,1) NOT NULL,
	[documentName] [nvarchar](50) NOT NULL,
	[uploadDate] [date] NOT NULL,
	[documentType] [nvarchar](50) NOT NULL,
	[path] [nvarchar](50) NOT NULL,
	[taskID] [int] NULL,
	[userID] [int] NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[documentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proj_ExceptionLog]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_ExceptionLog](
	[logID] [int] IDENTITY(1,1) NOT NULL,
	[source] [nvarchar](50) NOT NULL,
	[date] [date] NOT NULL,
	[exception] [nvarchar](50) NOT NULL,
	[userID] [int] NULL,
 CONSTRAINT [PK_ExceptionLog] PRIMARY KEY CLUSTERED 
(
	[logID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proj_Notification]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_Notification](
	[notifID] [int] IDENTITY(1,1) NOT NULL,
	[message] [nvarchar](50) NOT NULL,
	[type] [nvarchar](50) NOT NULL,
	[isRead] [bit] NOT NULL,
	[userID] [int] NULL,
 CONSTRAINT [PK_proj_Notification] PRIMARY KEY CLUSTERED 
(
	[notifID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proj_Project]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_Project](
	[projectID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED 
(
	[projectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proj_ProjectUser]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_ProjectUser](
	[projectUserID] [int] IDENTITY(1,1) NOT NULL,
	[userID] [int] NULL,
	[projectID] [int] NULL,
	[manager] [bit] NOT NULL,
 CONSTRAINT [PK_ProjectUser] PRIMARY KEY CLUSTERED 
(
	[projectUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proj_Status]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_Status](
	[statusID] [int] IDENTITY(1,1) NOT NULL,
	[status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[statusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proj_Task]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_Task](
	[taskID] [int] IDENTITY(1,1) NOT NULL,
	[taskName] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NOT NULL,
	[deadline] [date] NOT NULL,
	[userID] [int] NULL,
	[statusID] [int] NULL,
	[projectID] [int] NULL,
 CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED 
(
	[taskID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[proj_User]    Script Date: 5/31/2023 8:01:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[proj_User](
	[userID] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[pass] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_proj_User] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[proj_ActionLogs] ON 

INSERT [dbo].[proj_ActionLogs] ([logID], [source], [date], [message], [originalValue], [currentValue], [userID]) VALUES (1, N'test', CAST(N'2023-05-31' AS Date), N'test', N'test1', N'test2', 1)
SET IDENTITY_INSERT [dbo].[proj_ActionLogs] OFF
GO
SET IDENTITY_INSERT [dbo].[proj_Comment] ON 

INSERT [dbo].[proj_Comment] ([commentID], [commentDate], [commentText], [userID], [taskID]) VALUES (1, CAST(N'2023-05-31' AS Date), N'comment text', 1, 2)
SET IDENTITY_INSERT [dbo].[proj_Comment] OFF
GO
SET IDENTITY_INSERT [dbo].[proj_Document] ON 

INSERT [dbo].[proj_Document] ([documentID], [documentName], [uploadDate], [documentType], [path], [taskID], [userID]) VALUES (6, N'testDoc', CAST(N'2023-05-30' AS Date), N'word', N'users/desktop', 2, 1)
SET IDENTITY_INSERT [dbo].[proj_Document] OFF
GO
SET IDENTITY_INSERT [dbo].[proj_ExceptionLog] ON 

INSERT [dbo].[proj_ExceptionLog] ([logID], [source], [date], [exception], [userID]) VALUES (1, N'test', CAST(N'2023-05-31' AS Date), N'test', 1)
SET IDENTITY_INSERT [dbo].[proj_ExceptionLog] OFF
GO
SET IDENTITY_INSERT [dbo].[proj_Notification] ON 

INSERT [dbo].[proj_Notification] ([notifID], [message], [type], [isRead], [userID]) VALUES (1, N'test notification', N'urgent', 0, 1)
SET IDENTITY_INSERT [dbo].[proj_Notification] OFF
GO
SET IDENTITY_INSERT [dbo].[proj_Project] ON 

INSERT [dbo].[proj_Project] ([projectID], [name], [description]) VALUES (2, N'building plans', N'create the blueprints for a new building')
INSERT [dbo].[proj_Project] ([projectID], [name], [description]) VALUES (4, N'building plan', N'building the base of a building')
INSERT [dbo].[proj_Project] ([projectID], [name], [description]) VALUES (5, N'test', N'test')
SET IDENTITY_INSERT [dbo].[proj_Project] OFF
GO
SET IDENTITY_INSERT [dbo].[proj_ProjectUser] ON 

INSERT [dbo].[proj_ProjectUser] ([projectUserID], [userID], [projectID], [manager]) VALUES (1, 1, 2, 1)
INSERT [dbo].[proj_ProjectUser] ([projectUserID], [userID], [projectID], [manager]) VALUES (5, 3, 2, 0)
SET IDENTITY_INSERT [dbo].[proj_ProjectUser] OFF
GO
SET IDENTITY_INSERT [dbo].[proj_Status] ON 

INSERT [dbo].[proj_Status] ([statusID], [status]) VALUES (1, N'in-progress')
INSERT [dbo].[proj_Status] ([statusID], [status]) VALUES (2, N'finished')
SET IDENTITY_INSERT [dbo].[proj_Status] OFF
GO
SET IDENTITY_INSERT [dbo].[proj_Task] ON 

INSERT [dbo].[proj_Task] ([taskID], [taskName], [description], [deadline], [userID], [statusID], [projectID]) VALUES (2, N'test task', N'testing if this works', CAST(N'2023-05-31' AS Date), 1, 1, 2)
SET IDENTITY_INSERT [dbo].[proj_Task] OFF
GO
SET IDENTITY_INSERT [dbo].[proj_User] ON 

INSERT [dbo].[proj_User] ([userID], [name], [email], [pass]) VALUES (1, N'ahmed', N'ahmed@test.com', N'test123')
INSERT [dbo].[proj_User] ([userID], [name], [email], [pass]) VALUES (3, N'test', N'test@test', N'123')
SET IDENTITY_INSERT [dbo].[proj_User] OFF
GO
ALTER TABLE [dbo].[proj_ActionLogs]  WITH CHECK ADD  CONSTRAINT [FK_proj_ActionLogs_proj_User] FOREIGN KEY([userID])
REFERENCES [dbo].[proj_User] ([userID])
GO
ALTER TABLE [dbo].[proj_ActionLogs] CHECK CONSTRAINT [FK_proj_ActionLogs_proj_User]
GO
ALTER TABLE [dbo].[proj_Comment]  WITH CHECK ADD  CONSTRAINT [FK_proj_Comment_proj_Task] FOREIGN KEY([taskID])
REFERENCES [dbo].[proj_Task] ([taskID])
GO
ALTER TABLE [dbo].[proj_Comment] CHECK CONSTRAINT [FK_proj_Comment_proj_Task]
GO
ALTER TABLE [dbo].[proj_Comment]  WITH CHECK ADD  CONSTRAINT [FK_proj_Comment_proj_User] FOREIGN KEY([userID])
REFERENCES [dbo].[proj_User] ([userID])
GO
ALTER TABLE [dbo].[proj_Comment] CHECK CONSTRAINT [FK_proj_Comment_proj_User]
GO
ALTER TABLE [dbo].[proj_Document]  WITH CHECK ADD  CONSTRAINT [FK_proj_Document_proj_Task] FOREIGN KEY([taskID])
REFERENCES [dbo].[proj_Task] ([taskID])
GO
ALTER TABLE [dbo].[proj_Document] CHECK CONSTRAINT [FK_proj_Document_proj_Task]
GO
ALTER TABLE [dbo].[proj_Document]  WITH CHECK ADD  CONSTRAINT [FK_proj_Document_proj_User] FOREIGN KEY([userID])
REFERENCES [dbo].[proj_User] ([userID])
GO
ALTER TABLE [dbo].[proj_Document] CHECK CONSTRAINT [FK_proj_Document_proj_User]
GO
ALTER TABLE [dbo].[proj_ExceptionLog]  WITH CHECK ADD  CONSTRAINT [FK_proj_ExceptionLog_proj_User] FOREIGN KEY([userID])
REFERENCES [dbo].[proj_User] ([userID])
GO
ALTER TABLE [dbo].[proj_ExceptionLog] CHECK CONSTRAINT [FK_proj_ExceptionLog_proj_User]
GO
ALTER TABLE [dbo].[proj_Notification]  WITH CHECK ADD  CONSTRAINT [FK_proj_Notification_proj_User] FOREIGN KEY([userID])
REFERENCES [dbo].[proj_User] ([userID])
GO
ALTER TABLE [dbo].[proj_Notification] CHECK CONSTRAINT [FK_proj_Notification_proj_User]
GO
ALTER TABLE [dbo].[proj_ProjectUser]  WITH CHECK ADD  CONSTRAINT [FK_proj_ProjectUser_proj_Project] FOREIGN KEY([projectID])
REFERENCES [dbo].[proj_Project] ([projectID])
GO
ALTER TABLE [dbo].[proj_ProjectUser] CHECK CONSTRAINT [FK_proj_ProjectUser_proj_Project]
GO
ALTER TABLE [dbo].[proj_ProjectUser]  WITH CHECK ADD  CONSTRAINT [FK_proj_ProjectUser_proj_User1] FOREIGN KEY([userID])
REFERENCES [dbo].[proj_User] ([userID])
GO
ALTER TABLE [dbo].[proj_ProjectUser] CHECK CONSTRAINT [FK_proj_ProjectUser_proj_User1]
GO
ALTER TABLE [dbo].[proj_Task]  WITH CHECK ADD  CONSTRAINT [FK_proj_Task_proj_Project] FOREIGN KEY([projectID])
REFERENCES [dbo].[proj_Project] ([projectID])
GO
ALTER TABLE [dbo].[proj_Task] CHECK CONSTRAINT [FK_proj_Task_proj_Project]
GO
ALTER TABLE [dbo].[proj_Task]  WITH CHECK ADD  CONSTRAINT [FK_proj_Task_proj_Status] FOREIGN KEY([statusID])
REFERENCES [dbo].[proj_Status] ([statusID])
GO
ALTER TABLE [dbo].[proj_Task] CHECK CONSTRAINT [FK_proj_Task_proj_Status]
GO
ALTER TABLE [dbo].[proj_Task]  WITH CHECK ADD  CONSTRAINT [FK_proj_Task_proj_User] FOREIGN KEY([userID])
REFERENCES [dbo].[proj_User] ([userID])
GO
ALTER TABLE [dbo].[proj_Task] CHECK CONSTRAINT [FK_proj_Task_proj_User]
GO
USE [master]
GO
ALTER DATABASE [TaskMasterDB] SET  READ_WRITE 
GO

