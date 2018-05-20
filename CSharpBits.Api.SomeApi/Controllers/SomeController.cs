using CSharpBits.BusinessLogic.SomeAbstraction;
using CSharpBits.Domain.Model.EntityGroup;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpBits.Api.SomeApi.Controllers
{
    [Route("CSharpBits/[controller]")]
    public class SomeController : ControllerBase
    {
        private readonly ISomeBusinessLogic SomeBusinessLogic;

        public SomeController(ISomeBusinessLogic someBusinessLogic)
        {
            SomeBusinessLogic = someBusinessLogic;
        }

        [HttpGet("SomeData")]
        public async Task<List<SomeEntityGroupModel>> Get()
        {
            try
            {
                var someDate = await SomeBusinessLogic.Get();
                if (someDate != null && someDate.Count > 0)
                    return someDate;
                return null;
            }
            catch (Exception) { throw; }
        }

        [HttpGet("SomeData/id={id}")]
        public async Task<List<SomeEntityGroupModel>> Get(int id)
        {
            try
            {
                var someDate = await SomeBusinessLogic.Get();
                if (someDate != null && someDate.Count > 0)
                    return someDate;
                return null;
            }
            catch (Exception) { throw; }
        }

        [HttpPost("SomeData/userId={userId}")]
        public async Task<SomeEntityGroupModel> Add([FromBody]SomeEntityGroupModel someEntityGroupModel, string userId)
        {
            try
            {
                var someDate = await SomeBusinessLogic.Add(someEntityGroupModel, userId);
                if (someDate != null)
                    return someDate;
                return null;
            }
            catch (Exception) { throw; }
        }

        [HttpPut("SomeData/userId={userId}")]
        public async Task<SomeEntityGroupModel> Update([FromBody]SomeEntityGroupModel someEntityGroupModel, string userId)
        {
            try
            {
                var someDate = await SomeBusinessLogic.Update(someEntityGroupModel, userId);
                if (someDate != null)
                    return someDate;
                return null;
            }
            catch (Exception) { throw; }
        }

        [HttpDelete("SomeData/id={id}/userId={userId}")]
        public async Task<SomeEntityGroupModel> Delete(int id, string userId)
        {
            try
            {
                var someDate = await SomeBusinessLogic.Delete(id, userId);
                if (someDate != null)
                    return someDate;
                return null;
            }
            catch (Exception) { throw; }
        }
    }
}
