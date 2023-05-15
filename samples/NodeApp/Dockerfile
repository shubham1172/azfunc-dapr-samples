# Builder image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS extensions-build

RUN mkdir -p /home/site/wwwroot
WORKDIR /home/site/wwwroot

# Copy the extension and sample for building
COPY ./azure-functions-dapr-extension /home/azure-functions-dapr-extension
COPY ./samples/NodeApp .

RUN dotnet build -o bin extensions.csproj

# Runtime image
FROM mcr.microsoft.com/azure-functions/node:4-node18

ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=extensions-build /home/site/wwwroot /home/site/wwwroot

RUN cd /home/site/wwwroot && \
    npm install