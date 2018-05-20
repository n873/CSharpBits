using CSharpBits.Helper.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpBits.Helper.Configuration
{
    public class ConfigurationHelper : ApiHelper
    {
        public ConfigurationHelper() : base("") {}

        public async Task<List<Domain.Model.Configuration.Configuration>> GetApiUrls()
        {
            try
            {
                var response = await Client.GetAsync("ApiUrls");

                var content = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    content.Wait();
                    return JsonConvert.DeserializeObject<List<Domain.Model.Configuration.Configuration>>(content.Result);
                }
                else
                    content.Wait();

                return null;
            }
            catch (Exception) { throw; }
        }
    }
}
