using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CryptoTask.Services.RegexCollections
{
    public static class HttpRequestRegexCollection
    {
        public static readonly Regex AssetsRequestRegex =
        new Regex(@"^https://cryptingup\.com/api/assets");
        public static readonly Regex MarketsRequestRegex =
        new Regex(@"^https://cryptingup\.com/api/markets");
    }
}
