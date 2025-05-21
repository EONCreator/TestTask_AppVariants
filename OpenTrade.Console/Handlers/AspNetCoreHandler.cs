using OpenTrade.Console.Services;

namespace OpenTrade.Console.Handlers
{
    internal class AspNetCoreHandler : IHandler
    {
        private readonly CustomHttpClient _httpClient;

        public AspNetCoreHandler()
        {
            _httpClient = new CustomHttpClient("https://localhost:7286");
        }

        public async Task<string> GetPreviousFibonacci(int n)
        {
            System.Console.WriteLine("\n--- ASP.NET Core variant ---");

            var response = await _httpClient.GetAsync("/api/fibonacci/getprevious", new Dictionary<string, string> {
                { "n", n.ToString() }
            });
            return response;
        }
    }
}
