## Prerequisite:
- Visual Studio 2015 Update 2
- Install .NET Core SDK (RC2) and NuGet Manager extension for Visual Studio (https://www.microsoft.com/net/core#windows)
- StyleCop 4.7
- SQL Server or Postgree

## Technologies and frameworks used:
- ASP.NET MVC Core 1.0 RC2 on dotnetcore 1.0 RC2
- Angular 1.5
- Autofac 4.0.0 RC1
- Entity framework Core 1.0 RC2
- ASP.NET Identity Core 1.0 RC2

## How to run on local (Windows)
- Create a database in SQL Server
- Update the connection string in appsettings.json in SimplCommerce.Web
- Open Package Manager Console Window and type "Update-Database" then press Enter. This action will create database schema
- Run src/Database/StaticData.sql to create seed data
- Press Controll + F5
- The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## How to run on Ubuntu 14.04
 - Install the Install .NET Core SDK as instruction here https://www.microsoft.com/net/core#ubuntu
 - Install Postgresql https://www.postgresql.org/download/linux/ubuntu/
 - Create an empty database
 - Clone the source code if you haven't and move to the folder src/SimplCommerce.Web
 - Open file project.json and add package "Npgsql.EntityFrameworkCore.PostgreSQL": "1.0.0-rc2-release1"
 - Open appsettings.json and change the connection string to postgre database that you just created.
   Ex: "DefaultConnection": "User ID=thien;Password=12345;Host=localhost;Port=5432;Database=SimplCommerce;Pooling=true;"
 - Open the file Startup.cs replay the SqlServer provider by Postgre
   services.AddDbContext<HvDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SimplCommerce.Web")));
 - Re-add migration for postgre by deleting all file in SimplCommerce.Web/Migrations and run donet ef migrations add initialSchema
 - Run dotnet ef database update
 - Run dotnet restore
 - Run dotnet run

## How to contribute:
- Suggest features by create new issues or add comments to issues
- Pickup an issue, create your own branch and implement it, then submit a Merge Request when you finished the implemntation and testing
- Remember to fix all the StyleCop violations before submit a Merge Request

## License
SimplCommerce is licensed under the Apache 2.0 license.
