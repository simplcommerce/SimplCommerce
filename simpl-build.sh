#!/bin/bash
set -e

sed -i'' 's|<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="1.1.0" />|<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="1.1.0" />|' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj
sed -i'' 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Startup.cs
sed -i'' 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs

rm -rf src/SimplCommerce.WebHost/Migrations/*

dotnet restore && dotnet build

cd src/SimplCommerce.WebHost \
	&& npm install \
	&& npm install --global gulp-cli \
	&& gulp copy-modules \
	&& dotnet ef migrations add initialSchema \
	&& sed -i'' '/using SimplCommerce.Module.*.Models;/d' Migrations/SimplDbContextModelSnapshot.cs \
	&& sed -i'' '/using SimplCommerce.Module.*.Models;/d' Migrations/*_initialSchema.Designer.cs \
	&& dotnet ef database update
	
echo "The database schema has been created. Please execute the src/Database/StaticData_Postgres.sql to insert static data."
echo "Then type 'dotnet run' in src/SimplCommerce.WebHost to start the app."
