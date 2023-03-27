SET IDENTITY_INSERT [dbo].[Booking] ON
INSERT INTO [dbo].[Booking] ([Id], [customerName], [centerName], [startDate], [endDate]) VALUES (1, N'James', N'sliit', N'2022-10-19', N'2022-10-29')
INSERT INTO [dbo].[Booking] ([Id], [customerName], [centerName], [startDate], [endDate]) VALUES (2, N'sliit     ', N'Nuzha     ', NULL, N'2022-10-21')
INSERT INTO [dbo].[Booking] ([Id], [customerName], [centerName], [startDate], [endDate]) VALUES (3, N'sliit     ', N'Nuzha     ', NULL, N'2022-10-23')
INSERT INTO [dbo].[Booking] ([Id], [customerName], [centerName], [startDate], [endDate]) VALUES (4, N'sliit     ', N'Nuzha     ', N'2022-11-11', N'2022-11-26')
INSERT INTO [dbo].[Booking] ([Id], [customerName], [centerName], [startDate], [endDate]) VALUES (5, N'sliit     ', N'Nuzha     ', N'2022-11-11', N'2022-11-26')
INSERT INTO [dbo].[Booking] ([Id], [customerName], [centerName], [startDate], [endDate]) VALUES (6, N'Ocean     ', N'Anne      ', N'2022-10-21', N'2022-11-05')
SET IDENTITY_INSERT [dbo].[Booking] OFF

truncate table [dbo].[Booking]