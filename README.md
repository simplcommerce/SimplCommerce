# A simple, cross platform, modularized ecommerce system built on .NET Core

[![Join the chat at https://gitter.im/simplcommerce/SimplCommerce](https://badges.gitter.im/simplcommerce/SimplCommerce.svg)](https://gitter.im/simplcommerce/SimplCommerce?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Build Status
| Build server| Platform       | Status      |
|-------------|----------------|-------------|
| AppVeyor    | Windows        |[![Build status](https://ci.appveyor.com/api/projects/status/cq61prgs6ta8e9hi/branch/master?svg=true)](https://ci.appveyor.com/project/thiennn/simplcommerce/branch/master) |
|Travis       | Linux / MacOS  |[![Build Status](https://travis-ci.org/simplcommerce/SimplCommerce.svg?branch=master)](https://travis-ci.org/simplcommerce/SimplCommerce) |

## Online demo (Azure Website)
- Store front: http://demo.simplcommerce.com
- Administration: http://demo.simplcommerce.com/admin Email: admin@simplcommerce.com Password: 1qazZAQ!

## Docker

For testing purpose only `docker run -p 5000:80 simplcommerce/ci-build`

Continuous deployment: https://ci.simplcommerce.com

## Visual Studio 2017 and SQL Server

#### Prerequisites

- SQL Server
- [Visual Studio 2017 version >= 15.8 with .NET Core SDK 2.1.402](https://www.microsoft.com/net/download/all)

#### Steps to run

- Update the connection string in appsettings.json in SimplCommerce.WebHost
- Build whole solution.
- Open Package Manager Console Window and type "Update-Database" then press "Enter". This action will create database schema.
- In Visual Studio, press "Control + F5".
- The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## Mac/Linux with PostgreSQL

#### Prerequisite

- PostgreSQL
- [.NET Core SDK 2.1.402](https://www.microsoft.com/net/download/all)

#### Steps to run

- Update the connection string in appsettings.json in SimplCommerce.WebHost.
- Run file simpl-build.sh by "sudo ./simpl-build.sh". For ubuntu 18 "sudo bash simpl-build.sh"
- In the terminal, navigate to the "src/SimplCommerce.WebHost" type "dotnet run" and hit "Enter".
- Open browser, open http://localhost:5000. The back-office can access via /Admin using the pre-created account: admin@simplcommerce.com, 1qazZAQ!

## Technologies and frameworks used:
- ASP.NET MVC Core 2.1
- Entity Framework Core 2.1
- ASP.NET Identity Core 2.1
- Angular 1.6.3
- MediatR 5.0.1 for domain event

## Docs

http://docs.simplcommerce.com

## Roadmap

https://github.com/simplcommerce/SimplCommerce/wiki/Roadmap

## How to contribute

- Star this project on GitHub.
- Report bugs or suggest features by create new issues or add comments to issues
- Submit pull requests
- Spread the word by blogging about SimplCommerce or sharing it on social networks
- Donate us 

     [![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=JWYGHJQSYLVVQ)

## License

SimplCommerce is licensed under the Apache 2.0 license.
