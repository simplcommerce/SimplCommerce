DELETE FROM [dbo].[Cms_MenuItem]
GO
DELETE FROM [dbo].[Core_Entity]
GO
DELETE FROM [dbo].[ShoppingCart_Cart]
GO
DELETE FROM [dbo].[ShoppingCart_CartItem]
GO
DELETE FROM [dbo].[Orders_OrderItem]
GO
DELETE FROM [dbo].[Orders_Order]
GO
DELETE FROM [dbo].[Inventory_StockHistory]
GO
DELETE FROM [dbo].[Inventory_Stock]
GO
DELETE FROM [dbo].[Catalog_ProductAttributeValue]
GO
DELETE FROM [dbo].[Catalog_ProductOptionCombination]
GO
DELETE FROM [dbo].[Catalog_ProductOptionValue]
GO
DELETE FROM [dbo].[Catalog_ProductAttribute]
GO
DELETE FROM [dbo].[Catalog_ProductAttributeGroup]
GO
DELETE FROM [dbo].[Catalog_ProductMedia]
GO
DELETE FROM [dbo].[Catalog_ProductCategory]
GO
DELETE FROM [dbo].[Catalog_ProductLink]
GO
DELETE FROM [dbo].[Catalog_Product]
GO
DELETE FROM [dbo].[Catalog_Category]
GO
DELETE FROM [dbo].[News_NewsItem]
GO
DELETE FROM [dbo].[Core_Media]
GO
DELETE FROM [dbo].[Catalog_Brand]
GO
DELETE FROM [dbo].[Catalog_ProductTemplateProductAttribute]
GO
DELETE FROM [dbo].[Catalog_ProductTemplate]
GO
DELETE FROM [dbo].[Cms_Page]
GO
DELETE FROM [dbo].[Core_WidgetInstance]
GO
DELETE FROM [dbo].[Reviews_Review]
GO

SET IDENTITY_INSERT [dbo].[Catalog_Category] ON 
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (1, N'Phones', N'phones', NULL, 0, 1, 0, NULL, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (2, N'Smart Phones', N'smart-phones', NULL, 0, 1, 0, 1, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (3, N'Basic Phones', N'basic-phones', NULL, 0, 1, 0, 1, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (4, N'Tablets', N'tablets', NULL, 0, 1, 0, NULL, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (5, N'Wifi + Cellular tablets', N'wifi-cellular-tablets', NULL, 0, 1, 0, 4, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (6, N'Cellular tablets', N'cellular-tablets', NULL, 0, 1, 0, 4, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (7, N'Computers', N'computers', NULL, 0, 1, 0, NULL, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (8, N'Gaming', N'gaming', NULL, 0, 1, 0, 7, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (9, N'Business', N'business', NULL, 0, 1, 0, 7, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (10, N'Accessories', N'accessories', NULL, 0, 1, 0, NULL, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (11, N'Headphones', N'headphones', NULL, 0, 1, 0, 10, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (12, N'Cables', N'cables', NULL, 0, 1, 0, 10, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (13, N'USB Drives', N'usb-drives', NULL, 0, 1, 0, 10, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (14, N'Test 1', N'test-1', NULL, 0, 1, 0, 2, NULL, 1)
INSERT [dbo].[Catalog_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [ThumbnailImageId], [IncludeInMenu]) VALUES (15, N'Test 2', N'test-2', NULL, 0, 1, 0, 2, NULL, 1)
SET IDENTITY_INSERT [dbo].[Catalog_Category] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_Brand] ON 
INSERT [dbo].[Catalog_Brand] ([Id], [Name], [SeoTitle], [Description], [IsPublished], [IsDeleted]) VALUES (1, N'Apple', N'apple', NULL, 1, 0)
INSERT [dbo].[Catalog_Brand] ([Id], [Name], [SeoTitle], [Description], [IsPublished], [IsDeleted]) VALUES (2, N'Samsung', N'samsung', NULL, 1, 0)
INSERT [dbo].[Catalog_Brand] ([Id], [Name], [SeoTitle], [Description], [IsPublished], [IsDeleted]) VALUES (3, N'Dell', N'dell', NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Catalog_Brand] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_ProductAttributeGroup] ON 
INSERT [dbo].[Catalog_ProductAttributeGroup] ([Id], [Name]) VALUES (1, N'General')
INSERT [dbo].[Catalog_ProductAttributeGroup] ([Id], [Name]) VALUES (2, N'Screen')
INSERT [dbo].[Catalog_ProductAttributeGroup] ([Id], [Name]) VALUES (3, N'Connectivity')
INSERT [dbo].[Catalog_ProductAttributeGroup] ([Id], [Name]) VALUES (4, N'Camera')
SET IDENTITY_INSERT [dbo].[Catalog_ProductAttributeGroup] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_ProductAttribute] ON 
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (1, N'CPU', 1)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (2, N'OS', 1)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (3, N'GPU', 1)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (4, N'RAM', 1)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (5, N'Capacity', 1)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (6, N'Size', 2)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (7, N'Type', 2)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (8, N'Resolution', 2)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (9, N'2G', 3)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (10, N'3G', 3)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (11, N'4G', 3)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (12, N'Wifi', 3)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (13, N'Bluetooth', 3)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (14, N'NFC', 3)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (15, N'USP', 3)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (16, N'GPS', 3)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (17, N'Main camera', 4)
INSERT [dbo].[Catalog_ProductAttribute] ([Id], [Name], [GroupId]) VALUES (18, N'Sub camera', 4)
SET IDENTITY_INSERT [dbo].[Catalog_ProductAttribute] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_ProductTemplate] ON 
INSERT [dbo].[Catalog_ProductTemplate] ([Id], [Name]) VALUES (1, N'Tablet')
INSERT [dbo].[Catalog_ProductTemplate] ([Id], [Name]) VALUES (2, N'Phone')
SET IDENTITY_INSERT [dbo].[Catalog_ProductTemplate] OFF 
GO

INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (1, 1)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (1, 2)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (1, 3)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (1, 4)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 1)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 2)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 3)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 4)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 5)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 6)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 7)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 8)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 11)
INSERT [dbo].[Catalog_ProductTemplateProductAttribute] ([ProductTemplateId], [ProductAttributeId]) VALUES (2, 17)
GO

