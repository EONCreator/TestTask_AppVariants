namespace OpenTrade.Console.Services
{
    internal class CustomHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public CustomHttpClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl.TrimEnd('/');
        }

        public async Task<string> GetAsync(string relativeUrl,
                                   Dictionary<string, string> queryParams = null,
                                   CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_baseUrl}/{relativeUrl.TrimStart('/')}";

            if (queryParams != null && queryParams.Count > 0)
            {
                var queryString = string.Join("&", queryParams.Select(kvp =>
                    $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));

                requestUrl += $"?{queryString}";
            }

            var response = await _httpClient.GetAsync(requestUrl, cancellationToken);
            var content = await response.Content.ReadAsStringAsync(cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return $"{content}";
            }

            return content;
        }
    }
}
