# azfunc-dapr-samples
Samples on using the Dapr extension for Azure Functions

## Using the samples

Start the NodeApp
```bash
cd samples/NodeApp
dotnet build -o bin extensions.csproj
dapr run --app-id nodeapp --app-port 3001 --app-protocol http --dapr-http-port 3500 -- func host start --no-build --verbose -p 7070
```

Start the Dotnet App
```bash
cd samples/DotnetApp
dapr run --app-id dotnetapp --dapr-http-port 3501 -- func start --verbose -p 7071
```