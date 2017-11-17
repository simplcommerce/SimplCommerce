#!/bin/bash

dotnet restore && dotnet build

cd src/SimplCommerce.WebHost \
	&& npm install \
	&& npm install --global gulp-cli \
	&& gulp copy-modules
