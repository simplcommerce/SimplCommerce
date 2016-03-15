DELETE FROM [dbo].[Core_UrlSlug]
GO
DELETE FROM [dbo].[Core_ProductAttributeCombination]
GO
DELETE FROM [dbo].[Orders_ShoppingCartItem]
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

GO
INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (1, N'Computers', N'computers', NULL, 0, 1, 0, NULL, NULL)
GO
INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (2, N'Laptops', N'laptops', NULL, 0, 1, 0, 1, NULL)
GO
INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (3, N'Desktop', N'desktop', NULL, 0, 1, 0, 1, NULL)
GO
INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (4, N'Phones', N'phones', NULL, 0, 1, 0, NULL, NULL)
GO
INSERT [dbo].[Core_Category] ([Id], [Name], [SeoTitle], [Description], [DisplayOrder], [IsPublished], [IsDeleted], [ParentId], [Image]) VALUES (5, N'Book', N'book', NULL, 0, 1, 0, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Core_Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_Media] ON 

GO
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (1, NULL, 0, N'68053a72-56c2-49fa-8770-fa346b8a397d..jpeg', 0)
GO
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (2, NULL, 0, N'ce7afb9c-f12c-4c5a-abaa-a22df9eb0fd6..jpeg', 0)
GO
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (3, NULL, 0, N'c1181f07-0f19-44d5-a1b5-44f0b56924cd..jpeg', 0)
GO
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (4, NULL, 0, N'b5e7e195-6c81-4440-80d6-ba6beaa5db54..jpeg', 0)
GO
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (5, NULL, 0, N'1d146691-ba4d-4a4a-a39b-3ca438ff7787..jpeg', 0)
GO
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (6, NULL, 0, N'c4f469af-9f0a-4bfc-93ff-6bbc755e7566..jpeg', 0)
GO
INSERT [dbo].[Core_Media] ([Id], [Caption], [FileSize], [FileName], [MediaType]) VALUES (7, NULL, 0, N'7cb6b059-632c-494a-afbf-6e3e29038b21..jpg', 0)
GO
SET IDENTITY_INSERT [dbo].[Core_Media] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_Product] ON 

GO
INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (1, N'a very powerful laptop', N'a very powerful laptop', NULL, CAST(21.00 AS Decimal(18, 2)), CAST(32121.00 AS Decimal(18, 2)), 0, N'HP Elite 8570w', N'hp-elite-8570w', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-07 14:06:23.167' AS DateTime), CAST(N'2016-03-07 14:06:23.167' AS DateTime), NULL, NULL, NULL)
GO
INSERT [dbo].[Core_Product] ([Id], [ShortDescription], [Description], [Specification], [Price], [OldPrice], [DisplayOrder], [Name], [SeoTitle], [MetaTitle], [MetaKeywords], [MetaDescription], [IsPublished], [PublishedOn], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ThumbnailImageId], [UpdatedById]) VALUES (2, N'fsdfsd', N'fsdfds', NULL, CAST(32.00 AS Decimal(18, 2)), CAST(4234.00 AS Decimal(18, 2)), 0, N'Test', N'test', NULL, NULL, NULL, 1, NULL, 0, CAST(N'2016-03-15 16:33:52.830' AS DateTime), CAST(N'2016-03-15 16:33:52.830' AS DateTime), NULL, 7, NULL)
GO
SET IDENTITY_INSERT [dbo].[Core_Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_ProductCategory] ON 

GO
INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (1, 0, 0, 2, 1)
GO
INSERT [dbo].[Core_ProductCategory] ([Id], [IsFeaturedProduct], [DisplayOrder], [CategoryId], [ProductId]) VALUES (2, 0, 0, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[Core_ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_ProductMedia] ON 

GO
INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (1, 2, 1, 0)
GO
INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (2, 2, 2, 0)
GO
INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (3, 2, 3, 0)
GO
INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (4, 2, 4, 0)
GO
INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (5, 2, 5, 0)
GO
INSERT [dbo].[Core_ProductMedia] ([Id], [ProductId], [MediaId], [DisplayOrder]) VALUES (6, 2, 6, 0)
GO
SET IDENTITY_INSERT [dbo].[Core_ProductMedia] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_ProductAttribute] ON 

GO
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name]) VALUES (1, N'Color')
GO
INSERT [dbo].[Core_ProductAttribute] ([Id], [Name]) VALUES (2, N'Size')
GO
SET IDENTITY_INSERT [dbo].[Core_ProductAttribute] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_ProductAttributeValue] ON 

GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (1, 1, 1, N'Red')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (2, 1, 1, N'Gree')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (3, 1, 1, N'Blue')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (4, 2, 1, N'L')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (5, 2, 1, N'M')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (6, 2, 1, N'S')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (7, 2, 2, N'L')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (8, 2, 2, N'M')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (9, 2, 2, N'S')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (10, 1, 2, N'RED')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (11, 1, 2, N'GREEN')
GO
INSERT [dbo].[Core_ProductAttributeValue] ([Id], [AttributeId], [ProductId], [Value]) VALUES (12, 1, 2, N'BLUE')
GO
SET IDENTITY_INSERT [dbo].[Core_ProductAttributeValue] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_ProductVariation] ON 

GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (1, N'Red-L', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-07 07:06:23.167' AS DateTime), CAST(N'2016-03-07 07:06:23.167' AS DateTime), NULL, 1, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (2, N'Red-M', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-07 07:06:23.167' AS DateTime), CAST(N'2016-03-07 07:06:23.167' AS DateTime), NULL, 1, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (3, N'Red-S', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-07 07:06:23.167' AS DateTime), CAST(N'2016-03-07 07:06:23.167' AS DateTime), NULL, 1, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (4, N'Gree-L', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-07 07:06:23.167' AS DateTime), CAST(N'2016-03-07 07:06:23.167' AS DateTime), NULL, 1, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (5, N'Gree-M', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-07 07:06:23.167' AS DateTime), CAST(N'2016-03-07 07:06:23.167' AS DateTime), NULL, 1, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (6, N'Gree-S', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-07 07:06:23.167' AS DateTime), CAST(N'2016-03-07 07:06:23.167' AS DateTime), NULL, 1, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (7, N'Blue-L', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-07 07:06:23.167' AS DateTime), CAST(N'2016-03-07 07:06:23.167' AS DateTime), NULL, 1, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (8, N'Blue-M', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-07 07:06:23.167' AS DateTime), CAST(N'2016-03-07 07:06:23.167' AS DateTime), NULL, 1, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (9, N'Blue-S', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-07 07:06:23.167' AS DateTime), CAST(N'2016-03-07 07:06:23.167' AS DateTime), NULL, 1, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (10, N'L-RED', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 09:33:52.833' AS DateTime), CAST(N'2016-03-15 09:33:52.833' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (11, N'L-GREEN', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 09:33:52.833' AS DateTime), CAST(N'2016-03-15 09:33:52.833' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (12, N'L-BLUE', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 09:33:52.833' AS DateTime), CAST(N'2016-03-15 09:33:52.833' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (13, N'M-RED', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 09:33:52.833' AS DateTime), CAST(N'2016-03-15 09:33:52.833' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (14, N'M-GREEN', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 09:33:52.833' AS DateTime), CAST(N'2016-03-15 09:33:52.833' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (15, N'M-BLUE', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 09:33:52.833' AS DateTime), CAST(N'2016-03-15 09:33:52.833' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (16, N'S-RED', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 09:33:52.833' AS DateTime), CAST(N'2016-03-15 09:33:52.833' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (17, N'S-GREEN', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 09:33:52.833' AS DateTime), CAST(N'2016-03-15 09:33:52.833' AS DateTime), NULL, 2, NULL)
GO
INSERT [dbo].[Core_ProductVariation] ([Id], [Name], [Sku], [PriceOffset], [IsAllowOrder], [ReasonNotAllowOrder], [DisplayOrder], [IsPublished], [IsDeleted], [CreatedOn], [UpdatedOn], [CreatedById], [ProductId], [UpdatedById]) VALUES (18, N'S-BLUE', NULL, CAST(0.00 AS Decimal(18, 2)), 0, NULL, 0, 0, 0, CAST(N'2016-03-15 09:33:52.833' AS DateTime), CAST(N'2016-03-15 09:33:52.833' AS DateTime), NULL, 2, NULL)
GO
SET IDENTITY_INSERT [dbo].[Core_ProductVariation] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_ProductAttributeCombination] ON 

GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (1, 1, 1, N'Red')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (2, 1, 2, N'L')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (3, 2, 1, N'Red')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (4, 2, 2, N'M')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (5, 3, 1, N'Red')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (6, 3, 2, N'S')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (7, 4, 1, N'Gree')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (8, 4, 2, N'L')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (9, 5, 1, N'Gree')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (10, 5, 2, N'M')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (11, 6, 1, N'Gree')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (12, 6, 2, N'S')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (13, 7, 1, N'Blue')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (14, 7, 2, N'L')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (15, 8, 1, N'Blue')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (16, 8, 2, N'M')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (17, 9, 1, N'Blue')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (18, 9, 2, N'S')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (19, 10, 2, N'L')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (20, 10, 1, N'RED')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (21, 11, 2, N'L')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (22, 11, 1, N'GREEN')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (23, 12, 2, N'L')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (24, 12, 1, N'BLUE')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (25, 13, 2, N'M')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (26, 13, 1, N'RED')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (27, 14, 2, N'M')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (28, 14, 1, N'GREEN')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (29, 15, 2, N'M')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (30, 15, 1, N'BLUE')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (31, 16, 2, N'S')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (32, 16, 1, N'RED')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (33, 17, 2, N'S')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (34, 17, 1, N'GREEN')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (35, 18, 2, N'S')
GO
INSERT [dbo].[Core_ProductAttributeCombination] ([Id], [VariationId], [AttributeId], [Value]) VALUES (36, 18, 1, N'BLUE')
GO
SET IDENTITY_INSERT [dbo].[Core_ProductAttributeCombination] OFF
GO
SET IDENTITY_INSERT [dbo].[Core_UrlSlug] ON 

GO
INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (1, N'computers', 1, N'Category')
GO
INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (2, N'laptops', 2, N'Category')
GO
INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (3, N'desktop', 3, N'Category')
GO
INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (4, N'phones', 4, N'Category')
GO
INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (5, N'book', 5, N'Category')
GO
INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (6, N'hp-elite-8570w', 1, N'Product')
GO
INSERT [dbo].[Core_UrlSlug] ([Id], [Slug], [EntityId], [EntityName]) VALUES (7, N'test', 2, N'Product')
GO
SET IDENTITY_INSERT [dbo].[Core_UrlSlug] OFF
GO
