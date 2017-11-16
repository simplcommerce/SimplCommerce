#!/bin/bash
set -e

sed -i'' -e 's|<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.0.0" />|<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="2.0.0" />|' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj
sed -i'' -e 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Program.cs
sed -i'' -e 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs

rm -rf src/SimplCommerce.WebHost/Migrations/*

dotnet restore && dotnet build

cd src/SimplCommerce.WebHost \
	&& npm install \
	&& npm install --global gulp-cli \
	&& gulp copy-module
