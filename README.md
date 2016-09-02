# A super simple, modularized ecommerce system built on .NET Core

[![Join the chat at https://gitter.im/simplcommerce/SimplCommerce](https://badges.gitter.im/simplcommerce/SimplCommerce.svg)](https://gitter.im/simplcommerce/SimplCommerce?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Prerequisite:
- Visual Studio 2015 Update 3
- Install .NET Core SDK for Visual Studio (https://www.microsoft.com/net/core#windows)
- StyleCop 4.7
- SQL Server or PostgreSQL

## Technologies and frameworks used:
- ASP.NET MVC Core 1.0 on .NET Core 1.0
- Entity Framework Core 1.0
- ASP.NET Identity Core 1.0
- Autofac 4.0.0
- Angular 1.5
- MediatR for domain event

## The architecture highlight
![](https://github.com/simplcommerce/SimplCommerce/blob/master/simplcommerce.png)

The application is divided into modules. Each module contains all the stuff for itself to run including Controllers, Services, Views and event static files. If a module is no longer need, you can simply just delete it by a single click.

The SimplCommerce.WebHost is the ASP.NET Core project and act as the host. It will bootstrap the app and load all the modules it found in it's Modules folder. In the gulpfile.js, there is a "copy-modules" that is bound to 'AfterBuild' event of Visual Studio to copy /bin, /Views, /wwwroot in each module to the Modules folder in the WebHost.

During the application startup, the host will scan for all the *.dll in the Modules folder and load it up using AssemblyLoadContext. These assemblies then be registered to MVC Core by ApplicationPart

A ModuleViewLocationExpander is implemented to help the ViewEngine can find the right location for views in modules.

Static files (wwwroot) in each module is served by configuring the static files middleware as follows

```cs
    // Serving static file for modules
    foreach (var module in modules)
    {
        var wwwrootDir = new DirectoryInfo(Path.Combine(module.Path, "wwwroot"));
        if (!wwwrootDir.Exists)
        {
            continue;
        }

        app.UseStaticFiles(new StaticFileOptions()
        {
            FileProvider = new PhysicalFileProvider(wwwrootDir.FullName),
            RequestPath = new PathString("/" + module.ShortName)
        });
    }
 ```
#### For entity framework
Every domain entities need to inherit from Entity, then on the "OnModelCreating" method, we find them and register them to DbContext
```cs
    private static void RegisterEntities(ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
    {
        var entityTypes = typeToRegisters.Where(x => x.GetTypeInfo().IsSubclassOf(typeof(Entity)) && !x.GetTypeInfo().IsAbstract);
        foreach (var type in entityTypes)
        {
            modelBuilder.Entity(type);
        }
    }
```
By default domain entities is mapped by convention. In case you need to some special mapping for your model. You can create a class that implement the ICustomModelBuilder for example
```cs
    public class CatalogCustomModelBuilder : ICustomModelBuilder
    {
        public void Build(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductLink>()
                .HasOne(x => x.Product)
                .WithMany(p => p.ProductLinks)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
```

## How to run on local (Windows)
- Create a database in SQL Server
- Update the connection string in appsettings.json in SimplCommerce.WebHost
- Open Package Manager Console Window and type "Update-Database" then press Enter. This action will create database schema
- Run src/Database/StaticData.sql to create seeding data
- Press Controll + F5
- The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## How to run on Ubuntu 14.04
 - Install the Install .NET Core SDK as instruction here https://www.microsoft.com/net/core#ubuntu
 - Install Postgresql https://www.postgresql.org/download/linux/ubuntu/
 - Create an empty database
 - Clone the source code if you haven't and cd to the folder src/SimplCommerce.WebHost
 - Open file project.json and add package "Npgsql.EntityFrameworkCore.PostgreSQL": "1.0.0"
 - Open appsettings.json and change the connection string to postgre database that you just created. For example
   ``` "DefaultConnection": "User ID=thien;Password=12345;Host=localhost;Port=5432;Database=SimplCommerce;Pooling=true;" ```
 - Open the file Startup.cs replay the SqlServer provider by Postgre
 ```
   services.AddDbContext<SimplDbContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("SimplCommerce.WebHost")));
 ```
 - Run ```dotnet restore``` 
 - Re-add migration for postgre by deleting all file in SimplCommerce.Web/Migrations and run ```donet ef migrations add initialSchema```
 - Run ```dotnet ef database update```
 - Run src/Database/StaticData_Postgre.sql to create seeding data
 - Run ```dotnet run```
 - The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## Online demo (Azure Website)
http://demo.simplcommerce.com

## Roadmap
https://github.com/simplcommerce/SimplCommerce/wiki/Roadmap

## How to contribute:
- Report bugs or suggest features by create new issues or add comments to issues
- Pickup an issue, create your own branch and implement it, then submit a Merge Request when you finished the implemntation and testing
- Remember to fix all the StyleCop violations before submit a Merge Request

## License
SimplCommerce is licensed under the Apache 2.0 license.
