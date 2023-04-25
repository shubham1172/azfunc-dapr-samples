# azfunc-dapr-samples
Samples on using the Dapr extension for Azure Functions

## Running the sample locally

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

## Running the sample on ACA

### Building from source

```bash
docker build -t ghcr.io/shubham1172/azfunc-sample/nodeapp:0.1.0 -f samples/NodeApp/Dockerfile ./samples/NodeApp
docker build -t ghcr.io/shubham1172/azfunc-sample/dotnetapp:0.1.0 -f samples/DotnetApp/Dockerfile ./samples/DotnetApp

docker push ghcr.io/shubham1172/azfunc-sample/nodeapp:0.1.0
docker push ghcr.io/shubham1172/azfunc-sample/dotnetapp:0.1.0
```