using OpenTrade.Grpc.Services;
using OpenTrade.Logic.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddFibonacciServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<FibonacciService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
