FROM simplcommerce/simpl-sdk
  
ARG source=.
WORKDIR /app
COPY $source .

RUN sed -i 's/"Microsoft.EntityFrameworkCore.SqlServer": "1.1.0"/"Npgsql.EntityFrameworkCore.PostgreSQL": "1.1.0"/' src/SimplCommerce.WebHost/Extensions/project.json

RUN sed -i 's/UseSqlServer/UseNpgsql/' src/SimplCommerce.WebHost/Extensions/ServiceCollectionExtensions.cs

RUN cd src/SimplCommerce.WebHost && rm Migrations/* && cp -f appsettings.docker.json appsettings.json

RUN cd src && dotnet restore && dotnet build **/**/project.json

RUN cd src/SimplCommerce.WebHost && npm install && gulp copy-modules

RUN cd src/SimplCommerce.WebHost && dotnet ef migrations add initialSchema

# Don't know why ef migration tool add this.
RUN sed -i '/using SimplCommerce.Module.*.Models;/d' src/SimplCommerce.WebHost/Migrations/SimplDbContextModelSnapshot.cs
RUN sed -i '/using SimplCommerce.Module.*.Models;/d' src/SimplCommerce.WebHost/Migrations/*_initialSchema.Designer.cs

COPY docker-entrypoint.sh /
RUN chmod 755 /docker-entrypoint.sh

ENTRYPOINT ["/docker-entrypoint.sh"]
