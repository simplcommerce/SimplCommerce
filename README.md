## Prerequisite:
- Visual Studio 2015 Update 3
- Install .NET Core SDK for Visual Studio (https://www.microsoft.com/net/core#windows)
- StyleCop 4.7
- SQL Server or Postgree

## Technologies and frameworks used:
- ASP.NET MVC Core 1.0 on .NET Core 1.0
- Entity Framework Core 1.0
- ASP.NET Identity Core 1.0
- Autofac 4.0.0 RC3
- Angular 1.5


## How to run on local (Windows)
- Create a database in SQL Server
- Update the connection string in appsettings.json in SimplCommerce.Web
- Open Package Manager Console Window and type "Update-Database" then press Enter. This action will create database schema
- Run src/Database/StaticData.sql to create seeding data
- Press Controll + F5
- The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## How to run on Ubuntu 14.04
 - Install the Install .NET Core SDK as instruction here https://www.microsoft.com/net/core#ubuntu
 - Install Postgresql https://www.postgresql.org/download/linux/ubuntu/
 - Create an empty database
 - Clone the source code if you haven't and cd to the folder src/SimplCommerce.Web
 - Open file project.json and add package "Npgsql.EntityFrameworkCore.PostgreSQL": "1.0.0"
 - Open appsettings.json and change the connection string to postgre database that you just created. For example
   ``` "DefaultConnection": "User ID=thien;Password=12345;Host=localhost;Port=5432;Database=SimplCommerce;Pooling=true;" ```
 - Open the file Startup.cs replay the SqlServer provider by Postgre
 ```
   services.AddDbContext<HvDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SimplCommerce.Web")));
 ```
 - Run ```dotnet restore``` 
 - Re-add migration for postgre by deleting all file in SimplCommerce.Web/Migrations and run ```donet ef migrations add initialSchema```
 - Run ```dotnet ef database update```
 - Run src/Database/StaticData_Postgre.sql to create seeding data
 - Run ```dotnet run```
 - The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## Online demo
Hosted in an Azure virtual machine A0 (shared core, 768 MB memory)
Ubuntu 14.04 + Postgresql
http://demo.simplcommerce.com

## Roadmap
https://github.com/simplcommerce/SimplCommerce/wiki/Roadmap

## How to contribute:
- Report bugs or suggest features by create new issues or add comments to issues
- Pickup an issue, create your own branch and implement it, then submit a Merge Request when you finished the implemntation and testing
- Remember to fix all the StyleCop violations before submit a Merge Request

## License
SimplCommerce is licensed under the Apache 2.0 license.
