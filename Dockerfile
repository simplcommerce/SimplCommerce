FROM simplcommerce/simpl-sdk AS build-env
  
WORKDIR /app
COPY . ./

RUN sed -i 's#<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.0.0" />#<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="2.0.0-preview2-final" />#' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj
RUN sed -i 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Program.cs
RUN sed -i 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs

RUN rm src/SimplCommerce.WebHost/Migrations/* && cp -f src/SimplCommerce.WebHost/appsettings.docker.json src/SimplCommerce.WebHost/appsettings.json
RUN dotnet restore && dotnet build -c Release
RUN cd src/SimplCommerce.WebHost \
    && sed -i 's/Debug/Release/' gulpfile.js \
	&& npm install \
	&& gulp copy-modules \
	&& dotnet ef migrations add initialSchema \
	&& sed -i '/using SimplCommerce.Module.*.Models;/d' Migrations/SimplDbContextModelSnapshot.cs \
	&& sed -i '/using SimplCommerce.Module.*.Models;/d' Migrations/*_initialSchema.Designer.cs \
	&& dotnet ef migrations script -o dbscript.sql \
	&& dotnet publish -c Release -o out

# remove BOM for psql	
RUN sed -i -e '1s/^\xEF\xBB\xBF//' /app/src/SimplCommerce.WebHost/dbscript.sql \
	&& sed -i -e '1s/^\xEF\xBB\xBF//' /app/src/Database/StaticData_Postgres.sql

FROM microsoft/aspnetcore:2.0.0-jessie
RUN apt-get update \
	&& apt-get install -y --no-install-recommends \
		postgresql-client \
	&& rm -rf /var/lib/apt/lists/*
	
ENV ASPNETCORE_URLS http://+:5000

WORKDIR /app	
COPY --from=build-env /app/src/SimplCommerce.WebHost/out ./
COPY --from=build-env /app/src/SimplCommerce.WebHost/dbscript.sql ./
COPY --from=build-env /app/src/Database/StaticData_Postgres.sql ./

COPY --from=build-env /app/docker-entrypoint.sh /
RUN chmod 755 /docker-entrypoint.sh

ENTRYPOINT ["/docker-entrypoint.sh"]
