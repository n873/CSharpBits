using CSharpBits.Domain.Model.Settings.Api;
using CSharpBits.Helper.Configuration;
using System;
using System.Threading.Tasks;

namespace CSharpBits.Common.Utility.Settings.Api
{
    public static class EnsureUtility
    {
        internal async static Task EnsureApiUrlsLoaded()
        {
            try
            {
                if (ApiGlobalConfiguration.ApiUrls == null)
                    ApiGlobalConfiguration.ApiUrls = await new ConfigurationHelper().GetApiUrls();
            }
            catch (Exception) { throw; }
        }
    }
}
