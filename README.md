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
DAPR_APP_PORT=3002 dapr run --app-id dotnetapp --app-port 3002 --app-protocol http --dapr-http-port 3501 -- func start --verbose -p 7071
```

Invoke the Dotnet App
```bash
curl http://localhost:7071/api/StoreFunc
```

Look at the logs to confirm the apps' execution.

## Running the sample on ACA

### Building from source

```bash
ocker build -t ghcr.io/shubham1172/azfunc-sample/nodeapp:0.1.2 -f samples/NodeApp/Dockerfile .
docker build -t ghcr.io/shubham1172/azfunc-sample/dotnetapp:0.1.2 -f samples/DotnetApp/Dockerfile .

docker push ghcr.io/shubham1172/azfunc-sample/nodeapp:0.1.2
docker push ghcr.io/shubham1172/azfunc-sample/dotnetapp:0.1.2
```

## ACA Setup

Node app
- Enable Dapr and set the app port to 3001.

Dotnet app
- Enable Dapr and set the app port to 3002.
- Create an environment variable, `DAPR_APP_PORT`, and set it to 3002.

Redis app
- ngrok tcp 6379 on your local machine (or use a public redis instance)

CApps Environment
- Create a redis component and point to the redis app.



