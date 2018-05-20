using CSharpBits.Domain.Enum.Configuration;
using CSharpBits.Repository.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpBits.Service.Configuration
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository ConfigurationRepository;

        public ConfigurationService(IConfigurationRepository configurationRepository)
        {
            ConfigurationRepository = configurationRepository;
        }
        public async Task<List<Domain.Model.Configuration.Configuration>> GetApiUrls()
        {
            try
            {
                return await ConfigurationRepository.GetConfigurations(ConfigurationTag.Api);
            }
            catch (Exception) { throw; }
        }
    }
}