SET IDENTITY_INSERT [dbo].[Core_Media] ON 
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (1, NULL, N'd74fd909-6fe0-4bc3-bf61-86d12dc98a2e.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (2, NULL, N'81b606ea-0bb0-4cea-a9d7-6406175df9bb.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (3, NULL, N'68c7ff8f-014e-46c8-8daa-f35c646cc10a.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (4, NULL, N'89374e88-b14c-4d38-b5cd-eacdc5ce3015.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (5, NULL, N'ffc255b3-07c8-4ee5-94e9-d472c6af3f07.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (6, NULL, N'bb1243c9-63d5-4518-bbd5-cb3e35ade294.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (7, NULL, N'282e5cd3-b664-43dc-ba06-d7e91721c560.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (8, NULL, N'd013921e-5f11-4472-b5ff-7f78d5987a69.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (9, NULL, N'ea0af866-a650-4909-877d-00eabbf3d8fd.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (10, NULL, N'3a3f587c-9c70-4e68-b480-20829a9f3e95.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (11, NULL, N'f9a76a94-6e1a-4489-bf7d-3dc6a68a0785.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (12, NULL, N'a88b4a09-5824-4398-ac08-101d9061f927.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (13, NULL, N'fdfd1daf-ec7a-4c6e-83dd-a862eae735db.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (14, NULL, N'4495b930-a901-44e2-9275-935f7e8ec53c.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (15, NULL, N'284b77c8-2ba8-43e1-826d-7c79c5cf4489.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (16, NULL, N'e32c3caa-f7bc-4a3c-b970-f62c503b85bc.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (17, NULL, N'bffb6f2c-8a3f-4fdd-817d-09a9f18cd190.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (18, NULL, N'25d3da45-b57b-40b6-8f41-2fc5170cb6b7.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (19, NULL, N'7da07700-9a17-498b-ba58-526559343878.jpg', 0, 1)
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileName], [FileSize], [MediaType]) VALUES (20, NULL, N'fefe68b9-aee8-4e7d-a49a-17f805555591.jpg', 0, 1)
SET IDENTITY_INSERT [dbo].[Core_Media] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_Product] ON 
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (1, 1, NULL, CAST(N'2016-06-19T00:15:59.9468401+00:00' AS DateTimeOffset), N'<p><img src="/user-content/9874f0f5-46dc-495d-8c61-2c515577aa05.jpg" style="width: 100%;"></p><p>iPad Pro is more than the next generation of iPad — it’s an uncompromising vision of personal computing for the modern world. It puts incredible power that leaps past most portable PCs at your fingertips. It makes even complex work as natural as touching, swiping, or writing with a pencil. And whether you choose the 12.9-inch model or the new 9.7-inch model, iPad Pro is more capable, versatile, and portable than anything that’s come before. In a word, super.</p><p><img src="/user-content/5887a479-bb96-436f-8414-fa188cdc2aac.jpg" style="width: 100%;"></p><p>The key to the iPad experience is the display. It’s how you interact using Multi-Touch, and how you view content in spectacular detail. So we created our most vivid Retina display ever. The 12.9‑inch iPad Pro has the highest resolution of any iOS device. And the new 9.7-inch iPad Pro screen — our most advanced display — is the brightest and least reflective in the world.<br></p>', 0, 1, 0, 1, 1, 1, NULL, NULL, NULL, N'iPad Pro Wi-Fi 4G 128GB', NULL, CAST(899.00 AS Decimal(18, 2)), CAST(999.00 AS Decimal(18, 2)), NULL, N'ipad-pro-wi-fi-4g-128gb', N'<ul><li>Retina Display</li><li>ATX chip</li><li>iOS 9</li><li>Apps for iPad</li><li>Slim and light design</li><li>12.9" with Retina Display, 2732 x 2048 Resolution</li><li>Apple iOS 9, Dual-Core A9X Chip with Quad-Core Graphics</li></ul>', NULL, NULL, 1, NULL, CAST(N'2016-06-19T00:15:59.9468401+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 0, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (2, 1, NULL, CAST(N'2016-06-19T00:15:59.9798387+00:00' AS DateTimeOffset), N'<p><img src="/user-content/9874f0f5-46dc-495d-8c61-2c515577aa05.jpg" style="width: 100%;"></p><p>iPad Pro is more than the next generation of iPad — it’s an uncompromising vision of personal computing for the modern world. It puts incredible power that leaps past most portable PCs at your fingertips. It makes even complex work as natural as touching, swiping, or writing with a pencil. And whether you choose the 12.9-inch model or the new 9.7-inch model, iPad Pro is more capable, versatile, and portable than anything that’s come before. In a word, super.</p><p><img src="/user-content/5887a479-bb96-436f-8414-fa188cdc2aac.jpg" style="width: 100%;"></p><p>The key to the iPad experience is the display. It’s how you interact using Multi-Touch, and how you view content in spectacular detail. So we created our most vivid Retina display ever. The 12.9‑inch iPad Pro has the highest resolution of any iOS device. And the new 9.7-inch iPad Pro screen — our most advanced display — is the brightest and least reflective in the world.<br></p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'iPad Pro Wi-Fi 4G 128GB Gray', N'Gray', CAST(999.00 AS Decimal(18, 2)), CAST(899.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:15:59.9798387+00:00' AS DateTimeOffset), N'ipad-pro-wi-fi-4g-128gb-gray', N'<ul><li>Retina Display</li><li>ATX chip</li><li>iOS 9</li><li>Apps for iPad</li><li>Slim and light design</li><li>12.9" with Retina Display, 2732 x 2048 Resolution</li><li>Apple iOS 9, Dual-Core A9X Chip with Quad-Core Graphics</li></ul>', NULL, NULL, 1, NULL, CAST(N'2016-06-19T00:15:59.9798387+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (3, 1, NULL, CAST(N'2016-06-19T00:15:59.9818408+00:00' AS DateTimeOffset), N'<p><img src="/user-content/9874f0f5-46dc-495d-8c61-2c515577aa05.jpg" style="width: 100%;"></p><p>iPad Pro is more than the next generation of iPad — it’s an uncompromising vision of personal computing for the modern world. It puts incredible power that leaps past most portable PCs at your fingertips. It makes even complex work as natural as touching, swiping, or writing with a pencil. And whether you choose the 12.9-inch model or the new 9.7-inch model, iPad Pro is more capable, versatile, and portable than anything that’s come before. In a word, super.</p><p><img src="/user-content/5887a479-bb96-436f-8414-fa188cdc2aac.jpg" style="width: 100%;"></p><p>The key to the iPad experience is the display. It’s how you interact using Multi-Touch, and how you view content in spectacular detail. So we created our most vivid Retina display ever. The 12.9‑inch iPad Pro has the highest resolution of any iOS device. And the new 9.7-inch iPad Pro screen — our most advanced display — is the brightest and least reflective in the world.<br></p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'iPad Pro Wi-Fi 4G 128GB Silver', N'Silver', CAST(999.00 AS Decimal(18, 2)), CAST(899.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:15:59.9818408+00:00' AS DateTimeOffset), N'ipad-pro-wi-fi-4g-128gb-silver', N'<ul><li>Retina Display</li><li>ATX chip</li><li>iOS 9</li><li>Apps for iPad</li><li>Slim and light design</li><li>12.9" with Retina Display, 2732 x 2048 Resolution</li><li>Apple iOS 9, Dual-Core A9X Chip with Quad-Core Graphics</li></ul>', NULL, NULL, 1, NULL, CAST(N'2016-06-19T00:15:59.9818408+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (4, 1, NULL, CAST(N'2016-06-19T00:15:59.9818408+00:00' AS DateTimeOffset), N'<p><img src="/user-content/9874f0f5-46dc-495d-8c61-2c515577aa05.jpg" style="width: 100%;"></p><p>iPad Pro is more than the next generation of iPad — it’s an uncompromising vision of personal computing for the modern world. It puts incredible power that leaps past most portable PCs at your fingertips. It makes even complex work as natural as touching, swiping, or writing with a pencil. And whether you choose the 12.9-inch model or the new 9.7-inch model, iPad Pro is more capable, versatile, and portable than anything that’s come before. In a word, super.</p><p><img src="/user-content/5887a479-bb96-436f-8414-fa188cdc2aac.jpg" style="width: 100%;"></p><p>The key to the iPad experience is the display. It’s how you interact using Multi-Touch, and how you view content in spectacular detail. So we created our most vivid Retina display ever. The 12.9‑inch iPad Pro has the highest resolution of any iOS device. And the new 9.7-inch iPad Pro screen — our most advanced display — is the brightest and least reflective in the world.<br></p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'iPad Pro Wi-Fi 4G 128GB Gold', N'Gold', CAST(999.00 AS Decimal(18, 2)), CAST(999.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:15:59.9818408+00:00' AS DateTimeOffset), N'ipad-pro-wi-fi-4g-128gb-gold', N'<ul><li>Retina Display</li><li>ATX chip</li><li>iOS 9</li><li>Apps for iPad</li><li>Slim and light design</li><li>12.9" with Retina Display, 2732 x 2048 Resolution</li><li>Apple iOS 9, Dual-Core A9X Chip with Quad-Core Graphics</li></ul>', NULL, NULL, 1, NULL, CAST(N'2016-06-19T00:15:59.9818408+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (5, 2, NULL, CAST(N'2016-06-19T00:19:55.8562434+00:00' AS DateTimeOffset), N'<p>The new Galaxy A (2017) comes with protection that lets you enjoy life without a worry. Equipped with IP68 to withstand the elements of nature, it shields out everything from water to dust in most situations.</p><p>A memorable moment becomes more beautiful if captured perfectly. The powerful 16MP front &amp; rear cameras with f/1.9 aperture lenses in the new Galaxy A (2017), give your pictures the added depth and detail they deserve<br></p>', 0, 1, 0, 1, 1, 1, NULL, NULL, NULL, N'Samsung Galaxy A5', NULL, CAST(449.00 AS Decimal(18, 2)), CAST(399.00 AS Decimal(18, 2)), NULL, N'samsung-galaxy-a5', N'<ul><li>Dust and Water Resistant (IP68 Rating)</li><li> Always on Display</li><li> 16 MP Front and Rear Camera </li><li>FHD sAMOLED<br></li></ul>', NULL, NULL, 5, NULL, CAST(N'2016-06-19T00:19:55.8562434+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 0, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (6, 2, NULL, CAST(N'2016-06-19T00:19:55.8892432+00:00' AS DateTimeOffset), N'<p>The new Galaxy A (2017) comes with protection that lets you enjoy life without a worry. Equipped with IP68 to withstand the elements of nature, it shields out everything from water to dust in most situations.</p><p>A memorable moment becomes more beautiful if captured perfectly. The powerful 16MP front &amp; rear cameras with f/1.9 aperture lenses in the new Galaxy A (2017), give your pictures the added depth and detail they deserve<br></p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'Samsung Galaxy A5 Pink', N'Pink', CAST(499.00 AS Decimal(18, 2)), CAST(399.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:19:55.8892432+00:00' AS DateTimeOffset), N'samsung-galaxy-a5-pink', N'<ul><li>Dust and Water Resistant (IP68 Rating)</li><li> Always on Display</li><li> 16 MP Front and Rear Camera </li><li>FHD sAMOLED<br></li></ul>', NULL, NULL, 5, NULL, CAST(N'2016-06-19T00:19:55.8892432+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (7, 2, NULL, CAST(N'2016-06-19T00:19:55.8892432+00:00' AS DateTimeOffset), N'<p>The new Galaxy A (2017) comes with protection that lets you enjoy life without a worry. Equipped with IP68 to withstand the elements of nature, it shields out everything from water to dust in most situations.</p><p>A memorable moment becomes more beautiful if captured perfectly. The powerful 16MP front &amp; rear cameras with f/1.9 aperture lenses in the new Galaxy A (2017), give your pictures the added depth and detail they deserve<br></p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'Samsung Galaxy A5 Black', N'Black', CAST(499.00 AS Decimal(18, 2)), CAST(399.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:19:55.8892432+00:00' AS DateTimeOffset), N'samsung-galaxy-a5-black', N'<ul><li>Dust and Water Resistant (IP68 Rating)</li><li> Always on Display</li><li> 16 MP Front and Rear Camera </li><li>FHD sAMOLED<br></li></ul>', NULL, NULL, 5, NULL, CAST(N'2016-06-19T00:19:55.8892432+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (8, 2, NULL, CAST(N'2016-06-19T00:19:55.8892432+00:00' AS DateTimeOffset), N'<p>The new Galaxy A (2017) comes with protection that lets you enjoy life without a worry. Equipped with IP68 to withstand the elements of nature, it shields out everything from water to dust in most situations.</p><p>A memorable moment becomes more beautiful if captured perfectly. The powerful 16MP front &amp; rear cameras with f/1.9 aperture lenses in the new Galaxy A (2017), give your pictures the added depth and detail they deserve<br></p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'Samsung Galaxy A5 Gold', N'Gold', CAST(499.00 AS Decimal(18, 2)), CAST(399.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:19:55.8892432+00:00' AS DateTimeOffset), N'samsung-galaxy-a5-gold', N'<ul><li>Dust and Water Resistant (IP68 Rating)</li><li> Always on Display</li><li> 16 MP Front and Rear Camera </li><li>FHD sAMOLED<br></li></ul>', NULL, NULL, 5, NULL, CAST(N'2016-06-19T00:19:55.8892432+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (9, 1, NULL, CAST(N'2016-06-19T00:23:42.6582261+00:00' AS DateTimeOffset), N'<p>Apple iPhone 6s smartphone was launched in September 2015. The phone comes with a 4.70-inch touchscreen display with a resolution of 750 pixels by 1334 pixels at a PPI of 326 pixels per inch. Apple iPhone 6s price in India starts from Rs. 35,999.&nbsp;</p><p>A9It comes with 2GB of RAM. The phone packs 16GB of internal storage that cannot be expanded. As far as the cameras are concerned, the Apple iPhone 6s packs a 12-megapixel primary camera on the rear and a 5-megapixel front shooter for selfies.</p><p>The Apple iPhone 6s runs iOS 9 and is powered by a 1715mAh non removable battery. It measures 138.30 x 67.10 x 7.10 (height x width x thickness) and weigh 143.00 grams.</p><p>The Apple iPhone 6s is a single SIM (GSM) smartphone that accepts a Nano-SIM. Connectivity options include Wi-Fi, GPS, Bluetooth, NFC, 3G and 4G (with support for Band 40 used by some LTE networks in India). Sensors on the phone include Compass Magnetometer, Proximity sensor, Accelerometer, Ambient light sensor, Gyroscope and Barometer.</p>', 0, 1, 0, 1, 1, 1, NULL, NULL, NULL, N'iPhone 6s 16GB', NULL, CAST(599.00 AS Decimal(18, 2)), CAST(499.00 AS Decimal(18, 2)), NULL, N'iphone-6s-16gb', N'<p>A 4.7-inch Retina HD display with 3D Touch. 7000 series aluminum and stronger cover glass. An A9 chip with 64-bit desktop-class architecture. All new 12MP iSight camera with Live Photos. Touch ID. Faster LTE and Wi-Fi. Long battery life and iOS 10 and iCloud. All in a smooth, continuous unibody design.<br></p>', NULL, NULL, 10, NULL, CAST(N'2016-06-19T00:23:42.6582261+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 0, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (10, 1, NULL, CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), N'<p>Apple iPhone 6s smartphone was launched in September 2015. The phone comes with a 4.70-inch touchscreen display with a resolution of 750 pixels by 1334 pixels at a PPI of 326 pixels per inch. Apple iPhone 6s price in India starts from Rs. 35,999.&nbsp;</p><p>A9It comes with 2GB of RAM. The phone packs 16GB of internal storage that cannot be expanded. As far as the cameras are concerned, the Apple iPhone 6s packs a 12-megapixel primary camera on the rear and a 5-megapixel front shooter for selfies.</p><p>The Apple iPhone 6s runs iOS 9 and is powered by a 1715mAh non removable battery. It measures 138.30 x 67.10 x 7.10 (height x width x thickness) and weigh 143.00 grams.</p><p>The Apple iPhone 6s is a single SIM (GSM) smartphone that accepts a Nano-SIM. Connectivity options include Wi-Fi, GPS, Bluetooth, NFC, 3G and 4G (with support for Band 40 used by some LTE networks in India). Sensors on the phone include Compass Magnetometer, Proximity sensor, Accelerometer, Ambient light sensor, Gyroscope and Barometer.</p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'iPhone 6s 16GB Gray', N'Gray', CAST(599.00 AS Decimal(18, 2)), CAST(499.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), N'iphone-6s-16gb-gray', N'<p>A 4.7-inch Retina HD display with 3D Touch. 7000 series aluminum and stronger cover glass. An A9 chip with 64-bit desktop-class architecture. All new 12MP iSight camera with Live Photos. Touch ID. Faster LTE and Wi-Fi. Long battery life and iOS 10 and iCloud. All in a smooth, continuous unibody design.<br></p>', NULL, NULL, 10, NULL, CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (11, 1, NULL, CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), N'<p>Apple iPhone 6s smartphone was launched in September 2015. The phone comes with a 4.70-inch touchscreen display with a resolution of 750 pixels by 1334 pixels at a PPI of 326 pixels per inch. Apple iPhone 6s price in India starts from Rs. 35,999.&nbsp;</p><p>A9It comes with 2GB of RAM. The phone packs 16GB of internal storage that cannot be expanded. As far as the cameras are concerned, the Apple iPhone 6s packs a 12-megapixel primary camera on the rear and a 5-megapixel front shooter for selfies.</p><p>The Apple iPhone 6s runs iOS 9 and is powered by a 1715mAh non removable battery. It measures 138.30 x 67.10 x 7.10 (height x width x thickness) and weigh 143.00 grams.</p><p>The Apple iPhone 6s is a single SIM (GSM) smartphone that accepts a Nano-SIM. Connectivity options include Wi-Fi, GPS, Bluetooth, NFC, 3G and 4G (with support for Band 40 used by some LTE networks in India). Sensors on the phone include Compass Magnetometer, Proximity sensor, Accelerometer, Ambient light sensor, Gyroscope and Barometer.</p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'iPhone 6s 16GB Pink', N'Pink', CAST(599.00 AS Decimal(18, 2)), CAST(499.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), N'iphone-6s-16gb-pink', N'<p>A 4.7-inch Retina HD display with 3D Touch. 7000 series aluminum and stronger cover glass. An A9 chip with 64-bit desktop-class architecture. All new 12MP iSight camera with Live Photos. Touch ID. Faster LTE and Wi-Fi. Long battery life and iOS 10 and iCloud. All in a smooth, continuous unibody design.<br></p>', NULL, NULL, 10, NULL, CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (12, 1, NULL, CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), N'<p>Apple iPhone 6s smartphone was launched in September 2015. The phone comes with a 4.70-inch touchscreen display with a resolution of 750 pixels by 1334 pixels at a PPI of 326 pixels per inch. Apple iPhone 6s price in India starts from Rs. 35,999.&nbsp;</p><p>A9It comes with 2GB of RAM. The phone packs 16GB of internal storage that cannot be expanded. As far as the cameras are concerned, the Apple iPhone 6s packs a 12-megapixel primary camera on the rear and a 5-megapixel front shooter for selfies.</p><p>The Apple iPhone 6s runs iOS 9 and is powered by a 1715mAh non removable battery. It measures 138.30 x 67.10 x 7.10 (height x width x thickness) and weigh 143.00 grams.</p><p>The Apple iPhone 6s is a single SIM (GSM) smartphone that accepts a Nano-SIM. Connectivity options include Wi-Fi, GPS, Bluetooth, NFC, 3G and 4G (with support for Band 40 used by some LTE networks in India). Sensors on the phone include Compass Magnetometer, Proximity sensor, Accelerometer, Ambient light sensor, Gyroscope and Barometer.</p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'iPhone 6s 16GB Gold', N'Gold', CAST(599.00 AS Decimal(18, 2)), CAST(549.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), N'iphone-6s-16gb-gold', N'<p>A 4.7-inch Retina HD display with 3D Touch. 7000 series aluminum and stronger cover glass. An A9 chip with 64-bit desktop-class architecture. All new 12MP iSight camera with Live Photos. Touch ID. Faster LTE and Wi-Fi. Long battery life and iOS 10 and iCloud. All in a smooth, continuous unibody design.<br></p>', NULL, NULL, 10, NULL, CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (13, 1, NULL, CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), N'<p>Apple iPhone 6s smartphone was launched in September 2015. The phone comes with a 4.70-inch touchscreen display with a resolution of 750 pixels by 1334 pixels at a PPI of 326 pixels per inch. Apple iPhone 6s price in India starts from Rs. 35,999.&nbsp;</p><p>A9It comes with 2GB of RAM. The phone packs 16GB of internal storage that cannot be expanded. As far as the cameras are concerned, the Apple iPhone 6s packs a 12-megapixel primary camera on the rear and a 5-megapixel front shooter for selfies.</p><p>The Apple iPhone 6s runs iOS 9 and is powered by a 1715mAh non removable battery. It measures 138.30 x 67.10 x 7.10 (height x width x thickness) and weigh 143.00 grams.</p><p>The Apple iPhone 6s is a single SIM (GSM) smartphone that accepts a Nano-SIM. Connectivity options include Wi-Fi, GPS, Bluetooth, NFC, 3G and 4G (with support for Band 40 used by some LTE networks in India). Sensors on the phone include Compass Magnetometer, Proximity sensor, Accelerometer, Ambient light sensor, Gyroscope and Barometer.</p>', 0, 0, 0, 1, 1, 0, NULL, NULL, NULL, N'iPhone 6s 16GB Silver', N'Silver', CAST(599.00 AS Decimal(18, 2)), CAST(499.00 AS Decimal(18, 2)), CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), N'iphone-6s-16gb-silver', N'<p>A 4.7-inch Retina HD display with 3D Touch. 7000 series aluminum and stronger cover glass. An A9 chip with 64-bit desktop-class architecture. All new 12MP iSight camera with Live Photos. Touch ID. Faster LTE and Wi-Fi. Long battery life and iOS 10 and iCloud. All in a smooth, continuous unibody design.<br></p>', NULL, NULL, 10, NULL, CAST(N'2016-06-19T00:23:42.6962206+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
INSERT [dbo].[Catalog_Product] ([Id], [BrandId], [CreatedById], [CreatedOn], [Description], [DisplayOrder], [HasOptions], [IsDeleted], [IsFeatured], [IsPublished], [IsVisibleIndividually], [MetaDescription], [MetaKeywords], [MetaTitle], [Name], [NormalizedName], [OldPrice], [Price], [PublishedOn], [SeoTitle], [ShortDescription], [Sku], [Specification], [ThumbnailImageId], [UpdatedById], [UpdatedOn], [RatingAverage], [ReviewsCount], [SpecialPrice], [SpecialPriceEnd], [SpecialPriceStart], [IsAllowToOrder], [IsCallForPricing], [StockQuantity], [VendorId], [TaxClassId]) VALUES (14, 3, NULL, CAST(N'2016-06-19T00:30:45.8467606+00:00' AS DateTimeOffset), N'<p>The world''s smallest 15.6-inch laptop, the Dell XPS 15 stands apart with its stunning 4K UHD display and razor-thin profile. It''s the only PC with a 15.6-inch InfinityEdge display, a virtually borderless 15.6-inch screen placed into the body of an 14-inch laptop. Plus, the XPS 15 is only 0.4 inches thin and weighs just 4.5 pounds, making it the lightest performance-class 15-inch laptop on the market. It also comes with NVIDIA GeForce GTX 1050 graphics that deliver extremely smooth, cinematic gameplay.<br></p>', 0, 0, 0, 1, 1, 1, NULL, NULL, NULL, N'Dell XPS 15 9550', NULL, CAST(1599.00 AS Decimal(18, 2)), CAST(1499.00 AS Decimal(18, 2)), NULL, N'dell-xps-15-9550', N'<p>CPU: 6th Gen Intel® Core™ i7 (Skylake) 6700HQ (Quad-Core, up to 3.2GHz)</p><p>RAM: 8GB DDR4 2133MHz</p><p>Display: 15.6 inch</p><p>Video Card: 2GB NVIDIA® GeForce® GTX 960M GDDR5</p><p>Windows 10 Pro</p>', NULL, NULL, 16, NULL, CAST(N'2016-06-19T00:30:45.8467606+00:00' AS DateTimeOffset), NULL, 0, NULL, NULL, NULL, 1, 0, 10, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Catalog_Product] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_ProductMedia] ON 
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (1, 0, 2, 1)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (2, 0, 4, 1)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (3, 0, 3, 1)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (4, 0, 9, 5)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (5, 0, 8, 5)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (6, 0, 7, 5)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (7, 0, 6, 5)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (8, 0, 14, 9)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (9, 0, 11, 9)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (10, 0, 12, 9)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (11, 0, 13, 9)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (12, 0, 15, 9)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (13, 0, 17, 14)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (14, 0, 18, 14)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (15, 0, 19, 14)
INSERT [dbo].[Catalog_ProductMedia] ([Id], [DisplayOrder], [MediaId], [ProductId]) VALUES (16, 0, 20, 14)
SET IDENTITY_INSERT [dbo].[Catalog_ProductMedia] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_ProductAttributeValue] ON 
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (1, 1, 1, N'A9')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (2, 4, 3, N'4GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (3, 5, 3, N'128 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (4, 8, 3, N'2732 x 2048 pixels')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (5, 8, 2, N'2732 x 2048 pixels')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (6, 5, 2, N'128 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (7, 4, 2, N'4GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (8, 2, 2, N'IOS')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (9, 1, 2, N'A9')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (10, 2, 3, N'IOS')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (11, 1, 4, N'A9')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (12, 1, 3, N'A9')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (13, 4, 4, N'4GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (14, 5, 4, N'128 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (15, 8, 4, N'2732 x 2048 pixels')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (16, 8, 1, N'2732 x 2048 pixels')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (17, 5, 1, N'128 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (18, 4, 1, N'4GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (19, 2, 1, N'IOS')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (20, 2, 4, N'IOS')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (21, 1, 5, N'Octa-core 1.6 GHz')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (22, 1, 6, N'Octa-core 1.6 GHz')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (23, 2, 6, N'Android')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (24, 4, 6, N'2 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (25, 5, 6, N'32 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (26, 6, 6, N'144.8 x 71 x 7.3 mm')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (27, 8, 6, N'1080 x 1920 pixels')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (28, 5, 7, N'32 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (29, 11, 6, N'Yes')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (30, 17, 7, N'8 MP')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (31, 11, 7, N'Yes')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (32, 8, 7, N'1080 x 1920 pixels')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (33, 1, 7, N'Octa-core 1.6 GHz')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (34, 2, 7, N'Android')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (35, 4, 7, N'2 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (36, 17, 6, N'8 MP')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (37, 1, 8, N'Octa-core 1.6 GHz')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (38, 6, 7, N'144.8 x 71 x 7.3 mm')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (39, 4, 8, N'2 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (40, 5, 8, N'32 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (41, 6, 8, N'144.8 x 71 x 7.3 mm')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (42, 8, 8, N'1080 x 1920 pixels')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (43, 11, 8, N'Yes')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (44, 17, 8, N'8 MP')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (45, 2, 5, N'Android')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (46, 4, 5, N'2 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (47, 17, 5, N'8 MP')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (48, 2, 8, N'Android')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (49, 5, 5, N'32 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (50, 11, 5, N'Yes')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (51, 8, 5, N'1080 x 1920 pixels')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (52, 6, 5, N'144.8 x 71 x 7.3 mm')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (53, 1, 9, N'Apple A9, Dual-core 1.84 GHz')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (54, 17, 10, N'12 MP')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (55, 1, 11, N'Apple A9, Dual-core 1.84 GHz')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (56, 4, 11, N'2 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (57, 5, 11, N'16 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (58, 8, 11, N'750 x 1334 px')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (59, 11, 11, N'Yes')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (60, 17, 11, N'12 MP')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (61, 1, 12, N'Apple A9, Dual-core 1.84 GHz')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (62, 2, 12, N'IOS')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (63, 4, 12, N'2 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (64, 5, 12, N'16 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (65, 8, 12, N'750 x 1334 px')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (66, 11, 12, N'Yes')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (67, 17, 12, N'12 MP')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (68, 1, 13, N'Apple A9, Dual-core 1.84 GHz')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (69, 2, 13, N'IOS')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (70, 4, 13, N'2 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (71, 5, 13, N'16 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (72, 8, 13, N'750 x 1334 px')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (73, 11, 13, N'Yes')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (74, 17, 13, N'12 MP')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (75, 11, 10, N'Yes')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (76, 8, 10, N'750 x 1334 px')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (77, 2, 11, N'IOS')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (78, 4, 10, N'2 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (79, 2, 10, N'IOS')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (80, 17, 9, N'12 MP')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (81, 1, 10, N'Apple A9, Dual-core 1.84 GHz')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (82, 5, 10, N'16 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (83, 11, 9, N'Yes')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (84, 8, 9, N'750 x 1334 px')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (85, 2, 9, N'IOS')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (86, 4, 9, N'2 GB')
INSERT [dbo].[Catalog_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (87, 5, 9, N'16 GB')
SET IDENTITY_INSERT [dbo].[Catalog_ProductAttributeValue] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_ProductCategory] ON 
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (1, 6, 0, 0, 3)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (2, 4, 0, 0, 3)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (3, 4, 0, 0, 4)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (4, 6, 0, 0, 4)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (5, 5, 0, 0, 3)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (6, 6, 0, 0, 2)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (7, 5, 0, 0, 2)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (8, 5, 0, 0, 4)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (9, 4, 0, 0, 2)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (10, 4, 0, 0, 1)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (11, 6, 0, 0, 1)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (12, 5, 0, 0, 1)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (13, 3, 0, 0, 7)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (14, 3, 0, 0, 8)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (15, 1, 0, 0, 8)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (16, 1, 0, 0, 7)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (17, 2, 0, 0, 7)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (18, 3, 0, 0, 6)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (19, 2, 0, 0, 6)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (20, 2, 0, 0, 8)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (21, 1, 0, 0, 6)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (22, 1, 0, 0, 5)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (23, 3, 0, 0, 5)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (24, 2, 0, 0, 5)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (25, 1, 0, 0, 12)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (26, 3, 0, 0, 9)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (27, 2, 0, 0, 9)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (28, 1, 0, 0, 9)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (29, 2, 0, 0, 11)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (30, 1, 0, 0, 11)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (31, 3, 0, 0, 12)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (32, 1, 0, 0, 13)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (33, 2, 0, 0, 13)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (34, 3, 0, 0, 13)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (35, 2, 0, 0, 10)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (36, 3, 0, 0, 10)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (37, 1, 0, 0, 10)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (38, 3, 0, 0, 11)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (39, 2, 0, 0, 12)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (40, 7, 0, 0, 14)
INSERT [dbo].[Catalog_ProductCategory] ([Id], [CategoryId], [DisplayOrder], [IsFeaturedProduct], [ProductId]) VALUES (41, 9, 0, 0, 14)
SET IDENTITY_INSERT [dbo].[Catalog_ProductCategory] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_ProductLink] ON 
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (1, 1, 4, 1)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (2, 1, 2, 1)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (3, 1, 3, 1)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (4, 1, 6, 5)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (5, 1, 8, 5)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (6, 1, 7, 5)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (7, 1, 12, 9)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (8, 1, 10, 9)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (9, 1, 11, 9)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (10, 1, 13, 9)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (11, 2, 9, 5)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (12, 2, 5, 9)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (13, 2, 14, 1)
INSERT [dbo].[Catalog_ProductLink] ([Id], [LinkType], [LinkedProductId], [ProductId]) VALUES (14, 2, 1, 14)
SET IDENTITY_INSERT [dbo].[Catalog_ProductLink] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_ProductOptionCombination] ON 
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (1, 0, 1, 2, N'Gray')
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (2, 0, 1, 3, N'Silver')
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (3, 0, 1, 4, N'Gold')
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (4, 0, 1, 6, N'Pink')
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (5, 0, 1, 8, N'Gold')
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (6, 0, 1, 7, N'Black')
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (7, 0, 1, 11, N'Pink')
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (8, 0, 1, 10, N'Gray')
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (9, 0, 1, 12, N'Gold')
INSERT [dbo].[Catalog_ProductOptionCombination] ([Id], [SortIndex], [OptionId], [ProductId], [Value]) VALUES (10, 0, 1, 13, N'Silver')
SET IDENTITY_INSERT [dbo].[Catalog_ProductOptionCombination] OFF 
GO

SET IDENTITY_INSERT [dbo].[Catalog_ProductOptionValue] ON 
INSERT [dbo].[Catalog_ProductOptionValue] ([Id], [SortIndex], [DisplayType], [OptionId], [ProductId], [Value]) VALUES (1, 0, 'color', 1, 1, N'[{{"Key":"Silver","Display":"#E5E4EA"}},{{"Key":"Gold","Display":"#daa520"}},{{"Key":"Gray","Display":"#a9a9a9"}}]')
INSERT [dbo].[Catalog_ProductOptionValue] ([Id], [SortIndex], [DisplayType], [OptionId], [ProductId], [Value]) VALUES (2, 0, 'color', 1, 5, N'[{{"Key":"Gold","Display":"#daa520"}},{{"Key":"Black","Display":"#000000"}},{{"Key":"Pink","Display":"#FFC0CB"}}]')
INSERT [dbo].[Catalog_ProductOptionValue] ([Id], [SortIndex], [DisplayType], [OptionId], [ProductId], [Value]) VALUES (3, 0, 'color', 1, 9, N'[{{"Key":"Gray","Display":"#a9a9a9"}},{{"Key":"Pink","Display":"#FFC0CB"}},{{"Key":"Gold","Display":"#daa520"}},{{"Key":"Silver","Display":"#E5E4EA"}}]')
SET IDENTITY_INSERT [dbo].[Catalog_ProductOptionValue] OFF 
GO

SET IDENTITY_INSERT [dbo].[Inventory_Stock] ON 
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (2, 2, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (3, 3, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (4, 4, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (6, 6, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (7, 7, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (8, 8, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (10, 10, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (11, 11, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (12, 12, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (13, 13, 10, 1, 0)
INSERT [dbo].[Inventory_Stock] ([Id], [ProductId], [Quantity], [WarehouseId], [ReservedQuantity]) VALUES (14, 14, 10, 1, 0)
SET IDENTITY_INSERT [dbo].[Inventory_Stock] OFF 
GO

SET IDENTITY_INSERT [dbo].[Inventory_StockHistory] ON 
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (1, 10, 10, CAST(N'2018-01-23T09:49:39.4372243+07:00' AS DateTimeOffset), NULL, 14, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (2, 10, 10, CAST(N'2018-01-23T09:49:39.6950025+07:00' AS DateTimeOffset), NULL, 13, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (3, 10, 10, CAST(N'2018-01-23T09:49:39.7177315+07:00' AS DateTimeOffset), NULL, 12, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (4, 10, 10, CAST(N'2018-01-23T09:49:39.7356927+07:00' AS DateTimeOffset), NULL, 11, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (5, 10, 10, CAST(N'2018-01-23T09:49:39.7424939+07:00' AS DateTimeOffset), NULL, 10, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (6, 10, 10, CAST(N'2018-01-23T09:49:39.7496600+07:00' AS DateTimeOffset), NULL, 8, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (7, 10, 10, CAST(N'2018-01-23T09:49:39.7559222+07:00' AS DateTimeOffset), NULL, 7, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (8, 10, 10, CAST(N'2018-01-23T09:49:39.7618612+07:00' AS DateTimeOffset), NULL, 6, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (9, 10, 10, CAST(N'2018-01-23T09:49:39.7677309+07:00' AS DateTimeOffset), NULL, 4, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (10, 10, 10, CAST(N'2018-01-23T09:49:39.7739607+07:00' AS DateTimeOffset), NULL, 3, 1)
INSERT [dbo].[Inventory_StockHistory] ([Id], [AdjustedQuantity], [CreatedById], [CreatedOn], [Note], [ProductId], [WareHouseId]) VALUES (11, 10, 10, CAST(N'2018-01-23T09:49:39.7802334+07:00' AS DateTimeOffset), NULL, 2, 1)
SET IDENTITY_INSERT [dbo].[Inventory_StockHistory] OFF 
GO

SET IDENTITY_INSERT [dbo].[Cms_Page] ON 
INSERT [dbo].[Cms_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (1, N'<h1>About us</h1><p>Your information. Use admin site to update</p>', N'About us', N'about-us', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-10 08:45:44.953' AS DateTime), CAST(N'2016-04-10 08:45:44.953' AS DateTime), NULL, NULL)

INSERT [dbo].[Cms_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (2, N'<h1>Term and Conditions</h1><p>Your term and conditions. Use admin site to update</p>', N'Terms & Conditions', N'terms-of-use', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 02:54:57.177' AS DateTime), CAST(N'2016-04-11 02:54:57.177' AS DateTime), NULL, NULL)

INSERT [dbo].[Cms_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (3, N'<h1>Privacy Policy</h1><p>Your privacy policy information. Use admin site to update</p>', N'Privacy Policy', N'privacy', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 02:59:31.963' AS DateTime), CAST(N'2016-04-11 02:59:31.963' AS DateTime), NULL, NULL)

INSERT [dbo].[Cms_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (4, N'<h1>Help center</h1><p><a href="/help-center/how-to-buy">How to buy</a></p><p><a href="help-center/shipping">Shipping and delivery</a></p><p><a href="help-center/how-to-return">How to return</a></p><p><a href="help-center/warranty">Warranty</a></p>', N'Help Center', N'help-center', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 03:14:04.447' AS DateTime), CAST(N'2016-04-11 03:14:04.447' AS DateTime), NULL, NULL)

INSERT [dbo].[Cms_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (5, N'<h1>How to buy</h1><p>Your how to buy instructions. Use admin site to update</p>', N'How to buy', N'help-center/how-to-buy', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 03:16:14.323' AS DateTime), CAST(N'2016-04-11 03:24:13.833' AS DateTime), NULL, NULL)

INSERT [dbo].[Cms_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (6, N'<h1>Shipping and Delivery</h1><p>Shipping and delivery information. Use admin site to update</p>', N'Shipping and delivery', N'help-center/shipping', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 02:57:13.497' AS DateTime), CAST(N'2016-04-11 03:23:31.597' AS DateTime), NULL, NULL)

INSERT [dbo].[Cms_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (7, N'<h1>How to return</h1><p>Your how to return instructions. Use admin site to update</p>', N'How to return', N'help-center/how-to-return', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 03:17:42.067' AS DateTime), CAST(N'2016-04-11 03:17:42.067' AS DateTime), NULL, NULL)

INSERT [dbo].[Cms_Page] ([Id], [Body], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [UpdatedById]) VALUES (8, N'<h1>Warranty</h1><p>Your warranty policy. Use admin site to update</p>', N'Warranty', N'help-center/warranty', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-04-11 03:19:01.927' AS DateTime), CAST(N'2016-04-11 03:19:01.927' AS DateTime), NULL, NULL)

SET IDENTITY_INSERT [dbo].[Cms_Page] OFF 
GO

SET IDENTITY_INSERT [dbo].[Core_WidgetInstance] ON 
INSERT [dbo].[Core_WidgetInstance] ([Id], [CreatedOn], [Data], [DisplayOrder], [HtmlData], [Name], [PublishEnd], [PublishStart], [UpdatedOn], [WidgetId], [WidgetZoneId]) VALUES (1, CAST(N'2016-07-11 05:29:31.1868415' AS DateTime2), N'[{{"Image":"7d868097-58a5-43f8-a882-6d7872345fe7.jpg","ImageUrl":null,"Caption":null,"TargetUrl":"#"}},{{"Image":"d539b558-15ea-4317-9a5b-62e4db9a45f5.jpg","ImageUrl":null,"Caption":null,"TargetUrl":"#"}},{{"Image":"e543ed8e-5feb-4a39-8860-51d94a00ee31.jpg","ImageUrl":null,"Caption":null,"TargetUrl":"#"}},{{"Image":"c015d99d-6c3b-4337-9ba7-26822d75a8e2.jpg","ImageUrl":null,"Caption":null,"TargetUrl":"#"}}]', 0, NULL, N'Home Carousel', NULL, CAST(N'2016-07-11 05:42:44.7523284' AS DateTime2), CAST(N'2016-07-11 05:29:31.1868415' AS DateTime2), 1, 1)

INSERT [dbo].[Core_WidgetInstance] ([Id], [CreatedOn], [Data], [DisplayOrder], [HtmlData], [Name], [PublishEnd], [PublishStart], [UpdatedOn], [WidgetId], [WidgetZoneId]) VALUES (2, CAST(N'2016-07-11 05:30:49.3473494' AS DateTime2), N'{{"NumberOfProducts":4,"CategoryIds":null,"OrderBy":0,"FeaturedOnly":false}}', 0, NULL, N'Latest Products', NULL, CAST(N'2016-07-11 05:42:44.7523284' AS DateTime2), CAST(N'2016-07-11 05:30:49.3473494' AS DateTime2), 3, 2)
INSERT [dbo].[Core_WidgetInstance] ([Id], [CreatedOn], [Data], [DisplayOrder], [HtmlData], [Name], [PublishEnd], [PublishStart], [UpdatedOn], [WidgetId], [WidgetZoneId]) VALUES (3, CAST(N'2018-01-03T15:20:53.1550824+07:00' AS DateTimeOffset), N'[{{"IconHtml":"fa fa-truck","Title":"Free Shipping","Description":"For orders over $99"}},{{"IconHtml":"fa fa-money","Title":"Money Return","Description":"30 days money return"}},{{"IconHtml":"fa fa-credit-card-alt","Title":"Safe Payment","Description":"Protected online payment"}}]', 0, NULL, N'Home Promote Content', NULL, CAST(N'2018-01-03T08:16:47.1160000+00:00' AS DateTimeOffset), CAST(N'2018-01-03T15:20:53.1552733+07:00' AS DateTimeOffset), 5, 3)
INSERT [dbo].[Core_WidgetInstance] ([Id], [CreatedOn], [Data], [DisplayOrder], [HtmlData], [Name], [PublishEnd], [PublishStart], [UpdatedOn], [WidgetId], [WidgetZoneId]) VALUES (4, CAST(N'2016-07-11 05:42:44.7523284' AS DateTime2), NULL, 0, N'
<div>
    <h2 class="page-header">Administrator</h2>
    <p>Manage your store. Admin email: admin@SimplCommerce.com. Admin password: 1qazZAQ!</p>
    <p>
        <a class="btn btn-primary" href="Admin" role="button">Go to Dashboard</a>
    </p>
</div>', N'Administration', NULL, CAST(N'2016-07-11 05:42:44.7523284' AS DateTime2), CAST(N'2016-07-11 05:42:44.7523284' AS DateTime2), 2, 3)
SET IDENTITY_INSERT [dbo].[Core_WidgetInstance] OFF 
GO

SET IDENTITY_INSERT [dbo].[Core_Entity] ON 
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (1, 1, 1, N'Phones', N'phones')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (2, 2, 1, N'Smart Phones', N'smart-phones')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (3, 3, 1, N'Basic Phones', N'basic-phones')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (4, 4, 1, N'Tablets', N'tablets')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (5, 5, 1, N'Wifi Cellular Tablets', N'wifi-cellular-tablets')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (6, 6, 1, N'Cellular Tablets', N'cellular-tablets')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (7, 7, 1, N'Computers', N'computers')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (8, 8, 1, N'Gaming', N'gaming')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (9, 9, 1, N'Business', N'business')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (10, 10, 1, N'Accessories', N'accessories')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (11, 11, 1, N'Headphones', N'headphones')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (12, 12, 1, N'Cables', N'cables')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (13, 13, 1, N'Usb Drives', N'usb-drives')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (18, 1, 4, N'About Us', N'about-us')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (19, 2, 4, N'Terms of Use', N'terms-of-use')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (20, 3, 4, N'Privacy', N'privacy')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (21, 4, 4, N'Help Center', N'help-center')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (22, 5, 4, N'How to buy', N'help-center/how-to-buy')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (23, 6, 4, N'Shipping', N'help-center/shipping')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (24, 7, 4, N'How to return', N'help-center/how-to-return')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (25, 8, 4, N'Warranty', N'help-center/warranty')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (26, 1, 3, N'IPad pro Wifi 4G 128GB', N'ipad-pro-wi-fi-4g-128gb')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (27, 5, 3, N'Samsung Galaxy A5', N'samsung-galaxy-a5')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (28, 9, 3, N'IPhone 6S 16GB', N'iphone-6s-16gb')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (29, 1, 2, N'Apple', N'apple')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (30, 2, 2, N'Samsung', N'samsung')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (31, 3, 2, N'Dell', N'dell')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (32, 14, 3, N'Dell XPS 15 9550', N'dell-xps-15-9550')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (33, 14, 1, N'Test 1', N'test-1')
INSERT [dbo].[Core_Entity] ([Id], [EntityId], [EntityTypeId], [Name], [Slug]) VALUES (34, 15, 1, N'Test 2', N'test-2')
SET IDENTITY_INSERT [dbo].[Core_Entity] OFF 
GO

SET IDENTITY_INSERT [dbo].[Cms_MenuItem] ON 
INSERT [dbo].[Cms_MenuItem] ([Id], [CustomLink], [EntityId], [MenuId], [ParentId], [Name]) VALUES (1, NULL, 21, 1, NULL, N'Help Center')
INSERT [dbo].[Cms_MenuItem] ([Id], [CustomLink], [EntityId], [MenuId], [ParentId], [Name]) VALUES (2, NULL, 22, 1, NULL, N'How to buy')
INSERT [dbo].[Cms_MenuItem] ([Id], [CustomLink], [EntityId], [MenuId], [ParentId], [Name]) VALUES (3, NULL, 23, 1, NULL, N'Shipping')
INSERT [dbo].[Cms_MenuItem] ([Id], [CustomLink], [EntityId], [MenuId], [ParentId], [Name]) VALUES (4, NULL, 24, 1, NULL, N'How to return')
INSERT [dbo].[Cms_MenuItem] ([Id], [CustomLink], [EntityId], [MenuId], [ParentId], [Name]) VALUES (5, NULL, 25, 1, NULL, N'Warranty')
INSERT [dbo].[Cms_MenuItem] ([Id], [CustomLink], [EntityId], [MenuId], [ParentId], [Name]) VALUES (6, NULL, 18, 2, NULL, N'About Us')
INSERT [dbo].[Cms_MenuItem] ([Id], [CustomLink], [EntityId], [MenuId], [ParentId], [Name]) VALUES (7, NULL, 19, 2, NULL, N'Terms of Use')
INSERT [dbo].[Cms_MenuItem] ([Id], [CustomLink], [EntityId], [MenuId], [ParentId], [Name]) VALUES (8, NULL, 20, 2, NULL, N'Privacy')
SET IDENTITY_INSERT [dbo].[Cms_MenuItem] OFF 
GO
