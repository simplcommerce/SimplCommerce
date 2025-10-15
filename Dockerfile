# powershell and .Net core SDK/runtime is required in base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY . ./

RUN rm src/SimplCommerce.WebHost/Migrations/* && cp -f src/SimplCommerce.WebHost/appsettings.docker.json src/SimplCommerce.WebHost/appsettings.json

RUN dotnet tool install --global dotnet-ef --version 8.0.0
ENV PATH="${PATH}:/root/.dotnet/tools"

# ef core migrations run in debug, so we have to build in Debug for copying module correctly
RUN dotnet build \
    && cd src/SimplCommerce.WebHost \
	&& dotnet ef migrations remove --force || echo "No migrations to remove" \
	&& dotnet ef migrations add initialSchema \
    && dotnet ef migrations script -o dbscript.sql

RUN dotnet build -c Release \
	&& cd src/SimplCommerce.WebHost \
    && dotnet build -c Release \
	&& dotnet publish -c Release -o out
	
RUN curl -SL "https://github.com/rdvojmoc/DinkToPdf/raw/v1.0.8/v0.12.4/64%20bit/libwkhtmltox.so" --output /app/src/SimplCommerce.WebHost/out/libwkhtmltox.so

# remove BOM for psql	
RUN sed -i -e '1s/^\xEF\xBB\xBF//' /app/src/SimplCommerce.WebHost/dbscript.sql

FROM mcr.microsoft.com/dotnet/aspnet:8.0
# hack to make postgresql-client install work on slim
RUN mkdir -p /usr/share/man/man1 \
    && mkdir -p /usr/share/man/man7

RUN apt-get update \
	&& apt-get install -y --no-install-recommends postgresql-client \
	&& apt-get install libgdiplus -y \
	&& rm -rf /var/lib/apt/lists/*
# Install the agent
RUN apt-get update && apt-get install -y wget ca-certificates gnupg \
	&& echo 'deb http://apt.newrelic.com/debian/ newrelic non-free' | tee /etc/apt/sources.list.d/newrelic.list \
	&& wget https://download.newrelic.com/548C16BF.gpg \
	&& apt-key add 548C16BF.gpg \
	&& apt-get update \
	&& apt-get install -y 'newrelic-dotnet-agent' \
	&& rm -rf /var/lib/apt/lists/*

# Enable the agent
ENV CORECLR_ENABLE_PROFILING=1 \
	CORECLR_PROFILER={36032161-FFC0-4B61-B559-F6C5D41BAE5A} \
	CORECLR_NEWRELIC_HOME=/usr/local/newrelic-dotnet-agent \
	CORECLR_PROFILER_PATH=/usr/local/newrelic-dotnet-agent/libNewRelicProfiler.so \
	NEW_RELIC_LICENSE_KEY=a1169725e396c7a441e0715dec5cf806FFFFNRAL \
	NEW_RELIC_APP_NAME="mars-simplcommerce" \
	DB_HOST="simpldb.cluster-cne8sm0g84jd.us-west-1.rds.amazonaws.com" \
	DB_NAME="simpldb" \
	DB_USER="postgres" \
	PGPASSWORD="marsDevTest"\
	ASPNETCORE_URLS=http://+:80

WORKDIR /app	
COPY --from=build-env /app/src/SimplCommerce.WebHost/out ./
COPY --from=build-env /app/src/SimplCommerce.WebHost/dbscript.sql ./

COPY --from=build-env /app/docker-entrypoint.sh /
RUN chmod 755 /docker-entrypoint.sh

ENTRYPOINT ["/docker-entrypoint.sh"]