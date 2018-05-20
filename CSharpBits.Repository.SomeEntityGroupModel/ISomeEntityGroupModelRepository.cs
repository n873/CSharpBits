using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpBits.Domain.Model.EntityGroup;
using Microsoft.EntityFrameworkCore;

namespace CSharpBits.Repository.SomeEntityGroupModel
{
    public interface ISomeEntityGroupModelRepository
    {
        DbSet<Domain.Model.EntityGroup.SomeEntityGroupModel> SomeEntityGroupModel { get; set; }

        Task<Domain.Model.EntityGroup.SomeEntityGroupModel> Add(Domain.Model.EntityGroup.SomeEntityGroupModel someEntityGroupModel);
        Task<List<Domain.Model.EntityGroup.SomeEntityGroupModel>> Get();
        Task<Domain.Model.EntityGroup.SomeEntityGroupModel> GetById(int id);
        Task<Domain.Model.EntityGroup.SomeEntityGroupModel> Update(Domain.Model.EntityGroup.SomeEntityGroupModel someEntityGroupModel);
    }
}