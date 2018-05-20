using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpBits.Domain.Enum.Configuration;
using CSharpBits.Domain.Model.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CSharpBits.Repository.Configuration
{
    public interface IConfigurationRepository
    {
        DbSet<Domain.Model.Configuration.Configuration> Configuration { get; set; }

        Task<List<Domain.Model.Configuration.Configuration>> GetAllConfigurations();
        Task<Domain.Model.Configuration.Configuration> GetConfiguration(ConfigurationKey configurationKey);
        Task<List<Domain.Model.Configuration.Configuration>> GetConfigurations(ConfigurationTag configTag);
        Task<List<Domain.Model.Configuration.Configuration>> GetConfigurationsAsync(List<string> tags);
    }
}