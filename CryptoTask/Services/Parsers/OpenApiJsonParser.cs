using CryptoTask.Models;
using CryptoTask.Services.Helpers;
using CryptoTask.Services.RegexCollections;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoTask.Services.Parsers
{
    public static class OpenApiJsonParser
    {
        private static List<T> Parse<T>(string request,string className)
        {
          
           
                    var httpClient = new HttpClient();
                    var response = httpClient.GetAsync(request);
                    string body = response.Result.Content.ReadAsStringAsync().Result;
                    Regex r1 = new Regex(@",""next"":""\d+?""");
                    Regex r2 = new Regex($@"{{""{className}"":");
                    body = r2.Replace(r1.Replace(body, ""), "");
                    body = body.Remove(body.Length - 1);
                    return JsonConvert.DeserializeObject<List<T>>(body);
        }

        public static List<Asset> ParseAssets(string request)
        {
            if (!HttpRequestRegexCollection.AssetsRequestRegex.IsMatch(request))
            {
                throw new ArgumentException("assets request was invalid!");
            }
            else
            {
                if (ConnectionChecker.OK())
                {
                    return Parse<Asset>(request, "assets");
                }
                else
                {
                    return new List<Asset>();
                }
            }
        }

        public static List<Market> ParseMarkets(string request)
        {
            if (!HttpRequestRegexCollection.MarketsRequestRegex.IsMatch(request))
            {
                throw new ArgumentException("markets request was invalid!");
            }
            else
            {
                if (ConnectionChecker.OK())
                {
                    return Parse<Market>(request, "markets");
                }
                else
                {
                    return new List<Market>();
                }
            }
        }
    }
}
