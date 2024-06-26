
USE [BeSpokedBikes]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 19/5/2024 7:57:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [varchar](50) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Phone] [varchar](11) NOT NULL,
	[Address] [varchar](250) NULL,
	[StartDate] [datetimeoffset](7) NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Discount]    Script Date: 19/5/2024 7:57:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Discount](
	[ProductId] [varchar](50) NOT NULL,
	[Id] [varchar](50) NOT NULL,
	[BeginDate] [datetimeoffset](7) NOT NULL,
	[EndDate] [datetimeoffset](7) NOT NULL,
	[DiscountPercentage] [float] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Discount] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 19/5/2024 7:57:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Manufacturer] [varchar](50) NOT NULL,
	[Style] [varchar](50) NOT NULL,
	[PurchasePrice] [real] NOT NULL,
	[SalePrice] [float] NULL,
	[QtyOnHand] [int] NOT NULL,
	[CommissionPercentage] [float] NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 19/5/2024 7:57:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[ProductId] [varchar](50) NOT NULL,
	[SalespersonId] [varchar](50) NOT NULL,
	[CustomerId] [varchar](50) NOT NULL,
	[Id] [varchar](50) NOT NULL,
	[SalesDate] [datetimeoffset](7) NOT NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salesperson]    Script Date: 19/5/2024 7:57:59 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salesperson](
	[Id] [varchar](50) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Phone] [varchar](11) NOT NULL,
	[Address] [varchar](250) NULL,
	[StartDate] [datetimeoffset](7) NOT NULL,
	[TerminationDate] [datetimeoffset](7) NULL,
	[ManagerId] [varchar](50) NULL,
	[CreatedAt] [datetimeoffset](7) NOT NULL,
	[UpdatedAt] [datetimeoffset](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Salesperson] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'097eb3f7-2de7-42e0-8062-c3ed07d826bb', N'David', N'Brown', N'555-4040', N'321 Pine St, Springfield, USA', CAST(N'2022-03-10T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-05-19T18:37:52.2853676-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'1695f2e5-d0be-45ce-be74-e2ac152650d3', N'Bob', N'Smith', N'555-2020', N'456 Elm St, Springfield, USA', CAST(N'2020-05-20T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2024-05-19T18:37:52.2654374-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'78647851-5a1b-4c03-904c-7fd20b86f784', N'Mak', N'Rony', N'641-2330049', N'12012 Lake Union Hill Way', CAST(N'2024-05-18T19:43:20.9870000+00:00' AS DateTimeOffset), CAST(N'0001-01-01T00:00:00.0000000+00:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'7a917e03-2198-4c1e-b609-b8f12c61c28e', N'Alice', N'Johnson', N'555-1010', N'123 Main St, Springfield, USA', CAST(N'2021-01-15T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2024-05-19T18:37:49.6730171-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'97bd528b-9b67-41bc-b161-22ad753083a0', N'Eve', N'Davis', N'555-5050', N'654 Cedar St, Springfield, USA', CAST(N'2020-07-25T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2024-05-19T18:37:52.2899125-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Customer] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'df8fadf0-7c5f-45cb-a44d-d96b4210471d', N'Carol', N'Williams', N'555-3030', N'789 Oak St, Springfield, USA', CAST(N'2019-09-30T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2024-05-19T18:37:52.2786146-04:00' AS DateTimeOffset), NULL, 0)
GO
INSERT [dbo].[Products] ([Id], [Name], [Manufacturer], [Style], [PurchasePrice], [SalePrice], [QtyOnHand], [CommissionPercentage], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'cdd452a2-acc1-4b44-a19c-be3a6ed500f2', N'City Cruiser updated', N'UrbanRide', N'City', 350, 550, 30, 8, CAST(N'2024-05-19T08:36:01.4423508-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Products] ([Id], [Name], [Manufacturer], [Style], [PurchasePrice], [SalePrice], [QtyOnHand], [CommissionPercentage], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'd311f227-0a0a-45f8-8645-2020fc58adbf', N'Kids'' Fun Ride', N'JuniorBikes', N'JuniorBikes', 150, 300, 200, 9, CAST(N'2024-05-18T23:25:24.9858005-04:00' AS DateTimeOffset), CAST(N'2024-05-19T22:42:39.7216724+00:00' AS DateTimeOffset), 0)
INSERT [dbo].[Products] ([Id], [Name], [Manufacturer], [Style], [PurchasePrice], [SalePrice], [QtyOnHand], [CommissionPercentage], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'ec8e4b60-bfe1-488e-9f54-6627c7ce12fc', N'Beach Comber', N'SunCycle', N'Cruiser', 250, 400, 25, 7, CAST(N'2024-05-18T23:25:24.9662718-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Products] ([Id], [Name], [Manufacturer], [Style], [PurchasePrice], [SalePrice], [QtyOnHand], [CommissionPercentage], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'edecb225-e051-409b-b860-5fdb84ef8908', N'Mountain Explorer', N'TrailBlazer', N'Mountain', 600, 850, 14, 10, CAST(N'2024-05-18T23:25:23.0120117-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Products] ([Id], [Name], [Manufacturer], [Style], [PurchasePrice], [SalePrice], [QtyOnHand], [CommissionPercentage], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'f1748615-e098-44b0-955b-b8ca9ae9eb3b', N'Speed Demon', N'FastTrack', N'Road', 950, 1200, 10, 12, CAST(N'2024-05-18T23:25:24.9347187-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Products] ([Id], [Name], [Manufacturer], [Style], [PurchasePrice], [SalePrice], [QtyOnHand], [CommissionPercentage], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'f4c5e02c-6d06-4d0e-be20-30c36866c767', N'My new bike', N'MAK', N'City', 80, 100, 15, 9.5, CAST(N'2024-05-19T08:52:14.9184494-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Products] ([Id], [Name], [Manufacturer], [Style], [PurchasePrice], [SalePrice], [QtyOnHand], [CommissionPercentage], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'fa5e4f45-0e84-4914-b7e0-f0582fbae869', N'asda', N'asd', N'asd', 0, 0, 0, 0, CAST(N'2024-05-19T19:40:50.0844948-04:00' AS DateTimeOffset), NULL, 0)
GO
INSERT [dbo].[Sales] ([ProductId], [SalespersonId], [CustomerId], [Id], [SalesDate], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'd311f227-0a0a-45f8-8645-2020fc58adbf', N'fc073f5b-9321-452c-a00c-2daa5f3dad81', N'78647851-5a1b-4c03-904c-7fd20b86f784', N'3fa3f63b-fcac-45c0-b4d5-246dcc28d3c8', CAST(N'2024-05-19T20:51:19.6796566+00:00' AS DateTimeOffset), CAST(N'2024-05-19T16:51:19.6794573-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Sales] ([ProductId], [SalespersonId], [CustomerId], [Id], [SalesDate], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'ec8e4b60-bfe1-488e-9f54-6627c7ce12fc', N'6591e8b6-3e99-40bf-953b-6e07fd7e70c0', N'78647851-5a1b-4c03-904c-7fd20b86f784', N'4acb1fb8-ffe0-40f0-9bc2-3848e1162862', CAST(N'2024-05-19T14:15:40.7288970-04:00' AS DateTimeOffset), CAST(N'2024-05-19T14:15:40.7288970-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Sales] ([ProductId], [SalespersonId], [CustomerId], [Id], [SalesDate], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'edecb225-e051-409b-b860-5fdb84ef8908', N'81063219-8c6e-40cb-8064-ed95ab1e3fbc', N'97bd528b-9b67-41bc-b161-22ad753083a0', N'6128518c-6ad3-4b3d-b9a5-0fc401c126ae', CAST(N'2024-05-19T22:49:04.6573152+00:00' AS DateTimeOffset), CAST(N'2024-05-19T18:49:04.6570807-04:00' AS DateTimeOffset), NULL, 0)
GO
INSERT [dbo].[Salesperson] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [TerminationDate], [ManagerId], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'1221d13e-ac35-4663-b8b9-2eebf720d90d', N'Ema', N'Watson', N'6412330049', N'10004 Lake Union Hill Way Alpharetta 30004.', CAST(N'2021-09-10T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2030-06-30T00:00:00.0000000-04:00' AS DateTimeOffset), N'fc073f5b-9321-452c-a00c-2daa5f3dad81', CAST(N'2024-05-19T14:15:40.7288970-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Salesperson] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [TerminationDate], [ManagerId], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'6591e8b6-3e99-40bf-953b-6e07fd7e70c0', N'Bill', N'Johnson', N'555-9012', N'789 Oak St, Anothertown, USA', CAST(N'2018-07-01T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2030-06-30T00:00:00.0000000-04:00' AS DateTimeOffset), N'1221d13e-ac35-4663-b8b9-2eebf720d90d', CAST(N'2024-05-19T10:53:56.2089303-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Salesperson] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [TerminationDate], [ManagerId], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'76abf475-c246-4adf-8e1f-8210f3960724', N'John', N'Doe', N'555-1234', N'123 Main St, Anytown, USA', CAST(N'2020-01-15T00:00:00.0000000-05:00' AS DateTimeOffset), CAST(N'2030-06-30T00:00:00.0000000-04:00' AS DateTimeOffset), NULL, CAST(N'2024-05-19T10:53:52.2881246-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Salesperson] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [TerminationDate], [ManagerId], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'81063219-8c6e-40cb-8064-ed95ab1e3fbc', N'Chris', N'Brown', N'555-7890', N'654 Cedar St, Smalltown, USA', CAST(N'2020-05-18T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2030-06-30T00:00:00.0000000-04:00' AS DateTimeOffset), NULL, CAST(N'2024-05-19T10:53:56.2541057-04:00' AS DateTimeOffset), NULL, 0)
INSERT [dbo].[Salesperson] ([Id], [FirstName], [LastName], [Phone], [Address], [StartDate], [TerminationDate], [ManagerId], [CreatedAt], [UpdatedAt], [IsDeleted]) VALUES (N'fc073f5b-9321-452c-a00c-2daa5f3dad81', N'Jane', N'Smith', N'555-5678', N'456 Elm St, Othertown, USA', CAST(N'2019-03-22T00:00:00.0000000-04:00' AS DateTimeOffset), CAST(N'2030-06-30T00:00:00.0000000-04:00' AS DateTimeOffset), NULL, CAST(N'2024-05-19T10:53:56.1469604-04:00' AS DateTimeOffset), NULL, 0)
GO
ALTER TABLE [dbo].[Discount]  WITH CHECK ADD  CONSTRAINT [FK_Discount_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Discount] CHECK CONSTRAINT [FK_Discount_Products]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Customer]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Products]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Salesperson] FOREIGN KEY([SalespersonId])
REFERENCES [dbo].[Salesperson] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Salesperson]
GO
ALTER TABLE [dbo].[Salesperson]  WITH CHECK ADD  CONSTRAINT [FK_Salesperson_Salesperson] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Salesperson] ([Id])
GO
ALTER TABLE [dbo].[Salesperson] CHECK CONSTRAINT [FK_Salesperson_Salesperson]
GO
USE [master]
GO
ALTER DATABASE [BeSpokedBikes] SET  READ_WRITE 
GO
