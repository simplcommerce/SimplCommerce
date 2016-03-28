DELETE FROM [dbo].[Core_UrlSlug]
GO
DELETE FROM [dbo].[Core_ProductAttributeCombination]
GO
DELETE FROM [dbo].[Core_ProductVariation]
GO
DELETE FROM [dbo].[Core_ProductAttributeValue]
GO
DELETE FROM [dbo].[Core_ProductAttribute]
GO
DELETE FROM [dbo].[Core_ProductMedia]
GO
DELETE FROM [dbo].[Core_ProductCategory]
GO
DELETE FROM [dbo].[Core_Product]
GO
DELETE FROM [dbo].[Core_Media]
GO
DELETE FROM [dbo].[Core_Category]
GO
SET IDENTITY_INSERT [dbo].[Core_Category] ON 
INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (1, N'Phones', N'mobile-tablets', NULL, 0, 1, 0, NULL, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (2, N'Smart Phones', N'smart-phones', NULL, 0, 1, 0, 1, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (3, N'Basic Phones', N'basic-phones', NULL, 0, 1, 0, 1, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (4, N'Tablets', N'tablets', NULL, 0, 1, 0, NULL, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (5, N'Wifi + Cellular tablets', N'wifi-cellular-tablets', NULL, 0, 1, 0, 4, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (6, N'Cellular tablets', N'cellular-tablets', NULL, 0, 1, 0, 4, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (7, N'Computers', N'desktops', NULL, 0, 1, 0, NULL, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (8, N'Gaming', N'gaming', NULL, 0, 1, 0, 7, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (9, N'Business', N'business', NULL, 0, 1, 0, 7, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (10, N'Accessories', N'accessories', NULL, 0, 1, 0, NULL, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (11, N'Headphones', N'headphones', NULL, 0, 1, 0, 10, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (12, N'Cables', N'cables', NULL, 0, 1, 0, 10, NULL)

INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (13, N'USB Drives', N'usb-drives', NULL, 0, 1, 0, 10, NULL)

SET IDENTITY_INSERT [dbo].[Core_Category] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_Media] ON 
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (1, NULL, 0, N'e52bfa6b-415d-4282-8c41-18411413fd65..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (2, NULL, 0, N'50df8e5c-4726-4d5d-9554-f61166716683..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (3, NULL, 0, N'a6cfacc4-2b60-4f02-b197-6c53bf2c6eaf..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (4, NULL, 0, N'a8788571-6be9-485a-87b4-d7d5736a993e..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (5, NULL, 0, N'b8379df7-c020-494f-9857-2a1a3f001a46..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (6, NULL, 0, N'7624a48e-6494-4678-b96f-18ccffadf821..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (7, NULL, 0, N'eb857768-ef93-4e46-8ee1-bda89f433673..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (8, NULL, 0, N'66b37c29-3481-46ba-91e2-8baa915ec1eb..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (9, NULL, 0, N'7707f8c1-f946-4c75-8fc4-c33d9f49aa91..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (10, NULL, 0, N'9973292e-e318-432d-b862-3e33861e3a84..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (11, NULL, 0, N'022056b4-f952-4831-9f1e-e0f71689a6db..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (12, NULL, 0, N'7422495a-1444-4e2d-920b-4f9f84223260..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (13, NULL, 0, N'866a8745-28ed-4a8e-beb0-578bf1294397..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (14, NULL, 0, N'2ddb06fc-922d-4062-8198-7686b9ce7e13..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (15, NULL, 0, N'75d7d6f0-5b4d-4542-9825-cfdad5624ab5..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (16, NULL, 0, N'b35ff42e-5ddc-4932-baee-6604eea0cded..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (17, NULL, 0, N'ccd95afe-06fa-40df-9151-382db77ca540..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (18, NULL, 0, N'0868831f-d370-4de8-ad7a-6e938755f1c0..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (19, NULL, 0, N'97d6d80a-2376-4184-a90c-3b52f44d8b3e..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (20, NULL, 0, N'61285b70-e865-4f8b-ba83-827f96e690d3..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (21, NULL, 0, N'89a21727-15fd-4b86-b4af-1c0445cc3205..jpg', 0)

INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (22, NULL, 0, N'cb7ba387-69ec-4568-ad48-0f37010cc839..jpg', 0)

SET IDENTITY_INSERT [dbo].[Core_Media] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_Product] ON 
INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (1, N'Màn hình Retina 3D Touch
Chip xử lý A9 64-bit tiên tiến; Hệ điều hành iOS 9
RAM 2GB; ROM 16GB
Camera trước 5MP; Camera sau 12MP
Quay phim độ phân giải 4K
Vỏ nhôm Aluminum 7000 Series chắc chắn', N'Tiếp nối thành công từ những phiên bản trước đó, mới đây ngày 10/9/2015 Apple đã cho ra mắt iPhone 6s trong sự kiện Hey Siri vốn được hàng triệu tín đồ Apple mong chờ từ trước đó nửa năm. Hai siêu phẩm iPhone 6s và 6s Plus ngoài các phiên bản màu sắc gồm vàng, bạc và xám như mẫu iPhone 6, 6 Plus tiền nhiệm còn được hãng Apple “ưu ái” bổ sung màu vàng hồng không kém phần sang trọng. Phái đẹp trên toàn thế giới chắc chắn sẽ đánh giá cao sự bổ sung tuyệt vời này từ Apple.

Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.', NULL, CAST(8490000.00 AS Decimal(18, 2)), CAST(11999000.00 AS Decimal(18, 2)), 0, N'iPhone 5S 16G', N'iphone-5s-16g', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-15 22:42:39.073' AS DateTime), CAST(N'2016-03-15 22:42:39.073' AS DateTime), NULL, 6, NULL)

INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (2, N'Màn hình Retina 3D Touch
Chip xử lý A9 64-bit tiên tiến; Hệ điều hành iOS 9
RAM 2GB; ROM 16GB
Camera trước 5MP; Camera sau 12MP
Quay phim độ phân giải 4K
Vỏ nhôm Aluminum 7000 Series chắc chắn', N'Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.

Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.

Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.

Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.
', NULL, CAST(16880000.00 AS Decimal(18, 2)), CAST(17380000.00 AS Decimal(18, 2)), 0, N'iPhone 6s 16GB', N'iphone-6s-16gb', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-15 22:52:49.610' AS DateTime), CAST(N'2016-03-15 22:52:49.610' AS DateTime), NULL, 12, NULL)

INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (3, N'Màn hình: FullHD, 5.2 inches
HĐH: Android 5.1 Lollipop
CPU: 8 nhân 1.6GHz, RAM 2GB
Camera: 13.0MP, 2 SIM
Dung lượng pin: 2900 mAh', N'Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.

Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.


Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.

Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.
', NULL, CAST(8999000.00 AS Decimal(18, 2)), CAST(9999000.00 AS Decimal(18, 2)), 0, N'Samsung Galaxy A5', N'samsung-galaxy-a5', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-15 23:08:42.637' AS DateTime), CAST(N'2016-03-15 23:08:42.637' AS DateTime), NULL, 18, NULL)

INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (4, N'Bảo hành 12 tháng (hóa đơn)
Thiết kế vượt trội với màn hình "ngoại cỡ" 12.9 inch
Cấu hình mạnh mẽ; hiệu năng nhanh hơn Laptop
Tương tác thông minh; làm hai việc cùng lúc', N'Là hàng được nhập khẩu trực tiếp từ nước ngoài bởi doanh nghiệp trong nước, không thông qua nhà phân phối chính thức tại thị trường Việt Nam.

Hàng nhập khẩu được nhiều người chọn lựa bởi giá thành tốt, chất lượng vẫn được đảm bảo như những sản phẩm được nhập khẩu thông qua nhà phân phối chính thức (vì được sản xuất từ cùng một nhà máy của hãng sản xuất). Hơn nữa, dù không được bảo hành tại các trung tâm bảo hành chính thức của hãng, các sản phẩm này vẫn được áp dụng đầy đủ chính sách bảo hành của doanh nghiệp nhập khẩu.
Là hàng được nhập khẩu trực tiếp từ nước ngoài bởi doanh nghiệp trong nước, không thông qua nhà phân phối chính thức tại thị trường Việt Nam.

Hàng nhập khẩu được nhiều người chọn lựa bởi giá thành tốt, chất lượng vẫn được đảm bảo như những sản phẩm được nhập khẩu thông qua nhà phân phối chính thức (vì được sản xuất từ cùng một nhà máy của hãng sản xuất). Hơn nữa, dù không được bảo hành tại các trung tâm bảo hành chính thức của hãng, các sản phẩm này vẫn được áp dụng đầy đủ chính sách bảo hành của doanh nghiệp nhập khẩu.
Là hàng được nhập khẩu trực tiếp từ nước ngoài bởi doanh nghiệp trong nước, không thông qua nhà phân phối chính thức tại thị trường Việt Nam.

Hàng nhập khẩu được nhiều người chọn lựa bởi giá thành tốt, chất lượng vẫn được đảm bảo như những sản phẩm được nhập khẩu thông qua nhà phân phối chính thức (vì được sản xuất từ cùng một nhà máy của hãng sản xuất). Hơn nữa, dù không được bảo hành tại các trung tâm bảo hành chính thức của hãng, các sản phẩm này vẫn được áp dụng đầy đủ chính sách bảo hành của doanh nghiệp nhập khẩu.', NULL, CAST(21290000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), 0, N'iPad Pro Wi-Fi 4G 128GB', N'ipad-pro-wi-fi-4g-128gb', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-15 23:16:27.487' AS DateTime), CAST(N'2016-03-15 23:16:27.487' AS DateTime), NULL, 22, NULL)

SET IDENTITY_INSERT [dbo].[Core_Product] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_ProductCategory] ON 
INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (1, 0, 0, 1, 1)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (2, 0, 0, 2, 1)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (3, 0, 0, 1, 2)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (4, 0, 0, 2, 2)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (5, 0, 0, 1, 3)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (6, 0, 0, 2, 3)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (7, 0, 0, 1, 4)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (8, 0, 0, 2, 4)

SET IDENTITY_INSERT [dbo].[Core_ProductCategory] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_ProductMedia] ON 
INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (1, 1, 1, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (2, 1, 2, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (3, 1, 3, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (4, 1, 4, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (5, 1, 5, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (6, 2, 7, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (7, 2, 8, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (8, 2, 9, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (9, 2, 10, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (10, 2, 11, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (11, 3, 13, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (12, 3, 14, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (13, 3, 15, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (14, 3, 16, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (15, 3, 17, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (16, 4, 19, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (17, 4, 20, 0)

INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (18, 4, 21, 0)

SET IDENTITY_INSERT [dbo].[Core_ProductMedia] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_ProductAttribute] ON 
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name]) VALUES (1, N'Color')

INSERT [dbo].[Core_ProductAttribute] ([Id], [Name]) VALUES (2, N'Size')

SET IDENTITY_INSERT [dbo].[Core_ProductAttribute] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_ProductAttributeValue] ON 
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (1, 1, 1, N'Black')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (2, 1, 1, N'White')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (3, 1, 2, N'Pink')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (4, 1, 2, N'Gold')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (5, 1, 2, N'Gray')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (6, 1, 2, N'Silver')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (7, 1, 3, N'Pink')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (8, 1, 3, N'Black')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (9, 1, 3, N'Gold')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (10, 1, 4, N'Gold')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (11, 1, 4, N'Gray')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (12, 1, 4, N'Silver')

SET IDENTITY_INSERT [dbo].[Core_ProductAttributeValue] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_ProductVariation] ON 
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (1, N'Pink', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 15:52:49.610' AS DateTime), CAST(N'2016-03-15 15:52:49.610' AS DateTime), NULL, 2, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (2, N'Gold', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 15:52:49.613' AS DateTime), CAST(N'2016-03-15 15:52:49.613' AS DateTime), NULL, 2, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (3, N'Gray', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 15:52:49.613' AS DateTime), CAST(N'2016-03-15 15:52:49.613' AS DateTime), NULL, 2, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (4, N'Silver', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 15:52:49.613' AS DateTime), CAST(N'2016-03-15 15:52:49.613' AS DateTime), NULL, 2, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (5, N'Pink', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:08:42.637' AS DateTime), CAST(N'2016-03-15 16:08:42.637' AS DateTime), NULL, 3, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (6, N'Black', NULL, CAST(-1000.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:08:42.637' AS DateTime), CAST(N'2016-03-15 16:08:42.637' AS DateTime), NULL, 3, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (7, N'Gold', NULL, CAST(1000.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:08:42.637' AS DateTime), CAST(N'2016-03-15 16:08:42.637' AS DateTime), NULL, 3, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (8, N'Gold', NULL, CAST(1000.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:16:27.487' AS DateTime), CAST(N'2016-03-15 16:16:27.487' AS DateTime), NULL, 4, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (9, N'Gray', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:16:27.487' AS DateTime), CAST(N'2016-03-15 16:16:27.487' AS DateTime), NULL, 4, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (10, N'Silver', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:16:27.487' AS DateTime), CAST(N'2016-03-15 16:16:27.487' AS DateTime), NULL, 4, NULL)

SET IDENTITY_INSERT [dbo].[Core_ProductVariation] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_ProductAttributeCombination] ON 
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (1, 1, 1, N'Pink')

INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (2, 2, 1, N'Gold')

INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (3, 3, 1, N'Gray')

INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (4, 4, 1, N'Silver')

INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (5, 5, 1, N'Pink')

INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (6, 6, 1, N'Black')

INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (7, 7, 1, N'Gold')

INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (8, 8, 1, N'Gold')

INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (9, 9, 1, N'Gray')

INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (10, 10, 1, N'Silver')

SET IDENTITY_INSERT [dbo].[Core_ProductAttributeCombination] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_UrlSlug] ON 
INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (1, N'mobile-tablets', 1, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (2, N'smart-phones', 2, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (3, N'basic-phones', 3, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (4, N'tablets', 4, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (5, N'wifi-cellular-tablets', 5, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (6, N'cellular-tablets', 6, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (7, N'desktops', 7, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (8, N'gaming', 8, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (9, N'business', 9, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (10, N'accessories', 10, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (11, N'headphones', 11, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (12, N'cables', 12, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (13, N'usb-drives', 13, N'Category')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (14, N'iphone-5s-16g', 1, N'Product')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (15, N'iphone-6s-16gb', 2, N'Product')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (16, N'samsung-galaxy-a5', 3, N'Product')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (17, N'ipad-pro-wi-fi-4g-128gb', 4, N'Product')

SET IDENTITY_INSERT [dbo].[Core_UrlSlug] OFF
GO
