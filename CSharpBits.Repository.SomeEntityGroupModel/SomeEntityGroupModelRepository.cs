using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpBits.Repository.SomeEntityGroupModel
{
    public class SomeEntityGroupModelRepository : DbContext, ISomeEntityGroupModelRepository
    {
        public SomeEntityGroupModelRepository(DbContextOptions<SomeEntityGroupModelRepository> options) : base(options) { }

        public DbSet<Domain.Model.EntityGroup.SomeEntityGroupModel> SomeEntityGroupModel { get; set; }

        public async Task<List<Domain.Model.EntityGroup.SomeEntityGroupModel>> Get()
        {
            try
            {
                ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                return await SomeEntityGroupModel.ToListAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<Domain.Model.EntityGroup.SomeEntityGroupModel> GetById(int id)
        {
            try
            {
                ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                return await SomeEntityGroupModel.FirstOrDefaultAsync();
            }
            catch (Exception) { throw; }
        }

        public async Task<Domain.Model.EntityGroup.SomeEntityGroupModel> Add(Domain.Model.EntityGroup.SomeEntityGroupModel someEntityGroupModel)
        {
            try
            {
                var createdSomeEntityGroupModel = SomeEntityGroupModel.Add(someEntityGroupModel);
                await SaveChangesAsync();
                if (createdSomeEntityGroupModel?.Entity != null)
                    return createdSomeEntityGroupModel.Entity;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<Domain.Model.EntityGroup.SomeEntityGroupModel> Update(Domain.Model.EntityGroup.SomeEntityGroupModel someEntityGroupModel)
        {
            try
            {
                var updatedSomeEntityGroupModel = SomeEntityGroupModel.Update(someEntityGroupModel);
                await SaveChangesAsync();
                if (updatedSomeEntityGroupModel?.Entity != null)
                    return updatedSomeEntityGroupModel.Entity;
                return null;
            }
            catch (Exception) { throw; }
        }
    }
}
