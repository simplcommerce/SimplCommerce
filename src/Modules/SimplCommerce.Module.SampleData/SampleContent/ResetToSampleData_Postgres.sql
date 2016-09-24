DELETE FROM "Core_UrlSlug";
DELETE FROM "Orders_CartItem";
DELETE FROM "Orders_OrderItem";
DELETE FROM "Orders_Order";
DELETE FROM "Catalog_ProductAttributeValue";
DELETE FROM "Catalog_ProductOptionCombination";
DELETE FROM "Catalog_ProductOptionValue";
DELETE FROM "Catalog_ProductAttribute";
DELETE FROM "Catalog_ProductAttributeGroup";
DELETE FROM "Catalog_ProductMedia";
DELETE FROM "Catalog_ProductCategory";
DELETE FROM "Catalog_ProductLink";
DELETE FROM "Catalog_Product";
DELETE FROM "Core_Media";
DELETE FROM "Catalog_Category";
DELETE FROM "Catalog_Brand";
DELETE FROM "Catalog_ProductTemplateProductAttribute";
DELETE FROM "Catalog_ProductTemplate";
DELETE FROM "Cms_Page";


INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (1, 'Phones', 'phones', NULL, 0, true, false, NULL, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (2, 'Smart Phones', 'smart-phones', NULL, 0, true, false, 1, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (3, 'Basic Phones', 'basic-phones', NULL, 0, true, false, 1, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (4, 'Tablets', 'tablets', NULL, 0, true, false, NULL, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (5, 'Wifi + Cellular tablets', 'wifi-cellular-tablets', NULL, 0, true, false, 4, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (6, 'Cellular tablets', 'cellular-tablets', NULL, 0, true, false, 4, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (7, 'Computers', 'computers', NULL, 0, true, false, NULL, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (8, 'Gaming', 'gaming', NULL, 0, true, false, 7, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (9, 'Business', 'business', NULL, 0, true, false, 7, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (10, 'Accessories', 'accessories', NULL, 0, true, false, NULL, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (11, 'Headphones', 'headphones', NULL, 0, true, false, 10, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (12, 'Cables', 'cables', NULL, 0, true, false, 10, NULL);

INSERT INTO "Catalog_Category" ("Id", "Name", "SeoTitle", "Description", "DisplayOrder", "IsPublished", "IsDeleted", "ParentId", "Image") VALUES (13, 'USB Drives', 'usb-drives', NULL, 0, true, false, 10, NULL);


INSERT INTO "Catalog_Brand" ("Id", "Name", "SeoTitle", "Description", "IsPublished", "IsDeleted") VALUES (1, 'Apple', 'apple', NULL, true, false);
INSERT INTO "Catalog_Brand" ("Id", "Name", "SeoTitle", "Description", "IsPublished", "IsDeleted") VALUES (2, 'Samsung', 'samsung', NULL, true, false);
INSERT INTO "Catalog_Brand" ("Id", "Name", "SeoTitle", "Description", "IsPublished", "IsDeleted") VALUES (3, 'Dell', 'dell', NULL, true, false);



INSERT INTO "Catalog_ProductAttributeGroup" ("Id", "Name") VALUES (1, 'General');
INSERT INTO "Catalog_ProductAttributeGroup" ("Id", "Name") VALUES (2, 'Scree');
INSERT INTO "Catalog_ProductAttributeGroup" ("Id", "Name") VALUES (3, 'Connectivity');
INSERT INTO "Catalog_ProductAttributeGroup" ("Id", "Name") VALUES (4, 'Camera');


INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (1, 'CPU', 1);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (2, 'OS', 1);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (3, 'GPU', 1);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (4, 'RAM', 1);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (5, 'Capacity', 1);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (6, 'Size', 2);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (7, 'Type', 2);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (8, 'Resolutio', 2);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (9, '2G', 3);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (10, '3G', 3);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (11, '4G', 3);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (12, 'Wifi', 3);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (13, 'Bluetooth', 3);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (14, 'NFC', 3);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (15, 'USP', 3);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (16, 'GPS', 3);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (17, 'Main camera', 4);
INSERT INTO "Catalog_ProductAttribute" ("Id", "Name", "GroupId") VALUES (18, 'Sub camera', 4);


INSERT INTO "Catalog_ProductTemplate" ("Id", "Name") VALUES (1, 'Tablet');
INSERT INTO "Catalog_ProductTemplate" ("Id", "Name") VALUES (2, 'Phone');


INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (1, 1);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (1, 2);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (1, 3);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (1, 4);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 1);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 2);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 3);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 4);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 5);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 6);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 7);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 8);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 11);
INSERT INTO "Catalog_ProductTemplateProductAttribute" ("ProductTemplateId", "ProductAttributeId") VALUES (2, 17);


INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (1, NULL, 'd74fd909-6fe0-4bc3-bf61-86d12dc98a2e.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (2, NULL, '81b606ea-0bb0-4cea-a9d7-6406175df9bb.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (3, NULL, '68c7ff8f-014e-46c8-8daa-f35c646cc10a.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (4, NULL, '89374e88-b14c-4d38-b5cd-eacdc5ce3015.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (5, NULL, 'ffc255b3-07c8-4ee5-94e9-d472c6af3f07.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (6, NULL, 'bb1243c9-63d5-4518-bbd5-cb3e35ade294.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (7, NULL, '282e5cd3-b664-43dc-ba06-d7e91721c560.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (8, NULL, 'd013921e-5f11-4472-b5ff-7f78d5987a69.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (9, NULL, 'ea0af866-a650-4909-877d-00eabbf3d8fd.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (10, NULL, '3a3f587c-9c70-4e68-b480-20829a9f3e95.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (11, NULL, 'f9a76a94-6e1a-4489-bf7d-3dc6a68a0785.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (12, NULL, 'a88b4a09-5824-4398-ac08-101d9061f927.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (13, NULL, 'fdfd1daf-ec7a-4c6e-83dd-a862eae735db.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (14, NULL, '4495b930-a901-44e2-9275-935f7e8ec53c.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (15, NULL, '284b77c8-2ba8-43e1-826d-7c79c5cf4489.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (16, NULL, 'e32c3caa-f7bc-4a3c-b970-f62c503b85bc.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (17, NULL, 'bffb6f2c-8a3f-4fdd-817d-09a9f18cd190.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (18, NULL, '25d3da45-b57b-40b6-8f41-2fc5170cb6b7.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (19, NULL, '7da07700-9a17-498b-ba58-526559343878.jpg', 0, 0);
INSERT INTO "Core_Media" ("Id", "Caption", "FileName", "FileSize", "MediaType") VALUES (20, NULL, 'fefe68b9-aee8-4e7d-a49a-17f805555591.jpg', 0, 0);


INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (1, true, 1, NULL, '2016-06-19 00:15:59.94', '<p><img src="/user-content/9874f0f5-46dc-495d-8c61-2c515577aa05.jpg" style="width: 976px;"></p><p>Suốt thời gian qua, iPad vẫn luôn được đánh giá là dòng sản phẩm máy tính bảng tốt nhất. Với khả năng tối ưu hoàn hảo giữa thiết kế phần cứng và hệ điều hành iOS, iPad luôn đáp ứng mọi tác vụ người dùng một cách trơn tru và mượt mà tuyệt đối. Và, trong khi không còn nhiều tên tuổi mặn mà với dòng sản phẩm tablet cao cấp, Apple lại tiếp tục ra mắt iPad Pro, một siêu phẩm với niềm tin sẽ đưa chuẩn mực của một chiếc máy tính bảng lên tầm cao mới.</p><p><img src="/user-content/5887a479-bb96-436f-8414-fa188cdc2aac.jpg" style="width: 976px;"></p><p>Hãng “táo cắn dở” trong suốt một thời gian dài vẫn trung thành với màn hình 9.7 inch của iPad thường, 7.9 inch với dòng iPad Mini. Nhưng trên iPad Pro, tiêu chuẩn ấy đã hoàn toàn bị phá vỡ với kích thước lên tới 12.9 inch, độ phân giải “chuẩn” Retina 2732 x 2048 pixel. Kích thước của iPad Pro đã lớn hơn tới 78% so với iPad Air 2 trước đó. Kích thước màn hình này cho ta cảm giác đây giống như một chiếc laptop hơn là tablet. Nhưng, kích thước đó cũng sẽ mang tới nhiều không gian trải nghiệm hơn, nhiều khoảng trống làm việc hơn để dành cho nhiều ý tưởng lớn hơn.<br></p>', 0, true, false, true, true, NULL, NULL, NULL, 'iPad Pro Wi-Fi 4G 128GB', NULL, 25000000, 21290000, NULL, 2, 0, 'ipad-pro-wi-fi-4g-128gb', '<p>Bảo hành 12 tháng (hóa đơn)Thiết kế vượt trội với màn hình "ngoại cỡ" 12.9 inchCấu hình mạnh mẽ; hiệu năng nhanh hơn LaptopTương tác thông minh; làm hai việc cùng lúc<br></p>', NULL, NULL, 1, NULL, '2016-06-19 00:15:59.9468401' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (2, true, 1, NULL, '2016-06-19 00:15:59.9798387', '<p><img src="/user-content/9874f0f5-46dc-495d-8c61-2c515577aa05.jpg" style="width: 976px;"></p><p>Suốt thời gian qua, iPad vẫn luôn được đánh giá là dòng sản phẩm máy tính bảng tốt nhất. Với khả năng tối ưu hoàn hảo giữa thiết kế phần cứng và hệ điều hành iOS, iPad luôn đáp ứng mọi tác vụ người dùng một cách trơn tru và mượt mà tuyệt đối. Và, trong khi không còn nhiều tên tuổi mặn mà với dòng sản phẩm tablet cao cấp, Apple lại tiếp tục ra mắt iPad Pro, một siêu phẩm với niềm tin sẽ đưa chuẩn mực của một chiếc máy tính bảng lên tầm cao mới.</p><p><img src="/user-content/5887a479-bb96-436f-8414-fa188cdc2aac.jpg" style="width: 976px;"></p><p>Hãng “táo cắn dở” trong suốt một thời gian dài vẫn trung thành với màn hình 9.7 inch của iPad thường, 7.9 inch với dòng iPad Mini. Nhưng trên iPad Pro, tiêu chuẩn ấy đã hoàn toàn bị phá vỡ với kích thước lên tới 12.9 inch, độ phân giải “chuẩn” Retina 2732 x 2048 pixel. Kích thước của iPad Pro đã lớn hơn tới 78% so với iPad Air 2 trước đó. Kích thước màn hình này cho ta cảm giác đây giống như một chiếc laptop hơn là tablet. Nhưng, kích thước đó cũng sẽ mang tới nhiều không gian trải nghiệm hơn, nhiều khoảng trống làm việc hơn để dành cho nhiều ý tưởng lớn hơn.<br></p>', 0, false, false, true, false, NULL, NULL, NULL, 'iPad Pro Wi-Fi 4G 128GB Gray', 'Gray', 25000000, 20290000, '2016-06-19 00:15:59.9798387', 2, 0 , 'ipad-pro-wi-fi-4g-128gb-gray', '<p>Bảo hành 12 tháng (hóa đơn)Thiết kế vượt trội với màn hình "ngoại cỡ" 12.9 inchCấu hình mạnh mẽ; hiệu năng nhanh hơn LaptopTương tác thông minh; làm hai việc cùng lúc<br></p>', NULL, NULL, 1, NULL, '2016-06-19 00:15:59.9798387' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (3, true, 1, NULL, '2016-06-19 00:15:59.9818408', '<p><img src="/user-content/9874f0f5-46dc-495d-8c61-2c515577aa05.jpg" style="width: 976px;"></p><p>Suốt thời gian qua, iPad vẫn luôn được đánh giá là dòng sản phẩm máy tính bảng tốt nhất. Với khả năng tối ưu hoàn hảo giữa thiết kế phần cứng và hệ điều hành iOS, iPad luôn đáp ứng mọi tác vụ người dùng một cách trơn tru và mượt mà tuyệt đối. Và, trong khi không còn nhiều tên tuổi mặn mà với dòng sản phẩm tablet cao cấp, Apple lại tiếp tục ra mắt iPad Pro, một siêu phẩm với niềm tin sẽ đưa chuẩn mực của một chiếc máy tính bảng lên tầm cao mới.</p><p><img src="/user-content/5887a479-bb96-436f-8414-fa188cdc2aac.jpg" style="width: 976px;"></p><p>Hãng “táo cắn dở” trong suốt một thời gian dài vẫn trung thành với màn hình 9.7 inch của iPad thường, 7.9 inch với dòng iPad Mini. Nhưng trên iPad Pro, tiêu chuẩn ấy đã hoàn toàn bị phá vỡ với kích thước lên tới 12.9 inch, độ phân giải “chuẩn” Retina 2732 x 2048 pixel. Kích thước của iPad Pro đã lớn hơn tới 78% so với iPad Air 2 trước đó. Kích thước màn hình này cho ta cảm giác đây giống như một chiếc laptop hơn là tablet. Nhưng, kích thước đó cũng sẽ mang tới nhiều không gian trải nghiệm hơn, nhiều khoảng trống làm việc hơn để dành cho nhiều ý tưởng lớn hơn.<br></p>', 0, false, false, true, false, NULL, NULL, NULL, 'iPad Pro Wi-Fi 4G 128GB Silver', 'Silver', 25000000, 21290000, '2016-06-19 00:15:59.9818408', 2, 0 , 'ipad-pro-wi-fi-4g-128gb-silver', '<p>Bảo hành 12 tháng (hóa đơn)Thiết kế vượt trội với màn hình "ngoại cỡ" 12.9 inchCấu hình mạnh mẽ; hiệu năng nhanh hơn LaptopTương tác thông minh; làm hai việc cùng lúc<br></p>', NULL, NULL, 1, NULL, '2016-06-19 00:15:59.9818408' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (4, true, 1, NULL, '2016-06-19 00:15:59.9818408', '<p><img src="/user-content/9874f0f5-46dc-495d-8c61-2c515577aa05.jpg" style="width: 976px;"></p><p>Suốt thời gian qua, iPad vẫn luôn được đánh giá là dòng sản phẩm máy tính bảng tốt nhất. Với khả năng tối ưu hoàn hảo giữa thiết kế phần cứng và hệ điều hành iOS, iPad luôn đáp ứng mọi tác vụ người dùng một cách trơn tru và mượt mà tuyệt đối. Và, trong khi không còn nhiều tên tuổi mặn mà với dòng sản phẩm tablet cao cấp, Apple lại tiếp tục ra mắt iPad Pro, một siêu phẩm với niềm tin sẽ đưa chuẩn mực của một chiếc máy tính bảng lên tầm cao mới.</p><p><img src="/user-content/5887a479-bb96-436f-8414-fa188cdc2aac.jpg" style="width: 976px;"></p><p>Hãng “táo cắn dở” trong suốt một thời gian dài vẫn trung thành với màn hình 9.7 inch của iPad thường, 7.9 inch với dòng iPad Mini. Nhưng trên iPad Pro, tiêu chuẩn ấy đã hoàn toàn bị phá vỡ với kích thước lên tới 12.9 inch, độ phân giải “chuẩn” Retina 2732 x 2048 pixel. Kích thước của iPad Pro đã lớn hơn tới 78% so với iPad Air 2 trước đó. Kích thước màn hình này cho ta cảm giác đây giống như một chiếc laptop hơn là tablet. Nhưng, kích thước đó cũng sẽ mang tới nhiều không gian trải nghiệm hơn, nhiều khoảng trống làm việc hơn để dành cho nhiều ý tưởng lớn hơn.<br></p>', 0, false, false, true, false, NULL, NULL, NULL, 'iPad Pro Wi-Fi 4G 128GB Gold', 'Gold', 25000000, 22290000, '2016-06-19 00:15:59.9818408', 2, 0 , 'ipad-pro-wi-fi-4g-128gb-gold', '<p>Bảo hành 12 tháng (hóa đơn)Thiết kế vượt trội với màn hình "ngoại cỡ" 12.9 inchCấu hình mạnh mẽ; hiệu năng nhanh hơn LaptopTương tác thông minh; làm hai việc cùng lúc<br></p>', NULL, NULL, 1, NULL, '2016-06-19 00:15:59.9818408' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (5, true, 2, NULL, '2016-06-19 00:19:55.8562434', '<p>Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.<br></p>', 0, true, false, false, true, NULL, NULL, NULL, 'Samsung Galaxy A5', NULL, 9999000, 8999000, NULL, 2, 0, 'samsung-galaxy-a5', '<p>Màn hình: FullHD, 5.2 inchesHĐH: Android 5.1 LollipopCPU: 8 nhân 1.6GHz, RAM 2GBCamera: 13.0MP, 2 SIMDung lượng pin: 2900 mAh<br></p>', NULL, NULL, 5, NULL, '2016-06-19 00:19:55.8562434' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (6, true, 2, NULL, '2016-06-19 00:19:55.8892432', '<p>Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.<br></p>', 0, false, false, false, true, NULL, NULL, NULL, 'Samsung Galaxy A5 Pink', 'Pink', 9999000, 8999000, '2016-06-19 00:19:55.8892432', 2, 0 , 'samsung-galaxy-a5-pink', '<p>Màn hình: FullHD, 5.2 inchesHĐH: Android 5.1 LollipopCPU: 8 nhân 1.6GHz, RAM 2GBCamera: 13.0MP, 2 SIMDung lượng pin: 2900 mAh<br></p>', NULL, NULL, 5, NULL, '2016-06-19 00:19:55.8892432' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (7, true, 2, NULL, '2016-06-19 00:19:55.8892432', '<p>Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.<br></p>', 0, false, false, false, true, NULL, NULL, NULL, 'Samsung Galaxy A5 Black', 'Black', 9999000, 7999000, '2016-06-19 00:19:55.8892432', 2, 0 , 'samsung-galaxy-a5-black', '<p>Màn hình: FullHD, 5.2 inchesHĐH: Android 5.1 LollipopCPU: 8 nhân 1.6GHz, RAM 2GBCamera: 13.0MP, 2 SIMDung lượng pin: 2900 mAh<br></p>', NULL, NULL, 5, NULL, '2016-06-19 00:19:55.8892432' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (8, true, 2, NULL, '2016-06-19 00:19:55.8892432', '<p>Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.Tiếp nối thành công của dòng điện thoại A series, ông lớn Samsung tiếp tục ra mắt smartphoneSamsung Galaxy A5 (A510F) với phiên bản 2016 mạnh mẽ và chất lượng hơn so với thiết bị A5 tiền nhiệm. Siêu phẩm này sở hữu thiết kế khung nhôm, vỏ kính cực kỳ tinh tế và sành điệu, đồng thời, máy cũng được nâng cấp về cấu hình, dung lượng pin và màn hình kích thước lớn hơn, đáp ứng nhu cầu sử dụng, làm hài lòng các khách hàng khó tính nhất.<br></p>', 0, false, false, false, true, NULL, NULL, NULL, 'Samsung Galaxy A5 Gold', 'Gold', 9999000, 9999000, '2016-06-19 00:19:55.8892432', 2, 0 , 'samsung-galaxy-a5-gold', '<p>Màn hình: FullHD, 5.2 inchesHĐH: Android 5.1 LollipopCPU: 8 nhân 1.6GHz, RAM 2GBCamera: 13.0MP, 2 SIMDung lượng pin: 2900 mAh<br></p>', NULL, NULL, 5, NULL, '2016-06-19 00:19:55.8892432' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (9, true, 1, NULL, '2016-06-19 00:23:42.6582261', '<p>Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.<br></p>', 0, true, false, true, true, NULL, NULL, NULL, 'iPhone 6s 16GB', NULL, 16880000, 16880000, NULL, 2, 0, 'iphone-6s-16gb', '<p>Màn hình Retina 3D TouchChip xử lý A9 64-bit tiên tiến; Hệ điều hành iOS 9RAM 2GB; ROM 16GBCamera trước 5MP; Camera sau 12MPQuay phim độ phân giải 4KVỏ nhôm Aluminum 7000 Series chắc chắn<br></p>', NULL, NULL, 10, NULL, '2016-06-19 00:23:42.6582261' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (10, true, 1, NULL, '2016-06-19 00:23:42.6962206', '<p>Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.<br></p>', 0, false, false, true, false, NULL, NULL, NULL, 'iPhone 6s 16GB Gray', 'Gray', 16880000, 15880000, '2016-06-19 00:23:42.6962206', 2, 0 , 'iphone-6s-16gb-gray', '<p>Màn hình Retina 3D TouchChip xử lý A9 64-bit tiên tiến; Hệ điều hành iOS 9RAM 2GB; ROM 16GBCamera trước 5MP; Camera sau 12MPQuay phim độ phân giải 4KVỏ nhôm Aluminum 7000 Series chắc chắn<br></p>', NULL, NULL, 10, NULL, '2016-06-19 00:23:42.6962206' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (11, true, 1, NULL, '2016-06-19 00:23:42.6962206', '<p>Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.<br></p>', 0, false, false, true, false, NULL, NULL, NULL, 'iPhone 6s 16GB Pink', 'Pink', 16880000, 16880000, '2016-06-19 00:23:42.6962206', 2, 0 , 'iphone-6s-16gb-pink', '<p>Màn hình Retina 3D TouchChip xử lý A9 64-bit tiên tiến; Hệ điều hành iOS 9RAM 2GB; ROM 16GBCamera trước 5MP; Camera sau 12MPQuay phim độ phân giải 4KVỏ nhôm Aluminum 7000 Series chắc chắn<br></p>', NULL, NULL, 10, NULL, '2016-06-19 00:23:42.6962206' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (12, true, 1, NULL, '2016-06-19 00:23:42.6962206', '<p>Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.<br></p>', 0, false, false, true, false, NULL, NULL, NULL, 'iPhone 6s 16GB Gold', 'Gold', 16880000, 19880000, '2016-06-19 00:23:42.6962206', 2, 0 , 'iphone-6s-16gb-gold', '<p>Màn hình Retina 3D TouchChip xử lý A9 64-bit tiên tiến; Hệ điều hành iOS 9RAM 2GB; ROM 16GBCamera trước 5MP; Camera sau 12MPQuay phim độ phân giải 4KVỏ nhôm Aluminum 7000 Series chắc chắn<br></p>', NULL, NULL, 10, NULL, '2016-06-19 00:23:42.6962206' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (13, true, 1, NULL, '2016-06-19 00:23:42.6962206', '<p>Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.Với kích thước màn hình không thay đổi so với dòng iPhone 6, 6 Plus trước đó, điểm khác biệt mà Apple đã đưa vào hai sản phẩm mới này của mình nằm ở chất liệu khung máy bền bỉ hơn, công nghệ màn hình cảm ứng 3D Touch tối tân, nâng cấp cụm camera, ứng dụng chỉnh sửa ảnh kết hợp video Live Photos và không thể không nhắc đến việc nâng cấp lên chip xử lý A9 64-bit cho hiệu quả đáng kinh ngạc.<br></p>', 0, false, false, true, false, NULL, NULL, NULL, 'iPhone 6s 16GB Silver', 'Silver', 16880000, 17880000, '2016-06-19 00:23:42.6962206', 2, 0 , 'iphone-6s-16gb-silver', '<p>Màn hình Retina 3D TouchChip xử lý A9 64-bit tiên tiến; Hệ điều hành iOS 9RAM 2GB; ROM 16GBCamera trước 5MP; Camera sau 12MPQuay phim độ phân giải 4KVỏ nhôm Aluminum 7000 Series chắc chắn<br></p>', NULL, NULL, 10, NULL, '2016-06-19 00:23:42.6962206' );

INSERT INTO "Catalog_Product" ("Id", "IsFeatured", "BrandId", "CreatedById", "CreatedOn", "Description", "DisplayOrder", "HasOptions", "IsDeleted", "IsPublished", "IsVisibleIndividually", "MetaDescription", "MetaKeywords", "MetaTitle", "Name", "NormalizedName", "OldPrice", "Price", "PublishedOn", "RatingAverage", "ReviewsCount", "SeoTitle", "ShortDescription", "Sku", "Specification", "ThumbnailImageId", "UpdatedById", "UpdatedOn") VALUES (14, true, 3, NULL, '2016-06-19 00:30:45.8467606', '<p>Dòng XPS là dòng laptop cao cấp được quan tâm nhiều nhất của Dell. Không chỉ bởi cấu hình khủng mà còn bởi mức giá ngất ngưởng của nó. XPS là dòng sản phẩm thiết kế từ những thành phần công nghệ cao cấp. Các bạn hãy cùng Prolap đánh giá chiếc Dell XPS 15 9550 này nhé. Đây là một phiên bản lớn hơn của chiếc XPS 13, với chip đồ họa và CPU High – Power cho phép bạn chơi các tựa game mới nhất với chất lượng đồ họa tuyệt hảo. &nbsp;DELL XPS 15 &nbsp;9550 cũng giữ lại tính linh động của mình. Nó không chỉ là một chiếc laptop để bạn có thế mang đi cà phê sau giờ làm. Nó còn là một chiếc máy tính gia đình mạnh mẽ, có khả năng đảm đương những tác vụ nặng trong công việc.<br></p>', 0, false, false, true, true, NULL, NULL, NULL, 'Dell XPS 15 9550', NULL, 34990000, 34990000, NULL, 2, 0, 'dell-xps-15-9550', '<p>CPU: 6th Gen Intel® Core™ i7 (Skylake) 6700HQ (Quad-Core, up to 3.2GHz)</p><p>RAM: 8GB DDR4 2133MHz</p><p>Màn hình: 15.6 inch</p><p>Card đồ họa: 2GB NVIDIA® GeForce® GTX 960M GDDR5</p><p>Windows 10 bản quyền</p>', NULL, NULL, 16, NULL, '2016-06-19 00:30:45.8467606' );


INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (1, 0, 2, 1);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (2, 0, 4, 1);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (3, 0, 3, 1);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (4, 0, 9, 5);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (5, 0, 8, 5);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (6, 0, 7, 5);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (7, 0, 6, 5);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (8, 0, 14, 9);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (9, 0, 11, 9);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (10, 0, 12, 9);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (11, 0, 13, 9);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (12, 0, 15, 9);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (13, 0, 17, 14);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (14, 0, 18, 14);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (15, 0, 19, 14);
INSERT INTO "Catalog_ProductMedia" ("Id", "DisplayOrder", "MediaId", "ProductId") VALUES (16, 0, 20, 14);


INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (1, 1, 1, 'A9');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (2, 4, 3, '4GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (3, 5, 3, '128 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (4, 8, 3, '2732 x 2048 pixels');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (5, 8, 2, '2732 x 2048 pixels');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (6, 5, 2, '128 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (7, 4, 2, '4GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (8, 2, 2, 'IOS');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (9, 1, 2, 'A9');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (10, 2, 3, 'IOS');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (11, 1, 4, 'A9');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (12, 1, 3, 'A9');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (13, 4, 4, '4GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (14, 5, 4, '128 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (15, 8, 4, '2732 x 2048 pixels');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (16, 8, 1, '2732 x 2048 pixels');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (17, 5, 1, '128 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (18, 4, 1, '4GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (19, 2, 1, 'IOS');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (20, 2, 4, 'IOS');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (21, 1, 5, 'Octa-core 1.6 GHz');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (22, 1, 6, 'Octa-core 1.6 GHz');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (23, 2, 6, 'Android');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (24, 4, 6, '2 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (25, 5, 6, '32 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (26, 6, 6, '144.8 x 71 x 7.3 mm');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (27, 8, 6, '1080 x 1920 pixels');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (28, 5, 7, '32 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (29, 11, 6, 'Yes');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (30, 17, 7, '8 MP');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (31, 11, 7, 'Yes');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (32, 8, 7, '1080 x 1920 pixels');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (33, 1, 7, 'Octa-core 1.6 GHz');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (34, 2, 7, 'Android');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (35, 4, 7, '2 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (36, 17, 6, '8 MP');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (37, 1, 8, 'Octa-core 1.6 GHz');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (38, 6, 7, '144.8 x 71 x 7.3 mm');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (39, 4, 8, '2 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (40, 5, 8, '32 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (41, 6, 8, '144.8 x 71 x 7.3 mm');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (42, 8, 8, '1080 x 1920 pixels');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (43, 11, 8, 'Yes');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (44, 17, 8, '8 MP');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (45, 2, 5, 'Android');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (46, 4, 5, '2 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (47, 17, 5, '8 MP');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (48, 2, 8, 'Android');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (49, 5, 5, '32 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (50, 11, 5, 'Yes');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (51, 8, 5, '1080 x 1920 pixels');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (52, 6, 5, '144.8 x 71 x 7.3 mm');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (53, 1, 9, 'Apple A9, Dual-core 1.84 GHz');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (54, 17, 10, '12 MP');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (55, 1, 11, 'Apple A9, Dual-core 1.84 GHz');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (56, 4, 11, '2 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (57, 5, 11, '16 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (58, 8, 11, '750 x 1334 px');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (59, 11, 11, 'Yes');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (60, 17, 11, '12 MP');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (61, 1, 12, 'Apple A9, Dual-core 1.84 GHz');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (62, 2, 12, 'IOS');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (63, 4, 12, '2 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (64, 5, 12, '16 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (65, 8, 12, '750 x 1334 px');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (66, 11, 12, 'Yes');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (67, 17, 12, '12 MP');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (68, 1, 13, 'Apple A9, Dual-core 1.84 GHz');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (69, 2, 13, 'IOS');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (70, 4, 13, '2 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (71, 5, 13, '16 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (72, 8, 13, '750 x 1334 px');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (73, 11, 13, 'Yes');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (74, 17, 13, '12 MP');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (75, 11, 10, 'Yes');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (76, 8, 10, '750 x 1334 px');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (77, 2, 11, 'IOS');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (78, 4, 10, '2 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (79, 2, 10, 'IOS');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (80, 17, 9, '12 MP');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (81, 1, 10, 'Apple A9, Dual-core 1.84 GHz');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (82, 5, 10, '16 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (83, 11, 9, 'Yes');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (84, 8, 9, '750 x 1334 px');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (85, 2, 9, 'IOS');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (86, 4, 9, '2 GB');
INSERT INTO "Catalog_ProductAttributeValue" ("Id", "AttributeId", "ProductId", "Value") VALUES (87, 5, 9, '16 GB');


INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (1, 6, 0, false, 3);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (2, 4, 0, false, 3);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (3, 4, 0, false, 4);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (4, 6, 0, false, 4);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (5, 5, 0, false, 3);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (6, 6, 0, false, 2);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (7, 5, 0, false, 2);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (8, 5, 0, false, 4);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (9, 4, 0, false, 2);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (10, 4, 0, false, 1);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (11, 6, 0, false, 1);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (12, 5, 0, false, 1);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (13, 3, 0, false, 7);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (14, 3, 0, false, 8);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (15, 1, 0, false, 8);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (16, 1, 0, false, 7);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (17, 2, 0, false, 7);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (18, 3, 0, false, 6);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (19, 2, 0, false, 6);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (20, 2, 0, false, 8);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (21, 1, 0, false, 6);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (22, 1, 0, false, 5);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (23, 3, 0, false, 5);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (24, 2, 0, false, 5);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (25, 1, 0, false, 12);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (26, 3, 0, false, 9);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (27, 2, 0, false, 9);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (28, 1, 0, false, 9);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (29, 2, 0, false, 11);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (30, 1, 0, false, 11);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (31, 3, 0, false, 12);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (32, 1, 0, false, 13);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (33, 2, 0, false, 13);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (34, 3, 0, false, 13);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (35, 2, 0, false, 10);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (36, 3, 0, false, 10);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (37, 1, 0, false, 10);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (38, 3, 0, false, 11);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (39, 2, 0, false, 12);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (40, 7, 0, false, 14);
INSERT INTO "Catalog_ProductCategory" ("Id", "CategoryId", "DisplayOrder", "IsFeaturedProduct", "ProductId") VALUES (41, 9, 0, false, 14);


INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (1, 1, 4, 1);
INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (2, 1, 2, 1);
INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (3, 1, 3, 1);
INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (4, 1, 6, 5);
INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (5, 1, 8, 5);
INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (6, 1, 7, 5);
INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (7, 1, 12, 9);
INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (8, 1, 10, 9);
INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (9, 1, 11, 9);
INSERT INTO "Catalog_ProductLink" ("Id", "LinkType", "LinkedProductId", "ProductId") VALUES (10, 1, 13, 9);


INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (1, 1, 0, 2, 'Gray');
INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (2, 1, 0, 3, 'Silver');
INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (3, 1, 0, 4, 'Gold');
INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (4, 1, 0, 6, 'Pink');
INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (5, 1, 0, 8, 'Gold');
INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (6, 1, 0, 7, 'Black');
INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (7, 1, 0, 11, 'Pink');
INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (8, 1, 0, 10, 'Gray');
INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (9, 1, 0, 12, 'Gold');
INSERT INTO "Catalog_ProductOptionCombination" ("Id", "OptionId", "ProducdtId", "ProductId", "Value") VALUES (10, 1, 0, 13, 'Silver');


INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (1, 1, 1, 'Silver');
INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (2, 1, 1, 'Gold');
INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (3, 1, 1, 'Gray');
INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (4, 1, 5, 'Gold');
INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (5, 1, 5, 'Black');
INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (6, 1, 5, 'Pink');
INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (7, 1, 9, 'Gray');
INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (8, 1, 9, 'Pink');
INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (9, 1, 9, 'Gold');
INSERT INTO "Catalog_ProductOptionValue" ("Id", "OptionId", "ProductId", "Value") VALUES (10, 1, 9, 'Silver');


INSERT INTO "Cms_Page" ("Id", "Body", "Name", "SeoTitle", "MetaTitle", "MetaKeywords", "MetaDescription", "IsPublished", "PublishedOn", "IsDeleted", "CreatedOn", "UpdatedOn", "CreatedById", "UpdatedById") VALUES (1, '<h1>About us</h1><p>Your information. Use admin site to update</p>', 'About us', 'about-us', NULL, NULL, NULL, true, NULL, false, '2016-04-10 08:45:44.953' , '2016-04-10 08:45:44.953' , NULL, NULL);

INSERT INTO "Cms_Page" ("Id", "Body", "Name", "SeoTitle", "MetaTitle", "MetaKeywords", "MetaDescription", "IsPublished", "PublishedOn", "IsDeleted", "CreatedOn", "UpdatedOn", "CreatedById", "UpdatedById") VALUES (2, '<h1>Term and Conditions</h1><p>Your term and conditions. Use admin site to update</p>', 'Terms & Conditions', 'terms-of-use', NULL, NULL, NULL, true, NULL, false, '2016-04-11 02:54:57.177' , '2016-04-11 02:54:57.177' , NULL, NULL);

INSERT INTO "Cms_Page" ("Id", "Body", "Name", "SeoTitle", "MetaTitle", "MetaKeywords", "MetaDescription", "IsPublished", "PublishedOn", "IsDeleted", "CreatedOn", "UpdatedOn", "CreatedById", "UpdatedById") VALUES (3, '<h1>Privacy Policy</h1><p>Your privacy policy information. Use admin site to update</p>', 'Privacy Policy', 'privacy', NULL, NULL, NULL, true, NULL, false, '2016-04-11 02:59:31.963' , '2016-04-11 02:59:31.963' , NULL, NULL);

INSERT INTO "Cms_Page" ("Id", "Body", "Name", "SeoTitle", "MetaTitle", "MetaKeywords", "MetaDescription", "IsPublished", "PublishedOn", "IsDeleted", "CreatedOn", "UpdatedOn", "CreatedById", "UpdatedById") VALUES (4, '<h1>Help center</h1><p><a href="/help-center/how-to-buy">How to buy</a></p><p><a href="help-center/shipping">Shipping and delivery</a></p><p><a href="help-center/how-to-return">How to return</a></p><p><a href="help-center/warranty">Warranty</a></p>', 'Help Center', 'help-center', NULL, NULL, NULL, true, NULL, false, '2016-04-11 03:14:04.447' , '2016-04-11 03:14:04.447' , NULL, NULL);

INSERT INTO "Cms_Page" ("Id", "Body", "Name", "SeoTitle", "MetaTitle", "MetaKeywords", "MetaDescription", "IsPublished", "PublishedOn", "IsDeleted", "CreatedOn", "UpdatedOn", "CreatedById", "UpdatedById") VALUES (5, '<h1>How to buy</h1><p>Your how to buy instructions. Use admin site to update</p>', 'How to buy', 'help-center/how-to-buy', NULL, NULL, NULL, true, NULL, false, '2016-04-11 03:16:14.323' , '2016-04-11 03:24:13.833' , NULL, NULL);

INSERT INTO "Cms_Page" ("Id", "Body", "Name", "SeoTitle", "MetaTitle", "MetaKeywords", "MetaDescription", "IsPublished", "PublishedOn", "IsDeleted", "CreatedOn", "UpdatedOn", "CreatedById", "UpdatedById") VALUES (6, '<h1>Shipping and Delivery</h1><p>Shipping and delivery information. Use admin site to update</p>', 'Shipping and delivery', 'help-center/shipping', NULL, NULL, NULL, true, NULL, false, '2016-04-11 02:57:13.497' , '2016-04-11 03:23:31.597' , NULL, NULL);

INSERT INTO "Cms_Page" ("Id", "Body", "Name", "SeoTitle", "MetaTitle", "MetaKeywords", "MetaDescription", "IsPublished", "PublishedOn", "IsDeleted", "CreatedOn", "UpdatedOn", "CreatedById", "UpdatedById") VALUES (7, '<h1>How to return</h1><p>Your how to return instructions. Use admin site to update</p>', 'How to retur', 'help-center/how-to-retur', NULL, NULL, NULL, true, NULL, false, '2016-04-11 03:17:42.067' , '2016-04-11 03:17:42.067' , NULL, NULL);

INSERT INTO "Cms_Page" ("Id", "Body", "Name", "SeoTitle", "MetaTitle", "MetaKeywords", "MetaDescription", "IsPublished", "PublishedOn", "IsDeleted", "CreatedOn", "UpdatedOn", "CreatedById", "UpdatedById") VALUES (8, '<h1>Warranty</h1><p>Your warranty policy. Use admin site to update</p>', 'Warranty', 'help-center/warranty', NULL, NULL, NULL, true, NULL, false, '2016-04-11 03:19:01.927' , '2016-04-11 03:19:01.927' , NULL, NULL);



INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (1, 1, 1, 'phones');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (2, 2, 1, 'smart-phones');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (3, 3, 1, 'basic-phones');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (4, 4, 1, 'tablets');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (5, 5, 1, 'wifi-cellular-tablets');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (6, 6, 1, 'cellular-tablets');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (7, 7, 1, 'computers');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (8, 8, 1, 'gaming');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (9, 9, 1, 'business');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (10, 10, 1, 'accessories');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (11, 11, 1, 'headphones');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (12, 12, 1, 'cables');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (13, 13, 1, 'usb-drives');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (18, 1, 4, 'about-us');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (19, 2, 4, 'terms-of-use');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (20, 3, 4, 'privacy');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (21, 4, 4, 'help-center');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (22, 5, 4, 'help-center/how-to-buy');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (23, 6, 4, 'help-center/shipping');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (24, 7, 4, 'help-center/how-to-return');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (25, 8, 4, 'help-center/warranty');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (26, 1, 3, 'ipad-pro-wi-fi-4g-128gb');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (27, 5, 3, 'samsung-galaxy-a5');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (28, 9, 3, 'iphone-6s-16gb');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (29, 1, 2, 'apple');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (30, 2, 2, 'samsung');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (31, 3, 2, 'dell');

INSERT INTO "Core_UrlSlug" ("Id", "EntityId", "EntityTypeId", "Slug") VALUES (32, 14, 3, 'dell-xps-15-9550');





