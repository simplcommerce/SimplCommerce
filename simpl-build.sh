#!/bin/bash
set -e

sed -i'' -e 's|<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.0"/>|<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="5.0.0"/>|' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj
sed -i'' -e 's|<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.1"/>|<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="5.0.0"/>|' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj
sed -i'' -e 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Program.cs
sed -i'' -e 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs

sed -i'' -e 's/UseSqlite/UseNpgsql/' src/SimplCommerce.WebHost/Program.cs
sed -i'' -e 's/UseSqlite/UseNpgsql/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs

# For this to work you need a connection to the database. Spin an postgresql in howto-build-docker.md 
sed -i'' -e 's/"DefaultConnection": ".*"/"DefaultConnection": "User ID=postgres;Password=postgres;Server=simpldb;Port=5432;Database=simplcommerce;Pooling=true;"/' src/SimplCommerce.WebHost/appsettings.json

rm -rf src/SimplCommerce.WebHost/Migrations/*

dotnet restore && dotnet build

cd src/SimplCommerce.WebHost \
	&& dotnet ef migrations add initialSchema \
	&& dotnet ef database update
	
echo "The database schema has been created. Please execute the src/Database/StaticData_Postgres.sql to insert static data."
echo "Then type 'dotnet run' in src/SimplCommerce.WebHost to start the app."
