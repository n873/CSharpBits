using CSharpBits.Domain.Model.Common;
using CSharpBits.Domain.Model.EntityGroup;
using CSharpBits.Helper.Api;
using CSharpBits.Settings.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharpBits.Helper.SomeApi
{
    public class SomeApiHelper : ApiHelper
    {
        public SomeApiHelper() : base(ApiSettings.GetSomeApi()) { }

        public async Task<SomeEntityGroupModel> GetSomeDataById(int id)
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync($"SomeApiControllerName/id={id}");

                var content = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    content.Wait();
                    return JsonConvert.DeserializeObject<SomeEntityGroupModel>(content.Result);
                }
                else
                {
                    content.Wait();
                }

                return null;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<List<SomeEntityGroupModel>> GetSomeData()
        {
            try
            {
                HttpResponseMessage response = await Client.GetAsync($"SomeApiControllerName");

                var content = response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    content.Wait();
                    return JsonConvert.DeserializeObject<List<SomeEntityGroupModel>>(content.Result);
                }
                else
                {
                    content.Wait();
                }

                return null;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<Result> AddSomeData(SomeEntityGroupModel someData, string userId)
        {
            try
            {
                var response = await Client.PostAsync($"SomeApiControllerName/SomeApiAddEndpoint/userId={userId}", GetByteArrayContent(someData));
                if (response.IsSuccessStatusCode)
                {
                    var task = response.Content.ReadAsStringAsync();
                    task.Wait();
                    var result = task.Result;
                    return JsonConvert.DeserializeObject<Result>(result);
                }
                else
                    return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<Result> AddSomeData(List<SomeEntityGroupModel> someData, string userId) 
        {
            try
            {
                var response = await Client.PostAsync($"SomeApiControllerName/SomeApiAddListEndpoint/userId={userId}", GetByteArrayContent(someData));
                if (response.IsSuccessStatusCode)
                {
                    var task = response.Content.ReadAsStringAsync();
                    task.Wait();
                    var result = task.Result;
                    return JsonConvert.DeserializeObject<Result>(result);
                }
                else
                    return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<Result> UpdateSomeData(SomeEntityGroupModel someData, string userId)
        {
            try
            { 
                var response = await Client.PutAsync($"SomeApiControllerName/SomeApiAddEndpoint/userId={userId}", GetByteArrayContent(someData));
                if (response.IsSuccessStatusCode)
                {
                    var task = response.Content.ReadAsStringAsync();
                    task.Wait();
                    var result = task.Result;
                    return JsonConvert.DeserializeObject<Result>(result);
                }
                else
                    return null;
            }
            catch (Exception) { throw; }
        }

        public async Task<Result> DeleteSomeData(int id, string userId)
        {
            try
            {
                var response = await Client.DeleteAsync($"SomeApiControllerName/SomeApiAddEndpoint/userId={userId}/id={id}");
                if (response.IsSuccessStatusCode)
                {
                    var task = response.Content.ReadAsStringAsync();
                    task.Wait();
                    var result = task.Result;
                    return JsonConvert.DeserializeObject<Result>(result);
                }
                else
                    return null;
            }
            catch (Exception) { throw; }
        }
    }
}
