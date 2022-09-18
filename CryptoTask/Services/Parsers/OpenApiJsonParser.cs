﻿using CryptoTask.Models;
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
        public static List<Asset> ParseAssets(string request)
        {
            if (!HttpRequestRegexCollection.AssetsRequestRegex.IsMatch(request))
            {
                throw new ArgumentException("assets request was invalid!");
            }
            else
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetAsync(request);
                string body = response.Result.Content.ReadAsStringAsync().Result;
                Regex r1 = new Regex(@",""next"":""\d+?""");
                Regex r2 = new Regex(@"{""assets"":");
                body = r2.Replace(r1.Replace(body, ""), "");
                body = body.Remove(body.Length - 1);
                return JsonConvert.DeserializeObject<List<Asset>>(body);
            }
        }

    }
}
