# Builder image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS installer-env

RUN mkdir -p /home/site/wwwroot
WORKDIR /home/site/wwwroot

# Copy the extension and sample into the installer-env to build
COPY ./azure-functions-dapr-extension /home/azure-functions-dapr-extension
COPY /samples/DotnetApp .

# Build project
RUN dotnet publish DotnetApp.csproj --output /home/site/wwwroot

# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet:4.0-appservice
FROM mcr.microsoft.com/azure-functions/dotnet:4.0
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]
