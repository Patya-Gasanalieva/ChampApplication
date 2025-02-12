USE [dbPersonalManagement]
GO
/****** Object:  Table [dbo].[Absences]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absences](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[ReplacementID] [int] NOT NULL,
	[Reason] [nvarchar](50) NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_Absences] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calendars]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calendars](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalendarTypeID] [int] NOT NULL,
	[DivisionID] [int] NULL,
	[EmployeeID] [int] NOT NULL,
 CONSTRAINT [PK_Calendars] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CalendarTypes]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CalendarTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CalendarTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CalendarTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Candidates]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Candidates](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[Resume] [nvarchar](max) NOT NULL,
	[ApplicationDate] [date] NOT NULL,
	[Area] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentID] [int] NOT NULL,
	[Text] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	[AuthorID] [int] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Divisions]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Divisions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[DivisionName] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[DirectorID] [int] NULL,
 CONSTRAINT [PK_Divisions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titile] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NOT NULL,
	[Category] [nvarchar](50) NOT NULL,
	[HasComments] [bit] NOT NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[BirthDay] [date] NULL,
	[DivisionID] [int] NULL,
	[PositionID] [int] NULL,
	[WorkPhone] [nvarchar](20) NULL,
	[Cabinet] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[MobilePhone] [nvarchar](20) NULL,
	[DirectorID] [int] NULL,
	[AssistantID] [int] NULL,
	[OtherInfo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventName] [nvarchar](50) NOT NULL,
	[EventStatusID] [int] NOT NULL,
	[EventTypeID] [int] NOT NULL,
	[StrartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[ResponsiblePerson] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventStatuses]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventStatuses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventStatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EventStatuses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventTypes]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_EventTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialName] [nvarchar](50) NOT NULL,
	[ApprovalDate] [date] NOT NULL,
	[ModificationDate] [date] NOT NULL,
	[MaterialStatusID] [int] NOT NULL,
	[MaterialTypeID] [int] NOT NULL,
	[Area] [nvarchar](50) NOT NULL,
	[AuthorID] [int] NOT NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialStatuses]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialStatuses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialStatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MaterialStatuses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialTypes]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaterialTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MaterialTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Positions]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PostName] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Positions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainingClasses]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainingClasses](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[MaterialID] [int] NULL,
 CONSTRAINT [PK_TrainingClasses] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkingCalendar]    Script Date: 01.02.2025 13:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkingCalendar](
	[Id] [bigint] NOT NULL,
	[ExceptionDate] [date] NOT NULL,
	[IsWorkingDay] [bit] NOT NULL,
 CONSTRAINT [WorkingCalendar_pk] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Absences]  WITH CHECK ADD  CONSTRAINT [FK_Absences_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Absences] CHECK CONSTRAINT [FK_Absences_Employees]
GO
ALTER TABLE [dbo].[Absences]  WITH CHECK ADD  CONSTRAINT [FK_Absences_Employees1] FOREIGN KEY([ReplacementID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Absences] CHECK CONSTRAINT [FK_Absences_Employees1]
GO
ALTER TABLE [dbo].[Absences]  WITH CHECK ADD  CONSTRAINT [FK_Absences_Employees2] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Absences] CHECK CONSTRAINT [FK_Absences_Employees2]
GO
ALTER TABLE [dbo].[Calendars]  WITH CHECK ADD  CONSTRAINT [FK_Calendars_CalendarTypes] FOREIGN KEY([CalendarTypeID])
REFERENCES [dbo].[CalendarTypes] ([ID])
GO
ALTER TABLE [dbo].[Calendars] CHECK CONSTRAINT [FK_Calendars_CalendarTypes]
GO
ALTER TABLE [dbo].[Calendars]  WITH CHECK ADD  CONSTRAINT [FK_Calendars_Divisions] FOREIGN KEY([DivisionID])
REFERENCES [dbo].[Divisions] ([ID])
GO
ALTER TABLE [dbo].[Calendars] CHECK CONSTRAINT [FK_Calendars_Divisions]
GO
ALTER TABLE [dbo].[Calendars]  WITH CHECK ADD  CONSTRAINT [FK_Calendars_Employees] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Calendars] CHECK CONSTRAINT [FK_Calendars_Employees]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Documents] FOREIGN KEY([DocumentID])
REFERENCES [dbo].[Documents] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Documents]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Employees] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Employees]
GO
ALTER TABLE [dbo].[Divisions]  WITH CHECK ADD  CONSTRAINT [FK_Divisions_Employees] FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Divisions] CHECK CONSTRAINT [FK_Divisions_Employees]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Divisions] FOREIGN KEY([DivisionID])
REFERENCES [dbo].[Divisions] ([ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Divisions]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees1] FOREIGN KEY([AssistantID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees1]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Positions] FOREIGN KEY([PositionID])
REFERENCES [dbo].[Positions] ([ID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Positions]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventStatuses] FOREIGN KEY([EventStatusID])
REFERENCES [dbo].[EventStatuses] ([ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventStatuses]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_EventTypes] FOREIGN KEY([EventTypeID])
REFERENCES [dbo].[EventTypes] ([ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_EventTypes]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_Employees] FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Employees] ([ID])
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_Employees]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_MaterialStatuses] FOREIGN KEY([MaterialStatusID])
REFERENCES [dbo].[MaterialStatuses] ([ID])
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_MaterialStatuses]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_Materials_MaterialTypes] FOREIGN KEY([MaterialTypeID])
REFERENCES [dbo].[MaterialTypes] ([ID])
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_Materials_MaterialTypes]
GO
ALTER TABLE [dbo].[TrainingClasses]  WITH CHECK ADD  CONSTRAINT [FK_TrainingClasses_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([ID])
GO
ALTER TABLE [dbo].[TrainingClasses] CHECK CONSTRAINT [FK_TrainingClasses_Events]
GO
ALTER TABLE [dbo].[TrainingClasses]  WITH CHECK ADD  CONSTRAINT [FK_TrainingClasses_Materials] FOREIGN KEY([MaterialID])
REFERENCES [dbo].[Materials] ([ID])
GO
ALTER TABLE [dbo].[TrainingClasses] CHECK CONSTRAINT [FK_TrainingClasses_Materials]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Идентификатор строки' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkingCalendar', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'День-исключение' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkingCalendar', @level2type=N'COLUMN',@level2name=N'ExceptionDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 - будний день, но законодательно принят выходным' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkingCalendar', @level2type=N'COLUMN',@level2name=N'IsWorkingDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Список дней исключений в производственном календаре' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WorkingCalendar'
GO
