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

RUN sed -i 's#<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="2.1.1" />#<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="2.1.1" />#' src/SimplCommerce.WebHost/SimplCommerce.WebHost.csproj
RUN sed -i 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Program.cs
RUN sed -i 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs

RUN rm src/SimplCommerce.WebHost/Migrations/* && cp -f src/SimplCommerce.WebHost/appsettings.docker.json src/SimplCommerce.WebHost/appsettings.json

RUN dotnet restore && dotnet build -c Release \
	&& cd src/SimplCommerce.WebHost \
	&& npm run gulp-copy-modules -- --configurationName Release \
    && dotnet ef migrations add initialSchema \
	&& dotnet ef migrations script -o dbscript.sql \
	&& dotnet publish -c Release -o out

# remove BOM for psql	
RUN sed -i -e '1s/^\xEF\xBB\xBF//' /app/src/SimplCommerce.WebHost/dbscript.sql \
	&& sed -i -e '1s/^\xEF\xBB\xBF//' /app/src/Database/StaticData_PostgreSQL.sql

FROM microsoft/dotnet:2.1.1-aspnetcore-runtime

# hack to make postgresql-client install work on slim
RUN mkdir -p /usr/share/man/man1 \
    && mkdir -p /usr/share/man/man7

RUN apt-get update \
	&& apt-get install -y --no-install-recommends postgresql-client \
	&& apt-get install libgdiplus -y \
	&& rm -rf /var/lib/apt/lists/*

WORKDIR /app	
COPY --from=build-env /app/src/SimplCommerce.WebHost/out ./
COPY --from=build-env /app/src/SimplCommerce.WebHost/dbscript.sql ./

RUN curl -SL "https://github.com/rdvojmoc/DinkToPdf/raw/v1.0.8/v0.12.4/64%20bit/libwkhtmltox.so" --output ./libwkhtmltox.so

COPY --from=build-env /app/docker-entrypoint.sh /
RUN chmod 755 /docker-entrypoint.sh

ENTRYPOINT ["/docker-entrypoint.sh"]
