USE [loginTb]
GO
/****** Object:  Table [dbo].[IRBook]    Script Date: 19-10-23 10.51.16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IRBook](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[stu_enroll] [varchar](250) NOT NULL,
	[stu_name] [varchar](250) NOT NULL,
	[stu_dept] [varchar](250) NOT NULL,
	[stu_sem] [varchar](250) NOT NULL,
	[stu_contact] [bigint] NOT NULL,
	[stu_email] [varchar](250) NOT NULL,
	[book_name] [varchar](250) NOT NULL,
	[book_issue_book] [varchar](250) NOT NULL,
	[book_return_date] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[loginTable]    Script Date: 19-10-23 10.51.17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loginTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_loginTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewBook]    Script Date: 19-10-23 10.51.17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewBook](
	[bid] [int] IDENTITY(1,1) NOT NULL,
	[bName] [varchar](250) NOT NULL,
	[bAuthor] [varchar](250) NOT NULL,
	[bPubl] [varchar](250) NOT NULL,
	[bPDate] [varchar](250) NOT NULL,
	[bPrice] [bigint] NOT NULL,
	[bQuan] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[bid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewStudent]    Script Date: 19-10-23 10.51.17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewStudent](
	[stuid] [int] IDENTITY(1,1) NOT NULL,
	[sname] [varchar](250) NOT NULL,
	[enroll] [varchar](250) NOT NULL,
	[dep] [varchar](250) NOT NULL,
	[sem] [varchar](250) NOT NULL,
	[contact] [bigint] NOT NULL,
	[email] [varchar](250) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[stuid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student1]    Script Date: 19-10-23 10.51.17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[dob] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[IRBook] ON 

INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (1, N'21CEUOG050', N'shruti', N'CE', N'5', 6546534263, N'abc@gmail.com', N'Data Structure', N'10 April, 2022', N'23 APril, 2022')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (2, N'21CEUOG050', N'shruti', N'CE', N'5', 6767676767, N'abc@gmail.com', N'Oops', N'10 April, 2022', N'23 April, 2022')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (3, N'21CEUOG050', N'shruti', N'CE ', N'5', 6767676767, N'abc@gmail.com', N'Java', N'10 April, 2022', N'23 April, 2022')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (4, N'21ITUOG053', N'riya', N'IT ', N'5', 7878787878, N'abc@gmail.com', N'Microprocessor', N'23 APril, 2022', N'29 April, 2022')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (5, N'21CEUOS034', N'Priya', N'CE', N'5', 6756765667, N'xyz@gmail.com', N'Java', N'3 April, 2022', NULL)
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (6, N'21CEUOS034', N'Priya', N'CE', N'5', 6756765667, N'xyz@gmail.com', N'Oops', N'5 April, 2022', NULL)
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (7, N'21CEUOS034', N'Priya', N'CE', N'5', 6756765667, N'xyz@gmail.com', N'MicroProcessor', N'6 April, 2022', NULL)
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (8, N'21CEUOG050', N'shruti', N'CE', N'5', 6546534263, N'abc@gmail.com', N'Data Structure', N'20 August 2023', N'22 August 2023')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (9, N'21CEUOG051', N'shyam', N'CE', N'5', 4545454545, N'shyam@gmail.com', N'Advanced algorithms', N'3 October 2023', N'3 October 2023')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (10, N'21ecubg091', N'Hetvi', N'EC', N'5', 987654321, N'abc@yahoo.com', N'Microprocessor', N'3 October 2023', NULL)
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (11, N'21ecubg091', N'Hetvi', N'EC', N'5', 987654321, N'abc@yahoo.com', N'Microprocessor', N'3 October 2023', N'3 October 2023')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (12, N'21ecubg091', N'Hetvi', N'EC', N'5', 987654321, N'abc@yahoo.com', N'Microprocessor', N'3 October 2023', NULL)
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (13, N'21ecubg091', N'Hetvi', N'EC', N'5', 987654321, N'abc@yahoo.com', N'Microprocessor', N'3 October 2023', NULL)
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (14, N'21CEUOG050', N'shruti', N'CE', N'5', 6546534263, N'abc@gmail.com', N'Data Structure', N'3 October 2023', N'4 October 2023')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (15, N'21CEUOG050', N'shruti', N'CE', N'5', 6546534263, N'abc@gmail.com', N'Data Structure', N'3 October 2023', N'4 October 2023')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (16, N'21CEUOG050', N'shruti', N'CE', N'5', 6546534263, N'abc@gmail.com', N'Data Structure', N'3 October 2023', NULL)
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (17, N'21CEUOG051', N'shyam', N'CE', N'5', 4545454545, N'shyam@gmail.com', N'Microprocessor', N'4 October 2023', N'4 October 2023')
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (18, N'21CEUOG051', N'shyam', N'CE', N'5', 5656565656, N'shyam@gmail.com', N'Javascript', N'4 October 2023', NULL)
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (19, N'21CEUOG051', N'shyam', N'CE', N'5', 5656565656, N'shyam@gmail.com', N'Javascript', N'4 October 2023', NULL)
INSERT [dbo].[IRBook] ([id], [stu_enroll], [stu_name], [stu_dept], [stu_sem], [stu_contact], [stu_email], [book_name], [book_issue_book], [book_return_date]) VALUES (20, N'21CEUOG051', N'shyam', N'CE', N'5', 5656565656, N'shyam@gmail.com', N'Javascript', N'4 October 2023', N'4 October 2023')
SET IDENTITY_INSERT [dbo].[IRBook] OFF
GO
SET IDENTITY_INSERT [dbo].[loginTable] ON 

INSERT [dbo].[loginTable] ([id], [username], [password]) VALUES (1, N'shruti', N'sss')
INSERT [dbo].[loginTable] ([id], [username], [password]) VALUES (2, N'priya', N'ppp')
SET IDENTITY_INSERT [dbo].[loginTable] OFF
GO
SET IDENTITY_INSERT [dbo].[NewBook] ON 

INSERT [dbo].[NewBook] ([bid], [bName], [bAuthor], [bPubl], [bPDate], [bPrice], [bQuan]) VALUES (1, N'Data Structure', N'Jk Singh Kumar', N'R and D', N'20 April, 2022', 5000, 45)
INSERT [dbo].[NewBook] ([bid], [bName], [bAuthor], [bPubl], [bPDate], [bPrice], [bQuan]) VALUES (3, N'Java', N'Douglas', N'Sb Publication', N'12 August 2023', 500, 50)
INSERT [dbo].[NewBook] ([bid], [bName], [bAuthor], [bPubl], [bPDate], [bPrice], [bQuan]) VALUES (4, N'.Net Framework', N'net Kumar', N'Rk publication', N'18 July 2023', 800, 80)
INSERT [dbo].[NewBook] ([bid], [bName], [bAuthor], [bPubl], [bPDate], [bPrice], [bQuan]) VALUES (5, N'Microprocessor', N'mfp xyz', N'xyz publication', N'12 August 2023', 566, 34)
INSERT [dbo].[NewBook] ([bid], [bName], [bAuthor], [bPubl], [bPDate], [bPrice], [bQuan]) VALUES (6, N'Javascript', N'abc', N'abc', N'18 August 2023', 3456, 56)
INSERT [dbo].[NewBook] ([bid], [bName], [bAuthor], [bPubl], [bPDate], [bPrice], [bQuan]) VALUES (7, N'Advanced algorithms', N'AA', N'JK publication', N'3 October 2023', 600, 50)
INSERT [dbo].[NewBook] ([bid], [bName], [bAuthor], [bPubl], [bPDate], [bPrice], [bQuan]) VALUES (8, N'abc', N'abc', N'abc publication', N'4 October 2023', 250, 10)
SET IDENTITY_INSERT [dbo].[NewBook] OFF
GO
SET IDENTITY_INSERT [dbo].[NewStudent] ON 

INSERT [dbo].[NewStudent] ([stuid], [sname], [enroll], [dep], [sem], [contact], [email]) VALUES (1, N'shruti', N'21CEUOG050', N'CE', N'7', 6546534263, N'abc@gmail.com')
INSERT [dbo].[NewStudent] ([stuid], [sname], [enroll], [dep], [sem], [contact], [email]) VALUES (2, N'priya', N'21CEUOS034', N'CE', N'5', 6565545423, N'xyz@gmail.com')
INSERT [dbo].[NewStudent] ([stuid], [sname], [enroll], [dep], [sem], [contact], [email]) VALUES (3, N'riya', N'21ITUOG053', N'IT', N'5', 7676767676, N'pqr@gmail.com')
INSERT [dbo].[NewStudent] ([stuid], [sname], [enroll], [dep], [sem], [contact], [email]) VALUES (5, N'shyam', N'21CEUOG051', N'CE', N'5', 5656565656, N'shyam@gmail.com')
INSERT [dbo].[NewStudent] ([stuid], [sname], [enroll], [dep], [sem], [contact], [email]) VALUES (6, N'venu', N'22ITUOS060', N'IT', N'3', 2323232323, N'venu@gmail.com')
INSERT [dbo].[NewStudent] ([stuid], [sname], [enroll], [dep], [sem], [contact], [email]) VALUES (7, N'Het', N'21CEUOG051', N'CE', N'5', 1234567890, N'het@gmail.com')
INSERT [dbo].[NewStudent] ([stuid], [sname], [enroll], [dep], [sem], [contact], [email]) VALUES (8, N'Hetvi', N'21ecubg091', N'EC', N'5', 987654321, N'abc@yahoo.com')
INSERT [dbo].[NewStudent] ([stuid], [sname], [enroll], [dep], [sem], [contact], [email]) VALUES (9, N'shruti1', N'21CEUOG000', N'CE', N'5', 1234567890, N'shruti1@gmail.com')
SET IDENTITY_INSERT [dbo].[NewStudent] OFF
GO
SET IDENTITY_INSERT [dbo].[Student1] ON 

INSERT [dbo].[Student1] ([id], [name], [dob]) VALUES (1, N'Shruti', CAST(N'2003-09-11' AS Date))
INSERT [dbo].[Student1] ([id], [name], [dob]) VALUES (2, N'Kanya', CAST(N'2003-12-13' AS Date))
SET IDENTITY_INSERT [dbo].[Student1] OFF
GO
