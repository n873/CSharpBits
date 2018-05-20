using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpBits.Domain.Model.EntityGroup;

namespace CSharpBits.BusinessLogic.SomeAbstraction
{
    public interface ISomeBusinessLogic
    {
        Task<SomeEntityGroupModel> Add(SomeEntityGroupModel someEntityGroupModel, string userId);
        Task<SomeEntityGroupModel> Delete(int id, string userId);
        Task<List<SomeEntityGroupModel>> Get();
        Task<SomeEntityGroupModel> GetById(int id);
        Task<SomeEntityGroupModel> Update(SomeEntityGroupModel someEntityGroupModel, string userId);
    }
}