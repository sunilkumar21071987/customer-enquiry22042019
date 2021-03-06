USE [UserDB]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 4/15/2019 12:56:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [nvarchar](10) NOT NULL,
	[CustomerName] [nvarchar](30) NOT NULL,
	[ContactEmail] [nvarchar](25) NOT NULL,
	[MobileNo] [nvarchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transaction]    Script Date: 4/15/2019 12:56:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transaction](
	[TransactionID] [int] IDENTITY(1,1) NOT NULL,
	[TransactionDate] [datetime] NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[CurrencyCode] [nvarchar](3) NOT NULL,
	[Status] [int] NOT NULL,
	[CustomerID] [nvarchar](10) NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [ContactEmail], [MobileNo]) VALUES (N'1001', N'Sunil', N'sunil.kumar@gmail.com', N'9867121212')
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [ContactEmail], [MobileNo]) VALUES (N'1002', N'Anil', N'anil.kumar@gmail.com', N'9718122212')
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [ContactEmail], [MobileNo]) VALUES (N'1003', N'Kapil', N'kapil.kumar@gmail.com', N'9717312121')
SET IDENTITY_INSERT [dbo].[Transaction] ON 

INSERT [dbo].[Transaction] ([TransactionID], [TransactionDate], [Amount], [CurrencyCode], [Status], [CustomerID]) VALUES (3, CAST(N'2019-04-15T12:26:08.563' AS DateTime), CAST(101.00 AS Decimal(18, 2)), N'THD', 0, N'1001')
INSERT [dbo].[Transaction] ([TransactionID], [TransactionDate], [Amount], [CurrencyCode], [Status], [CustomerID]) VALUES (4, CAST(N'2019-04-14T12:26:39.843' AS DateTime), CAST(102.00 AS Decimal(18, 2)), N'THD', 1, N'1002')
INSERT [dbo].[Transaction] ([TransactionID], [TransactionDate], [Amount], [CurrencyCode], [Status], [CustomerID]) VALUES (5, CAST(N'2019-04-13T12:27:00.090' AS DateTime), CAST(103.00 AS Decimal(18, 2)), N'THD', 1, N'1003')
INSERT [dbo].[Transaction] ([TransactionID], [TransactionDate], [Amount], [CurrencyCode], [Status], [CustomerID]) VALUES (6, CAST(N'2019-04-13T12:27:10.100' AS DateTime), CAST(103.00 AS Decimal(18, 2)), N'THD', 1, N'1001')
INSERT [dbo].[Transaction] ([TransactionID], [TransactionDate], [Amount], [CurrencyCode], [Status], [CustomerID]) VALUES (7, CAST(N'2019-04-13T12:27:14.857' AS DateTime), CAST(103.00 AS Decimal(18, 2)), N'THD', 1, N'1002')
INSERT [dbo].[Transaction] ([TransactionID], [TransactionDate], [Amount], [CurrencyCode], [Status], [CustomerID]) VALUES (8, CAST(N'2019-04-13T12:27:23.397' AS DateTime), CAST(103.00 AS Decimal(18, 2)), N'THD', 2, N'1002')
SET IDENTITY_INSERT [dbo].[Transaction] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Customer__A4AE64B90AB0B333]    Script Date: 4/15/2019 12:56:28 PM ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Customer__FFA796CDCAF3E406]    Script Date: 4/15/2019 12:56:28 PM ******/
ALTER TABLE [dbo].[Customer] ADD UNIQUE NONCLUSTERED 
(
	[ContactEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[enq_CustomerDetail]    Script Date: 4/15/2019 12:56:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[enq_CustomerDetail] 
@CustomerID nvarchar(10),
@Email nvarchar(25)
as
begin
select CustomerID, CustomerName name, ContactEmail email, MobileNo mobile from Customer 
where CustomerID = @CustomerID or ContactEmail=@email

select TransactionID id, TransactionDate date, Amount amount, CurrencyCode currency, [Status] [status]
from [Transaction] where CustomerID = @CustomerID

end
GO
