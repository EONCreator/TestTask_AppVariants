using OpenTrade.Logic.Services;

namespace OpenTrade.Console.Handlers
{
    internal class ConsoleHandler : IHandler
    {
        private readonly IFibonacciHandler _fibonacciHandler;

        public ConsoleHandler()
        {
            _fibonacciHandler = new FibonacciHandler();
        }

        public async Task<string> GetPreviousFibonacci(int n)
        {
            System.Console.WriteLine("\n--- Console variant ---");
            try
            {
                var result = _fibonacciHandler.GetPreviousFibonacci(n);
                return $"f(n-1): {result.prev1}; f(n-2): {result.prev2}";
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }
    }
}
