# A simple, cross platform, modularized ecommerce system built on .NET Core

[![Join the chat at https://gitter.im/simplcommerce/SimplCommerce](https://badges.gitter.im/simplcommerce/SimplCommerce.svg)](https://gitter.im/simplcommerce/SimplCommerce?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Build Status
| Build server| Platform       | Status      |
|-------------|----------------|-------------|
| AppVeyor    | Windows        |[![Build status](https://ci.appveyor.com/api/projects/status/cq61prgs6ta8e9hi/branch/master?svg=true)](https://ci.appveyor.com/project/thiennn/simplcommerce/branch/master) |
|Travis       | Linux / MacOS  |[![Build Status](https://travis-ci.org/simplcommerce/SimplCommerce.svg?branch=master)](https://travis-ci.org/simplcommerce/SimplCommerce) |

## Online demo (Azure Website)
http://demo.simplcommerce.com

## Docker
- First run the database: `docker run --name simpldb -d postgres`
- Then run the app: `docker run --name simplsite -d -p 5000:5000 --link simpldb:simpldb simplcommerce/nightly-build`


## Visual Studio 2017 and SQL Server

#### Prerequisites

- SQL Server
- [Visual Studio 2017 version 15.3 with .NET Core SDK 2.0](https://www.microsoft.com/net/core/)

#### Steps to run

- Create a database in SQL Server
- Update the connection string in appsettings.json in SimplCommerce.WebHost
- Build whole solution.
- In the Task Runner Explorer, right click on the "copy-modules" task and Run.
- Open Package Manager Console Window and type "Update-Database" then press "Enter". This action will create database schema.
- Execute src/Database/StaticData.sql on the created database to insert seed data.
- In Visual Studio, press "Control + F5".
- The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## Mac/Linux with PostgreSQL

#### Prerequisite

- PostgreSQL
- NodeJS
- [.NET Core SDK 2.0](https://www.microsoft.com/net/core/)

#### Steps to run

- Create a database in PostgreSQL.
- Update the connection string in appsettings.json in SimplCommerce.WebHost.
- Run file "sudo ./simpl-build.sh".
- Execute src/Database/StaticData_Postgres.sql on the created database to insert seed data.
- In the terminal, navigate to the "src/SimplCommerce.WebHost" type "dotnet run" and hit "Enter".
- Open browser, open http://localhost:5000. The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## Technologies and frameworks used:
- ASP.NET MVC Core 2.0.0 on .NET Core 2.0.0 
- Entity Framework Core 2.0.0
- ASP.NET Identity Core 2.0.0
- Autofac 4.2.0
- Angular 1.6.3
- MediatR 3.0.1 for domain event

## The architecture highlight
![](https://raw.githubusercontent.com/simplcommerce/SimplCommerce/master/simplcommerce.png)

The application is divided into modules. Each module contains all the stuff for itself to run including Controllers, Services, Views and even static files. If a module is no longer need, you can simply just delete it by a single click.

The SimplCommerce.WebHost is the ASP.NET Core project and acts as the host. It will bootstrap the app and load all the modules it found in its Modules folder. In the gulpfile.js, there is a "copy-modules" that is bound to 'After Build' event of Visual Studio to copy /bin, /Views, /wwwroot in each module to the Modules folder in the WebHost.

During the application startup, the host will scan for all the *.dll in the Modules folder and load them up using AssemblyLoadContext. These assemblies will be then registered to MVC Core by the AddApplicationPart method.

A ModuleViewLocationExpander is implemented to help the ViewEngine can find the right location for views in modules.

#### For Entity Framework Core
Every domain entity needs to inherit from Entity, then on the "OnModelCreating" method, we find them and register them to the DbContext:
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
By default domain entities are mapped by convention. In case you need to some special mapping for your model. You can create a class that implements the ICustomModelBuilder for example:
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

## How to contribute

- Report bugs or suggest features by create new issues or add comments to issues
- Submit pull requests
- If SimplCommerce has been helpful to you, then you might want to buy us a beer

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JWYGHJQSYLVVQ)

## License

SimplCommerce is licensed under the Apache 2.0 license.
