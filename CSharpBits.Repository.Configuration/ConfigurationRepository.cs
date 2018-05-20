using CSharpBits.Domain.Enum.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpBits.Repository.Configuration
{
    public class ConfigurationRepository : DbContext, IConfigurationRepository
    {
        public ConfigurationRepository(DbContextOptions<ConfigurationRepository> options) : base(options) { }

        public DbSet<Domain.Model.Configuration.Configuration> Configuration { get; set; }

        public async Task<List<Domain.Model.Configuration.Configuration>> GetConfigurations(ConfigurationTag configTag)
        {
            try
            {
                var configurations = await Configuration.ToListAsync();
                var result = new List<Domain.Model.Configuration.Configuration>();
                configurations.ForEach(config =>
                {
                    if (config.Tags.Contains(configTag.ToString().ToLower()))
                        result.Add(config);
                });

                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Domain.Model.Configuration.Configuration> GetConfiguration(ConfigurationKey configurationKey)
        {
            try
            {
                return await Configuration
                    .SingleOrDefaultAsync(config => config.Key == configurationKey.ToString());
            }
            catch (Exception) { throw; }
        }

        public async Task<List<Domain.Model.Configuration.Configuration>> GetAllConfigurations()
        {
            try
            {
                return await Configuration.ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<List<Domain.Model.Configuration.Configuration>> GetConfigurationsAsync(List<string> tags)
        {
            try
            {
                return await Configuration
                .Where(config => config.TagList
                .Intersect(tags)
                .Any()).ToListAsync();
            }
            catch (Exception ex) { throw; }
        }
    }
}
