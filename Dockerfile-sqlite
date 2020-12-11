FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
  
WORKDIR /app
COPY . ./

RUN sed -i 's#<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="3.1.0"/>#<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="3.1.0"/>#' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj
RUN sed -i 's/UseSqlServer/UseSqlite/' src/SimplCommerce.WebHost/Program.cs
RUN sed -i 's/UseSqlServer/UseSqlite/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs
RUN sed -i 's/UseNpgsql/UseSqlite/' src/SimplCommerce.WebHost/Program.cs
RUN sed -i 's/UseNpgsql/UseSqlite/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs
RUN sed -i 's/"DefaultConnection": ".*"/"DefaultConnection": "Data Source=simplcommerce.db"/' src/SimplCommerce.WebHost/appsettings.json

RUN rm src/SimplCommerce.WebHost/Migrations/*

RUN dotnet tool install --global dotnet-ef --version 5.0.1
ENV PATH="${PATH}:/root/.dotnet/tools"

# ef core migrations run in debug, so we have to build in Debug for copying module correctly 
RUN dotnet restore && dotnet build \
    && cd src/SimplCommerce.WebHost \
	&& dotnet ef migrations add initialSchema \
    && dotnet ef database update

RUN dotnet build -c Release \
	&& cd src/SimplCommerce.WebHost \
	&& dotnet build -c Release \
	&& dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0

RUN apt-get update \
	&& apt-get install libgdiplus -y \
	&& apt-get install curl -y \
	&& rm -rf /var/lib/apt/lists/*

WORKDIR /app	
COPY --from=build-env /app/src/SimplCommerce.WebHost/out ./
COPY --from=build-env /app/src/SimplCommerce.WebHost/simplcommerce.db ./

RUN curl -SL "https://github.com/rdvojmoc/DinkToPdf/raw/v1.0.8/v0.12.4/64%20bit/libwkhtmltox.so" --output ./libwkhtmltox.so

ENTRYPOINT ["dotnet", "SimplCommerce.WebHost.dll"]