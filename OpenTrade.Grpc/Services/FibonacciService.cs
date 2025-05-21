using Grpc.Core;
using OpenTrade.Logic.Services;

namespace OpenTrade.Grpc.Services
{
    public class FibonacciService : Fibonacci.FibonacciBase
    {
        private readonly ILogger<FibonacciService> _logger;
        private readonly IFibonacciHandler _fibonacciHandler;

        public FibonacciService(ILogger<FibonacciService> logger, IFibonacciHandler fibonacciHandler)
        {
            _logger = logger;
            _fibonacciHandler = fibonacciHandler;
        }

        public override Task<PreviousFibonacciReply> GetPrevious(PreviousFibonacciRequest request, ServerCallContext context)
        {
            try
            {
                var result = _fibonacciHandler.GetPreviousFibonacci(request.N);
                return Task.FromResult(new PreviousFibonacciReply
                {
                    Result = $"f(n-1): {result.prev1}; f(n-2): {result.prev2}"
                });
            }
            catch (ArgumentException ex)
            {
                return Task.FromResult(new PreviousFibonacciReply
                {
                    Result = $"Ошибка: {ex.Message}"
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new PreviousFibonacciReply
                {
                    Result = $"Произошла непредвиденная ошибка: {ex.Message}"
                });
            }
        }
    }
}
