# A super simple, cross platform, modularized ecommerce system built on .NET Core

[![Join the chat at https://gitter.im/simplcommerce/SimplCommerce](https://badges.gitter.im/simplcommerce/SimplCommerce.svg)](https://gitter.im/simplcommerce/SimplCommerce?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Build Status
| Build server| Platform       | Status      |
|-------------|----------------|-------------|
| AppVeyor    | Windows        |[![Build status](https://ci.appveyor.com/api/projects/status/cq61prgs6ta8e9hi/branch/master?svg=true)](https://ci.appveyor.com/project/thiennn/simplcommerce/branch/master) |
|Travis       | Linux / MacOS  |[![Build Status](https://travis-ci.org/simplcommerce/SimplCommerce.svg?branch=master)](https://travis-ci.org/simplcommerce/SimplCommerce) |

## Online demo (Azure Website)
http://demo.simplcommerce.com

## Try out nightly docker images
- First run the database: `docker run --name simpldb -d postgres`
- Then run the app: `docker run --name simplsite -d -p 5000:5000 --link simpldb:simpldb simplcommerce/nightly-build`

## Prerequisite:
- Latest .NET Core SDK (https://www.microsoft.com/net/download/core#/current)
- SQL Server or PostgreSQL or MySQL

## How to run on local
### Using Visual Studio 2015 Update 3
- Install the latest versions (current) for both Runtime and .NET Core SDK for Visual Studio (https://www.microsoft.com/net/download/core#/current)
- Create a database in SQL Server
- Update the connection string in appsettings.json in SimplCommerce.WebHost
- Build whole solution **twice**.
- Open Package Manager Console Window and type "Update-Database" then press Enter. This action will create database schema
- Run src/Database/StaticData.sql to create seeding data
- Press Control + F5
- The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

### Using Command Line (Windows, Mac, Linux)
- Install NodeJS
- Install the latest versions (current) for both Runtime and SDK of .NET Core (https://www.microsoft.com/net/download/core#/current)
- Create a database in SQL Server or PostgreSQL
- If you use PostgreSQL
    - Open file project.json and add package "Npgsql.EntityFrameworkCore.PostgreSQL": "1.0.0"
    - Open Console Window, change directory to \src\SimplCommerce.WebHost type "dotnet restore" then press Enter
    - Open the file Extension\ServiceCollectionExtensions.cs replace the SqlServer provider by PostgreSQL
    ```
            - services.AddDbContext<SimplDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("SimplCommerce.WebHost")));
    ```
    - Delete all file in SimplCommerce.WebHost/Migrations
    
- Open \src\SimplCommerce.WebHost\appsettings.json and change the connection string to database that you just created. For example "DefaultConnection": "User ID=thien;Password=12345;Host=localhost;Port=5432;Database=SimplCommerce;Pooling=true;"
- In the Console Windows, type "cd .. && dotnet restore" then press Enter to change directory to /src 
- Type "dotnet build \*\*/\*\*/project.json" then press Enter
- Type "cd SimplCommerce.WebHost" then press Enter
- Type "npm install" then press Enter
- Type "gulp copy-modules" then press Enter. If you get the error "no command 'gulp' found" then type "npm install --global gulp-cli" and press Enter
- If you use Postgres: type "dotnet ef migrations add initialSchema" and hit Enter
- Type "dotnet ef database update" then press Enter. This action will create database schema
- Run src/Database/StaticData.sql on your database to create seeding data
- Type "dotnet run" then press Enter.
- Open browser, type http://localhost:5000 then hit Enter
- The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## Technologies and frameworks used:
- ASP.NET MVC Core 1.1.0 on .NET Core 1.1.0
- Entity Framework Core 1.1.0
- ASP.NET Identity Core 1.1.0
- Autofac 4.0.0
- Angular 1.5
- MediatR for domain event

## The architecture highlight
![](https://raw.githubusercontent.com/simplcommerce/SimplCommerce/master/simplcommerce.png)

The application is divided into modules. Each module contains all the stuff for itself to run including Controllers, Services, Views and even static files. If a module is no longer need, you can simply just delete it by a single click.

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

## Roadmap
https://github.com/simplcommerce/SimplCommerce/wiki/Roadmap

## How to contribute:
- Report bugs or suggest features by create new issues or add comments to issues
- Pickup an issue, create your own branch and implement it, then submit a Merge Request when you finished the implemntation and testing
- Remember to fix all the StyleCop violations before submit a Merge Request

## License
SimplCommerce is licensed under the Apache 2.0 license.
