FROM mcr.microsoft.com/dotnet/sdk:6.0 AS installer-env

RUN mkdir -p /home/site/wwwroot
ONBUILD RUN dotnet publish *.csproj --output /home/site/wwwroot

FROM mcr.microsoft.com/azure-functions/dotnet:4.0
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]