using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpBits.Domain.Model.Configuration;

namespace CSharpBits.Service.Configuration
{
    public interface IConfigurationService
    {
        Task<List<Domain.Model.Configuration.Configuration>> GetApiUrls();
    }
}