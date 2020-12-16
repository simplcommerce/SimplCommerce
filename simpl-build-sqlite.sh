#!/bin/bash
## Shell script for compiling the app. This build does not depend on a database (sqlite), it will create a simplcommerce.db file.
## 
set -e

sed -i'' -e 's|<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.0"/>|<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.1"/>|' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj
sed -i'' -e 's|<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="5.0.0"/>|<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.1"/>|' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj

sed -i'' -e 's/UseSqlServer/UseSqlite/' src/SimplCommerce.WebHost/Program.cs
sed -i'' -e 's/UseSqlServer/UseSqlite/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs

sed -i'' -e 's/UseNpgsql/UseSqlite/' src/SimplCommerce.WebHost/Program.cs
sed -i'' -e 's/UseNpgsql/UseSqlite/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs

sed -i'' -e 's/"DefaultConnection": ".*"/"DefaultConnection": "Data Source=simplcommerce.db"/' src/SimplCommerce.WebHost/appsettings.json

rm -rf src/SimplCommerce.WebHost/Migrations/*
rm -rf src/SimplCommerce.WebHost/simplcommerce.db

dotnet restore && dotnet build

cd src/SimplCommerce.WebHost \
	&& dotnet ef migrations add initialSchema \
	&& dotnet ef database update
	
echo "The database schema has been created. Please execute the src/Database/StaticData_Postgres.sql to insert static data."
echo "Then type 'dotnet run' in src/SimplCommerce.WebHost to start the app."
