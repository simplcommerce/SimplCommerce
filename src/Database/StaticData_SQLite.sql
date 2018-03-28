INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (1, 'Catalog.ProductPageSize', '10', 1, 'Catalog');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (2, 'Global.AssetVersion', '1.0', 1, 'Core');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (3, 'News.PageSize', '10', 1, 'News');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (4, 'GoogleAppKey', 'AIzaSyBmsQV2FUo6g52R1kovLyfvaYm4FryNs4g', 0, 'Core');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (5, 'SmtpServer', 'smtp.gmail.com', 0, 'Core');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (6, 'SmtpPort', '587', 0, 'Core');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (7, 'SmtpUsername', '', 0, 'Core');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (8, 'SmtpPassword', '', 0, 'Core');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (9, 'Theme', 'Generic', 0, 'Core');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (10, 'Tax.IsProductPriceIncludeTax', 'true', 1, 'Tax');
INSERT INTO Core_AppSetting (Id, Key, Value, IsVisibleInCommonSettingPage, Module) VALUES (11, 'Tax.DefaultTaxClassId', '1', 1, 'Tax');

INSERT INTO Core_Role (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (1, 'admin', 'ADMIN', 'bd3bee0b-5f1d-482d-b890-ffdc01915da3');
INSERT INTO Core_Role (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (2, 'customer', 'CUSTOMER', 'bd3bee0b-5f1d-482d-b890-ffdc01915da3');
INSERT INTO Core_Role (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (3, 'guest', 'GUEST', 'bd3bee0b-5f1d-482d-b890-ffdc01915da3');
INSERT INTO Core_Role (Id, Name, NormalizedName, ConcurrencyStamp) VALUES (4, 'vendor', 'VENDOR', 'bd3bee0b-5f1d-482d-b890-ffdc01915da3');

INSERT INTO Core_User (Id, UserGuid, FullName, IsDeleted, CreatedOn, UpdatedOn, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (2, '4653d7e5-f5ca-4813-a782-3385ca9739bc', 'System', 1, '2016-05-12 23:44:13', '2016-05-12 23:44:13.297', 'system@SimplCommerce.com', 'SYSTEM@SIMPLCOMMERCE.COM', 'system@SimplCommerce.com', 'SYSTEM@SIMPLCOMMERCE.COM', 0, 'AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==', '9e87ce89-64c0-45b9-8b52-6e0eaa79e5b8', '8620916f-e6b6-4f12-9041-83737154b339', NULL, 0, 0, '2050-05-12 23:44:13.297', 1, 0);
INSERT INTO Core_User (Id, UserGuid, FullName, IsDeleted, CreatedOn, UpdatedOn, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES (10, '1FFF10CE-0231-43A2-8B7D-C8DB18504F65', 'Shop Admin', 0, '2016-05-12 23:44:13', '2016-05-12 23:44:13.297', 'admin@SimplCommerce.com', 'ADMIN@SIMPLCOMMERCE.COM', 'admin@SimplCommerce.com', 'ADMIN@SIMPLCOMMERCE.COM', 0, 'AQAAAAEAACcQAAAAEAEqSCV8Bpg69irmeg8N86U503jGEAYf75fBuzvL00/mr/FGEsiUqfR0rWBbBUwqtw==', '9e87ce89-64c0-45b9-8b52-6e0eaa79e5b7', '8620916f-e6b6-4f12-9041-83737154b338', NULL, 0, 0, NULL, 1, 0);

INSERT INTO Core_UserRole (UserId, RoleId) VALUES (10, 1);

INSERT INTO Core_EntityType (Id, Name, RoutingController, RoutingAction, IsMenuable) VALUES (1, 'Category', 'Category', 'CategoryDetail', 1);
INSERT INTO Core_EntityType (Id, Name, RoutingController, RoutingAction, IsMenuable) VALUES (2, 'Brand', 'Brand', 'BrandDetail', 1);
INSERT INTO Core_EntityType (Id, Name, RoutingController, RoutingAction, IsMenuable) VALUES (3, 'Product', 'Product', 'ProductDetail', 0);
INSERT INTO Core_EntityType (Id, Name, RoutingController, RoutingAction, IsMenuable) VALUES (4, 'Page', 'Page', 'PageDetail', 1);
INSERT INTO Core_EntityType (Id, Name, RoutingController, RoutingAction, IsMenuable) VALUES (5, 'Vendor', 'Vendor', 'VendorDetail', 0);
INSERT INTO Core_EntityType (Id, Name, RoutingController, RoutingAction, IsMenuable) VALUES (6, 'NewsCategory', 'NewsCategory', 'NewsCategoryDetail', 1);
INSERT INTO Core_EntityType (Id, Name, RoutingController, RoutingAction, IsMenuable) VALUES (7, 'NewsItem', 'NewsItem', 'NewsItemDetail', 0);

INSERT INTO ActivityLog_ActivityType (Id, Name) VALUES (1, 'EntityView');

INSERT INTO Core_Widget (Id, Code, CreateUrl, CreatedOn, EditUrl, IsPublished, Name, ViewComponentName) VALUES (1, 'CarouselWidget', 'widget-carousel-create', '2016-06-19 00:00:00.0000000', 'widget-carousel-edit', 1, 'Carousel Widget', 'CarouselWidget');
INSERT INTO Core_Widget (Id, Code, CreateUrl, CreatedOn, EditUrl, IsPublished, Name, ViewComponentName) VALUES (2, 'HtmlWidget', 'widget-html-create', '2016-06-24 00:00:00.0000000', 'widget-html-edit', 1, 'Html Widget', 'HtmlWidget');
INSERT INTO Core_Widget (Id, Code, CreateUrl, CreatedOn, EditUrl, IsPublished, Name, ViewComponentName) VALUES (3, 'ProductWidget', 'widget-product-create', '2016-07-08 00:00:00.0000000', 'widget-product-edit', 1, 'Product Widget', 'ProductWidget');
INSERT INTO Core_Widget (Id, Code, CreateUrl, CreatedOn, EditUrl, IsPublished, Name, ViewComponentName) VALUES (4, 'CategoryWidget', 'widget-category-create', '2016-07-08 00:00:00.0000000', 'widget-category-edit', 1, 'Category Widget', 'CategoryWidget');
INSERT INTO Core_Widget (Id, Code, CreateUrl, CreatedOn, EditUrl, IsPublished, Name, ViewComponentName) VALUES (5, 'SpaceBarWidget', 'widget-spacebar-create', '2016-07-08 00:00:00.0000000', 'widget-spacebar-edit', 1, 'SpaceBar Widget', 'SpaceBarWidget');

INSERT INTO Core_WidgetZone (Id, Description, Name) VALUES (1, NULL, 'Home Featured');
INSERT INTO Core_WidgetZone (Id, Description, Name) VALUES (2, NULL, 'Home Main Content');
INSERT INTO Core_WidgetZone (Id, Description, Name) VALUES (3, NULL, 'Home After Main Content');

INSERT INTO Cms_Menu (Id, IsPublished, IsSystem, Name) VALUES (1, 1, 1, 'Customer services');
INSERT INTO Cms_Menu (Id, IsPublished, IsSystem, Name) VALUES (2, 1, 1, 'Information');

INSERT INTO Catalog_ProductOption (Id, Name) VALUES (1, 'Color');
INSERT INTO Catalog_ProductOption (Id, Name) VALUES (2, 'Size');
 
INSERT INTO Payments_PaymentProvider (Id, AdditionalSettings, ConfigureUrl, IsEnabled, LandingViewComponentName, Name) VALUES (1, NULL, NULL, 1, 'CoDLanding', 'Cash On Delivery');
INSERT INTO Payments_PaymentProvider (Id, AdditionalSettings, ConfigureUrl, IsEnabled, LandingViewComponentName, Name) VALUES (2, '{"IsSandbox":true,"ClientId":"","ClientSecret":""}', 'payments-paypalExpress-config', 1, 'PaypalExpressLanding', 'Paypal Express');
INSERT INTO Payments_PaymentProvider (Id, AdditionalSettings, ConfigureUrl, IsEnabled, LandingViewComponentName, Name) VALUES (3, '{"PublicKey": "pk_test_6pRNASCoBOKtIshFeQd4XMUh", "PrivateKey" : "sk_test_BQokikJOvBiI2HlWgH4olfQ2"}', 'payments-stripe-config', 1, 'StripeLanding', 'Stripe');
 
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (1, 'Afghanistan', 'AF', 'AFG', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (2, 'Albania', 'AL', 'ALB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (3, 'Algeria', 'DZ', 'DZA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (4, 'American Samoa', 'AS', 'ASM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (5, 'Andorra', 'AD', 'AND', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (6, 'Angola', 'AO', 'AGO', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (7, 'Anguilla', 'AI', 'AIA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (8, 'Antarctica', 'AQ', 'ATA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (9, 'Antigua &amp; Barbuda', 'AG', 'ATG', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (10, 'Argentina', 'AR', 'ARG', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (11, 'Armenia', 'AM', 'ARM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (12, 'Aruba', 'AW', 'ABW', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (13, 'Australia', 'AU', 'AUS', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (14, 'Austria', 'AT', 'AUT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (15, 'Azerbaijan', 'AZ', 'AZE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (16, 'Bahamas', 'BS', 'BHS', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (17, 'Bahrain', 'BH', 'BHR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (18, 'Bangladesh', 'BD', 'BGD', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (19, 'Barbados', 'BB', 'BRB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (20, 'Belarus', 'BY', 'BLR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (21, 'Belgium', 'BE', 'BEL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (22, 'Belize', 'BZ', 'BLZ', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (23, 'Benin', 'BJ', 'BEN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (24, 'Bermuda', 'BM', 'BMU', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (25, 'Bhutan', 'BT', 'BTN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (26, 'Bolivia', 'BO', 'BOL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (27, 'Bosnia &amp; Herzegovina', 'BA', 'BIH', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (28, 'Botswana', 'BW', 'BWA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (29, 'Bouvet Island', 'BV', 'BVT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (30, 'Brazil', 'BR', 'BRA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (31, 'British Indian Ocean Territory', 'IO', 'IOT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (32, 'British Virgin Islands', 'VG', 'VGB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (33, 'Brunei', 'BN', 'BRN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (34, 'Bulgaria', 'BG', 'BGR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (35, 'Burkina Faso', 'BF', 'BFA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (36, 'Burundi', 'BI', 'BDI', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (37, 'Cambodia', 'KH', 'KHM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (38, 'Cameroon', 'CM', 'CMR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (39, 'Canada', 'CA', 'CAN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (40, 'Cape Verde', 'CV', 'CPV', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (41, 'Cayman Islands', 'KY', 'CYM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (42, 'Central African Republic', 'CF', 'CAF', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (43, 'Chad', 'TD', 'TCD', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (44, 'Chile', 'CL', 'CHL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (45, 'China', 'CN', 'CHN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (46, 'Christmas Island', 'CX', 'CXR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (47, 'Cocos (Keeling) Islands', 'CC', 'CCK', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (48, 'Colombia', 'CO', 'COL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (49, 'Comoros', 'KM', 'COM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (50, 'Congo - Brazzaville', 'CG', 'COG', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (51, 'Congo - Kinshasa', 'CD', 'COD', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (52, 'Cook Islands', 'CK', 'COK', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (53, 'Costa Rica', 'CR', 'CRI', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (54, 'Croatia', 'HR', 'HRV', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (55, 'Cuba', 'CU', 'CUB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (56, 'Cyprus', 'CY', 'CYP', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (57, 'Czech Republic', 'CZ', 'CZE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (58, 'Côte d’Ivoire', 'CI', 'CIV', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (59, 'Denmark', 'DK', 'DNK', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (60, 'Djibouti', 'DJ', 'DJI', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (61, 'Dominica', 'DM', 'DMA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (62, 'Dominican Republic', 'DO', 'DOM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (63, 'Ecuador', 'EC', 'ECU', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (64, 'Egypt', 'EG', 'EGY', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (65, 'El Salvador', 'SV', 'SLV', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (66, 'Equatorial Guinea', 'GQ', 'GNQ', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (67, 'Eritrea', 'ER', 'ERI', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (68, 'Estonia', 'EE', 'EST', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (69, 'Ethiopia', 'ET', 'ETH', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (70, 'Falkland Islands', 'FK', 'FLK', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (71, 'Faroe Islands', 'FO', 'FRO', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (72, 'Fiji', 'FJ', 'FJI', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (73, 'Finland', 'FI', 'FIN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (74, 'France', 'FR', 'FRA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (75, 'French Guiana', 'GF', 'GUF', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (76, 'French Polynesia', 'PF', 'PYF', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (77, 'French Southern Territories', 'TF', 'ATF', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (78, 'Gabon', 'GA', 'GAB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (79, 'Gambia', 'GM', 'GMB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (80, 'Georgia', 'GE', 'GEO', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (81, 'Germany', 'DE', 'DEU', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (82, 'Ghana', 'GH', 'GHA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (83, 'Gibraltar', 'GI', 'GIB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (84, 'Greece', 'GR', 'GRC', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (85, 'Greenland', 'GL', 'GRL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (86, 'Grenada', 'GD', 'GRD', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (87, 'Guadeloupe', 'GP', 'GLP', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (88, 'Guam', 'GU', 'GUM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (89, 'Guatemala', 'GT', 'GTM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (90, 'Guernsey', 'GG', 'GGY', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (91, 'Guinea', 'GN', 'GIN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (92, 'Guinea-Bissau', 'GW', 'GNB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (93, 'Guyana', 'GY', 'GUY', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (94, 'Haiti', 'HT', 'HTI', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (95, 'Heard &amp; McDonald Islands', 'HM', 'HMD', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (96, 'Honduras', 'HN', 'HND', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (97, 'Hong Kong SAR China', 'HK', 'HKG', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (98, 'Hungary', 'HU', 'HUN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (99, 'Iceland', 'IS', 'ISL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (100, 'India', 'IN', 'IND', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (101, 'Indonesia', 'ID', 'IDN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (102, 'Iran', 'IR', 'IRN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (103, 'Iraq', 'IQ', 'IRQ', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (104, 'Ireland', 'IE', 'IRL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (105, 'Isle of Man', 'IM', 'IMN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (106, 'Israel', 'IL', 'ISR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (107, 'Italy', 'IT', 'ITA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (108, 'Jamaica', 'JM', 'JAM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (109, 'Japan', 'JP', 'JPN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (110, 'Jersey', 'JE', 'JEY', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (111, 'Jordan', 'JO', 'JOR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (112, 'Kazakhstan', 'KZ', 'KAZ', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (113, 'Kenya', 'KE', 'KEN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (114, 'Kiribati', 'KI', 'KIR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (115, 'Kuwait', 'KW', 'KWT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (116, 'Kyrgyzstan', 'KG', 'KGZ', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (117, 'Laos', 'LA', 'LAO', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (118, 'Latvia', 'LV', 'LVA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (119, 'Lebanon', 'LB', 'LBN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (120, 'Lesotho', 'LS', 'LSO', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (121, 'Liberia', 'LR', 'LBR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (122, 'Libya', 'LY', 'LBY', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (123, 'Liechtenstein', 'LI', 'LIE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (124, 'Lithuania', 'LT', 'LTU', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (125, 'Luxembourg', 'LU', 'LUX', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (126, 'Macau SAR China', 'MO', 'MAC', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (127, 'Macedonia', 'MK', 'MKD', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (128, 'Madagascar', 'MG', 'MDG', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (129, 'Malawi', 'MW', 'MWI', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (130, 'Malaysia', 'MY', 'MYS', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (131, 'Maldives', 'MV', 'MDV', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (132, 'Mali', 'ML', 'MLI', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (133, 'Malta', 'MT', 'MLT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (134, 'Marshall Islands', 'MH', 'MHL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (135, 'Martinique', 'MQ', 'MTQ', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (136, 'Mauritania', 'MR', 'MRT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (137, 'Mauritius', 'MU', 'MUS', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (138, 'Mayotte', 'YT', 'MYT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (139, 'Mexico', 'MX', 'MEX', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (140, 'Micronesia', 'FM', 'FSM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (141, 'Moldova', 'MD', 'MDA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (142, 'Monaco', 'MC', 'MCO', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (143, 'Mongolia', 'MN', 'MNG', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (144, 'Montenegro', 'ME', 'MNE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (145, 'Montserrat', 'MS', 'MSR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (146, 'Morocco', 'MA', 'MAR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (147, 'Mozambique', 'MZ', 'MOZ', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (148, 'Myanmar (Burma)', 'MM', 'MMR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (149, 'Namibia', 'NA', 'NAM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (150, 'Nauru', 'NR', 'NRU', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (151, 'Nepal', 'NP', 'NPL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (152, 'Netherlands', 'NL', 'NLD', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (153, 'New Caledonia', 'NC', 'NCL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (154, 'New Zealand', 'NZ', 'NZL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (155, 'Nicaragua', 'NI', 'NIC', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (156, 'Niger', 'NE', 'NER', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (157, 'Nigeria', 'NG', 'NGA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (158, 'Niue', 'NU', 'NIU', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (159, 'Norfolk Island', 'NF', 'NFK', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (160, 'North Korea', 'KP', 'PRK', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (161, 'Northern Mariana Islands', 'MP', 'MNP', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (162, 'Norway', 'NO', 'NOR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (163, 'Oman', 'OM', 'OMN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (164, 'Pakistan', 'PK', 'PAK', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (165, 'Palau', 'PW', 'PLW', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (166, 'Palestinian Territories', 'PS', 'PSE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (167, 'Panama', 'PA', 'PAN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (168, 'Papua New Guinea', 'PG', 'PNG', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (169, 'Paraguay', 'PY', 'PRY', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (170, 'Peru', 'PE', 'PER', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (171, 'Philippines', 'PH', 'PHL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (172, 'Pitcairn Islands', 'PN', 'PCN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (173, 'Poland', 'PL', 'POL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (174, 'Portugal', 'PT', 'PRT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (175, 'Qatar', 'QA', 'QAT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (176, 'Romania', 'RO', 'ROU', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (177, 'Russia', 'RU', 'RUS', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (178, 'Rwanda', 'RW', 'RWA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (179, 'Réunion', 'RE', 'REU', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (180, 'Samoa', 'WS', 'WSM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (181, 'San Marino', 'SM', 'SMR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (182, 'Saudi Arabia', 'SA', 'SAU', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (183, 'Senegal', 'SN', 'SEN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (184, 'Serbia', 'RS', 'SRB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (185, 'Seychelles', 'SC', 'SYC', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (186, 'Sierra Leone', 'SL', 'SLE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (187, 'Singapore', 'SG', 'SGP', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (188, 'Slovakia', 'SK', 'SVK', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (189, 'Slovenia', 'SI', 'SVN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (190, 'Solomon Islands', 'SB', 'SLB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (191, 'Somalia', 'SO', 'SOM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (192, 'South Africa', 'ZA', 'ZAF', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (193, 'South Georgia &amp; South Sandwich Islands', 'GS', 'SGS', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (194, 'South Korea', 'KR', 'KOR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (195, 'Spain', 'ES', 'ESP', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (196, 'Sri Lanka', 'LK', 'LKA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (197, 'St. Barthélemy', 'BL', 'BLM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (198, 'St. Helena', 'SH', 'SHN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (199, 'St. Kitts &amp; Nevis', 'KN', 'KNA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (200, 'St. Lucia', 'LC', 'LCA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (201, 'St. Martin', 'MF', 'MAF', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (202, 'St. Pierre &amp; Miquelon', 'PM', 'SPM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (203, 'St. Vincent &amp; Grenadines', 'VC', 'VCT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (204, 'Sudan', 'SD', 'SDN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (205, 'Suriname', 'SR', 'SUR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (206, 'Svalbard &amp; Jan Mayen', 'SJ', 'SJM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (207, 'Swaziland', 'SZ', 'SWZ', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (208, 'Sweden', 'SE', 'SWE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (209, 'Switzerland', 'CH', 'CHE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (210, 'Syria', 'SY', 'SYR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (211, 'São Tomé &amp; Príncipe', 'ST', 'STP', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (212, 'Taiwan', 'TW', 'TWN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (213, 'Tajikistan', 'TJ', 'TJK', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (214, 'Tanzania', 'TZ', 'TZA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (215, 'Thailand', 'TH', 'THA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (216, 'Timor-Leste', 'TL', 'TLS', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (217, 'Togo', 'TG', 'TGO', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (218, 'Tokelau', 'TK', 'TKL', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (219, 'Tonga', 'TO', 'TON', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (220, 'Trinidad &amp; Tobago', 'TT', 'TTO', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (221, 'Tunisia', 'TN', 'TUN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (222, 'Turkey', 'TR', 'TUR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (223, 'Turkmenistan', 'TM', 'TKM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (224, 'Turks &amp; Caicos Islands', 'TC', 'TCA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (225, 'Tuvalu', 'TV', 'TUV', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (226, 'U.S. Outlying Islands', 'UM', 'UMI', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (227, 'U.S. Virgin Islands', 'VI', 'VIR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (228, 'Uganda', 'UG', 'UGA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (229, 'Ukraine', 'UA', 'UKR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (230, 'United Arab Emirates', 'AE', 'ARE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (231, 'United Kingdom', 'GB', 'GBR', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (232, 'United States', 'US', 'USA', 1, 1, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (233, 'Uruguay', 'UY', 'URY', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (234, 'Uzbekistan', 'UZ', 'UZB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (235, 'Vanuatu', 'VU', 'VUT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (236, 'Vatican City', 'VA', 'VAT', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (237, 'Venezuela', 'VE', 'VEN', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (238, 'Vietnam', 'VN', 'VNM', 1, 1, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (239, 'Wallis &amp; Futuna', 'WF', 'WLF', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (240, 'Western Sahara', 'EH', 'ESH', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (241, 'Yemen', 'YE', 'YEM', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (242, 'Zambia', 'ZM', 'ZMB', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (243, 'Zimbabwe', 'ZW', 'ZWE', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (244, 'Åland Islands', 'AX', 'ALA', 0, 0, 1, 1, 1);
INSERT INTO Core_Country (Id, Name, Code2, Code3, IsBillingEnabled, IsShippingEnabled, IsCityEnabled, IsDistrictEnabled, IsZipCodeEnabled) VALUES (245, 'Netherlands Antilles', 'AN', 'ANT', 0, 0, 1, 1, 1);

INSERT INTO Core_StateOrProvince (Id, CountryId, Name, Type) VALUES
(1, 238, 'Hà Nội', 'Thành Phố'),
(2, 238, 'Hà Giang', 'Tỉnh'),
(4, 238, 'Cao Bằng', 'Tỉnh'),
(6, 238, 'Bắc Kạn', 'Tỉnh'),
(8, 238, 'Tuyên Quang', 'Tỉnh'),
(10, 238, 'Lào Cai', 'Tỉnh'),
(11, 238, 'Điện Biên', 'Tỉnh'),
(12, 238, 'Lai Châu', 'Tỉnh'),
(14, 238, 'Sơn La', 'Tỉnh'),
(15, 238, 'Yên Bái', 'Tỉnh'),
(17, 238, 'Hòa Bình', 'Tỉnh'),
(19, 238, 'Thái Nguyên', 'Tỉnh'),
(20, 238, 'Lạng Sơn', 'Tỉnh'),
(22, 238, 'Quảng Ninh', 'Tỉnh'),
(24, 238, 'Bắc Giang', 'Tỉnh'),
(25, 238, 'Phú Thọ', 'Tỉnh'),
(26, 238, 'Vĩnh Phúc', 'Tỉnh'),
(27, 238, 'Bắc Ninh', 'Tỉnh'),
(30, 238, 'Hải Dương', 'Tỉnh'),
(31, 238, 'Hải Phòng', 'Thành Phố'),
(33, 238, 'Hưng Yên', 'Tỉnh'),
(34, 238, 'Thái Bình', 'Tỉnh'),
(35, 238, 'Hà Nam', 'Tỉnh'),
(36, 238, 'Nam Định', 'Tỉnh'),
(37, 238, 'Ninh Bình', 'Tỉnh'),
(38, 238, 'Thanh Hóa', 'Tỉnh'),
(40, 238, 'Nghệ An', 'Tỉnh'),
(42, 238, 'Hà Tĩnh', 'Tỉnh'),
(44, 238, 'Quảng Bình', 'Tỉnh'),
(45, 238, 'Quảng Trị', 'Tỉnh'),
(46, 238, 'Thừa Thiên Huế', 'Tỉnh'),
(48, 238, 'Đà Nẵng', 'Thành Phố'),
(49, 238, 'Quảng Nam', 'Tỉnh'),
(51, 238, 'Quảng Ngãi', 'Tỉnh'),
(52, 238, 'Bình Định', 'Tỉnh'),
(54, 238, 'Phú Yên', 'Tỉnh'),
(56, 238, 'Khánh Hòa', 'Tỉnh'),
(58, 238, 'Ninh Thuận', 'Tỉnh'),
(60, 238, 'Bình Thuận', 'Tỉnh'),
(62, 238, 'Kon Tum', 'Tỉnh'),
(64, 238, 'Gia Lai', 'Tỉnh'),
(66, 238, 'Đắk Lắk', 'Tỉnh'),
(67, 238, 'Đắk Nông', 'Tỉnh'),
(68, 238, 'Lâm Đồng', 'Tỉnh'),
(70, 238, 'Bình Phước', 'Tỉnh'),
(72, 238, 'Tây Ninh', 'Tỉnh'),
(74, 238, 'Bình Dương', 'Tỉnh'),
(75, 238, 'Đồng Nai', 'Tỉnh'),
(77, 238, 'Bà Rịa - Vũng Tàu', 'Tỉnh'),
(79, 238, 'Hồ Chí Minh', 'Thành Phố'),
(80, 238, 'Long An', 'Tỉnh'),
(82, 238, 'Tiền Giang', 'Tỉnh'),
(83, 238, 'Bến Tre', 'Tỉnh'),
(84, 238, 'Trà Vinh', 'Tỉnh'),
(86, 238, 'Vĩnh Long', 'Tỉnh'),
(87, 238, 'Đồng Tháp', 'Tỉnh'),
(89, 238, 'An Giang', 'Tỉnh'),
(91, 238, 'Kiên Giang', 'Tỉnh'),
(92, 238, 'Cần Thơ', 'Thành Phố'),
(93, 238, 'Hậu Giang', 'Tỉnh'),
(94, 238, 'Sóc Trăng', 'Tỉnh'),
(95, 238, 'Bạc Liêu', 'Tỉnh'),
(96, 238, 'Cà Mau', 'Tỉnh');

INSERT INTO Core_StateOrProvince (CountryId, CountryCode, Code, Name) VALUES
(232, 'US', 'AL', 'Alabama'),
(232, 'US', 'AK', 'Alaska'),
(232, 'US', 'AS', 'American Samoa'),
(232, 'US', 'AZ', 'Arizona'),
(232, 'US', 'AR', 'Arkansas'),
(232, 'US', 'AE', 'Armed Forces Africa'),
(232, 'US', 'AA', 'Armed Forces Americas'),
(232, 'US', 'AE', 'Armed Forces Canada'),
(232, 'US', 'AE', 'Armed Forces Europe'),
(232, 'US', 'AE', 'Armed Forces Middle East'),
(232, 'US', 'AP', 'Armed Forces Pacific'),
(232, 'US', 'CA', 'California'),
(232, 'US', 'CO', 'Colorado'),
(232, 'US', 'CT', 'Connecticut'),
(232, 'US', 'DE', 'Delaware'),
(232, 'US', 'DC', 'District of Columbia'),
(232, 'US', 'FM', 'Federated States Of Micronesia'),
(232, 'US', 'FL', 'Florida'),
(232, 'US', 'GA', 'Georgia'),
(232, 'US', 'GU', 'Guam'),
(232, 'US', 'HI', 'Hawaii'),
(232, 'US', 'ID', 'Idaho'),
(232, 'US', 'IL', 'Illinois'),
(232, 'US', 'IN', 'Indiana'),
(232, 'US', 'IA', 'Iowa'),
(232, 'US', 'KS', 'Kansas'),
(232, 'US', 'KY', 'Kentucky'),
(232, 'US', 'LA', 'Louisiana'),
(232, 'US', 'ME', 'Maine'),
(232, 'US', 'MH', 'Marshall Islands'),
(232, 'US', 'MD', 'Maryland'),
(232, 'US', 'MA', 'Massachusetts'),
(232, 'US', 'MI', 'Michigan'),
(232, 'US', 'MN', 'Minnesota'),
(232, 'US', 'MS', 'Mississippi'),
(232, 'US', 'MO', 'Missouri'),
(232, 'US', 'MT', 'Montana'),
(232, 'US', 'NE', 'Nebraska'),
(232, 'US', 'NV', 'Nevada'),
(232, 'US', 'NH', 'New Hampshire'),
(232, 'US', 'NJ', 'New Jersey'),
(232, 'US', 'NM', 'New Mexico'),
(232, 'US', 'NY', 'New York'),
(232, 'US', 'NC', 'North Carolina'),
(232, 'US', 'ND', 'North Dakota'),
(232, 'US', 'MP', 'Northern Mariana Islands'),
(232, 'US', 'OH', 'Ohio'),
(232, 'US', 'OK', 'Oklahoma'),
(232, 'US', 'OR', 'Oregon'),
(232, 'US', 'PW', 'Palau'),
(232, 'US', 'PA', 'Pennsylvania'),
(232, 'US', 'PR', 'Puerto Rico'),
(232, 'US', 'RI', 'Rhode Island'),
(232, 'US', 'SC', 'South Carolina'),
(232, 'US', 'SD', 'South Dakota'),
(232, 'US', 'TN', 'Tennessee'),
(232, 'US', 'TX', 'Texas'),
(232, 'US', 'UT', 'Utah'),
(232, 'US', 'VT', 'Vermont'),
(232, 'US', 'VI', 'Virgin Islands'),
(232, 'US', 'VA', 'Virginia'),
(232, 'US', 'WA', 'Washington'),
(232, 'US', 'WV', 'West Virginia'),
(232, 'US', 'WI', 'Wisconsin'),
(232, 'US', 'WY', 'Wyoming'),
(39, 'CA', 'AB', 'Alberta'),
(39, 'CA', 'BC', 'British Columbia'),
(39, 'CA', 'MB', 'Manitoba'),
(39, 'CA', 'NL', 'Newfoundland and Labrador'),
(39, 'CA', 'NB', 'New Brunswick'),
(39, 'CA', 'NS', 'Nova Scotia'),
(39, 'CA', 'NT', 'Northwest Territories'),
(39, 'CA', 'NU', 'Nunavut'),
(39, 'CA', 'ON', 'Ontario'),
(39, 'CA', 'PE', 'Prince Edward Island'),
(39, 'CA', 'QC', 'Quebec'),
(39, 'CA', 'SK', 'Saskatchewan'),
(39, 'CA', 'YT', 'Yukon Territory'),
(195, 'ES', 'A Coruсa', 'A Coruña'),
(195, 'ES', 'Alava', 'Alava'),
(195, 'ES', 'Albacete', 'Albacete'),
(195, 'ES', 'Alicante', 'Alicante'),
(195, 'ES', 'Almeria', 'Almeria'),
(195, 'ES', 'Asturias', 'Asturias'),
(195, 'ES', 'Avila', 'Avila'),
(195, 'ES', 'Badajoz', 'Badajoz'),
(195, 'ES', 'Baleares', 'Baleares'),
(195, 'ES', 'Barcelona', 'Barcelona'),
(195, 'ES', 'Burgos', 'Burgos'),
(195, 'ES', 'Caceres', 'Caceres'),
(195, 'ES', 'Cadiz', 'Cadiz'),
(195, 'ES', 'Cantabria', 'Cantabria'),
(195, 'ES', 'Castellon', 'Castellon'),
(195, 'ES', 'Ceuta', 'Ceuta'),
(195, 'ES', 'Ciudad Real', 'Ciudad Real'),
(195, 'ES', 'Cordoba', 'Cordoba'),
(195, 'ES', 'Cuenca', 'Cuenca'),
(195, 'ES', 'Girona', 'Girona'),
(195, 'ES', 'Granada', 'Granada'),
(195, 'ES', 'Guadalajara', 'Guadalajara'),
(195, 'ES', 'Guipuzcoa', 'Guipuzcoa'),
(195, 'ES', 'Huelva', 'Huelva'),
(195, 'ES', 'Huesca', 'Huesca'),
(195, 'ES', 'Jaen', 'Jaen'),
(195, 'ES', 'La Rioja', 'La Rioja'),
(195, 'ES', 'Las Palmas', 'Las Palmas'),
(195, 'ES', 'Leon', 'Leon'),
(195, 'ES', 'Lleida', 'Lleida'),
(195, 'ES', 'Lugo', 'Lugo'),
(195, 'ES', 'Madrid', 'Madrid'),
(195, 'ES', 'Malaga', 'Malaga'),
(195, 'ES', 'Melilla', 'Melilla'),
(195, 'ES', 'Murcia', 'Murcia'),
(195, 'ES', 'Navarra', 'Navarra'),
(195, 'ES', 'Ourense', 'Ourense'),
(195, 'ES', 'Palencia', 'Palencia'),
(195, 'ES', 'Pontevedra', 'Pontevedra'),
(195, 'ES', 'Salamanca', 'Salamanca'),
(195, 'ES', 'Santa Cruz de Tenerife', 'Santa Cruz de Tenerife'),
(195, 'ES', 'Segovia', 'Segovia'),
(195, 'ES', 'Sevilla', 'Sevilla'),
(195, 'ES', 'Soria', 'Soria'),
(195, 'ES', 'Tarragona', 'Tarragona'),
(195, 'ES', 'Teruel', 'Teruel'),
(195, 'ES', 'Toledo', 'Toledo'),
(195, 'ES', 'Valencia', 'Valencia'),
(195, 'ES', 'Valladolid', 'Valladolid'),
(195, 'ES', 'Vizcaya', 'Vizcaya'),
(195, 'ES', 'Zamora', 'Zamora'),
(195, 'ES', 'Zaragoza', 'Zaragoza');

INSERT INTO Core_District (Id, Name, Type, Location, StateOrProvinceId) VALUES
(1, 'Ba Đình', 'Quận', '21 02 08N, 105 49 38E', '01'),
(2, 'Hoàn Kiếm', 'Quận', '21 01 53N, 105 51 09E', '01'),
(3, 'Tây Hồ', 'Quận', '21 04 10N, 105 49 07E', '01'),
(4, 'Long Biên', 'Quận', '21 02 21N, 105 53 07E', '01'),
(5, 'Cầu Giấy', 'Quận', '21 01 52N, 105 47 20E', '01'),
(6, 'Đống Đa', 'Quận', '21 00 56N, 105 49 06E', '01'),
(7, 'Hai Bà Trưng', 'Quận', '21 00 27N, 105 51 35E', '01'),
(8, 'Hoàng Mai', 'Quận', '20 58 33N, 105 51 22E', '01'),
(9, 'Thanh Xuân', 'Quận', '20 59 44N, 105 48 56E', '01'),
(16, 'Sóc Sơn', 'Huyện', '21 16 55N, 105 49 46E', '01'),
(17, 'Đông Anh', 'Huyện', '21 08 16N, 105 49 38E', '01'),
(18, 'Gia Lâm', 'Huyện', '21 01 28N, 105 56 54E', '01'),
(19, 'Từ Liêm', 'Huyện', '21 02 39N, 105 45 32E', '01'),
(20, 'Thanh Trì', 'Huyện', '20 56 32N, 105 50 55E', '01'),
(24, 'Hà Giang', 'Thị Xã', '22 46 23N, 105 02 39E', '02'),
(26, 'Đồng Văn', 'Huyện', '23 14 34N, 105 15 48E', '02'),
(27, 'Mèo Vạc', 'Huyện', '23 09 10N, 105 26 38E', '02'),
(28, 'Yên Minh', 'Huyện', '23 04 20N, 105 10 13E', '02'),
(29, 'Quản Bạ', 'Huyện', '23 04 03N, 104 58 05E', '02'),
(30, 'Vị Xuyên', 'Huyện', '22 45 50N, 104 56 26E', '02'),
(31, 'Bắc Mê', 'Huyện', '22 45 48N, 105 16 26E', '02'),
(32, 'Hoàng Su Phì', 'Huyện', '22 41 37N, 104 40 06E', '02'),
(33, 'Xín Mần', 'Huyện', '22 38 05N, 104 28 35E', '02'),
(34, 'Bắc Quang', 'Huyện', '22 23 42N, 104 55 06E', '02'),
(35, 'Quang Bình', 'Huyện', '22 23 07N, 104 37 11E', '02'),
(40, 'Cao Bằng', 'Thị Xã', '22 39 20N, 106 15 20E', '04'),
(42, 'Bảo Lâm', 'Huyện', '22 52 37N, 105 27 28E', '04'),
(43, 'Bảo Lạc', 'Huyện', '22 52 31N, 105 42 41E', '04'),
(44, 'Thông Nông', 'Huyện', '22 49 09N, 105 57 05E', '04'),
(45, 'Hà Quảng', 'Huyện', '22 53 42N, 106 06 32E', '04'),
(46, 'Trà Lĩnh', 'Huyện', '22 48 14N, 106 19 47E', '04'),
(47, 'Trùng Khánh', 'Huyện', '22 49 31N, 106 33 58E', '04'),
(48, 'Hạ Lang', 'Huyện', '22 42 37N, 106 41 42E', '04'),
(49, 'Quảng Uyên', 'Huyện', '22 40 15N, 106 27 42E', '04'),
(50, 'Phục Hoà', 'Huyện', '22 33 52N, 106 30 02E', '04'),
(51, 'Hoà An', 'Huyện', '22 41 20N, 106 02 05E', '04'),
(52, 'Nguyên Bình', 'Huyện', '22 38 52N, 105 57 02E', '04'),
(53, 'Thạch An', 'Huyện', '22 28 51N, 106 19 51E', '04'),
(58, 'Bắc Kạn', 'Thị Xã', '22 08 00N, 105 51 10E', '06'),
(60, 'Pác Nặm', 'Huyện', '22 35 46N, 105 40 25E', '06'),
(61, 'Ba Bể', 'Huyện', '22 23 54N, 105 43 30E', '06'),
(62, 'Ngân Sơn', 'Huyện', '22 25 50N, 106 01 00E', '06'),
(63, 'Bạch Thông', 'Huyện', '22 12 04N, 105 51 01E', '06'),
(64, 'Chợ Đồn', 'Huyện', '22 11 18N, 105 34 43E', '06'),
(65, 'Chợ Mới', 'Huyện', '21 57 56N, 105 51 29E', '06'),
(66, 'Na Rì', 'Huyện', '22 09 48N, 106 05 09E', '06'),
(70, 'Tuyên Quang', 'Thị Xã', '21 49 40N, 105 13 12E', '08'),
(72, 'Nà Hang', 'Huyện', '22 28 34N, 105 21 03E', '08'),
(73, 'Chiêm Hóa', 'Huyện', '22 12 49N, 105 14 32E', '08'),
(74, 'Hàm Yên', 'Huyện', '22 05 46N, 105 00 13E', '08'),
(75, 'Yên Sơn', 'Huyện', '21 51 53N, 105 18 14E', '08'),
(76, 'Sơn Dương', 'Huyện', '21 40 22N, 105 22 57E', '08'),
(80, 'Lào Cai', 'Thành Phố', '22 25 07N, 103 58 43E', '10'),
(82, 'Bát Xát', 'Huyện', '22 35 50N, 103 44 49E', '10'),
(83, 'Mường Khương', 'Huyện', '22 41 05N, 104 08 26E', '10'),
(84, 'Si Ma Cai', 'Huyện', '22 39 46N, 104 16 05E', '10'),
(85, 'Bắc Hà', 'Huyện', '22 30 08N, 104 18 54E', '10'),
(86, 'Bảo Thắng', 'Huyện', '22 22 47N, 104 10 00E', '10'),
(87, 'Bảo Yên', 'Huyện', '22 17 38N, 104 25 02E', '10'),
(88, 'Sa Pa', 'Huyện', '22 18 54N, 103 54 18E', '10'),
(89, 'Văn Bàn', 'Huyện', '22 03 48N, 104 10 59E', '10'),
(94, 'Điện Biên Phủ', 'Thành Phố', '21 24 52N, 103 02 31E', '11'),
(95, 'Mường Lay', 'Thị Xã', '22 01 47N, 103 07 10E', '11'),
(96, 'Mường Nhé', 'Huyện', '22 06 11N, 102 30 54E', '11'),
(97, 'Mường Chà', 'Huyện', '21 50 31N, 103 03 15E', '11'),
(98, 'Tủa Chùa', 'Huyện', '21 58 19N, 103 23 01E', '11'),
(99, 'Tuần Giáo', 'Huyện', '21 38 03N, 103 21 06E', '11'),
(100, 'Điện Biên', 'Huyện', '21 15 19N, 103 03 19E', '11'),
(101, 'Điện Biên Đông', 'Huyện', '21 14 07N, 103 15 19E', '11'),
(102, 'Mường Ảng', 'Huyện', '', '11'),
(104, 'Lai Châu', 'Thị Xã', '22 23 15N, 103 24 22E', '12'),
(106, 'Tam Đường', 'Huyện', '22 20 16N, 103 32 53E', '12'),
(107, 'Mường Tè', 'Huyện', '22 24 16N, 102 43 11E', '12'),
(108, 'Sìn Hồ', 'Huyện', '22 17 21N, 103 18 12E', '12'),
(109, 'Phong Thổ', 'Huyện', '22 38 24N, 103 22 38E', '12'),
(110, 'Than Uyên', 'Huyện', '21 59 35N, 103 45 30E', '12'),
(111, 'Tân Uyên', 'Huyện', '', '12'),
(116, 'Sơn La', 'Thành Phố', '21 20 39N, 103 54 52E', '14'),
(118, 'Quỳnh Nhai', 'Huyện', '21 46 34N, 103 39 02E', '14'),
(119, 'Thuận Châu', 'Huyện', '21 24 54N, 103 39 46E', '14'),
(120, 'Mường La', 'Huyện', '21 31 38N, 104 02 48E', '14'),
(121, 'Bắc Yên', 'Huyện', '21 13 23N, 104 22 09E', '14'),
(122, 'Phù Yên', 'Huyện', '21 13 33N, 104 41 51E', '14'),
(123, 'Mộc Châu', 'Huyện', '20 49 21N, 104 43 10E', '14'),
(124, 'Yên Châu', 'Huyện', '20 59 33N, 104 19 51E', '14'),
(125, 'Mai Sơn', 'Huyện', '21 10 08N, 103 59 36E', '14'),
(126, 'Sông Mã', 'Huyện', '21 06 04N, 103 43 56E', '14'),
(127, 'Sốp Cộp', 'Huyện', '20 52 46N, 103 30 38E', '14'),
(132, 'Yên Bái', 'Thành Phố', '21 44 28N, 104 53 42E', '15'),
(133, 'Nghĩa Lộ', 'Thị Xã', '21 35 58N, 104 29 22E', '15'),
(135, 'Lục Yên', 'Huyện', '22 06 44N, 104 43 12E', '15'),
(136, 'Văn Yên', 'Huyện', '21 55 55N, 104 33 51E', '15'),
(137, 'Mù Cang Chải', 'Huyện', '21 48 22N, 104 09 01E', '15'),
(138, 'Trấn Yên', 'Huyện', '21 42 20N, 104 48 56E', '15'),
(139, 'Trạm Tấu', 'Huyện', '21 30 40N, 104 28 03E', '15'),
(140, 'Văn Chấn', 'Huyện', '21 34 15N, 104 35 19E', '15'),
(141, 'Yên Bình', 'Huyện', '21 52 24N, 104 55 16E', '15'),
(148, 'Hòa Bình', 'Thành Phố', '20 50 36N, 105 19 20E', '17'),
(150, 'Đà Bắc', 'Huyện', '20 55 58N, 105 04 52E', '17'),
(151, 'Kỳ Sơn', 'Huyện', '20 54 06N, 105 23 18E', '17'),
(152, 'Lương Sơn', 'Huyện', '20 53 16N, 105 30 55E', '17'),
(153, 'Kim Bôi', 'Huyện', '20 40 34N, 105 32 15E', '17'),
(154, 'Cao Phong', 'Huyện', '20 41 23N, 105 17 48E', '17'),
(155, 'Tân Lạc', 'Huyện', '20 36 44N, 105 15 03E', '17'),
(156, 'Mai Châu', 'Huyện', '20 40 56N, 104 59 46E', '17'),
(157, 'Lạc Sơn', 'Huyện', '20 29 59N, 105 24 57E', '17'),
(158, 'Yên Thủy', 'Huyện', '20 25 42N, 105 37 59E', '17'),
(159, 'Lạc Thủy', 'Huyện', '20 29 12N, 105 44 06E', '17'),
(164, 'Thái Nguyên', 'Thành Phố', '21 33 20N, 105 48 26E', '19'),
(165, 'Sông Công', 'Thị Xã', '21 29 14N, 105 48 47E', '19'),
(167, 'Định Hóa', 'Huyện', '21 53 50N, 105 38 01E', '19'),
(168, 'Phú Lương', 'Huyện', '21 45 57N, 105 43 22E', '19'),
(169, 'Đồng Hỷ', 'Huyện', '21 41 10N, 105 55 43E', '19'),
(170, 'Võ Nhai', 'Huyện', '21 47 14N, 106 02 29E', '19'),
(171, 'Đại Từ', 'Huyện', '21 36 17N, 105 37 28E', '19'),
(172, 'Phổ Yên', 'Huyện', '21 27 08N, 105 45 19E', '19'),
(173, 'Phú Bình', 'Huyện', '21 29 36N, 105 57 42E', '19'),
(178, 'Lạng Sơn', 'Thành Phố', '21 51 19N, 106 44 50E', '20'),
(180, 'Tràng Định', 'Huyện', '22 18 09N, 106 26 32E', '20'),
(181, 'Bình Gia', 'Huyện', '22 03 56N, 106 19 01E', '20'),
(182, 'Văn Lãng', 'Huyện', '22 01 59N, 106 34 17E', '20'),
(183, 'Cao Lộc', 'Huyện', '21 53 05N, 106 50 34E', '20'),
(184, 'Văn Quan', 'Huyện', '21 51 04N, 106 33 04E', '20'),
(185, 'Bắc Sơn', 'Huyện', '21 48 57N, 106 15 28E', '20'),
(186, 'Hữu Lũng', 'Huyện', '21 34 33N, 106 20 33E', '20'),
(187, 'Chi Lăng', 'Huyện', '21 40 05N, 106 37 24E', '20'),
(188, 'Lộc Bình', 'Huyện', '21 40 41N, 106 58 12E', '20'),
(189, 'Đình Lập', 'Huyện', '21 32 07N, 107 07 25E', '20'),
(193, 'Hạ Long', 'Thành Phố', '20 52 24N, 107 05 23E', '22'),
(194, 'Móng Cái', 'Thành Phố', '21 26 31N, 107 55 09E', '22'),
(195, 'Cẩm Phả', 'Thị Xã', '21 03 42N, 107 17 22E', '22'),
(196, 'Uông Bí', 'Thị Xã', '21 04 33N, 106 45 07E', '22'),
(198, 'Bình Liêu', 'Huyện', '21 33 07N, 107 26 24E', '22'),
(199, 'Tiên Yên', 'Huyện', '21 22 24N, 107 22 50E', '22'),
(200, 'Đầm Hà', 'Huyện', '21 21 23N, 107 34 32E', '22'),
(201, 'Hải Hà', 'Huyện', '21 25 50N, 107 41 26E', '22'),
(202, 'Ba Chẽ', 'Huyện', '21 15 40N, 107 09 52E', '22'),
(203, 'Vân Đồn', 'Huyện', '20 56 17N, 107 28 02E', '22'),
(204, 'Hoành Bồ', 'Huyện', '21 06 30N, 107 02 43E', '22'),
(205, 'Đông Triều', 'Huyện', '21 07 10N, 106 34 36E', '22'),
(206, 'Yên Hưng', 'Huyện', '20 55 40N, 106 51 05E', '22'),
(207, 'Cô Tô', 'Huyện', '21 05 01N, 107 49 10E', '22'),
(213, 'Bắc Giang', 'Thành Phố', '21 17 36N, 106 11 18E', '24'),
(215, 'Yên Thế', 'Huyện', '21 31 29N, 106 09 27E', '24'),
(216, 'Tân Yên', 'Huyện', '21 23 23N, 106 05 55E', '24'),
(217, 'Lạng Giang', 'Huyện', '21 21 58N, 106 15 21E', '24'),
(218, 'Lục Nam', 'Huyện', '21 18 16N, 106 29 24E', '24'),
(219, 'Lục Ngạn', 'Huyện', '21 26 15N, 106 39 09E', '24'),
(220, 'Sơn Động', 'Huyện', '21 19 42N, 106 51 09E', '24'),
(221, 'Yên Dũng', 'Huyện', '21 12 22N, 106 14 12E', '24'),
(222, 'Việt Yên', 'Huyện', '21 16 16N, 106 04 59E', '24'),
(223, 'Hiệp Hòa', 'Huyện', '21 15 51N, 105 57 30E', '24'),
(227, 'Việt Trì', 'Thành Phố', '21 19 01N, 105 23 35E', '25'),
(228, 'Phú Thọ', 'Thị Xã', '21 24 54N, 105 13 46E', '25'),
(230, 'Đoan Hùng', 'Huyện', '21 36 56N, 105 08 42E', '25'),
(231, 'Hạ Hoà', 'Huyện', '21 35 13N, 105 00 22E', '25'),
(232, 'Thanh Ba', 'Huyện', '21 27 04N, 105 09 10E', '25'),
(233, 'Phù Ninh', 'Huyện', '21 26 59N, 105 18 13E', '25'),
(234, 'Yên Lập', 'Huyện', '21 22 21N, 105 01 25E', '25'),
(235, 'Cẩm Khê', 'Huyện', '21 23 04N, 105 05 25E', '25'),
(236, 'Tam Nông', 'Huyện', '21 18 24N, 105 14 59E', '25'),
(237, 'Lâm Thao', 'Huyện', '21 19 37N, 105 18 09E', '25'),
(238, 'Thanh Sơn', 'Huyện', '21 08 32N, 105 04 40E', '25'),
(239, 'Thanh Thuỷ', 'Huyện', '21 07 26N, 105 17 18E', '25'),
(240, 'Tân Sơn', 'Huyện', '', '25'),
(243, 'Vĩnh Yên', 'Thành Phố', '21 18 26N, 105 35 33E', '26'),
(244, 'Phúc Yên', 'Thị Xã', '21 18 55N, 105 43 54E', '26'),
(246, 'Lập Thạch', 'Huyện', '21 24 45N, 105 25 39E', '26'),
(247, 'Tam Dương', 'Huyện', '21 21 40N, 105 33 36E', '26'),
(248, 'Tam Đảo', 'Huyện', '21 27 34N, 105 35 09E', '26'),
(249, 'Bình Xuyên', 'Huyện', '21 19 48N, 105 39 43E', '26'),
(250, 'Mê Linh', 'Huyện', '21 10 53N, 105 42 05E', '01'),
(251, 'Yên Lạc', 'Huyện', '21 13 17N, 105 34 44E', '26'),
(252, 'Vĩnh Tường', 'Huyện', '21 14 58N, 105 29 37E', '26'),
(253, 'Sông Lô', 'Huyện', '', '26'),
(256, 'Bắc Ninh', 'Thành Phố', '21 10 48N, 106 03 58E', '27'),
(258, 'Yên Phong', 'Huyện', '21 12 40N, 105 59 36E', '27'),
(259, 'Quế Võ', 'Huyện', '21 08 44N, 106 11 06E', '27'),
(260, 'Tiên Du', 'Huyện', '21 07 37N, 106 02 19E', '27'),
(261, 'Từ Sơn', 'Thị Xã', '21 07 12N, 105 57 26E', '27'),
(262, 'Thuận Thành', 'Huyện', '21 02 24N, 106 04 10E', '27'),
(263, 'Gia Bình', 'Huyện', '21 03 55N, 106 12 53E', '27'),
(264, 'Lương Tài', 'Huyện', '21 01 33N, 106 13 28E', '27'),
(268, 'Hà Đông', 'Quận', '20 57 25N, 105 45 21E', '01'),
(269, 'Sơn Tây', 'Thị Xã', '21 05 51N, 105 28 27E', '01'),
(271, 'Ba Vì', 'Huyện', '21 09 40N, 105 22 43E', '01'),
(272, 'Phúc Thọ', 'Huyện', '21 06 32N, 105 34 52E', '01'),
(273, 'Đan Phượng', 'Huyện', '21 07 13N, 105 40 49E', '01'),
(274, 'Hoài Đức', 'Huyện', '21 01 25N, 105 42 03E', '01'),
(275, 'Quốc Oai', 'Huyện', '20 58 45N, 105 36 43E', '01'),
(276, 'Thạch Thất', 'Huyện', '21 02 17N, 105 33 05E', '01'),
(277, 'Chương Mỹ', 'Huyện', '20 52 46N, 105 39 01E', '01'),
(278, 'Thanh Oai', 'Huyện', '20 51 44N, 105 46 18E', '01'),
(279, 'Thường Tín', 'Huyện', '20 49 59N, 105 22 19E', '01'),
(280, 'Phú Xuyên', 'Huyện', '20 43 37N, 105 53 43E', '01'),
(281, 'Ứng Hòa', 'Huyện', '20 42 41N, 105 47 58E', '01'),
(282, 'Mỹ Đức', 'Huyện', '20 41 53N, 105 43 31E', '01'),
(288, 'Hải Dương', 'Thành Phố', '20 56 14N, 106 18 21E', '30'),
(290, 'Chí Linh', 'Huyện', '21 07 47N, 106 23 46E', '30'),
(291, 'Nam Sách', 'Huyện', '21 00 15N, 106 20 26E', '30'),
(292, 'Kinh Môn', 'Huyện', '21 00 04N, 106 30 23E', '30'),
(293, 'Kim Thành', 'Huyện', '20 55 40N, 106 30 33E', '30'),
(294, 'Thanh Hà', 'Huyện', '20 53 19N, 106 25 43E', '30'),
(295, 'Cẩm Giàng', 'Huyện', '20 57 05N, 106 12 29E', '30'),
(296, 'Bình Giang', 'Huyện', '20 52 36N, 106 11 24E', '30'),
(297, 'Gia Lộc', 'Huyện', '20 51 01N, 106 17 34E', '30'),
(298, 'Tứ Kỳ', 'Huyện', '20 49 05N, 106 24 05E', '30'),
(299, 'Ninh Giang', 'Huyện', '20 45 13N, 106 20 09E', '30'),
(300, 'Thanh Miện', 'Huyện', '20 46 02N, 106 12 26E', '30'),
(303, 'Hồng Bàng', 'Quận', '20 52 37N, 106 38 32E', '31'),
(304, 'Ngô Quyền', 'Quận', '20 51 13N, 106 41 57E', '31'),
(305, 'Lê Chân', 'Quận', '20 50 12N, 106 40 30E', '31'),
(306, 'Hải An', 'Quận', '20 49 38N, 106 45 57E', '31'),
(307, 'Kiến An', 'Quận', '20 48 26N, 106 38 03E', '31'),
(308, 'Đồ Sơn', 'Quận', '20 42 41N, 106 44 54E', '31'),
(309, 'Kinh Dương', 'Quận', '', '31'),
(311, 'Thuỷ Nguyên', 'Huyện', '20 56 36N, 106 39 38E', '31'),
(312, 'An Dương', 'Huyện', '20 53 06N, 106 35 36E', '31'),
(313, 'An Lão', 'Huyện', '20 47 54N, 106 33 19E', '31'),
(314, 'Kiến Thụy', 'Huyện', '20 45 13N, 106 41 47E', '31'),
(315, 'Tiên Lãng', 'Huyện', '20 42 23N, 106 36 03E', '31'),
(316, 'Vĩnh Bảo', 'Huyện', '20 40 56N, 106 29 57E', '31'),
(317, 'Cát Hải', 'Huyện', '20 47 09N, 106 58 07E', '31'),
(318, 'Bạch Long Vĩ', 'Huyện', '20 08 41N, 107 42 51E', '31'),
(323, 'Hưng Yên', 'Thành Phố', '20 39 38N, 106 03 08E', '33'),
(325, 'Văn Lâm', 'Huyện', '20 58 31N, 106 02 51E', '33'),
(326, 'Văn Giang', 'Huyện', '20 55 51N, 105 57 14E', '33'),
(327, 'Yên Mỹ', 'Huyện', '20 53 45N, 106 01 21E', '33'),
(328, 'Mỹ Hào', 'Huyện', '20 55 35N, 106 05 34E', '33'),
(329, 'Ân Thi', 'Huyện', '20 48 49N, 106 05 30E', '33'),
(330, 'Khoái Châu', 'Huyện', '20 49 53N, 105 58 28E', '33'),
(331, 'Kim Động', 'Huyện', '20 44 47N, 106 01 47E', '33'),
(332, 'Tiên Lữ', 'Huyện', '20 40 05N, 106 07 59E', '33'),
(333, 'Phù Cừ', 'Huyện', '20 42 51N, 106 11 30E', '33'),
(336, 'Thái Bình', 'Thành Phố', '20 26 45N, 106 19 56E', '34'),
(338, 'Quỳnh Phụ', 'Huyện', '20 38 57N, 106 21 16E', '34'),
(339, 'Hưng Hà', 'Huyện', '20 35 38N, 106 12 42E', '34'),
(340, 'Đông Hưng', 'Huyện', '20 32 50N, 106 20 15E', '34'),
(341, 'Thái Thụy', 'Huyện', '20 32 33N, 106 32 32E', '34'),
(342, 'Tiền Hải', 'Huyện', '20 21 05N, 106 32 45E', '34'),
(343, 'Kiến Xương', 'Huyện', '20 23 52N, 106 25 22E', '34'),
(344, 'Vũ Thư', 'Huyện', '20 25 29N, 106 16 43E', '34'),
(347, 'Phủ Lý', 'Thành Phố', '20 32 19N, 105 54 55E', '35'),
(349, 'Duy Tiên', 'Huyện', '20 37 33N, 105 58 01E', '35'),
(350, 'Kim Bảng', 'Huyện', '20 34 19N, 105 50 41E', '35'),
(351, 'Thanh Liêm', 'Huyện', '20 27 31N, 105 55 09E', '35'),
(352, 'Bình Lục', 'Huyện', '20 29 23N, 106 02 52E', '35'),
(353, 'Lý Nhân', 'Huyện', '20 32 55N, 106 04 48E', '35'),
(356, 'Nam Định', 'Thành Phố', '20 25 07N, 106 09 54E', '36'),
(358, 'Mỹ Lộc', 'Huyện', '20 27 21N, 106 07 56E', '36'),
(359, 'Vụ Bản', 'Huyện', '20 22 57N, 106 05 35E', '36'),
(360, 'Ý Yên', 'Huyện', '20 19 48N, 106 01 55E', '36'),
(361, 'Nghĩa Hưng', 'Huyện', '20 05 37N, 106 08 59E', '36'),
(362, 'Nam Trực', 'Huyện', '20 20 08N, 106 12 54E', '36'),
(363, 'Trực Ninh', 'Huyện', '20 14 42N, 106 12 45E', '36'),
(364, 'Xuân Trường', 'Huyện', '20 17 53N, 106 21 43E', '36'),
(365, 'Giao Thủy', 'Huyện', '20 14 45N, 106 28 39E', '36'),
(366, 'Hải Hậu', 'Huyện', '20 06 26N, 106 16 29E', '36'),
(369, 'Ninh Bình', 'Thành Phố', '20 14 45N, 105 58 24E', '37'),
(370, 'Tam Điệp', 'Thị Xã', '20 09 42N, 103 52 43E', '37'),
(372, 'Nho Quan', 'Huyện', '20 18 46N, 105 42 48E', '37'),
(373, 'Gia Viễn', 'Huyện', '20 19 50N, 105 52 20E', '37'),
(374, 'Hoa Lư', 'Huyện', '20 15 04N, 105 55 52E', '37'),
(375, 'Yên Khánh', 'Huyện', '20 11 26N, 106 04 33E', '37'),
(376, 'Kim Sơn', 'Huyện', '20 02 07N, 106 05 27E', '37'),
(377, 'Yên Mô', 'Huyện', '20 07 45N, 105 59 45E', '37'),
(380, 'Thanh Hóa', 'Thành Phố', '19 48 26N, 105 47 37E', '38'),
(381, 'Bỉm Sơn', 'Thị Xã', '20 05 21N, 105 51 48E', '38'),
(382, 'Sầm Sơn', 'Thị Xã', '19 45 11N, 105 54 03E', '38'),
(384, 'Mường Lát', 'Huyện', '20 30 42N, 104 37 27E', '38'),
(385, 'Quan Hóa', 'Huyện', '20 29 15N, 104 56 35E', '38'),
(386, 'Bá Thước', 'Huyện', '20 22 48N, 105 14 50E', '38'),
(387, 'Quan Sơn', 'Huyện', '20 15 17N, 104 51 58E', '38'),
(388, 'Lang Chánh', 'Huyện', '20 08 58N, 105 07 40E', '38'),
(389, 'Ngọc Lặc', 'Huyện', '20 04 08N, 105 22 39E', '38'),
(390, 'Cẩm Thủy', 'Huyện', '20 12 20N, 105 27 22E', '38'),
(391, 'Thạch Thành', 'Huyện', '21 12 41N, 105 36 38E', '38'),
(392, 'Hà Trung', 'Huyện', '20 03 20N, 105 51 20E', '38'),
(393, 'Vĩnh Lộc', 'Huyện', '20 02 29N, 105 39 28E', '38'),
(394, 'Yên Định', 'Huyện', '20 00 31N, 105 37 44E', '38'),
(395, 'Thọ Xuân', 'Huyện', '19 55 39N, 105 29 14E', '38'),
(396, 'Thường Xuân', 'Huyện', '19 54 55N, 105 10 46E', '38'),
(397, 'Triệu Sơn', 'Huyện', '19 48 11N, 105 34 03E', '38'),
(398, 'Thiệu Hoá', 'Huyện', '19 53 56N, 105 40 57E', '38'),
(399, 'Hoằng Hóa', 'Huyện', '19 51 59N, 105 51 34E', '38'),
(400, 'Hậu Lộc', 'Huyện', '19 56 02N, 105 53 19E', '38'),
(401, 'Nga Sơn', 'Huyện', '20 00 16N, 105 59 26E', '38'),
(402, 'Như Xuân', 'Huyện', '19 5 55N, 105 20 22E', '38'),
(403, 'Như Thanh', 'Huyện', '19 35 19N, 105 33 09E', '38'),
(404, 'Nông Cống', 'Huyện', '19 36 58N, 105 40 54E', '38'),
(405, 'Đông Sơn', 'Huyện', '19 47 44N, 105 42 19E', '38'),
(406, 'Quảng Xương', 'Huyện', '19 40 53N, 105 48 01E', '38'),
(407, 'Tĩnh Gia', 'Huyện', '19 27 13N, 105 43 38E', '38'),
(412, 'Vinh', 'Thành Phố', '18 41 06N, 105 42 05E', '40'),
(413, 'Cửa Lò', 'Thị Xã', '18 47 26N, 105 43 31E', '40'),
(414, 'Thái Hoà', 'Thị Xã', '', '40'),
(415, 'Quế Phong', 'Huyện', '19 42 25N, 104 54 21E', '40'),
(416, 'Quỳ Châu', 'Huyện', '19 32 16N, 105 03 18E', '40'),
(417, 'Kỳ Sơn', 'Huyện', '19 24 36N, 104 09 45E', '40'),
(418, 'Tương Dương', 'Huyện', '19 19 15N, 104 35 41E', '40'),
(419, 'Nghĩa Đàn', 'Huyện', '19 21 19N, 105 26 33E', '40'),
(420, 'Quỳ Hợp', 'Huyện', '19 19 24N, 105 09 12E', '40'),
(421, 'Quỳnh Lưu', 'Huyện', '19 14 01N, 105 37 00E', '40'),
(422, 'Con Cuông', 'Huyện', '19 03 50N, 107 47 15E', '40'),
(423, 'Tân Kỳ', 'Huyện', '19 06 11N, 105 14 14E', '40'),
(424, 'Anh Sơn', 'Huyện', '18 58 04N, 105 04 30E', '40'),
(425, 'Diễn Châu', 'Huyện', '19 01 20N, 105 34 13E', '40'),
(426, 'Yên Thành', 'Huyện', '19 01 25N, 105 26 17E', '40'),
(427, 'Đô Lương', 'Huyện', '18 55 00N, 105 21 03E', '40'),
(428, 'Thanh Chương', 'Huyện', '18 44 11N, 105 12 59E', '40'),
(429, 'Nghi Lộc', 'Huyện', '18 47 41N, 105 31 30E', '40'),
(430, 'Nam Đàn', 'Huyện', '18 40 28N, 105 30 32E', '40'),
(431, 'Hưng Nguyên', 'Huyện', '18 41 13N, 105 37 41E', '40'),
(436, 'Hà Tĩnh', 'Thành Phố', '18 21 20N, 105 54 00E', '42'),
(437, 'Hồng Lĩnh', 'Thị Xã', '18 32 05N, 105 42 40E', '42'),
(439, 'Hương Sơn', 'Huyện', '18 26 47N, 105 19 36E', '42'),
(440, 'Đức Thọ', 'Huyện', '18 29 23N, 105 36 39E', '42'),
(441, 'Vũ Quang', 'Huyện', '18 19 30N, 105 26 38E', '42'),
(442, 'Nghi Xuân', 'Huyện', '18 38 46N, 105 46 17E', '42'),
(443, 'Can Lộc', 'Huyện', '18 26 39N, 105 46 13E', '42'),
(444, 'Hương Khê', 'Huyện', '18 11 36N, 105 41 24E', '42'),
(445, 'Thạch Hà', 'Huyện', '18 19 29N, 105 52 43E', '42'),
(446, 'Cẩm Xuyên', 'Huyện', '18 11 32N, 106 00 04E', '42'),
(447, 'Kỳ Anh', 'Huyện', '18 05 15N, 106 15 49E', '42'),
(448, 'Lộc Hà', 'Huyện', '', '42'),
(450, 'Đồng Hới', 'Thành Phố', '17 26 53N, 106 35 15E', '44'),
(452, 'Minh Hóa', 'Huyện', '17 44 03N, 105 51 45E', '44'),
(453, 'Tuyên Hóa', 'Huyện', '17 54 04N, 105 58 17E', '44'),
(454, 'Quảng Trạch', 'Huyện', '17 50 04N, 106 22 24E', '44'),
(455, 'Bố Trạch', 'Huyện', '17 29 13N, 106 06 54E', '44'),
(456, 'Quảng Ninh', 'Huyện', '17 15 15N, 106 32 31E', '44'),
(457, 'Lệ Thủy', 'Huyện', '17 07 35N, 106 41 47E', '44'),
(461, 'Đông Hà', 'Thành Phố', '16 48 12N, 107 05 12E', '45'),
(462, 'Quảng Trị', 'Thị Xã', '16 44 37N, 107 11 20E', '45'),
(464, 'Vĩnh Linh', 'Huyện', '17 01 35N, 106 53 49E', '45'),
(465, 'Hướng Hóa', 'Huyện', '16 42 19N, 106 40 14E', '45'),
(466, 'Gio Linh', 'Huyện', '16 54 49N, 106 56 16E', '45'),
(467, 'Đa Krông', 'Huyện', '16 33 58N, 106 55 49E', '45'),
(468, 'Cam Lộ', 'Huyện', '16 47 09N, 106 57 52E', '45'),
(469, 'Triệu Phong', 'Huyện', '16 46 32N, 107 09 12E', '45'),
(470, 'Hải Lăng', 'Huyện', '16 41 07N, 107 13 34E', '45'),
(471, 'Cồn Cỏ', 'Huyện', '19 09 39N, 107 19 58E', '45'),
(474, 'Huế', 'Thành Phố', '16 27 16N, 107 34 29E', '46'),
(476, 'Phong Điền', 'Huyện', '16 32 42N, 106 16 37E', '46'),
(477, 'Quảng Điền', 'Huyện', '16 35 21N, 107 29 31E', '46'),
(478, 'Phú Vang', 'Huyện', '16 27 20N, 107 42 28E', '46'),
(479, 'Hương Thủy', 'Huyện', '16 19 27N, 107 37 26E', '46'),
(480, 'Hương Trà', 'Huyện', '16 25 49N, 107 28 37E', '46'),
(481, 'A Lưới', 'Huyện', '16 13 59N, 107 16 12E', '46'),
(482, 'Phú Lộc', 'Huyện', '16 17 16N, 107 55 25E', '46'),
(483, 'Nam Đông', 'Huyện', '16 07 11N, 107 41 25E', '46'),
(490, 'Liên Chiểu', 'Quận', '16 07 26N, 108 07 04E', '48'),
(491, 'Thanh Khê', 'Quận', '16 03 28N, 108 11 00E', '48'),
(492, 'Hải Châu', 'Quận', '16 03 38N, 108 11 46E', '48'),
(493, 'Sơn Trà', 'Quận', '16 06 13N, 108 16 26E', '48'),
(494, 'Ngũ Hành Sơn', 'Quận', '16 00 30N, 108 15 09E', '48'),
(495, 'Cẩm Lệ', 'Quận', '', '48'),
(497, 'Hoà Vang', 'Huyện', '16 03 59N, 108 01 57E', '48'),
(498, 'Hoàng Sa', 'Huyện', '16 21 36N, 111 57 01E', '48'),
(502, 'Tam Kỳ', 'Thành Phố', '15 34 37N, 108 29 52E', '49'),
(503, 'Hội An', 'Thành Phố', '15 53 20N, 108 20 42E', '49'),
(504, 'Tây Giang', 'Huyện', '15 53 46N, 107 25 52E', '49'),
(505, 'Đông Giang', 'Huyện', '15 54 44N, 107 47 06E', '49'),
(506, 'Đại Lộc', 'Huyện', '15 50 10N, 107 58 27E', '49'),
(507, 'Điện Bàn', 'Huyện', '15 54 15N, 108 13 38E', '49'),
(508, 'Duy Xuyên', 'Huyện', '15 47 58N, 108 13 27E', '49'),
(509, 'Quế Sơn', 'Huyện', '15 41 03N, 108 05 34E', '49'),
(510, 'Nam Giang', 'Huyện', '15 36 37N, 107 33 52E', '49'),
(511, 'Phước Sơn', 'Huyện', '15 23 17N, 107 50 22E', '49'),
(512, 'Hiệp Đức', 'Huyện', '15 31 09N, 108 05 56E', '49'),
(513, 'Thăng Bình', 'Huyện', '15 42 29N, 108 22 04E', '49'),
(514, 'Tiên Phước', 'Huyện', '15 29 30N, 108 15 28E', '49'),
(515, 'Bắc Trà My', 'Huyện', '15 08 00N, 108 05 32E', '49'),
(516, 'Nam Trà My', 'Huyện', '15 16 40N, 108 12 15E', '49'),
(517, 'Núi Thành', 'Huyện', '15 26 53N, 108 34 49E', '49'),
(518, 'Phú Ninh', 'Huyện', '15 30 43N, 108 24 43E', '49'),
(519, 'Nông Sơn', 'Huyện', '', '49'),
(522, 'Quảng Ngãi', 'Thành Phố', '15 07 17N, 108 48 24E', '51'),
(524, 'Bình Sơn', 'Huyện', '15 18 45N, 108 45 35E', '51'),
(525, 'Trà Bồng', 'Huyện', '15 13 30N, 108 29 57E', '51'),
(526, 'Tây Trà', 'Huyện', '15 11 13N, 108 22 23E', '51'),
(527, 'Sơn Tịnh', 'Huyện', '15 11 49N, 108 45 03E', '51'),
(528, 'Tư Nghĩa', 'Huyện', '15 05 25N, 108 45 23E', '51'),
(529, 'Sơn Hà', 'Huyện', '14 58 35N, 108 29 09E', '51'),
(530, 'Sơn Tây', 'Huyện', '14 58 11N, 108 21 22E', '51'),
(531, 'Minh Long', 'Huyện', '14 56 49N, 108 40 19E', '51'),
(532, 'Nghĩa Hành', 'Huyện', '14 58 06N, 108 46 05E', '51'),
(533, 'Mộ Đức', 'Huyện', '11 59 13N, 108 52 21E', '51'),
(534, 'Đức Phổ', 'Huyện', '14 44 59N, 108 56 58E', '51'),
(535, 'Ba Tơ', 'Huyện', '14 42 52N, 108 43 44E', '51'),
(536, 'Lý Sơn', 'Huyện', '15 22 50N, 109 06 56E', '51'),
(540, 'Qui Nhơn', 'Thành Phố', '13 47 15N, 109 12 48E', '52'),
(542, 'An Lão', 'Huyện', '14 32 10N, 108 47 52E', '52'),
(543, 'Hoài Nhơn', 'Huyện', '14 30 56N, 109 01 56E', '52'),
(544, 'Hoài Ân', 'Huyện', '14 20 51N, 108 54 04E', '52'),
(545, 'Phù Mỹ', 'Huyện', '14 14 41N, 109 05 43E', '52'),
(546, 'Vĩnh Thạnh', 'Huyện', '14 14 26N, 108 44 08E', '52'),
(547, 'Tây Sơn', 'Huyện', '13 56 47N, 108 53 06E', '52'),
(548, 'Phù Cát', 'Huyện', '14 03 48N, 109 03 57E', '52'),
(549, 'An Nhơn', 'Huyện', '13 51 28N, 109 04 02E', '52'),
(550, 'Tuy Phước', 'Huyện', '13 46 30N, 109 05 38E', '52'),
(551, 'Vân Canh', 'Huyện', '13 40 35N, 108 57 52E', '52'),
(555, 'Tuy Hòa', 'Thành Phố', '13 05 42N, 109 15 50E', '54'),
(557, 'Sông Cầu', 'Thị Xã', '13 31 40N, 109 12 39E', '54'),
(558, 'Đồng Xuân', 'Huyện', '13 24 59N, 108 56 46E', '54'),
(559, 'Tuy An', 'Huyện', '13 15 19N, 109 12 21E', '54'),
(560, 'Sơn Hòa', 'Huyện', '13 12 16N, 108 57 17E', '54'),
(561, 'Sông Hinh', 'Huyện', '12 54 19N, 108 53 38E', '54'),
(562, 'Tây Hoà', 'Huyện', '', '54'),
(563, 'Phú Hoà', 'Huyện', '13 04 07N, 109 11 24E', '54'),
(564, 'Đông Hoà', 'Huyện', '', '54'),
(568, 'Nha Trang', 'Thành Phố', '12 15 40N, 109 10 40E', '56'),
(569, 'Cam Ranh', 'Thị Xã', '11 59 05N, 108 08 17E', '56'),
(570, 'Cam Lâm', 'Huyện', '', '56'),
(571, 'Vạn Ninh', 'Huyện', '12 43 10N, 109 11 18E', '56'),
(572, 'Ninh Hòa', 'Huyện', '12 32 54N, 109 06 11E', '56'),
(573, 'Khánh Vĩnh', 'Huyện', '12 17 50N, 108 51 56E', '56'),
(574, 'Diên Khánh', 'Huyện', '12 13 19N, 109 02 16E', '56'),
(575, 'Khánh Sơn', 'Huyện', '12 02 17N, 108 53 47E', '56'),
(576, 'Trường Sa', 'Huyện', '9 07 27N, 114 15 00E', '56'),
(582, 'Phan Rang-Tháp Chàm', 'Thành Phố', '11 36 11N, 108 58 34E', '58'),
(584, 'Bác Ái', 'Huyện', '11 54 45N, 108 51 29E', '58'),
(585, 'Ninh Sơn', 'Huyện', '11 42 36N, 108 44 55E', '58'),
(586, 'Ninh Hải', 'Huyện', '11 42 46N, 109 05 41E', '58'),
(587, 'Ninh Phước', 'Huyện', '11 28 56N, 108 50 34E', '58'),
(588, 'Thuận Bắc', 'Huyện', '', '58'),
(589, 'Thuận Nam', 'Huyện', '', '58'),
(593, 'Phan Thiết', 'Thành Phố', '10 54 16N, 108 03 44E', '60'),
(594, 'La Gi', 'Thị Xã', '', '60'),
(595, 'Tuy Phong', 'Huyện', '11 20 26N, 108 41 15E', '60'),
(596, 'Bắc Bình', 'Huyện', '11 15 52N, 108 21 33E', '60'),
(597, 'Hàm Thuận Bắc', 'Huyện', '11 09 18N, 108 03 07E', '60'),
(598, 'Hàm Thuận Nam', 'Huyện', '10 56 20N, 107 54 38E', '60'),
(599, 'Tánh Linh', 'Huyện', '11 08 26N, 107 41 22E', '60'),
(600, 'Đức Linh', 'Huyện', '11 11 43N, 107 31 34E', '60'),
(601, 'Hàm Tân', 'Huyện', '10 44 41N, 107 41 33E', '60'),
(602, 'Phú Quí', 'Huyện', '10 33 13N, 108 57 46E', '60'),
(608, 'Kon Tum', 'Thành Phố', '14 20 32N, 107 58 04E', '62'),
(610, 'Đắk Glei', 'Huyện', '15 08 13N, 107 44 03E', '62'),
(611, 'Ngọc Hồi', 'Huyện', '14 44 23N, 107 38 49E', '62'),
(612, 'Đắk Tô', 'Huyện', '14 46 49N, 107 55 36E', '62'),
(613, 'Kon Plông', 'Huyện', '14 48 13N, 108 20 05E', '62'),
(614, 'Kon Rẫy', 'Huyện', '14 32 56N, 108 13 09E', '62'),
(615, 'Đắk Hà', 'Huyện', '14 36 50N, 107 59 55E', '62'),
(616, 'Sa Thầy', 'Huyện', '14 16 02N, 107 36 30E', '62'),
(617, 'Tu Mơ Rông', 'Huyện', '', '62'),
(622, 'Pleiku', 'Thành Phố', '13 57 42N, 107 58 03E', '64'),
(623, 'An Khê', 'Thị Xã', '14 01 24N, 108 41 29E', '64'),
(624, 'Ayun Pa', 'Thị Xã', '', '64'),
(625, 'Kbang', 'Huyện', '14 18 08N, 108 29 17E', '64'),
(626, 'Đăk Đoa', 'Huyện', '14 07 02N, 108 09 36E', '64'),
(627, 'Chư Păh', 'Huyện', '14 13 30N, 107 56 33E', '64'),
(628, 'Ia Grai', 'Huyện', '13 59 25N, 107 43 16E', '64'),
(629, 'Mang Yang', 'Huyện', '13 57 26N, 108 18 37E', '64'),
(630, 'Kông Chro', 'Huyện', '13 45 47N, 108 36 04E', '64'),
(631, 'Đức Cơ', 'Huyện', '13 46 16N, 107 38 26E', '64'),
(632, 'Chư Prông', 'Huyện', '13 35 39N, 107 47 36E', '64'),
(633, 'Chư Sê', 'Huyện', '13 37 04N, 108 06 56E', '64'),
(634, 'Đăk Pơ', 'Huyện', '13 55 47N, 108 36 16E', '64'),
(635, 'Ia Pa', 'Huyện', '13 31 37N, 108 30 34E', '64'),
(637, 'Krông Pa', 'Huyện', '13 14 13N, 108 39 12E', '64'),
(638, 'Phú Thiện', 'Huyện', '', '64'),
(639, 'Chư Pưh', 'Huyện', '', '64'),
(643, 'Buôn Ma Thuột', 'Thành Phố', '12 39 43N, 108 10 40E', '66'),
(644, 'Buôn Hồ', 'Thị Xã', '', '66'),
(645, 'Ea H''leo', 'Huyện', '13 13 52N, 108 12 30E', '66'),
(646, 'Ea Súp', 'Huyện', '13 10 59N, 107 46 49E', '66'),
(647, 'Buôn Đôn', 'Huyện', '12 52 45N, 107 45 20E', '66'),
(648, 'Cư M''gar', 'Huyện', '12 53 47N, 108 04 16E', '66'),
(649, 'Krông Búk', 'Huyện', '12 56 27N, 108 13 54E', '66'),
(650, 'Krông Năng', 'Huyện', '12 59 41N, 108 23 42E', '66'),
(651, 'Ea Kar', 'Huyện', '12 48 17N, 108 32 42E', '66'),
(652, 'M''đrắk', 'Huyện', '12 42 14N, 108 47 09E', '66'),
(653, 'Krông Bông', 'Huyện', '12 27 08N, 108 27 01E', '66'),
(654, 'Krông Pắc', 'Huyện', '12 41 20N, 108 18 42E', '66'),
(655, 'Krông A Na', 'Huyện', '12 31 51N, 108 05 03E', '66'),
(656, 'Lắk', 'Huyện', '12 19 20N, 108 12 17E', '66'),
(657, 'Cư Kuin', 'Huyện', '', '66'),
(660, 'Gia Nghĩa', 'Thị Xã', '', '67'),
(661, 'Đắk Glong', 'Huyện', '12 01 53N, 107 50 37E', '67'),
(662, 'Cư Jút', 'Huyện', '12 40 56N, 107 44 44E', '67'),
(663, 'Đắk Mil', 'Huyện', '12 31 08N, 107 42 24E', '67'),
(664, 'Krông Nô', 'Huyện', '12 22 16N, 107 53 49E', '67'),
(665, 'Đắk Song', 'Huyện', '12 14 04N, 107 36 30E', '67'),
(666, 'Đắk R''lấp', 'Huyện', '12 02 30N, 107 25 59E', '67'),
(667, 'Tuy Đức', 'Huyện', '', '67'),
(672, 'Đà Lạt', 'Thành Phố', '11 54 33N, 108 27 08E', '68'),
(673, 'Bảo Lộc', 'Thị Xã', '11 32 48N, 107 47 37E', '68'),
(674, 'Đam Rông', 'Huyện', '12 02 35N, 108 10 26E', '68'),
(675, 'Lạc Dương', 'Huyện', '12 08 30N, 108 27 48E', '68'),
(676, 'Lâm Hà', 'Huyện', '11 55 26N, 108 11 31E', '68'),
(677, 'Đơn Dương', 'Huyện', '11 48 26N, 108 32 48E', '68'),
(678, 'Đức Trọng', 'Huyện', '11 41 50N, 108 18 58E', '68'),
(679, 'Di Linh', 'Huyện', '11 31 10N, 108 05 23E', '68'),
(680, 'Bảo Lâm', 'Huyện', '11 38 31N, 107 43 25E', '68'),
(681, 'Đạ Huoai', 'Huyện', '11 27 11N, 107 38 08E', '68'),
(682, 'Đạ Tẻh', 'Huyện', '11 33 46N, 107 32 00E', '68'),
(683, 'Cát Tiên', 'Huyện', '11 39 38N, 107 23 27E', '68'),
(688, 'Phước Long', 'Thị Xã', '', '70'),
(689, 'Đồng Xoài', 'Thị Xã', '11 31 01N, 106 50 21E', '70'),
(690, 'Bình Long', 'Thị Xã', '', '70'),
(691, 'Bù Gia Mập', 'Huyện', '11 56 57N, 106 59 21E', '70'),
(692, 'Lộc Ninh', 'Huyện', '11 49 28N, 106 35 11E', '70'),
(693, 'Bù Đốp', 'Huyện', '11 59 08N, 106 49 54E', '70'),
(694, 'Hớn Quản', 'Huyện', '11 37 37N, 106 36 02E', '70'),
(695, 'Đồng Phù', 'Huyện', '11 28 45N, 106 57 07E', '70'),
(696, 'Bù Đăng', 'Huyện', '11 46 09N, 107 14 14E', '70'),
(697, 'Chơn Thành', 'Huyện', '11 28 45N, 106 39 26E', '70'),
(703, 'Tây Ninh', 'Thị Xã', '11 21 59N, 106 07 47E', '72'),
(705, 'Tân Biên', 'Huyện', '11 35 14N, 105 57 53E', '72'),
(706, 'Tân Châu', 'Huyện', '11 34 49N, 106 17 48E', '72'),
(707, 'Dương Minh Châu', 'Huyện', '11 22 04N, 106 16 58E', '72'),
(708, 'Châu Thành', 'Huyện', '11 19 02N, 106 00 15E', '72'),
(709, 'Hòa Thành', 'Huyện', '11 15 31N, 106 08 44E', '72'),
(710, 'Gò Dầu', 'Huyện', '11 09 39N, 106 14 42E', '72'),
(711, 'Bến Cầu', 'Huyện', '11 07 50N, 106 08 25E', '72'),
(712, 'Trảng Bàng', 'Huyện', '11 06 18N, 106 23 12E', '72'),
(718, 'Thủ Dầu Một', 'Thị Xã', '11 00 01N, 106 38 56E', '74'),
(720, 'Dầu Tiếng', 'Huyện', '11 19 07N, 106 26 59E', '74'),
(721, 'Bến Cát', 'Huyện', '11 12 42N, 106 36 28E', '74'),
(722, 'Phú Giáo', 'Huyện', '11 20 21N, 106 47 48E', '74'),
(723, 'Tân Uyên', 'Huyện', '11 06 31N, 106 49 02E', '74'),
(724, 'Dĩ An', 'Huyện', '10 55 03N, 106 47 09E', '74'),
(725, 'Thuận An', 'Huyện', '10 55 58N, 106 41 59E', '74'),
(731, 'Biên Hòa', 'Thành Phố', '10 56 31N, 106 50 50E', '75'),
(732, 'Long Khánh', 'Thị Xã', '10 56 24N, 107 14 29E', '75'),
(734, 'Tân Phú', 'Huyện', '11 22 51N, 107 21 35E', '75'),
(735, 'Vĩnh Cửu', 'Huyện', '11 14 31N, 107 00 06E', '75'),
(736, 'Định Quán', 'Huyện', '11 12 41N, 107 17 03E', '75'),
(737, 'Trảng Bom', 'Huyện', '10 58 39N, 107 00 52E', '75'),
(738, 'Thống Nhất', 'Huyện', '10 58 29N, 107 09 26E', '75'),
(739, 'Cẩm Mỹ', 'Huyện', '10 47 05N, 107 14 36E', '75'),
(740, 'Long Thành', 'Huyện', '10 47 38N, 106 59 42E', '75'),
(741, 'Xuân Lộc', 'Huyện', '10 55 39N, 107 24 21E', '75'),
(742, 'Nhơn Trạch', 'Huyện', '10 39 18N, 106 53 18E', '75'),
(747, 'Vũng Tầu', 'Thành Phố', '10 24 08N, 107 07 05E', '77'),
(748, 'Bà Rịa', 'Thị Xã', '10 30 33N, 107 10 47E', '77'),
(750, 'Châu Đức', 'Huyện', '10 39 23N, 107 15 08E', '77'),
(751, 'Xuyên Mộc', 'Huyện', '10 37 46N, 107 29 39E', '77'),
(752, 'Long Điền', 'Huyện', '10 26 47N, 107 12 53E', '77'),
(753, 'Đất Đỏ', 'Huyện', '10 28 40N, 107 18 27E', '77'),
(754, 'Tân Thành', 'Huyện', '10 34 50N, 107 05 06E', '77'),
(755, 'Côn Đảo', 'Huyện', '8 42 25N, 106 36 05E', '77'),
(760, 'Quận 1', 'Quận', '10 46 34N, 106 41 45E', '79'),
(761, 'Quận 12', 'Quận', '10 51 43N, 106 39 32E', '79'),
(762, 'Thủ Đức', 'Quận', '10 51 20N, 106 45 05E', '79'),
(763, 'Quận 9', 'Quận', '10 49 49N, 106 49 03E', '79'),
(764, 'Gò Vấp', 'Quận', '10 50 12N, 106 39 52E', '79'),
(765, 'Bình Thạnh', 'Quận', '10 48 46N, 106 42 57E', '79'),
(766, 'Tân Bình', 'Quận', '10 48 13N, 106 39 03E', '79'),
(767, 'Tân Phú', 'Quận', '10 47 32N, 106 37 31E', '79'),
(768, 'Phú Nhuận', 'Quận', '10 48 06N, 106 40 39E', '79'),
(769, 'Quận 2', 'Quận', '10 46 51N, 106 45 25E', '79'),
(770, 'Quận 3', 'Quận', '10 46 48N, 106 40 46E', '79'),
(771, 'Quận 10', 'Quận', '10 46 25N, 106 40 02E', '79'),
(772, 'Quận 11', 'Quận', '10 46 01N, 106 38 44E', '79'),
(773, 'Quận 4', 'Quận', '10 45 42N, 106 42 09E', '79'),
(774, 'Quận 5', 'Quận', '10 45 24N, 106 40 00E', '79'),
(775, 'Quận 6', 'Quận', '10 44 46N, 106 38 10E', '79'),
(776, 'Quận 8', 'Quận', '10 43 24N, 106 37 40E', '79'),
(777, 'Bình Tân', 'Quận', '10 46 16N, 106 35 26E', '79'),
(778, 'Quận 7', 'Quận', '10 44 19N, 106 43 35E', '79'),
(783, 'Củ Chi', 'Huyện', '11 02 17N, 106 30 20E', '79'),
(784, 'Hóc Môn', 'Huyện', '10 52 42N, 106 35 33E', '79'),
(785, 'Bình Chánh', 'Huyện', '10 45 01N, 106 30 45E', '79'),
(786, 'Nhà Bè', 'Huyện', '10 39 06N, 106 43 35E', '79'),
(787, 'Cần Giờ', 'Huyện', '10 30 43N, 106 52 50E', '79'),
(794, 'Tân An', 'Thành Phố', '10 31 36N, 106 24 06E', '80'),
(796, 'Tân Hưng', 'Huyện', '10 49 05N, 105 39 26E', '80'),
(797, 'Vĩnh Hưng', 'Huyện', '10 52 54N, 105 45 58E', '80'),
(798, 'Mộc Hóa', 'Huyện', '10 47 09N, 105 57 56E', '80'),
(799, 'Tân Thạnh', 'Huyện', '10 37 44N, 105 57 07E', '80'),
(800, 'Thạnh Hóa', 'Huyện', '10 41 37N, 106 11 08E', '80'),
(801, 'Đức Huệ', 'Huyện', '10 51 57N, 106 15 48E', '80'),
(802, 'Đức Hòa', 'Huyện', '10 53 04N, 106 23 58E', '80'),
(803, 'Bến Lức', 'Huyện', '10 41 40N, 106 26 28E', '80'),
(804, 'Thủ Thừa', 'Huyện', '10 39 41N, 106 20 12E', '80'),
(805, 'Tân Trụ', 'Huyện', '10 31 47N, 106 30 06E', '80'),
(806, 'Cần Đước', 'Huyện', '10 32 21N, 106 36 33E', '80'),
(807, 'Cần Giuộc', 'Huyện', '10 34 43N, 106 38 35E', '80'),
(808, 'Châu Thành', 'Huyện', '10 27 52N, 106 30 00E', '80'),
(815, 'Mỹ Tho', 'Thành Phố', '10 22 14N, 106 21 52E', '82'),
(816, 'Gò Công', 'Thị Xã', '10 21 55N, 106 40 24E', '82'),
(818, 'Tân Phước', 'Huyện', '10 30 36N, 106 13 02E', '82'),
(819, 'Cái Bè', 'Huyện', '10 24 21N, 105 56 01E', '82'),
(820, 'Cai Lậy', 'Huyện', '10 24 20N, 106 06 05E', '82'),
(821, 'Châu Thành', 'Huyện', '20 25 21N, 106 16 57E', '82'),
(822, 'Chợ Gạo', 'Huyện', '10 23 45N, 106 26 53E', '82'),
(823, 'Gò Công Tây', 'Huyện', '10 19 55N, 106 35 02E', '82'),
(824, 'Gò Công Đông', 'Huyện', '10 20 42N, 106 42 54E', '82'),
(825, 'Tân Phú Đông', 'Huyện', '', '82'),
(829, 'Bến Tre', 'Thành Phố', '10 14 17N, 106 22 26E', '83'),
(831, 'Châu Thành', 'Huyện', '10 17 24N, 106 17 45E', '83'),
(832, 'Chợ Lách', 'Huyện', '10 13 26N, 106 09 08E', '83'),
(833, 'Mỏ Cày Nam', 'Huyện', '10 06 56N, 106 19 40E', '83'),
(834, 'Giồng Trôm', 'Huyện', '10 08 46N, 106 28 12E', '83'),
(835, 'Bình Đại', 'Huyện', '10 09 56N, 106 37 46E', '83'),
(836, 'Ba Tri', 'Huyện', '10 04 08N, 106 35 10E', '83'),
(837, 'Thạnh Phú', 'Huyện', '9 55 53N, 106 32 45E', '83'),
(838, 'Mỏ Cày Bắc', 'Huyện', '', '83'),
(842, 'Trà Vinh', 'Thị Xã', '9 57 09N, 106 20 39E', '84'),
(844, 'Càng Long', 'Huyện', '9 58 18N, 106 12 52E', '84'),
(845, 'Cầu Kè', 'Huyện', '9 51 23N, 106 03 33E', '84'),
(846, 'Tiểu Cần', 'Huyện', '9 48 37N, 106 12 06E', '84'),
(847, 'Châu Thành', 'Huyện', '9 52 57N, 106 24 12E', '84'),
(848, 'Cầu Ngang', 'Huyện', '9 47 14N, 106 29 19E', '84'),
(849, 'Trà Cú', 'Huyện', '9 42 06N, 106 16 24E', '84'),
(850, 'Duyên Hải', 'Huyện', '9 39 58N, 106 26 23E', '84'),
(855, 'Vĩnh Long', 'Thành Phố', '10 15 09N, 105 56 08E', '86'),
(857, 'Long Hồ', 'Huyện', '10 13 58N, 105 55 47E', '86'),
(858, 'Mang Thít', 'Huyện', '10 10 58N, 106 05 13E', '86'),
(859, 'Vũng Liêm', 'Huyện', '10 03 32N, 106 10 35E', '86'),
(860, 'Tam Bình', 'Huyện', '10 03 58N, 105 58 03E', '86'),
(861, 'Bình Minh', 'Huyện', '10 05 45N, 105 47 21E', '86'),
(862, 'Trà Ôn', 'Huyện', '9 59 20N, 105 57 56E', '86'),
(863, 'Bình Tân', 'Huyện', '', '86'),
(866, 'Cao Lãnh', 'Thành Phố', '10 27 38N, 105 37 21E', '87'),
(867, 'Sa Đéc', 'Thị Xã', '10 19 22N, 105 44 31E', '87'),
(868, 'Hồng Ngự', 'Thị Xã', '', '87'),
(869, 'Tân Hồng', 'Huyện', '10 52 48N, 105 29 21E', '87'),
(870, 'Hồng Ngự', 'Huyện', '10 48 13N, 105 19 00E', '87'),
(871, 'Tam Nông', 'Huyện', '10 44 06N, 105 30 58E', '87'),
(872, 'Tháp Mười', 'Huyện', '10 33 36N, 105 47 13E', '87'),
(873, 'Cao Lãnh', 'Huyện', '10 29 03N, 105 41 40E', '87'),
(874, 'Thanh Bình', 'Huyện', '10 36 38N, 105 28 51E', '87'),
(875, 'Lấp Vò', 'Huyện', '10 21 27N, 105 36 06E', '87'),
(876, 'Lai Vung', 'Huyện', '10 14 43N, 105 38 40E', '87'),
(877, 'Châu Thành', 'Huyện', '10 13 27N, 105 48 38E', '87'),
(883, 'Long Xuyên', 'Thành Phố', '10 22 22N, 105 25 33E', '89'),
(884, 'Châu Đốc', 'Thị Xã', '10 41 20N, 105 05 15E', '89'),
(886, 'An Phú', 'Huyện', '10 50 12N, 105 05 33E', '89'),
(887, 'Tân Châu', 'Thị Xã', '10 49 11N, 105 11 18E', '89'),
(888, 'Phú Tân', 'Huyện', '10 40 26N, 105 14 40E', '89'),
(889, 'Châu Phú', 'Huyện', '10 34 12N, 105 12 13E', '89'),
(890, 'Tịnh Biên', 'Huyện', '10 33 30N, 105 00 17E', '89'),
(891, 'Tri Tôn', 'Huyện', '10 24 41N, 104 56 58E', '89'),
(892, 'Châu Thành', 'Huyện', '10 25 39N, 105 15 31E', '89'),
(893, 'Chợ Mới', 'Huyện', '10 27 23N, 105 26 57E', '89'),
(894, 'Thoại Sơn', 'Huyện', '10 16 45N, 105 15 59E', '89'),
(899, 'Rạch Giá', 'Thành Phố', '10 01 35N, 105 06 20E', '91'),
(900, 'Hà Tiên', 'Thị Xã', '10 22 54N, 104 30 10E', '91'),
(902, 'Kiên Lương', 'Huyện', '10 20 21N, 104 39 46E', '91'),
(903, 'Hòn Đất', 'Huyện', '10 14 20N, 104 55 57E', '91'),
(904, 'Tân Hiệp', 'Huyện', '10 05 18N, 105 14 04E', '91'),
(905, 'Châu Thành', 'Huyện', '9 57 37N, 105 10 16E', '91'),
(906, 'Giồng Giềng', 'Huyện', '9 56 05N, 105 22 06E', '91'),
(907, 'Gò Quao', 'Huyện', '9 43 17N, 105 17 06E', '91'),
(908, 'An Biên', 'Huyện', '9 48 37N, 105 03 18E', '91'),
(909, 'An Minh', 'Huyện', '9 40 24N, 104 59 05E', '91'),
(910, 'Vĩnh Thuận', 'Huyện', '9 33 25N, 105 11 30E', '91'),
(911, 'Phú Quốc', 'Huyện', '10 13 44N, 103 57 25E', '91'),
(912, 'Kiên Hải', 'Huyện', '9 48 31N, 104 37 48E', '91'),
(913, 'U Minh Thượng', 'Huyện', '', '91'),
(914, 'Giang Thành', 'Huyện', '', '91'),
(916, 'Ninh Kiều', 'Quận', '10 01 58N, 105 45 34E', '92'),
(917, 'Ô Môn', 'Quận', '10 07 28N, 105 37 51E', '92'),
(918, 'Bình Thuỷ', 'Quận', '10 03 42N, 105 43 17E', '92'),
(919, 'Cái Răng', 'Quận', '9 59 57N, 105 46 56E', '92'),
(923, 'Thốt Nốt', 'Quận', '10 14 23N, 105 32 02E', '92'),
(924, 'Vĩnh Thạnh', 'Huyện', '10 11 35N, 105 22 45E', '92'),
(925, 'Cờ Đỏ', 'Huyện', '10 02 48N, 105 29 46E', '92'),
(926, 'Phong Điền', 'Huyện', '9 59 57N, 105 39 35E', '92'),
(927, 'Thới Lai', 'Huyện', '', '92'),
(930, 'Vị Thanh', 'Thị Xã', '9 45 15N, 105 24 50E', '93'),
(931, 'Ngã Bảy', 'Thị Xã', '', '93'),
(932, 'Châu Thành A', 'Huyện', '9 55 50N, 105 38 31E', '93'),
(933, 'Châu Thành', 'Huyện', '9 55 22N, 105 48 37E', '93'),
(934, 'Phụng Hiệp', 'Huyện', '9 47 20N, 105 43 29E', '93'),
(935, 'Vị Thuỷ', 'Huyện', '9 48 05N, 105 32 13E', '93'),
(936, 'Long Mỹ', 'Huyện', '9 40 47N, 105 30 53E', '93'),
(941, 'Sóc Trăng', 'Thành Phố', '9 36 39N, 105 59 00E', '94'),
(942, 'Châu Thành', 'Huyện', '', '94'),
(943, 'Kế Sách', 'Huyện', '9 49 30N, 105 57 25E', '94'),
(944, 'Mỹ Tú', 'Huyện', '9 38 21N, 105 49 52E', '94'),
(945, 'Cù Lao Dung', 'Huyện', '9 37 36N, 106 12 13E', '94'),
(946, 'Long Phú', 'Huyện', '9 34 38N, 106 06 07E', '94'),
(947, 'Mỹ Xuyên', 'Huyện', '9 28 16N, 105 55 51E', '94'),
(948, 'Ngã Năm', 'Huyện', '9 31 38N, 105 37 22E', '94'),
(949, 'Thạnh Trị', 'Huyện', '9 28 05N, 105 43 02E', '94'),
(950, 'Vĩnh Châu', 'Huyện', '9 20 50N, 105 59 58E', '94'),
(951, 'Trần Đề', 'Huyện', '', '94'),
(954, 'Bạc Liêu', 'Thị Xã', '9 16 05N, 105 45 08E', '95'),
(956, 'Hồng Dân', 'Huyện', '9 30 37N, 105 24 25E', '95'),
(957, 'Phước Long', 'Huyện', '9 23 13N, 105 24 41E', '95'),
(958, 'Vĩnh Lợi', 'Huyện', '9 16 51N, 105 40 54E', '95'),
(959, 'Giá Rai', 'Huyện', '9 15 51N, 105 23 18E', '95'),
(960, 'Đông Hải', 'Huyện', '9 08 11N, 105 24 42E', '95'),
(961, 'Hoà Bình', 'Huyện', '', '95'),
(964, 'Cà Mau', 'Thành Phố', '9 10 33N, 105 11 11E', '96'),
(966, 'U Minh', 'Huyện', '9 22 30N, 104 57 00E', '96'),
(967, 'Thới Bình', 'Huyện', '9 22 50N, 105 07 35E', '96'),
(968, 'Trần Văn Thời', 'Huyện', '9 07 36N, 104 57 27E', '96'),
(969, 'Cái Nước', 'Huyện', '9 00 31N, 105 03 23E', '96'),
(970, 'Đầm Dơi', 'Huyện', '8 57 48N, 105 13 56E', '96'),
(971, 'Năm Căn', 'Huyện', '8 46 59N, 104 58 20E', '96'),
(972, 'Phú Tân', 'Huyện', '8 52 47N, 104 53 35E', '96'),
(973, 'Ngọc Hiển', 'Huyện', '8 40 47N, 104 57 58E', '96');

INSERT INTO Tax_TaxClass (Id, Name) VALUES (1, 'Standard VAT');

INSERT INTO Tax_TaxRate (Id, CountryId, Name, Rate, StateOrProvinceId, TaxClassId) VALUES (1, 238, 'Standard VN VAT', CAST(10.00 AS Decimal(18, 2)), NULL, 1);

INSERT INTO Core_Address (Id, AddressLine1, ContactName, CountryId, DistrictId, Phone, StateOrProvinceId, City, ZipCode) VALUES (1, NULL, 'SimplCommerce', 238, NULL, NULL, 93, NULL, NULL);

INSERT INTO Inventory_Warehouse (Id, AddressId, Name) VALUES (1, 1, 'Default warehouse');

INSERT INTO Shipping_ShippingProvider (Id, AdditionalSettings, ConfigureUrl, IsEnabled, Name, OnlyCountryIdsString, OnlyStateOrProvinceIdsString, ShippingPriceServiceTypeName, ToAllShippingEnabledCountries, ToAllShippingEnabledStatesOrProvinces) VALUES (1, '{MinimumOrderAmount : 100}', 'shipping-free-config', 1, 'Free Ship', NULL, NULL, 'SimplCommerce.Module.ShippingFree.Services.FreeShippingServiceProvider,SimplCommerce.Module.ShippingFree', 1, 1);
INSERT INTO Shipping_ShippingProvider (Id, AdditionalSettings, ConfigureUrl, IsEnabled, Name, OnlyCountryIdsString, OnlyStateOrProvinceIdsString, ShippingPriceServiceTypeName, ToAllShippingEnabledCountries, ToAllShippingEnabledStatesOrProvinces) VALUES (2, NULL, 'shipping-table-rate-config', 1, 'Table Rate', NULL, NULL, 'SimplCommerce.Module.ShippingTableRate.Services.TableRateShippingServiceProvider,SimplCommerce.Module.ShippingTableRate', 1, 1);

INSERT INTO ShippingTableRate_PriceAndDestination (Id, CountryId, MinOrderSubtotal, ShippingPrice, StateOrProvinceId) VALUES (1, 238, CAST(0.00 AS Decimal(18, 2)), CAST(7.00 AS Decimal(18, 2)), 92);
INSERT INTO ShippingTableRate_PriceAndDestination (Id, CountryId, MinOrderSubtotal, ShippingPrice, StateOrProvinceId) VALUES (2, 238, CAST(100.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), 92);

INSERT INTO Localization_Culture (Id, Name) VALUES (1, 'vi-VN');
INSERT INTO Localization_Culture (Id, Name) VALUES (2, 'fr-FR');
INSERT INTO Localization_Culture (Id, Name) VALUES (3, 'pt-BR');
INSERT INTO Localization_Culture (Id, Name) VALUES (4, 'uk-UA');
INSERT INTO Localization_Culture (Id, Name) VALUES (5, 'ru-RU');
INSERT INTO Localization_Culture (Id, Name) VALUES (6, 'ar-TN');
INSERT INTO Localization_Culture (Id, Name) VALUES (7, 'ko-KR');
INSERT INTO Localization_Culture (Id, Name) VALUES (8, 'tr-TR');
INSERT INTO Localization_Culture (Id, Name) VALUES (9, 'es-ES');
INSERT INTO Localization_Culture (Id, Name) VALUES (10, 'zh-CN');

INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Register', 'Đăng ký');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Hello {0}!', 'Chào {0}!');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Log in', 'Đăng nhập');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Log off', 'Đăng xuất');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'The Email field is required.', 'Địa chỉ email cần phải có ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Email', 'Địa chỉ email');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'User List', 'Danh sách người dùng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Remember me?', 'Ghi nhớ?');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Password', 'Mật khẩu');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Use a local account to log in.', 'Sử dụng tài khoản của bạn để đăng nhập');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Register as a new user?', 'Đăng ký người dùng mới');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Forgot your password?', 'Quên mật khẩu');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Use another service to log in.', 'Đăng nhập bằng các tài khoản khác');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Full name', 'Họ và tên');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Confirm password', 'Xác nhận mật khẩu');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create a new account.', 'Tạo tài khoản mới.');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'All', 'Tất cả');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Home', 'Trang chủ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Add to cart', 'Thêm vào giỏ hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product detail', 'Mô tả sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product specification', 'Thông số kỹ thuật');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Rate this product', 'Đánh giá sản phẩm này');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Review comment', 'Mô tả đánh giá');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Review title', 'Tiêu đề đánh giá');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Posted by', 'Đánh giá bởi');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Submit review', 'Gửi đánh giá');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'You have', 'Bạn có');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'products in your cart', 'sản phẩm trong giỏ hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Continue shopping', 'Tiếp tục mua sắm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'View cart', 'Xem giỏ hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'The product has been added to your cart', 'Sản phẩm đã được thêm vào giỏ hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Cart subtotal', 'Thành tiền');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Shopping Cart', 'Giỏ hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product', 'Sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Price', 'Giá');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Quantity', 'Số lượng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'There are no items in this cart.', 'Chưa có sản phẩm nào trong giỏ hàng của bạn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Go to shopping', 'Đi mua sắm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Order summary', 'Tóm lược đơn hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Subtotal', 'Thành tiền');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Process to Checkout', 'Tiến hành thanh toán');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Shipping address', 'Địa chỉ giao hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Add another address', 'Thêm địa chỉ mới');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Contact name', 'Tên người liên hệ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Address', 'Địa chỉ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'State or Province', 'Thành phố / Tỉnh');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'District', 'Quận / Huyện');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Phone', 'Số điện thoại');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Order', 'Đặt hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'products', 'sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'reviews', 'nhận xét');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Add Review', 'Viết nhận xét');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Customer reviews', 'Nhận xét của khách hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Your review will be showed within the next 24h.', 'Nhận xét của bạn sẽ được hiển thị trong vòng 24 tiếng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Thank you {0} for your review', 'Cảm ơn {0} đã gửi nhận xét');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Rating average', 'Đánh giá trung bình');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'stars', 'sao');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Filter by', 'Tìm theo');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Category', 'Danh mục');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Brand', 'Nhãn hiệu');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Sort by:', 'Sắp xếp theo:');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'results', 'kết quả');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'View options', 'Xem các tùy chọn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Associate your {0} account.', 'Liên kết với tài khoản {0} của bạn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Users', 'Người dùng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Vendors', 'Người bán');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Reviews', 'Đánh giá');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Products', 'Sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Categories', 'Danh mục');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Brands', 'Nhãn hiệu');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Options', 'Tùy chọn sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Attribute', 'Thuộc tính sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Attribute Groups', 'Nhóm thuộc tính sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Templates', 'Mẫu sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Sales', 'Bán hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Orders', 'Đơn hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Content Management', 'Quán lý nội dung');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Pages', 'Trang');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Widgets', 'Widgets');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'System', 'Hệ thống');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Configuration', 'Cấu hình');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Translations', 'Translations');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Dashboard', 'Dashboard');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Incomplete orders', 'Đơn hàng chưa xong');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Pending reviews', 'Đánh giá đang chờ duyệt');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Most search keywords', 'Từ khóa được tìm kiếm nhiều nhất');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Most viewed products', 'Sản phẩm được xem nhiều nhất');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'OrderId', 'Số đơn hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Order Status', 'Trạng thái đơn hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Customer', 'Khách hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Created On', 'Ngày tạo');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'SubTotal', 'Tổng tiền');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Actions', 'Hành động');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Site', 'Site');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Catalog', 'Quản lý sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Title', 'Tiêu đề');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Comment', 'Bình luận');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Status', 'Trạng thái');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Rating', 'Xếp hạng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Keyword', 'Từ khóa');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Count', 'Số lần');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create User', 'Tạo người dùng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'FullName', 'Họ và tên');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Roles', 'Roles');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit User', 'Chỉnh sửa user');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Manager of Vendor', 'Manager of Vendor');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Save', 'Lưu lại');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Cancel', 'Hủy');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Phone Number', 'Số điện thoại');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Vendor', 'Tạo người bán');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Is Active', 'Đang hoạt động');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Vendor', 'Chỉnh sửa người bán');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Managers', 'Quản lý');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Description', 'Mô tả');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Pending', 'Đang chờ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Approved', 'Đã duyệt');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Not Approved', 'Không duyệt');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Approve', 'Duyệt');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Product', 'Tạo sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Has Options', 'Tùy chọn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Is Visible Individually', 'Hiển thị riêng lẻ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Is Featured', 'Nổi bậc');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Is Allowed To Order', 'Cho phép đặt hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Is Called For Pricing', 'Gọi để biết giá');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Stock Quantity', 'Số lượng trong kho');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Is Published', 'Công bố');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Yes', 'Có');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'No', 'Không');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Product', 'Chỉnh sửa sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Name', 'Tên sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Short Description', 'Mô tả ngắn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Specification', 'Thông số kỹ thuật');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Old Price', 'Giá cũ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Special Price', 'Giá đặc biệt');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Special Price Start', 'Bắt đầu giá đặc biệt');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Special Price End', 'Kết thúc giá đặc biệt');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Thumbnail', 'Hình đại diện');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Images', 'Hình sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Documents', 'Tài liệu kỹ thuật');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Out Of Stock', 'Hết hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Available Options', 'Tùy chọn khả dụng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Add Option', 'Thêm tùy chọn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Option Values', 'Giá trị của tùy chọn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Delete Option', 'Xóa tùy chọn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Generate Combinations', 'Tự động tạo tùy chọn sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Variations', 'Những tùy chọn sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Option Combinations', 'Sự kết hợp của những tùy chọn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Images', 'Hình ảnh');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Apply', 'Áp dụng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Available Attributes', 'Đặt tính khả dụng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Add Attribute', 'Thêm đặc tính');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Attributes', 'Đặc tính của sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Attribute Name', 'Tên đặc tính');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Value', 'Giá trị');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'General Information', 'Thông tin chung');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Category Mapping', 'Danh mục');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Related Products', 'Sản phẩm tương tự');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Manage Related Products', 'Quản lý sản phẩm tương tự');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Category', 'Tạo danh mục');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Category', 'Chỉnh sửa danh mục');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Brand', 'Tạo nhãn hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Brand', 'Chỉnh sửa nhãn hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Name', 'Tên');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Parent Category', 'Danh mục cha');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Group', 'Nhóm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Product Attribute', 'Tạo đặt tính sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Product Attribute', 'Chỉnh sửa đặt tính sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Product Attribute Group', 'Tạo nhóm đặt tính sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Product Attribute Group', 'Chỉnh sửa nhóm đặt tính sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Product Option', 'Tạo tùy chọn sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Product Option', 'Chỉnh sửa tùy chọn sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Product Display Widget', 'Create Product Display Widget');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Product Display Widget', 'Edit Product Display Widget');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Widget Name', 'Widget Name');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Widget Zone', 'Widget Zone');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Publish Start', 'Thời gian bắt đầu công bố');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Publish End', 'Thời gian kết thúc');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Number of Products', 'Số lượng sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Order By', 'Sắp xếp theo');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Product Template', 'Tạo mẫu sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Product Template', 'Chỉnh sửa mẫu sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Added Attributes', 'Những đặt tính đã thêm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Back', 'Quay về');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Order Detail', 'Chi tiết đơn hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Order Information', 'Thông tin đơn hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Change', 'Thay đổi');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Product Information', 'Thông tin sản phẩm');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Shipping Information', 'Thông tin giao hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Application Settings', 'Application Settings');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Page', 'Tạo trang');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Page', 'Chỉnh sửa trang');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Body', 'Nội dung chính');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Account Dashboard', 'Quản lý tài khoản');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Account Information', 'Thông tin tài khoản');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit', 'Chỉnh sửa');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Security', 'Bảo mật');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create', 'Tạo mới');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'External Logins', 'Đăng nhập từ mạng xã hội');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Manage', 'Quản lý');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Default shipping address', 'Địa chỉ nhận hàng mặc định');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Manage address', 'Quản lý địa chỉ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'You don''t have any default address', 'Bạn chưa có địa chỉ mặc định nào');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Order History', 'Lịch sử mua hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Address Book', 'Sổ địa chỉ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Add Address', 'Thêm địa chỉ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Delete', 'Xóa');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Set as default shipping address', 'Chọn làm địa chỉ mặc định khi nhận hàng');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Edit Address', 'Chỉnh sửa địa chỉ');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Create Address', 'Tạo địa chỉ mới');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Your account', 'Tài khoản của bạn');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Date', 'Ngày');
INSERT INTO Localization_Resource (CultureId, Key, Value) VALUES (1, 'Customer Groups', 'Nhóm khách hàng');
