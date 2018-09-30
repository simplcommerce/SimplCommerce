#!/bin/bash
cd /app && dotnet SimplCommerce.WebHost.dll UpdateDb && dotnet SimplCommerce.WebHost.dll 
