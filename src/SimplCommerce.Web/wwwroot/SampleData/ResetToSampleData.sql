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
DELETE FROM [dbo].[Core_ProductLink]
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

