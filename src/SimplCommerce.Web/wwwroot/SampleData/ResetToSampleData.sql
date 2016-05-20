DELETE FROM [dbo].[Core_UrlSlug]
GO
DELETE FROM [dbo].[Orders_CartItem]
GO
DELETE FROM [dbo].[Orders_OrderItem]
GO
DELETE FROM [dbo].[Orders_Order]
GO
DELETE FROM [dbo].[Core_ProductOptionCombination]
GO
DELETE FROM [dbo].[Core_ProductVariation]
GO
DELETE FROM [dbo].[Core_ProductOptionValue]
GO
DELETE FROM [dbo].[Core_ProductAttribute]
GO
DELETE FROM [dbo].[Core_ProductAttributeGroup]
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
DELETE FROM [dbo].[Core_Brand]
GO
DELETE FROM [dbo].[Core_ProductTemplateProductAttribute]
GO
DELETE FROM [dbo].[Core_ProductTemplate]
GO
DELETE FROM [dbo].[Core_Page]
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

SET IDENTITY_INSERT [dbo].[Core_Brand] ON 
INSERT [dbo].[Core_Brand] ([Id], [Name], [SeoTitle], [Description], [IsPublished], [IsDeleted]) VALUES (1, N'Apple', N'apple', NULL, 1, 0)
INSERT [dbo].[Core_Brand] ([Id], [Name], [SeoTitle], [Description], [IsPublished], [IsDeleted]) VALUES (2, N'Samsung', N'samsung', NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Core_Brand] OFF 
GO

SET IDENTITY_INSERT [dbo].[Core_ProductAttributeGroup] ON 
INSERT [dbo].[Core_ProductAttributeGroup] ([Id], [Name]) VALUES (1, N'General')
INSERT [dbo].[Core_ProductAttributeGroup] ([Id], [Name]) VALUES (2, N'Screen')
INSERT [dbo].[Core_ProductAttributeGroup] ([Id], [Name]) VALUES (3, N'Connectivity')
INSERT [dbo].[Core_ProductAttributeGroup] ([Id], [Name]) VALUES (4, N'Camera')
SET IDENTITY_INSERT [dbo].[Core_ProductAttributeGroup] OFF 
GO

SET IDENTITY_INSERT [dbo].[Core_ProductAttribute] ON 
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (1, N'CPU', 1)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (2, N'OS', 1)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (3, N'GPU', 1)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (4, N'RAM', 1)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (5, N'Capacity', 1)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (6, N'Size', 2)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (7, N'Type', 2)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (8, N'Resolution', 2)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (9, N'2G', 3)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (10, N'3G', 3)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (11, N'4G', 3)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (12, N'Wifi', 3)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (13, N'Bluetooth', 3)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (14, N'NFC', 3)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (15, N'USP', 3)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (16, N'GPS', 3)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (17, N'Main camera', 4)
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (18, N'Sub camera', 4)
SET IDENTITY_INSERT [dbo].[Core_ProductAttribute] OFF 
GO

SET IDENTITY_INSERT [dbo].[Core_ProductTemplate] ON 
INSERT [dbo].[Core_ProductTemplate] ([Id], [Name]) VALUES (1, N'Tablet')
INSERT [dbo].[Core_ProductTemplate] ([Id], [Name]) VALUES (2, N'Phone')
SET IDENTITY_INSERT [dbo].[Core_ProductTemplate] OFF 
GO

INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (1, 1)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (1, 2)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (1, 3)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (1, 4)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 1)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 2)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 3)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 4)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 5)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 6)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 7)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 8)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 11)
INSERT [dbo].[Core_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 17)
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
INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [BrandId], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (1, N'Màn hình Retina 3D TouchChip xử lý A9 64-bit tiên tiến; Hệ điều hành iOS 9RAM 2GB; ROM 16GBCamera trước 5MP; Camera sau 12MPQuay phim độ phân giải 4KVỏ nhôm Aluminum 7000 Series chắc chắn', N'Tiếp nối thành công từ những phiên bản trước đó, mới đây ngày 10/9/2015 Apple đã cho ra mắt iPhone 6s trong sự kiện Hey Siri vốn được hàng triệu tín đồ Apple mong chờ từ trước đó nửa năm. Hai siêu phẩm iPhone 6s và 6s Plus ngoài các phiên bản màu sắc gồm vàng, bạc và xám như mẫu iPhone 6, 6 Plus tiền nhiệm còn được hãng Apple “ưu ái” bổ sung màu vàng hồng không kém phần sang trọng. Phái đẹp trên toàn thế giới chắc chắn sẽ đánh giá cao sự bổ sung tuyệt vời này từ Apple.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.', NULL, CAST(8490000.00 AS Decimal(18, 2)), CAST(11999000.00 AS Decimal(18, 2)), 0, 1, N'iPhone 5S 16G', N'iphone-5s-16g', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-15 22:42:39.073' AS DateTime), CAST(N'2016-03-15 22:42:39.073' AS DateTime), NULL, 6, NULL)

INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [BrandId], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (2, N'Màn hình Retina 3D TouchChip xử lý A9 64-bit tiên tiến; Hệ điều hành iOS 9RAM 2GB; ROM 16GBCamera trước 5MP; Camera sau 12MPQuay phim độ phân giải 4KVỏ nhôm Aluminum 7000 Series chắc chắn', N'Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.', NULL, CAST(16880000.00 AS Decimal(18, 2)), CAST(17380000.00 AS Decimal(18, 2)), 0, 1, N'iPhone 6s 16GB', N'iphone-6s-16gb', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-15 22:52:49.610' AS DateTime), CAST(N'2016-03-15 22:52:49.610' AS DateTime), NULL, 12, NULL)

INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [BrandId], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (3, N'Màn hình: FullHD, 5.2 inchesHĐH: Android 5.1 LollipopCPU: 8 nhân 1.6GHz, RAM 2GBCamera: 13.0MP, 2 SIMDung lượng pin: 2900 mAh', N'Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.', NULL, CAST(8999000.00 AS Decimal(18, 2)), CAST(9999000.00 AS Decimal(18, 2)), 0, 2, N'Samsung Galaxy A5', N'samsung-galaxy-a5', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-15 23:08:42.637' AS DateTime), CAST(N'2016-03-15 23:08:42.637' AS DateTime), NULL, 18, NULL)

INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [BrandId], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (4, N'Bảo hành 12 tháng (hóa đơn)Thiết kế vượt trội với màn hình "ngoại cỡ" 12.9 inchCấu hình mạnh mẽ; hiệu năng nhanh hơn LaptopTương tác thông minh; làm hai việc cùng lúc', N'<p><img src="/UserContents/d6711bf0-cd39-4e0a-b1bf-a5aed5a0d4ec.jpg"></p><p>Suốt thời gian qua, iPad vẫn luôn được đánh giá là dòng sản phẩm máy tính bảng tốt nhất. Với khả năng tối ưu hoàn hảo giữa thiết kế phần cứng và hệ điều hành iOS, iPad luôn đáp ứng mọi tác vụ người dùng một cách trơn tru và mượt mà tuyệt đối. Và, trong khi không còn nhiều tên tuổi mặn mà với dòng sản phẩm tablet cao cấp, Apple lại tiếp tục ra mắt iPad Pro, một siêu phẩm với niềm tin sẽ đưa chuẩn mực của một chiếc máy tính bảng lên tầm cao mới.</p><p><img src="/UserContents/0a3f4d85-6e04-4052-93db-067c1e6292c5.jpg" style="width: 976px;"></p><p>Hãng “táo cắn dở” trong suốt một thời gian dài vẫn trung thành với màn hình 9.7 inch của iPad thường, 7.9 inch với dòng iPad Mini. Nhưng trên iPad Pro, tiêu chuẩn ấy đã hoàn toàn bị phá vỡ với kích thước lên tới 12.9 inch, độ phân giải “chuẩn” Retina 2732 x 2048 pixel. Kích thước của iPad Pro đã lớn hơn tới 78% so với iPad Air 2 trước đó. Kích thước màn hình này cho ta cảm giác đây giống như một chiếc laptop hơn là tablet. Nhưng, kích thước đó cũng sẽ mang tới nhiều không gian trải nghiệm hơn, nhiều khoảng trống làm việc hơn để dành cho nhiều ý tưởng lớn hơn.<br></p><p><img src="/UserContents/d788dc0f-f609-4f3a-8d1b-06858f919bec.jpg" style="width: 976px;"></p><p>Có vẻ buồn cười khi cầm trên tay và sử dụng một chiếc “siêu” tablet với màn hình lên tới 13 inch. Nhưng Apple lại một lần nữa chinh phục giới công nghệ bởi khả năng thiết kế và chế tác tuyệt hảo của mình. Toàn bộ chiếc máy với hợp kim nhôm nguyên khối chỉ mỏng 6.9mm, một con số không tưởng! Cầm trên tay iPad Pro vẫn thật nhẹ nhàng và vô cùng thoải mái.<br></p><p><img src="/UserContents/27dc0e7d-71ff-4ce0-bb45-d58d0f47c029.jpg" style="width: 976px;"></p><p>Hệ điều hành mới nhất được cập nhật cho iPad Pro là iOS 9 với rất nhiều tính năng mới. Đặc biệt, khả năng đa nhiệm ở phiên bản iOS này đã được làm mới để hoạt động tốt hơn. Bên cạnh đó là các tính năng như chia đôi màn hình, kho ứng dụng dành riêng tối ưu cho iPad giúp cho iPad Pro hoàn thành vai trò là một công cụ làm việc tuyệt vời. Ngoài ra Apple cũng đã trang bị cho iPad Pro hệ thống 4 loa tự cân bằng hoàn toàn mới, biến chiếc tablet quá khổ này trở thành cỗ máy giải trí tuyệt đỉnh.</p><p><img src="/UserContents/c2a38abf-86ff-452f-81fd-eb2b744435d6.jpg" style="width: 976px;"></p><p>Nền tảng 64-bit đang là xu hướng mới nâng cao hiệu suất của vi xử lý. Apple A9X được tích hợp trên iPad Pro cũng sử dụng công nghệ này, và là bộ vi xử lý mạnh nhất mà hãng Apple sử dụng trên các thiết bị di động cho tới thời điểm hiện tại. Theo công bố của hãng, con chip A9X sẽ đem lại hiệu năng CPU mạnh hơn 1.8 lần so với con chip của iPad Air 2, và khả năng xử lý đồ họa vượt trội tới 2 lần. Nếu bạn đã từng trải nghiệm sự mượt mà trên những thế hệ iPad trước, iPad Pro sẽ càng làm tốt hơn nhiệm vụ khiến cho bạn bất ngờ.</p><p><img src="/UserContents/06637986-ecba-467f-bbaf-c9e77593c347.jpg" style="width: 976px;"></p><p>iSight Camera trên iPad Pro đã được nâng cấp với độ phân giải lên tới 8MP, sẵn sàng ghi lại những khoảnh khắc bạn muốn ghi nhớ. Bên cạnh đó là camera FaceTime HD, đáp ứng hoàn hảo nhu cầu liên lạc bằng hình ảnh qua videocall, FaceTime với bạn bè, người thân mọi nơi, mọi lúc.</p><p><img src="/UserContents/50eae808-2cb7-4c28-bb66-1ceb3d916fa2.jpg" style="width: 976px;"></p><p>Apple sản xuất iPad Pro với nhiều phiên bản tùy chọn về màu sắc như Silver/Gold/Space Gray, tùy chọn dung lượng bộ nhớ 32GB/128GB đảm bảo đáp ứng tốt nhất cho mọi nhu cầu của mọi đối tượng sử dụng. Nếu bạn thường xuyên làm việc khi di chuyển, hãy chọn &nbsp;phiên bản Cellular để sử dụng được kết nối 3G, hoặc nếu bạn có sở thích xem phim, hay có nhiều dữ liệu cần lưu trữ, hãy chọn cho mình phiên bản 128GB.</p><p><img src="/UserContents/2a4fa970-9ce1-44d7-8dd6-b4b5a4e6daaa.jpg" style="width: 976px;"></p><p>Hầu hết các thiết bị mới nhất đến từ Apple đều đã được hãng trang bị công nghệ bảo mật vân tay hiện đại, và iPad Pro cũng vậy. Ở phiên bản mới nhất này, cảm biến vân tay của iPad Pro càng được tăng thêm độ bảo mật cũng như tốc độ nhận diện, mang đến trải nghiệm sử dụng tiện lợi và thích thú hơn.&nbsp;<br></p>', NULL, CAST(21290000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), 0, 1, N'iPad Pro Wi-Fi 4G 128GB', N'ipad-pro-wi-fi-4g-128gb', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-15 23:16:27.487' AS DateTime), CAST(N'2016-03-15 23:16:27.487' AS DateTime), NULL, 22, NULL)

SET IDENTITY_INSERT [dbo].[Core_Product] OFF 
GO

SET IDENTITY_INSERT [dbo].[Core_ProductAttributeValue] ON 

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (5, 1, 4, N'A9X')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (6, 2, 4, N'IOS')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (7, 4, 4, N'4GB')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (8, 5, 4, N'128GB')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (9, 6, 4, N'305.7 x 220.6 x 6.9 mm')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (10, 10, 4, N'2732 x 2048 pixels')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (11, 12, 4, N'No')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (12, 14, 4, N'Yes')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (13, 17, 4, N'Yes')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (14, 1, 2, N'Apple A9, Dual-core 1.84 GHz')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (15, 2, 2, N'iOS')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (16, 3, 2, N'PowerVR GT7600')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (17, 4, 2, N'2 GB')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (18, 5, 2, N'16 GB')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (19, 8, 2, N'750 x 1334 px')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (20, 11, 2, N'Yes')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (21, 17, 2, N'Yes')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (22, 1, 3, N'Octa-core 1.6 GHz')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (23, 2, 3, N'Android')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (24, 4, 3, N'2 GB')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (25, 5, 3, N'16 GB')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (26, 6, 3, N'144.8 x 71 x 7.3 mm')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (27, 7, 3, N'Super AMOLED')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (28, 8, 3, N'1080 x 1920 pixels')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (29, 11, 3, N'yes')

INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (30, 17, 3, N'yes')

SET IDENTITY_INSERT [dbo].[Core_ProductAttributeValue] OFF 
GO

SET IDENTITY_INSERT [dbo].[Core_ProductCategory] ON 
INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (1, 0, 0, 1, 1)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (2, 0, 0, 2, 1)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (3, 0, 0, 1, 2)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (4, 0, 0, 2, 2)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (5, 0, 0, 1, 3)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (6, 0, 0, 2, 3)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (7, 0, 0, 1, 4)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (13, 0, 0, 4, 4)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (14, 0, 0, 5, 4)

INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (15, 0, 0, 3, 3)

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

SET IDENTITY_INSERT [dbo].[Core_ProductOptionValue] ON 
INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (1, 1, 2, N'Pink')

INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (2, 1, 2, N'Gold')

INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (3, 1, 2, N'Gray')

INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (4, 1, 2, N'Silver')

INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (5, 1, 3, N'Pink')

INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (6, 1, 3, N'Black')

INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (7, 1, 3, N'Gold')

INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (8, 1, 4, N'Gold')

INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (9, 1, 4, N'Gray')

INSERT [dbo].[Core_ProductOptionValue] ([Id], [OptionId], [ProductId], [Value]) VALUES (10, 1, 4, N'Silver')

SET IDENTITY_INSERT [dbo].[Core_ProductOptionValue] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_ProductVariation] ON 

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (1, N'Pink', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 15:52:49.610' AS DateTime), CAST(N'2016-03-15 15:52:49.610' AS DateTime), NULL, 2, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (2, N'Gold', NULL, CAST(1000000.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 15:52:49.613' AS DateTime), CAST(N'2016-03-15 15:52:49.613' AS DateTime), NULL, 2, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (3, N'Gray', NULL, CAST(-1000000.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 15:52:49.613' AS DateTime), CAST(N'2016-03-15 15:52:49.613' AS DateTime), NULL, 2, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (4, N'Silver', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 15:52:49.613' AS DateTime), CAST(N'2016-03-15 15:52:49.613' AS DateTime), NULL, 2, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (5, N'Pink', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:08:42.637' AS DateTime), CAST(N'2016-03-15 16:08:42.637' AS DateTime), NULL, 3, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (6, N'Black', NULL, CAST(-100000.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:08:42.637' AS DateTime), CAST(N'2016-03-15 16:08:42.637' AS DateTime), NULL, 3, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (7, N'Gold', NULL, CAST(100000.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:08:42.637' AS DateTime), CAST(N'2016-03-15 16:08:42.637' AS DateTime), NULL, 3, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (8, N'Gold', NULL, CAST(1000000.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:16:27.487' AS DateTime), CAST(N'2016-03-15 16:16:27.487' AS DateTime), NULL, 4, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (9, N'Gray', NULL, CAST(-1000000.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:16:27.487' AS DateTime), CAST(N'2016-03-15 16:16:27.487' AS DateTime), NULL, 4, NULL)

INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (10, N'Silver', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 16:16:27.487' AS DateTime), CAST(N'2016-03-15 16:16:27.487' AS DateTime), NULL, 4, NULL)

SET IDENTITY_INSERT [dbo].[Core_ProductVariation] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_ProductOptionCombination] ON 
INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (1, 1, 1, N'Pink')

INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (2, 2, 1, N'Gold')

INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (3, 3, 1, N'Gray')

INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (4, 4, 1, N'Silver')

INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (5, 5, 1, N'Pink')

INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (6, 6, 1, N'Black')

INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (7, 7, 1, N'Gold')

INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (8, 8, 1, N'Gold')

INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (9, 9, 1, N'Gray')

INSERT [dbo].[Core_ProductOptionCombination] ([Id], [VariationId], [OptionId], [Value]) VALUES (10, 10, 1, N'Silver')

SET IDENTITY_INSERT [dbo].[Core_ProductOptionCombination] OFF
GO

SET IDENTITY_INSERT [dbo].[Core_Page] ON 
INSERT [dbo].[Core_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (1, N'<h1>About us</h1><p>Your information. Use admin site to update</p>', N'About us', N'about-us', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-10 08:45:44.953' AS DateTime), CAST(N'2016-04-10 08:45:44.953' AS DateTime), NULL, NULL)

INSERT [dbo].[Core_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (2, N'<h1>Term and Conditions</h1><p>Your term and conditions. Use admin site to update</p>', N'Terms & Conditions', N'terms-of-use', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 02:54:57.177' AS DateTime), CAST(N'2016-04-11 02:54:57.177' AS DateTime), NULL, NULL)

INSERT [dbo].[Core_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (3, N'<h1>Privacy Policy</h1><p>Your privacy policy information. Use admin site to update</p>', N'Privacy Policy', N'privacy', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 02:59:31.963' AS DateTime), CAST(N'2016-04-11 02:59:31.963' AS DateTime), NULL, NULL)

INSERT [dbo].[Core_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (4, N'<h1>Help center</h1><p><a href="/help-center/how-to-buy">How to buy</a></p><p><a href="help-center/shipping">Shipping and delivery</a></p><p><a href="help-center/how-to-return">How to return</a></p><p><a href="help-center/warranty">Warranty</a></p>', N'Help Center', N'help-center', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 03:14:04.447' AS DateTime), CAST(N'2016-04-11 03:14:04.447' AS DateTime), NULL, NULL)

INSERT [dbo].[Core_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (5, N'<h1>How to buy</h1><p>Your how to buy instructions. Use admin site to update</p>', N'How to buy', N'help-center/how-to-buy', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 03:16:14.323' AS DateTime), CAST(N'2016-04-11 03:24:13.833' AS DateTime), NULL, NULL)

INSERT [dbo].[Core_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (6, N'<h1>Shipping and Delivery</h1><p>Shipping and delivery information. Use admin site to update</p>', N'Shipping and delivery', N'help-center/shipping', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 02:57:13.497' AS DateTime), CAST(N'2016-04-11 03:23:31.597' AS DateTime), NULL, NULL)

INSERT [dbo].[Core_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (7, N'<h1>How to return</h1><p>Your how to return instructions. Use admin site to update</p>', N'How to return', N'help-center/how-to-return', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 03:17:42.067' AS DateTime), CAST(N'2016-04-11 03:17:42.067' AS DateTime), NULL, NULL)

INSERT [dbo].[Core_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (8, N'<h1>Warranty</h1><p>Your warranty policy. Use admin site to update</p>', N'Warranty', N'help-center/warranty', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 03:19:01.927' AS DateTime), CAST(N'2016-04-11 03:19:01.927' AS DateTime), NULL, NULL)

SET IDENTITY_INSERT [dbo].[Core_Page] OFF
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

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (18, N'about-us', 1, N'Page')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (19, N'terms-of-use', 2, N'Page')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (20, N'privacy', 3, N'Page')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (21, N'help-center', 4, N'Page')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (22, N'help-center/how-to-buy', 5, N'Page')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (23, N'help-center/shipping', 6, N'Page')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (24, N'help-center/how-to-return', 7, N'Page')

INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (25, N'help-center/warranty', 8, N'Page')

SET IDENTITY_INSERT [dbo].[Core_UrlSlug] OFF
GO

