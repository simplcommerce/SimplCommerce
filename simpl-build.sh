#!/bin/bash

-rm -rf src/SimplCommerce.WebHost/Migrations/*

dotnet restore && dotnet build

cd src/SimplCommerce.WebHost \
	&& npm install \
	&& npm install --global gulp-cli \
	&& gulp copy-modules
