FROM microsoft/dotnet:2.1-sdk AS build-env

#setup node
ENV NODE_VERSION 8.9.4
ENV NODE_DOWNLOAD_SHA 21fb4690e349f82d708ae766def01d7fec1b085ce1f5ab30d9bda8ee126ca8fc

RUN curl -SL "https://nodejs.org/dist/v${NODE_VERSION}/node-v${NODE_VERSION}-linux-x64.tar.gz" --output nodejs.tar.gz \
    && echo "$NODE_DOWNLOAD_SHA nodejs.tar.gz" | sha256sum -c - \
    && tar -xzf "nodejs.tar.gz" -C /usr/local --strip-components=1 \
    && rm nodejs.tar.gz \
    && ln -s /usr/local/bin/node /usr/local/bin/nodejs
  
WORKDIR /app
COPY . ./

RUN sed -i 's#<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.1.0-rc1-final" />#<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="2.0.2" />#' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj
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
	&& sed -i -e '1s/^\xEF\xBB\xBF//' /app/src/Database/StaticData_PostgreSQL.sql

FROM microsoft/dotnet:2.1-aspnetcore-runtime
RUN apt-get update \
	&& apt-get install -y --no-install-recommends \
		postgresql-client \
	&& rm -rf /var/lib/apt/lists/*	

WORKDIR /app	
COPY --from=build-env /app/src/SimplCommerce.WebHost/out ./
COPY --from=build-env /app/src/SimplCommerce.WebHost/dbscript.sql ./
COPY --from=build-env /app/src/Database/StaticData_PostgreSQL.sql ./

COPY --from=build-env /app/docker-entrypoint.sh /
RUN chmod 755 /docker-entrypoint.sh

ENTRYPOINT ["/docker-entrypoint.sh"]
