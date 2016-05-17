Prerequisite:
- Visual Studio 2015 Update 2
- Install .NET Core SDK (RC2) and NuGet Manager extension for Visual Studio (https://www.microsoft.com/net/core#windows)
- StyleCop 4.7
- SQL Server, (other RDBMS will be supported soon)

Technologies and frameworks used:
- ASP.NET MVC Core 1.0 RC2 on dotnetcore 1.0 RC2
- Angular 1.5
- Autofac 4.0.0 RC1
- Entity framework Core 1.0 RC2
- ASP.NET Identity Core 1.0 RC2

How to run on local:
- Create a database in SQL Server
- Update the connection string in appsettings.json in SimplCommerce.Web
- Open Package Manager Console Window and type "Update-Database" then press Enter. This action will create database schema
- Run src/Database/StaticData.sql to create seed data
- Press Controll + F5
- The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

How to contribute:
- Suggest features by create new issues or add comments to issues
- Pickup an issue, create your own branch and implement it, then submit a Merge Request when you finished the implemntation and testing
- Remember to fix all the StyleCop violations before submit a Merge Request

License
SimplCommerce is licensed under the Apache 2.0 license.
