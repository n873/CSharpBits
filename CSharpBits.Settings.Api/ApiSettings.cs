using CSharpBits.Common.Utility.Settings.Api;
using CSharpBits.Domian.Constant.Settings.Api;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace CSharpBits.Settings.Api
{
    public static class ApiSettings
    {
        public static string GetConfigurationApi()
        {
            try
            {
                var apiUrl = ConfigurationManager.AppSettings[ApiSettingsKeys.ConfigurationApiKey].ToString();
                if (!string.IsNullOrEmpty(apiUrl))
                    return apiUrl;
                throw new Exception("ConfigurationApi configuration key not found, please check your app.config file");
            }
            catch (Exception) { throw; }
        }

        public static string GetSomeApi()
        {
            try
            {
                var apiUrl = Task.Run(async () =>
                {
                    return await SettingsUtility.GetApiUrl(ApiSettingsKeys.SomeApiKey);
                });
                if (apiUrl != null && !string.IsNullOrEmpty(apiUrl.Result))
                    return apiUrl.Result;
                throw new Exception("SomeApi configuration key not found, please check your configuration table");
            }
            catch (Exception) { throw; }
        }
    }
}
