CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" varchar(150) NOT NULL,
    "ProductVersion" varchar(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

CREATE TABLE "ActivityLog_ActivityType" (
    "Id" bigserial NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_ActivityLog_ActivityType" PRIMARY KEY ("Id")
);

CREATE TABLE "Catalog_Brand" (
    "Id" bigserial NOT NULL,
    "Description" varchar(5000) NULL,
    "IsDeleted" bool NOT NULL,
    "IsPublished" bool NOT NULL,
    "Name" text NULL,
    "SeoTitle" text NULL,
    CONSTRAINT "PK_Catalog_Brand" PRIMARY KEY ("Id")
);

CREATE TABLE "Catalog_ProductAttributeGroup" (
    "Id" bigserial NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Catalog_ProductAttributeGroup" PRIMARY KEY ("Id")
);

CREATE TABLE "Catalog_ProductOption" (
    "Id" bigserial NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Catalog_ProductOption" PRIMARY KEY ("Id")
);

CREATE TABLE "Catalog_ProductTemplate" (
    "Id" bigserial NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Catalog_ProductTemplate" PRIMARY KEY ("Id")
);

CREATE TABLE "Cms_Menu" (
    "Id" bigserial NOT NULL,
    "IsPublished" bool NOT NULL,
    "IsSystem" bool NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Cms_Menu" PRIMARY KEY ("Id")
);

CREATE TABLE "Contacts_ContactArea" (
    "Id" bigserial NOT NULL,
    "IsDeleted" bool NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Contacts_ContactArea" PRIMARY KEY ("Id")
);

CREATE TABLE "Core_AppSetting" (
    "Id" bigserial NOT NULL,
    "Key" text NULL,
    "Value" text NULL,
    CONSTRAINT "PK_Core_AppSetting" PRIMARY KEY ("Id")
);

CREATE TABLE "Core_Country" (
    "Id" bigserial NOT NULL,
    "Code2" text NULL,
    "Code3" text NULL,
    "IsBillingEnabled" bool NOT NULL,
    "IsShippingEnabled" bool NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Core_Country" PRIMARY KEY ("Id")
);

CREATE TABLE "Core_CustomerGroup" (
    "Id" bigserial NOT NULL,
    "CreatedOn" timestamptz NOT NULL,
    "Description" text NULL,
    "IsActive" bool NOT NULL,
    "IsDeleted" bool NOT NULL,
    "Name" text NULL,
    "UpdatedOn" timestamptz NOT NULL,
    CONSTRAINT "PK_Core_CustomerGroup" PRIMARY KEY ("Id")
);

CREATE TABLE "Core_EntityType" (
    "Id" bigserial NOT NULL,
    "IsMenuable" bool NOT NULL,
    "Name" text NULL,
    "RoutingAction" text NULL,
    "RoutingController" text NULL,
    CONSTRAINT "PK_Core_EntityType" PRIMARY KEY ("Id")
);

CREATE TABLE "Core_Media" (
    "Id" bigserial NOT NULL,
    "Caption" text NULL,
    "FileName" text NULL,
    "FileSize" int4 NOT NULL,
    "MediaType" int4 NOT NULL,
    CONSTRAINT "PK_Core_Media" PRIMARY KEY ("Id")
);

CREATE TABLE "Core_Role" (
    "Id" bigserial NOT NULL,
    "ConcurrencyStamp" text NULL,
    "Name" varchar(256) NULL,
    "NormalizedName" varchar(256) NULL,
    CONSTRAINT "PK_Core_Role" PRIMARY KEY ("Id")
);

CREATE TABLE "Core_Vendor" (
    "Id" bigserial NOT NULL,
    "CreatedOn" timestamptz NOT NULL,
    "Description" text NULL,
    "Email" text NULL,
    "IsActive" bool NOT NULL,
    "IsDeleted" bool NOT NULL,
    "Name" text NULL,
    "SeoTitle" text NULL,
    "UpdatedOn" timestamptz NOT NULL,
    CONSTRAINT "PK_Core_Vendor" PRIMARY KEY ("Id")
);

CREATE TABLE "Core_Widget" (
    "Id" bigserial NOT NULL,
    "Code" text NULL,
    "CreateUrl" text NULL,
    "CreatedOn" timestamptz NOT NULL,
    "EditUrl" text NULL,
    "IsPublished" bool NOT NULL,
    "Name" text NULL,
    "ViewComponentName" text NULL,
    CONSTRAINT "PK_Core_Widget" PRIMARY KEY ("Id")
);

CREATE TABLE "Core_WidgetZone" (
    "Id" bigserial NOT NULL,
    "Description" text NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Core_WidgetZone" PRIMARY KEY ("Id")
);

CREATE TABLE "Inventory_Stock" (
    "Id" bigserial NOT NULL,
    "ProductId" int8 NOT NULL,
    "Quantity" int4 NOT NULL,
    "WarehouseId" int8 NOT NULL,
    CONSTRAINT "PK_Inventory_Stock" PRIMARY KEY ("Id")
);

CREATE TABLE "Localization_Culture" (
    "Id" bigserial NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Localization_Culture" PRIMARY KEY ("Id")
);

CREATE TABLE "News_NewsCategory" (
    "Id" bigserial NOT NULL,
    "Description" varchar(5000) NULL,
    "DisplayOrder" int4 NOT NULL,
    "IsDeleted" bool NOT NULL,
    "IsPublished" bool NOT NULL,
    "Name" text NULL,
    "SeoTitle" text NULL,
    CONSTRAINT "PK_News_NewsCategory" PRIMARY KEY ("Id")
);

CREATE TABLE "Pricing_CartRule" (
    "Id" bigserial NOT NULL,
    "Description" text NULL,
    "DiscountAmount" numeric NOT NULL,
    "DiscountStep" int4 NULL,
    "EndOn" timestamptz NULL,
    "IsActive" bool NOT NULL,
    "IsCouponRequired" bool NOT NULL,
    "MaxDiscountAmount" numeric NULL,
    "Name" text NULL,
    "RuleToApply" text NULL,
    "StartOn" timestamptz NULL,
    "UsageLimitPerCoupon" int4 NULL,
    "UsageLimitPerCustomer" int4 NULL,
    CONSTRAINT "PK_Pricing_CartRule" PRIMARY KEY ("Id")
);

CREATE TABLE "Pricing_CatalogRule" (
    "Id" bigserial NOT NULL,
    "Description" text NULL,
    "DiscountAmount" numeric NOT NULL,
    "EndOn" timestamptz NULL,
    "IsActive" bool NOT NULL,
    "MaxDiscountAmount" numeric NULL,
    "Name" text NULL,
    "RuleToApply" text NULL,
    "StartOn" timestamptz NULL,
    CONSTRAINT "PK_Pricing_CatalogRule" PRIMARY KEY ("Id")
);

CREATE TABLE "ProductRecentlyViewed_RecentlyViewedProduct" (
    "Id" bigserial NOT NULL,
    "LatestViewedOn" timestamptz NOT NULL,
    "ProductId" int8 NOT NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_ProductRecentlyViewed_RecentlyViewedProduct" PRIMARY KEY ("Id")
);

CREATE TABLE "Search_Query" (
    "Id" bigserial NOT NULL,
    "CreatedOn" timestamptz NOT NULL,
    "QueryText" text NULL,
    "ResultsCount" int4 NOT NULL,
    CONSTRAINT "PK_Search_Query" PRIMARY KEY ("Id")
);

CREATE TABLE "Shipping_ShippingProvider" (
    "Id" bigserial NOT NULL,
    "AdditionalSettings" text NULL,
    "ConfigureUrl" text NULL,
    "IsEnabled" bool NOT NULL,
    "Name" text NULL,
    "OnlyCountryIdsString" text NULL,
    "OnlyStateOrProvinceIdsString" text NULL,
    "ShippingPriceServiceTypeName" text NULL,
    "ToAllShippingEnabledCountries" bool NOT NULL,
    "ToAllShippingEnabledStatesOrProvinces" bool NOT NULL,
    CONSTRAINT "PK_Shipping_ShippingProvider" PRIMARY KEY ("Id")
);

CREATE TABLE "Tax_TaxClass" (
    "Id" bigserial NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Tax_TaxClass" PRIMARY KEY ("Id")
);

CREATE TABLE "ActivityLog_Activity" (
    "Id" bigserial NOT NULL,
    "ActivityTypeId" int8 NOT NULL,
    "CreatedOn" timestamptz NOT NULL,
    "EntityId" int8 NOT NULL,
    "EntityTypeId" int8 NOT NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_ActivityLog_Activity" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ActivityLog_Activity_ActivityLog_ActivityType_ActivityTypeId" FOREIGN KEY ("ActivityTypeId") REFERENCES "ActivityLog_ActivityType" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Catalog_ProductAttribute" (
    "Id" bigserial NOT NULL,
    "GroupId" int8 NOT NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Catalog_ProductAttribute" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Catalog_ProductAttribute_Catalog_ProductAttributeGroup_GroupId" FOREIGN KEY ("GroupId") REFERENCES "Catalog_ProductAttributeGroup" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Contacts_Contact" (
    "Id" bigserial NOT NULL,
    "Address" text NULL,
    "ContactAreaId" int8 NOT NULL,
    "Content" text NULL,
    "CreatedOn" timestamptz NOT NULL,
    "EmailAddress" text NULL,
    "FullName" text NULL,
    "IsDeleted" bool NOT NULL,
    "PhoneNumber" text NULL,
    CONSTRAINT "PK_Contacts_Contact" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Contacts_Contact_Contacts_ContactArea_ContactAreaId" FOREIGN KEY ("ContactAreaId") REFERENCES "Contacts_ContactArea" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_StateOrProvince" (
    "Id" bigserial NOT NULL,
    "Code" text NULL,
    "CountryCode" text NULL,
    "CountryId" int8 NOT NULL,
    "Name" text NULL,
    "Type" text NULL,
    CONSTRAINT "PK_Core_StateOrProvince" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_StateOrProvince_Core_Country_CountryId" FOREIGN KEY ("CountryId") REFERENCES "Core_Country" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_Entity" (
    "Id" bigserial NOT NULL,
    "EntityId" int8 NOT NULL,
    "EntityTypeId" int8 NOT NULL,
    "Name" text NULL,
    "Slug" text NULL,
    CONSTRAINT "PK_Core_Entity" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_Entity_Core_EntityType_EntityTypeId" FOREIGN KEY ("EntityTypeId") REFERENCES "Core_EntityType" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Catalog_Category" (
    "Id" bigserial NOT NULL,
    "Description" varchar(5000) NULL,
    "DisplayOrder" int4 NOT NULL,
    "IncludeInMenu" bool NOT NULL,
    "IsDeleted" bool NOT NULL,
    "IsPublished" bool NOT NULL,
    "Name" text NULL,
    "ParentId" int8 NULL,
    "SeoTitle" text NULL,
    "ThumbnailImageId" int8 NULL,
    CONSTRAINT "PK_Catalog_Category" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Catalog_Category_Catalog_Category_ParentId" FOREIGN KEY ("ParentId") REFERENCES "Catalog_Category" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Catalog_Category_Core_Media_ThumbnailImageId" FOREIGN KEY ("ThumbnailImageId") REFERENCES "Core_Media" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Core_RoleClaim" (
    "Id" serial NOT NULL,
    "ClaimType" text NULL,
    "ClaimValue" text NULL,
    "RoleId" int8 NOT NULL,
    CONSTRAINT "PK_Core_RoleClaim" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_RoleClaim_Core_Role_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Core_Role" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_WidgetInstance" (
    "Id" bigserial NOT NULL,
    "CreatedOn" timestamptz NOT NULL,
    "Data" text NULL,
    "DisplayOrder" int4 NOT NULL,
    "HtmlData" text NULL,
    "Name" text NULL,
    "PublishEnd" timestamptz NULL,
    "PublishStart" timestamptz NULL,
    "UpdatedOn" timestamptz NOT NULL,
    "WidgetId" int8 NOT NULL,
    "WidgetZoneId" int8 NOT NULL,
    CONSTRAINT "PK_Core_WidgetInstance" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_WidgetInstance_Core_Widget_WidgetId" FOREIGN KEY ("WidgetId") REFERENCES "Core_Widget" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Core_WidgetInstance_Core_WidgetZone_WidgetZoneId" FOREIGN KEY ("WidgetZoneId") REFERENCES "Core_WidgetZone" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Localization_Resource" (
    "Id" bigserial NOT NULL,
    "CultureId" int8 NOT NULL,
    "Key" text NULL,
    "Value" text NULL,
    CONSTRAINT "PK_Localization_Resource" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Localization_Resource_Localization_Culture_CultureId" FOREIGN KEY ("CultureId") REFERENCES "Localization_Culture" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Pricing_CartRuleCustomerGroup" (
    "CartRuleId" int8 NOT NULL,
    "CustomerGroupId" int8 NOT NULL,
    CONSTRAINT "PK_Pricing_CartRuleCustomerGroup" PRIMARY KEY ("CartRuleId", "CustomerGroupId"),
    CONSTRAINT "FK_Pricing_CartRuleCustomerGroup_Pricing_CartRule_CartRuleId" FOREIGN KEY ("CartRuleId") REFERENCES "Pricing_CartRule" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Pricing_CartRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId" FOREIGN KEY ("CustomerGroupId") REFERENCES "Core_CustomerGroup" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Pricing_Coupon" (
    "Id" bigserial NOT NULL,
    "CartRuleId" int8 NOT NULL,
    "Code" text NULL,
    "CreatedOn" timestamptz NOT NULL,
    CONSTRAINT "PK_Pricing_Coupon" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Pricing_Coupon_Pricing_CartRule_CartRuleId" FOREIGN KEY ("CartRuleId") REFERENCES "Pricing_CartRule" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Pricing_CatalogRuleCustomerGroup" (
    "CatalogRuleId" int8 NOT NULL,
    "CustomerGroupId" int8 NOT NULL,
    CONSTRAINT "PK_Pricing_CatalogRuleCustomerGroup" PRIMARY KEY ("CatalogRuleId", "CustomerGroupId"),
    CONSTRAINT "FK_Pricing_CatalogRuleCustomerGroup_Pricing_CatalogRule_CatalogRuleId" FOREIGN KEY ("CatalogRuleId") REFERENCES "Pricing_CatalogRule" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Pricing_CatalogRuleCustomerGroup_Core_CustomerGroup_CustomerGroupId" FOREIGN KEY ("CustomerGroupId") REFERENCES "Core_CustomerGroup" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Catalog_ProductTemplateProductAttribute" (
    "ProductTemplateId" int8 NOT NULL,
    "ProductAttributeId" int8 NOT NULL,
    CONSTRAINT "PK_Catalog_ProductTemplateProductAttribute" PRIMARY KEY ("ProductTemplateId", "ProductAttributeId"),
    CONSTRAINT "FK_Catalog_ProductTemplateProductAttribute_Catalog_ProductAttribute_ProductAttributeId" FOREIGN KEY ("ProductAttributeId") REFERENCES "Catalog_ProductAttribute" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Catalog_ProductTemplateProductAttribute_Catalog_ProductTemplate_ProductTemplateId" FOREIGN KEY ("ProductTemplateId") REFERENCES "Catalog_ProductTemplate" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_District" (
    "Id" bigserial NOT NULL,
    "Location" text NULL,
    "Name" text NULL,
    "StateOrProvinceId" int8 NOT NULL,
    "Type" text NULL,
    CONSTRAINT "PK_Core_District" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_District_Core_StateOrProvince_StateOrProvinceId" FOREIGN KEY ("StateOrProvinceId") REFERENCES "Core_StateOrProvince" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ShippingTableRate_PriceAndDestination" (
    "Id" bigserial NOT NULL,
    "CountryId" int8 NULL,
    "MinOrderSubtotal" numeric NOT NULL,
    "Note" text NULL,
    "ShippingPrice" numeric NOT NULL,
    "StateOrProvinceId" int8 NULL,
    CONSTRAINT "PK_ShippingTableRate_PriceAndDestination" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ShippingTableRate_PriceAndDestination_Core_Country_CountryId" FOREIGN KEY ("CountryId") REFERENCES "Core_Country" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_ShippingTableRate_PriceAndDestination_Core_StateOrProvince_StateOrProvinceId" FOREIGN KEY ("StateOrProvinceId") REFERENCES "Core_StateOrProvince" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Tax_TaxRate" (
    "Id" bigserial NOT NULL,
    "CountryId" int8 NOT NULL,
    "Name" text NULL,
    "Rate" numeric NOT NULL,
    "StateOrProvinceId" int8 NULL,
    "TaxClassId" int8 NOT NULL,
    CONSTRAINT "PK_Tax_TaxRate" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Tax_TaxRate_Core_Country_CountryId" FOREIGN KEY ("CountryId") REFERENCES "Core_Country" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Tax_TaxRate_Core_StateOrProvince_StateOrProvinceId" FOREIGN KEY ("StateOrProvinceId") REFERENCES "Core_StateOrProvince" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Tax_TaxRate_Tax_TaxClass_TaxClassId" FOREIGN KEY ("TaxClassId") REFERENCES "Tax_TaxClass" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Cms_MenuItem" (
    "Id" bigserial NOT NULL,
    "CustomLink" text NULL,
    "EntityId" int8 NULL,
    "MenuId" int8 NOT NULL,
    "Name" text NULL,
    "ParentId" int8 NULL,
    CONSTRAINT "PK_Cms_MenuItem" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Cms_MenuItem_Core_Entity_EntityId" FOREIGN KEY ("EntityId") REFERENCES "Core_Entity" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Cms_MenuItem_Cms_Menu_MenuId" FOREIGN KEY ("MenuId") REFERENCES "Cms_Menu" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Cms_MenuItem_Cms_MenuItem_ParentId" FOREIGN KEY ("ParentId") REFERENCES "Cms_MenuItem" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Pricing_CartRuleCategory" (
    "CartRuleId" int8 NOT NULL,
    "CategoryId" int8 NOT NULL,
    CONSTRAINT "PK_Pricing_CartRuleCategory" PRIMARY KEY ("CartRuleId", "CategoryId"),
    CONSTRAINT "FK_Pricing_CartRuleCategory_Pricing_CartRule_CartRuleId" FOREIGN KEY ("CartRuleId") REFERENCES "Pricing_CartRule" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Pricing_CartRuleCategory_Catalog_Category_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Catalog_Category" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_Address" (
    "Id" bigserial NOT NULL,
    "AddressLine1" text NULL,
    "AddressLine2" text NULL,
    "City" text NULL,
    "ContactName" text NULL,
    "CountryId" int8 NOT NULL,
    "DistrictId" int8 NULL,
    "Phone" text NULL,
    "PostalCode" text NULL,
    "StateOrProvinceId" int8 NOT NULL,
    CONSTRAINT "PK_Core_Address" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_Address_Core_Country_CountryId" FOREIGN KEY ("CountryId") REFERENCES "Core_Country" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Core_Address_Core_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "Core_District" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Core_Address_Core_StateOrProvince_StateOrProvinceId" FOREIGN KEY ("StateOrProvinceId") REFERENCES "Core_StateOrProvince" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Orders_OrderAddress" (
    "Id" bigserial NOT NULL,
    "AddressLine1" text NULL,
    "AddressLine2" text NULL,
    "City" text NULL,
    "ContactName" text NULL,
    "CountryId" int8 NOT NULL,
    "DistrictId" int8 NULL,
    "Phone" text NULL,
    "PostalCode" text NULL,
    "StateOrProvinceId" int8 NOT NULL,
    CONSTRAINT "PK_Orders_OrderAddress" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Orders_OrderAddress_Core_Country_CountryId" FOREIGN KEY ("CountryId") REFERENCES "Core_Country" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Orders_OrderAddress_Core_District_DistrictId" FOREIGN KEY ("DistrictId") REFERENCES "Core_District" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Orders_OrderAddress_Core_StateOrProvince_StateOrProvinceId" FOREIGN KEY ("StateOrProvinceId") REFERENCES "Core_StateOrProvince" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Inventory_Warehouse" (
    "Id" bigserial NOT NULL,
    "AddressId" int8 NULL,
    "Name" text NULL,
    CONSTRAINT "PK_Inventory_Warehouse" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Inventory_Warehouse_Core_Address_AddressId" FOREIGN KEY ("AddressId") REFERENCES "Core_Address" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Catalog_Product" (
    "Id" bigserial NOT NULL,
    "BrandId" int8 NULL,
    "CreatedById" int8 NULL,
    "CreatedOn" timestamptz NOT NULL,
    "Description" text NULL,
    "DisplayOrder" int4 NOT NULL,
    "HasOptions" bool NOT NULL,
    "IsAllowToOrder" bool NOT NULL,
    "IsCallForPricing" bool NOT NULL,
    "IsDeleted" bool NOT NULL,
    "IsFeatured" bool NOT NULL,
    "IsPublished" bool NOT NULL,
    "IsVisibleIndividually" bool NOT NULL,
    "MetaDescription" text NULL,
    "MetaKeywords" text NULL,
    "MetaTitle" text NULL,
    "Name" text NULL,
    "NormalizedName" text NULL,
    "OldPrice" numeric NULL,
    "Price" numeric NOT NULL,
    "PublishedOn" timestamptz NULL,
    "RatingAverage" float8 NULL,
    "ReviewsCount" int4 NOT NULL,
    "SeoTitle" text NULL,
    "ShortDescription" text NULL,
    "Sku" text NULL,
    "SpecialPrice" numeric NULL,
    "SpecialPriceEnd" timestamptz NULL,
    "SpecialPriceStart" timestamptz NULL,
    "Specification" text NULL,
    "StockQuantity" int4 NULL,
    "TaxClassId" int8 NULL,
    "ThumbnailImageId" int8 NULL,
    "UpdatedById" int8 NULL,
    "UpdatedOn" timestamptz NOT NULL,
    "VendorId" int8 NULL,
    CONSTRAINT "PK_Catalog_Product" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Catalog_Product_Catalog_Brand_BrandId" FOREIGN KEY ("BrandId") REFERENCES "Catalog_Brand" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Catalog_Product_Tax_TaxClass_TaxClassId" FOREIGN KEY ("TaxClassId") REFERENCES "Tax_TaxClass" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Catalog_Product_Core_Media_ThumbnailImageId" FOREIGN KEY ("ThumbnailImageId") REFERENCES "Core_Media" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Catalog_ProductAttributeValue" (
    "Id" bigserial NOT NULL,
    "AttributeId" int8 NOT NULL,
    "ProductId" int8 NOT NULL,
    "Value" text NULL,
    CONSTRAINT "PK_Catalog_ProductAttributeValue" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Catalog_ProductAttributeValue_Catalog_ProductAttribute_AttributeId" FOREIGN KEY ("AttributeId") REFERENCES "Catalog_ProductAttribute" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Catalog_ProductAttributeValue_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Catalog_ProductCategory" (
    "Id" bigserial NOT NULL,
    "CategoryId" int8 NOT NULL,
    "DisplayOrder" int4 NOT NULL,
    "IsFeaturedProduct" bool NOT NULL,
    "ProductId" int8 NOT NULL,
    CONSTRAINT "PK_Catalog_ProductCategory" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Catalog_ProductCategory_Catalog_Category_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "Catalog_Category" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Catalog_ProductCategory_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Catalog_ProductLink" (
    "Id" bigserial NOT NULL,
    "LinkType" int4 NOT NULL,
    "LinkedProductId" int8 NOT NULL,
    "ProductId" int8 NOT NULL,
    CONSTRAINT "PK_Catalog_ProductLink" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Catalog_ProductLink_Catalog_Product_LinkedProductId" FOREIGN KEY ("LinkedProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Catalog_ProductLink_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Catalog_ProductMedia" (
    "Id" bigserial NOT NULL,
    "DisplayOrder" int4 NOT NULL,
    "MediaId" int8 NOT NULL,
    "ProductId" int8 NOT NULL,
    CONSTRAINT "PK_Catalog_ProductMedia" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Catalog_ProductMedia_Core_Media_MediaId" FOREIGN KEY ("MediaId") REFERENCES "Core_Media" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Catalog_ProductMedia_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Catalog_ProductOptionCombination" (
    "Id" bigserial NOT NULL,
    "OptionId" int8 NOT NULL,
    "ProductId" int8 NOT NULL,
    "SortIndex" int4 NOT NULL,
    "Value" text NULL,
    CONSTRAINT "PK_Catalog_ProductOptionCombination" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Catalog_ProductOptionCombination_Catalog_ProductOption_OptionId" FOREIGN KEY ("OptionId") REFERENCES "Catalog_ProductOption" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Catalog_ProductOptionCombination_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Catalog_ProductOptionValue" (
    "Id" bigserial NOT NULL,
    "DisplayType" text NULL,
    "OptionId" int8 NOT NULL,
    "ProductId" int8 NOT NULL,
    "SortIndex" int4 NOT NULL,
    "Value" text NULL,
    CONSTRAINT "PK_Catalog_ProductOptionValue" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Catalog_ProductOptionValue_Catalog_ProductOption_OptionId" FOREIGN KEY ("OptionId") REFERENCES "Catalog_ProductOption" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Catalog_ProductOptionValue_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Pricing_CartRuleProduct" (
    "CartRuleId" int8 NOT NULL,
    "ProductId" int8 NOT NULL,
    CONSTRAINT "PK_Pricing_CartRuleProduct" PRIMARY KEY ("CartRuleId", "ProductId"),
    CONSTRAINT "FK_Pricing_CartRuleProduct_Pricing_CartRule_CartRuleId" FOREIGN KEY ("CartRuleId") REFERENCES "Pricing_CartRule" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Pricing_CartRuleProduct_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Orders_OrderItem" (
    "Id" bigserial NOT NULL,
    "OrderId" int8 NULL,
    "ProductId" int8 NOT NULL,
    "ProductPrice" numeric NOT NULL,
    "Quantity" int4 NOT NULL,
    "TaxAmount" numeric NOT NULL,
    "TaxPercent" numeric NOT NULL,
    CONSTRAINT "PK_Orders_OrderItem" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Orders_OrderItem_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ProductComparison_ComparingProduct" (
    "Id" bigserial NOT NULL,
    "CreatedOn" timestamptz NOT NULL,
    "ProductId" int8 NOT NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_ProductComparison_ComparingProduct" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ProductComparison_ComparingProduct_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ShoppingCart_CartItem" (
    "Id" bigserial NOT NULL,
    "CartId" int8 NOT NULL,
    "CreatedOn" timestamptz NOT NULL,
    "ProductId" int8 NOT NULL,
    "Quantity" int4 NOT NULL,
    CONSTRAINT "PK_ShoppingCart_CartItem" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ShoppingCart_CartItem_Catalog_Product_ProductId" FOREIGN KEY ("ProductId") REFERENCES "Catalog_Product" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_UserAddress" (
    "Id" bigserial NOT NULL,
    "AddressId" int8 NOT NULL,
    "AddressType" int4 NOT NULL,
    "LastUsedOn" timestamptz NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_Core_UserAddress" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_UserAddress_Core_Address_AddressId" FOREIGN KEY ("AddressId") REFERENCES "Core_Address" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_User" (
    "Id" bigserial NOT NULL,
    "AccessFailedCount" int4 NOT NULL,
    "ConcurrencyStamp" text NULL,
    "CreatedOn" timestamptz NOT NULL,
    "DefaultBillingAddressId" int8 NULL,
    "DefaultShippingAddressId" int8 NULL,
    "Email" varchar(256) NULL,
    "EmailConfirmed" bool NOT NULL,
    "FullName" text NULL,
    "IsDeleted" bool NOT NULL,
    "LockoutEnabled" bool NOT NULL,
    "LockoutEnd" timestamptz NULL,
    "NormalizedEmail" varchar(256) NULL,
    "NormalizedUserName" varchar(256) NULL,
    "PasswordHash" text NULL,
    "PhoneNumber" text NULL,
    "PhoneNumberConfirmed" bool NOT NULL,
    "SecurityStamp" text NULL,
    "TwoFactorEnabled" bool NOT NULL,
    "UpdatedOn" timestamptz NOT NULL,
    "UserGuid" uuid NOT NULL,
    "UserName" varchar(256) NULL,
    "VendorId" int8 NULL,
    CONSTRAINT "PK_Core_User" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_User_Core_UserAddress_DefaultBillingAddressId" FOREIGN KEY ("DefaultBillingAddressId") REFERENCES "Core_UserAddress" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Core_User_Core_UserAddress_DefaultShippingAddressId" FOREIGN KEY ("DefaultShippingAddressId") REFERENCES "Core_UserAddress" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Core_User_Core_Vendor_VendorId" FOREIGN KEY ("VendorId") REFERENCES "Core_Vendor" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Cms_Page" (
    "Id" bigserial NOT NULL,
    "Body" text NULL,
    "CreatedById" int8 NULL,
    "CreatedOn" timestamptz NOT NULL,
    "IsDeleted" bool NOT NULL,
    "IsPublished" bool NOT NULL,
    "MetaDescription" text NULL,
    "MetaKeywords" text NULL,
    "MetaTitle" text NULL,
    "Name" text NULL,
    "PublishedOn" timestamptz NULL,
    "SeoTitle" text NULL,
    "UpdatedById" int8 NULL,
    "UpdatedOn" timestamptz NOT NULL,
    CONSTRAINT "PK_Cms_Page" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Cms_Page_Core_User_CreatedById" FOREIGN KEY ("CreatedById") REFERENCES "Core_User" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Cms_Page_Core_User_UpdatedById" FOREIGN KEY ("UpdatedById") REFERENCES "Core_User" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Core_UserClaim" (
    "Id" serial NOT NULL,
    "ClaimType" text NULL,
    "ClaimValue" text NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_Core_UserClaim" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_UserClaim_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_UserCustomerGroup" (
    "Id" bigserial NOT NULL,
    "CustomerGroupId" int8 NOT NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_Core_UserCustomerGroup" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Core_UserCustomerGroup_Core_CustomerGroup_CustomerGroupId" FOREIGN KEY ("CustomerGroupId") REFERENCES "Core_CustomerGroup" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Core_UserCustomerGroup_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_UserLogin" (
    "LoginProvider" text NOT NULL,
    "ProviderKey" text NOT NULL,
    "ProviderDisplayName" text NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_Core_UserLogin" PRIMARY KEY ("LoginProvider", "ProviderKey"),
    CONSTRAINT "FK_Core_UserLogin_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_UserRole" (
    "UserId" int8 NOT NULL,
    "RoleId" int8 NOT NULL,
    CONSTRAINT "PK_Core_UserRole" PRIMARY KEY ("UserId", "RoleId"),
    CONSTRAINT "FK_Core_UserRole_Core_Role_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Core_Role" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Core_UserRole_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Core_UserToken" (
    "UserId" int8 NOT NULL,
    "LoginProvider" text NOT NULL,
    "Name" text NOT NULL,
    "Value" text NULL,
    CONSTRAINT "PK_Core_UserToken" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
    CONSTRAINT "FK_Core_UserToken_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "News_NewsItem" (
    "Id" bigserial NOT NULL,
    "CreatedById" int8 NULL,
    "CreatedOn" timestamptz NOT NULL,
    "FullContent" text NULL,
    "IsDeleted" bool NOT NULL,
    "IsPublished" bool NOT NULL,
    "MetaDescription" text NULL,
    "MetaKeywords" text NULL,
    "MetaTitle" text NULL,
    "Name" text NULL,
    "PublishedOn" timestamptz NULL,
    "SeoTitle" text NULL,
    "ShortContent" text NULL,
    "ThumbnailImageId" int8 NULL,
    "UpdatedById" int8 NULL,
    "UpdatedOn" timestamptz NOT NULL,
    CONSTRAINT "PK_News_NewsItem" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_News_NewsItem_Core_User_CreatedById" FOREIGN KEY ("CreatedById") REFERENCES "Core_User" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_News_NewsItem_Core_Media_ThumbnailImageId" FOREIGN KEY ("ThumbnailImageId") REFERENCES "Core_Media" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_News_NewsItem_Core_User_UpdatedById" FOREIGN KEY ("UpdatedById") REFERENCES "Core_User" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Orders_Order" (
    "Id" bigserial NOT NULL,
    "BillingAddressId" int8 NOT NULL,
    "CouponCode" text NULL,
    "CouponRuleName" text NULL,
    "CreatedById" int8 NOT NULL,
    "CreatedOn" timestamptz NOT NULL,
    "Discount" numeric NOT NULL,
    "OrderStatus" int4 NOT NULL,
    "OrderTotal" numeric NOT NULL,
    "ParentId" int8 NULL,
    "ShippingAddressId" int8 NOT NULL,
    "ShippingAmount" numeric NOT NULL,
    "ShippingMethod" text NULL,
    "SubTotal" numeric NOT NULL,
    "SubTotalWithDiscount" numeric NOT NULL,
    "TaxAmount" numeric NOT NULL,
    "UpdatedOn" timestamptz NULL,
    "VendorId" int8 NULL,
    CONSTRAINT "PK_Orders_Order" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Orders_Order_Orders_OrderAddress_BillingAddressId" FOREIGN KEY ("BillingAddressId") REFERENCES "Orders_OrderAddress" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Orders_Order_Core_User_CreatedById" FOREIGN KEY ("CreatedById") REFERENCES "Core_User" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Orders_Order_Orders_Order_ParentId" FOREIGN KEY ("ParentId") REFERENCES "Orders_Order" ("Id") ON DELETE NO ACTION,
    CONSTRAINT "FK_Orders_Order_Orders_OrderAddress_ShippingAddressId" FOREIGN KEY ("ShippingAddressId") REFERENCES "Orders_OrderAddress" ("Id") ON DELETE NO ACTION
);

CREATE TABLE "Pricing_CartRuleUsage" (
    "Id" bigserial NOT NULL,
    "CartRuleId" int8 NOT NULL,
    "OrderId" int8 NOT NULL,
    "UsedOn" timestamptz NOT NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_Pricing_CartRuleUsage" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Pricing_CartRuleUsage_Pricing_CartRule_CartRuleId" FOREIGN KEY ("CartRuleId") REFERENCES "Pricing_CartRule" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Pricing_CartRuleUsage_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Pricing_CouponUsage" (
    "Id" bigserial NOT NULL,
    "CouponId" int8 NOT NULL,
    "UsedOn" timestamptz NOT NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_Pricing_CouponUsage" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Pricing_CouponUsage_Pricing_Coupon_CouponId" FOREIGN KEY ("CouponId") REFERENCES "Pricing_Coupon" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_Pricing_CouponUsage_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Reviews_Review" (
    "Id" bigserial NOT NULL,
    "Comment" text NULL,
    "CreatedOn" timestamptz NOT NULL,
    "EntityId" int8 NOT NULL,
    "EntityTypeId" int8 NOT NULL,
    "Rating" int4 NOT NULL,
    "ReviewerName" text NULL,
    "Status" int4 NOT NULL,
    "Title" text NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_Reviews_Review" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Reviews_Review_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "ShoppingCart_Cart" (
    "Id" bigserial NOT NULL,
    "CouponCode" text NULL,
    "CouponRuleName" text NULL,
    "CreatedOn" timestamptz NOT NULL,
    "IsActive" bool NOT NULL,
    "UpdatedOn" timestamptz NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_ShoppingCart_Cart" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_ShoppingCart_Cart_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "News_NewsItemCategory" (
    "CategoryId" int8 NOT NULL,
    "NewsItemId" int8 NOT NULL,
    CONSTRAINT "PK_News_NewsItemCategory" PRIMARY KEY ("CategoryId", "NewsItemId"),
    CONSTRAINT "FK_News_NewsItemCategory_News_NewsCategory_CategoryId" FOREIGN KEY ("CategoryId") REFERENCES "News_NewsCategory" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_News_NewsItemCategory_News_NewsItem_NewsItemId" FOREIGN KEY ("NewsItemId") REFERENCES "News_NewsItem" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Shipments_Shipment" (
    "Id" bigserial NOT NULL,
    "CreatedOn" timestamptz NOT NULL,
    "OrderId" int8 NOT NULL,
    "TrackingNumber" text NULL,
    "UpdatedOn" timestamptz NOT NULL,
    "UserId" int8 NOT NULL,
    CONSTRAINT "PK_Shipments_Shipment" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Shipments_Shipment_Orders_Order_OrderId" FOREIGN KEY ("OrderId") REFERENCES "Orders_Order" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Shipments_ShipmentItem" (
    "Id" bigserial NOT NULL,
    "OrderItemId" int8 NOT NULL,
    "Quantity" int4 NOT NULL,
    "ShipmentId" int8 NOT NULL,
    CONSTRAINT "PK_Shipments_ShipmentItem" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Shipments_ShipmentItem_Shipments_Shipment_ShipmentId" FOREIGN KEY ("ShipmentId") REFERENCES "Shipments_Shipment" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_ActivityLog_Activity_ActivityTypeId" ON "ActivityLog_Activity" ("ActivityTypeId");

CREATE INDEX "IX_Catalog_Category_ParentId" ON "Catalog_Category" ("ParentId");

CREATE INDEX "IX_Catalog_Category_ThumbnailImageId" ON "Catalog_Category" ("ThumbnailImageId");

CREATE INDEX "IX_Catalog_Product_BrandId" ON "Catalog_Product" ("BrandId");

CREATE INDEX "IX_Catalog_Product_CreatedById" ON "Catalog_Product" ("CreatedById");

CREATE INDEX "IX_Catalog_Product_TaxClassId" ON "Catalog_Product" ("TaxClassId");

CREATE INDEX "IX_Catalog_Product_ThumbnailImageId" ON "Catalog_Product" ("ThumbnailImageId");

CREATE INDEX "IX_Catalog_Product_UpdatedById" ON "Catalog_Product" ("UpdatedById");

CREATE INDEX "IX_Catalog_ProductAttribute_GroupId" ON "Catalog_ProductAttribute" ("GroupId");

CREATE INDEX "IX_Catalog_ProductAttributeValue_AttributeId" ON "Catalog_ProductAttributeValue" ("AttributeId");

CREATE INDEX "IX_Catalog_ProductAttributeValue_ProductId" ON "Catalog_ProductAttributeValue" ("ProductId");

CREATE INDEX "IX_Catalog_ProductCategory_CategoryId" ON "Catalog_ProductCategory" ("CategoryId");

CREATE INDEX "IX_Catalog_ProductCategory_ProductId" ON "Catalog_ProductCategory" ("ProductId");

CREATE INDEX "IX_Catalog_ProductLink_LinkedProductId" ON "Catalog_ProductLink" ("LinkedProductId");

CREATE INDEX "IX_Catalog_ProductLink_ProductId" ON "Catalog_ProductLink" ("ProductId");

CREATE INDEX "IX_Catalog_ProductMedia_MediaId" ON "Catalog_ProductMedia" ("MediaId");

CREATE INDEX "IX_Catalog_ProductMedia_ProductId" ON "Catalog_ProductMedia" ("ProductId");

CREATE INDEX "IX_Catalog_ProductOptionCombination_OptionId" ON "Catalog_ProductOptionCombination" ("OptionId");

CREATE INDEX "IX_Catalog_ProductOptionCombination_ProductId" ON "Catalog_ProductOptionCombination" ("ProductId");

CREATE INDEX "IX_Catalog_ProductOptionValue_OptionId" ON "Catalog_ProductOptionValue" ("OptionId");

CREATE INDEX "IX_Catalog_ProductOptionValue_ProductId" ON "Catalog_ProductOptionValue" ("ProductId");

CREATE INDEX "IX_Catalog_ProductTemplateProductAttribute_ProductAttributeId" ON "Catalog_ProductTemplateProductAttribute" ("ProductAttributeId");

CREATE INDEX "IX_Cms_MenuItem_EntityId" ON "Cms_MenuItem" ("EntityId");

CREATE INDEX "IX_Cms_MenuItem_MenuId" ON "Cms_MenuItem" ("MenuId");

CREATE INDEX "IX_Cms_MenuItem_ParentId" ON "Cms_MenuItem" ("ParentId");

CREATE INDEX "IX_Cms_Page_CreatedById" ON "Cms_Page" ("CreatedById");

CREATE INDEX "IX_Cms_Page_UpdatedById" ON "Cms_Page" ("UpdatedById");

CREATE INDEX "IX_Contacts_Contact_ContactAreaId" ON "Contacts_Contact" ("ContactAreaId");

CREATE INDEX "IX_Core_Address_CountryId" ON "Core_Address" ("CountryId");

CREATE INDEX "IX_Core_Address_DistrictId" ON "Core_Address" ("DistrictId");

CREATE INDEX "IX_Core_Address_StateOrProvinceId" ON "Core_Address" ("StateOrProvinceId");

CREATE UNIQUE INDEX "IX_Core_CustomerGroup_Name" ON "Core_CustomerGroup" ("Name");

CREATE INDEX "IX_Core_District_StateOrProvinceId" ON "Core_District" ("StateOrProvinceId");

CREATE INDEX "IX_Core_Entity_EntityTypeId" ON "Core_Entity" ("EntityTypeId");

CREATE UNIQUE INDEX "RoleNameIndex" ON "Core_Role" ("NormalizedName");

CREATE INDEX "IX_Core_RoleClaim_RoleId" ON "Core_RoleClaim" ("RoleId");

CREATE INDEX "IX_Core_StateOrProvince_CountryId" ON "Core_StateOrProvince" ("CountryId");

CREATE INDEX "IX_Core_User_DefaultBillingAddressId" ON "Core_User" ("DefaultBillingAddressId");

CREATE INDEX "IX_Core_User_DefaultShippingAddressId" ON "Core_User" ("DefaultShippingAddressId");

CREATE INDEX "EmailIndex" ON "Core_User" ("NormalizedEmail");

CREATE UNIQUE INDEX "UserNameIndex" ON "Core_User" ("NormalizedUserName");

CREATE INDEX "IX_Core_User_VendorId" ON "Core_User" ("VendorId");

CREATE INDEX "IX_Core_UserAddress_AddressId" ON "Core_UserAddress" ("AddressId");

CREATE INDEX "IX_Core_UserAddress_UserId" ON "Core_UserAddress" ("UserId");

CREATE INDEX "IX_Core_UserClaim_UserId" ON "Core_UserClaim" ("UserId");

CREATE INDEX "IX_Core_UserCustomerGroup_CustomerGroupId" ON "Core_UserCustomerGroup" ("CustomerGroupId");

CREATE INDEX "IX_Core_UserCustomerGroup_UserId" ON "Core_UserCustomerGroup" ("UserId");

CREATE INDEX "IX_Core_UserLogin_UserId" ON "Core_UserLogin" ("UserId");

CREATE INDEX "IX_Core_UserRole_RoleId" ON "Core_UserRole" ("RoleId");

CREATE INDEX "IX_Core_WidgetInstance_WidgetId" ON "Core_WidgetInstance" ("WidgetId");

CREATE INDEX "IX_Core_WidgetInstance_WidgetZoneId" ON "Core_WidgetInstance" ("WidgetZoneId");

CREATE INDEX "IX_Inventory_Warehouse_AddressId" ON "Inventory_Warehouse" ("AddressId");

CREATE INDEX "IX_Localization_Resource_CultureId" ON "Localization_Resource" ("CultureId");

CREATE INDEX "IX_News_NewsItem_CreatedById" ON "News_NewsItem" ("CreatedById");

CREATE INDEX "IX_News_NewsItem_ThumbnailImageId" ON "News_NewsItem" ("ThumbnailImageId");

CREATE INDEX "IX_News_NewsItem_UpdatedById" ON "News_NewsItem" ("UpdatedById");

CREATE INDEX "IX_News_NewsItemCategory_NewsItemId" ON "News_NewsItemCategory" ("NewsItemId");

CREATE INDEX "IX_Orders_Order_BillingAddressId" ON "Orders_Order" ("BillingAddressId");

CREATE INDEX "IX_Orders_Order_CreatedById" ON "Orders_Order" ("CreatedById");

CREATE INDEX "IX_Orders_Order_ParentId" ON "Orders_Order" ("ParentId");

CREATE INDEX "IX_Orders_Order_ShippingAddressId" ON "Orders_Order" ("ShippingAddressId");

CREATE INDEX "IX_Orders_OrderAddress_CountryId" ON "Orders_OrderAddress" ("CountryId");

CREATE INDEX "IX_Orders_OrderAddress_DistrictId" ON "Orders_OrderAddress" ("DistrictId");

CREATE INDEX "IX_Orders_OrderAddress_StateOrProvinceId" ON "Orders_OrderAddress" ("StateOrProvinceId");

CREATE INDEX "IX_Orders_OrderItem_OrderId" ON "Orders_OrderItem" ("OrderId");

CREATE INDEX "IX_Orders_OrderItem_ProductId" ON "Orders_OrderItem" ("ProductId");

CREATE INDEX "IX_Pricing_CartRuleCategory_CategoryId" ON "Pricing_CartRuleCategory" ("CategoryId");

CREATE INDEX "IX_Pricing_CartRuleCustomerGroup_CustomerGroupId" ON "Pricing_CartRuleCustomerGroup" ("CustomerGroupId");

CREATE INDEX "IX_Pricing_CartRuleProduct_ProductId" ON "Pricing_CartRuleProduct" ("ProductId");

CREATE INDEX "IX_Pricing_CartRuleUsage_CartRuleId" ON "Pricing_CartRuleUsage" ("CartRuleId");

CREATE INDEX "IX_Pricing_CartRuleUsage_UserId" ON "Pricing_CartRuleUsage" ("UserId");

CREATE INDEX "IX_Pricing_CatalogRuleCustomerGroup_CustomerGroupId" ON "Pricing_CatalogRuleCustomerGroup" ("CustomerGroupId");

CREATE INDEX "IX_Pricing_Coupon_CartRuleId" ON "Pricing_Coupon" ("CartRuleId");

CREATE INDEX "IX_Pricing_CouponUsage_CouponId" ON "Pricing_CouponUsage" ("CouponId");

CREATE INDEX "IX_Pricing_CouponUsage_UserId" ON "Pricing_CouponUsage" ("UserId");

CREATE INDEX "IX_ProductComparison_ComparingProduct_ProductId" ON "ProductComparison_ComparingProduct" ("ProductId");

CREATE INDEX "IX_ProductComparison_ComparingProduct_UserId" ON "ProductComparison_ComparingProduct" ("UserId");

CREATE INDEX "IX_Reviews_Review_UserId" ON "Reviews_Review" ("UserId");

CREATE INDEX "IX_Shipments_Shipment_OrderId" ON "Shipments_Shipment" ("OrderId");

CREATE INDEX "IX_Shipments_ShipmentItem_ShipmentId" ON "Shipments_ShipmentItem" ("ShipmentId");

CREATE INDEX "IX_ShippingTableRate_PriceAndDestination_CountryId" ON "ShippingTableRate_PriceAndDestination" ("CountryId");

CREATE INDEX "IX_ShippingTableRate_PriceAndDestination_StateOrProvinceId" ON "ShippingTableRate_PriceAndDestination" ("StateOrProvinceId");

CREATE INDEX "IX_ShoppingCart_Cart_UserId" ON "ShoppingCart_Cart" ("UserId");

CREATE INDEX "IX_ShoppingCart_CartItem_CartId" ON "ShoppingCart_CartItem" ("CartId");

CREATE INDEX "IX_ShoppingCart_CartItem_ProductId" ON "ShoppingCart_CartItem" ("ProductId");

CREATE INDEX "IX_Tax_TaxRate_CountryId" ON "Tax_TaxRate" ("CountryId");

CREATE INDEX "IX_Tax_TaxRate_StateOrProvinceId" ON "Tax_TaxRate" ("StateOrProvinceId");

CREATE INDEX "IX_Tax_TaxRate_TaxClassId" ON "Tax_TaxRate" ("TaxClassId");

ALTER TABLE "Catalog_Product" ADD CONSTRAINT "FK_Catalog_Product_Core_User_CreatedById" FOREIGN KEY ("CreatedById") REFERENCES "Core_User" ("Id") ON DELETE NO ACTION;

ALTER TABLE "Catalog_Product" ADD CONSTRAINT "FK_Catalog_Product_Core_User_UpdatedById" FOREIGN KEY ("UpdatedById") REFERENCES "Core_User" ("Id") ON DELETE NO ACTION;

ALTER TABLE "Orders_OrderItem" ADD CONSTRAINT "FK_Orders_OrderItem_Orders_Order_OrderId" FOREIGN KEY ("OrderId") REFERENCES "Orders_Order" ("Id") ON DELETE NO ACTION;

ALTER TABLE "ProductComparison_ComparingProduct" ADD CONSTRAINT "FK_ProductComparison_ComparingProduct_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE CASCADE;

ALTER TABLE "ShoppingCart_CartItem" ADD CONSTRAINT "FK_ShoppingCart_CartItem_ShoppingCart_Cart_CartId" FOREIGN KEY ("CartId") REFERENCES "ShoppingCart_Cart" ("Id") ON DELETE CASCADE;

ALTER TABLE "Core_UserAddress" ADD CONSTRAINT "FK_Core_UserAddress_Core_User_UserId" FOREIGN KEY ("UserId") REFERENCES "Core_User" ("Id") ON DELETE NO ACTION;

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20171127163534_InitSchema', '2.0.0-rtm-26452');

