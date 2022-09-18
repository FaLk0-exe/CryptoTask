using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTask.Services
{
    public static class OpenApiJsonParser
    {
        public async static Task<List<Asset>> ParseAssets(string request)
        {
            if (!HttpRequestRegexCollection.AssetsRequestRegex.IsMatch(request))
            {
                throw new ArgumentException("assets request was invalid!");
            }
            else
            {
                var httpClient = new HttpClient();
                var response = (await httpClient.GetAsync(request)).EnsureSuccessStatusCode();
                string body = await response.Content.ReadAsStringAsync();
                Regex r1 = new Regex(@",""next"":""\d+?""");
                Regex r2 = new Regex(@"{""assets"":");
                body = r2.Replace(r1.Replace(body, ""), "");
                body = body.Remove(body.Length - 1);
                return JsonConvert.DeserializeObject<List<Asset>>(body);
            }
        }

    }
}
