DELETE FROM [dbo].[Core_Resource]
GO

SET IDENTITY_INSERT [dbo].[Core_Resource] ON 

INSERT [dbo].[Core_Resource] ([Id], [Key], [Value], [Culture]) VALUES (1, N'HomePage', N'Home Page', N'en-US')

INSERT [dbo].[Core_Resource] ([Id], [Key], [Value], [Culture]) VALUES (2, N'Administration', N'Administration', N'en-US')

INSERT [dbo].[Core_Resource] ([Id], [Key], [Value], [Culture]) VALUES (3, N'HomePage', N'Trang Chủ', N'vi-VN')

INSERT [dbo].[Core_Resource] ([Id], [Key], [Value], [Culture]) VALUES (4, N'Administration', N'Quản Trị', N'vi-VN')

SET IDENTITY_INSERT [dbo].[Core_Resource] OFF
GO

