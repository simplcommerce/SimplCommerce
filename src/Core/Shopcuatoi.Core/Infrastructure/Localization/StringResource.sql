DELETE FROM [dbo].[Core_StringResource]
GO

INSERT [dbo].[Core_StringResource] ([Culture], [Key], [Value]) VALUES 
('en-US', 'Common_Password', N'Password'),
('en-US', 'HomePage', N'Home Page'),
('en-US', 'Administration', N'Administration'),
('vi-VN', 'HomePage', N'Trang Chủ'),
('vi-VN', 'Administration', N'Quản Trị'); 
GO

