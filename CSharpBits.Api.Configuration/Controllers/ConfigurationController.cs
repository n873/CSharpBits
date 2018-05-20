using CSharpBits.Service.Configuration;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpBits.Api.Configuration.Controllers
{
    [Route("CSharpBits/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfigurationService ConfigurationService;
        public ConfigurationController(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
        }

        [HttpGet("ApiUrls")]
        public async Task<List<Domain.Model.Configuration.Configuration>> ApiUrls()
        {
            try
            {
                var apiUrls =  await ConfigurationService.GetApiUrls();
                if (apiUrls != null && apiUrls.Count > 0)
                    return apiUrls;
                return null;
            }
            catch (Exception) { throw; }
        }
    }
}
