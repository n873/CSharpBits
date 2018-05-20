using CSharpBits.Domain.Model.EntityGroup;
using CSharpBits.Repository.SomeEntityGroupModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpBits.BusinessLogic.SomeAbstraction
{
    public class SomeBusinessLogic : ISomeBusinessLogic
    {
        private readonly ISomeEntityGroupModelRepository SomeEntityGroupModelRepository;
        public SomeBusinessLogic(ISomeEntityGroupModelRepository someEntityGroupModelRepository)
        {
            SomeEntityGroupModelRepository = someEntityGroupModelRepository;
        }

        public async Task<List<SomeEntityGroupModel>> Get() {
            try
            {
                var someEntityGroupModels = await SomeEntityGroupModelRepository.Get();
                if (someEntityGroupModels != null && someEntityGroupModels.Count > 0)
                    return someEntityGroupModels;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<SomeEntityGroupModel> GetById(int id)
        {
            try
            {
                var someEntityGroupModel = await SomeEntityGroupModelRepository.GetById(id);
                if (someEntityGroupModel != null)
                    return someEntityGroupModel;
                return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<SomeEntityGroupModel> Add(SomeEntityGroupModel someEntityGroupModel, string userId)
        {
            var dateTimeNow = DateTime.Now;
            someEntityGroupModel.CreatedBy = userId;
            someEntityGroupModel.Created = dateTimeNow;
            someEntityGroupModel.LastUpdated = dateTimeNow;
            someEntityGroupModel.LastUpdatedBy = userId;

            var createSomeEntityGroupModel = await SomeEntityGroupModelRepository.Add(someEntityGroupModel);
            if (createSomeEntityGroupModel != null)
                return createSomeEntityGroupModel;
            return null;
        }

        public async Task<SomeEntityGroupModel> Update(SomeEntityGroupModel someEntityGroupModel, string userId)
        {
            someEntityGroupModel.LastUpdated = DateTime.Now;
            someEntityGroupModel.LastUpdatedBy = userId;

            var updatedSomeEntityGroupModel = await SomeEntityGroupModelRepository.Add(someEntityGroupModel);
            if (updatedSomeEntityGroupModel != null)
                return updatedSomeEntityGroupModel;
            return null;
        }

        public async Task<SomeEntityGroupModel> Delete(int id, string userId)
        {
            var someEntityGroupModel = await GetById(id);
            if (someEntityGroupModel != null)
            {
                var dateTimeNow = DateTime.Now;
                someEntityGroupModel.Deleted = true;
                someEntityGroupModel.DeletedBy = userId;
                someEntityGroupModel.DeletedDateTime = dateTimeNow;
                someEntityGroupModel.LastUpdated = dateTimeNow;
                someEntityGroupModel.LastUpdatedBy = userId;

                var updatedSomeEntityGroupModel = await SomeEntityGroupModelRepository.Add(someEntityGroupModel);
                if (updatedSomeEntityGroupModel != null)
                    return updatedSomeEntityGroupModel; 
            }
            return null;
        }
    }
}
