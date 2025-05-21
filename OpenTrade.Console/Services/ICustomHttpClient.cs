using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTrade.Console.Services
{
    internal interface ICustomHttpClient
    {
        Task<string> GetAsync(string relativeUrl, Dictionary<string, object> queryParams = null, CancellationToken cancellationToken = default);
    }
}
