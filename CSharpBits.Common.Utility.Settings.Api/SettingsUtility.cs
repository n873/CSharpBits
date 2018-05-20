using CSharpBits.Domain.Model.Settings.Api;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBits.Common.Utility.Settings.Api
{
    public static class SettingsUtility
    {
        public async static Task<string> GetApiUrl(string key)
        {
            try
            {
                await EnsureUtility.EnsureApiUrlsLoaded();
                var config = ApiGlobalConfiguration.ApiUrls.FirstOrDefault(apiUrl => apiUrl.Key.ToLower() == key.ToLower());
                return config != null ? config.Value : string.Empty;
            }
            catch (Exception) { throw; }
        }
    }
}
