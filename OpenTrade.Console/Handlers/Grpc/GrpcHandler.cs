using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Grpc.Net.Client;
using OpenTrade.Grpc.Client;

namespace OpenTrade.Console.Handlers.Grpc
{
    internal class GrpcHandler : IHandler, IDisposable
    {
        private readonly GrpcChannel _channel;
        private readonly Fibonacci.FibonacciClient _client;

        public GrpcHandler()
        {
            _channel = GrpcChannel.ForAddress("http://localhost:5062");
            _client = new Fibonacci.FibonacciClient(_channel);
        }

        public async Task<string> GetPreviousFibonacci(int n)
        {
            System.Console.WriteLine("\n--- gRPC variant ---");

            var result = await _client.GetPreviousAsync(new PreviousFibonacciRequest { N = n });
            return result.Result;
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
