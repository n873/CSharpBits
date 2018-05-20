using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CSharpBits.Helper.Api
{
    public class ApiHelper
    {
        private HttpClient _Client;
        protected internal string Setting;

        public ApiHelper(string _setting)
        {
            Setting = _setting;
        }

        protected internal HttpClient Client
        {
            get
            {
                if (_Client == null)
                    _Client = InstantiateClient();
                return _Client;
            }
        }

        private HttpClient InstantiateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Setting);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        protected ByteArrayContent GetByteArrayContent<T>(T data) where T : class
        {
            var byteContent = new ByteArrayContent(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return byteContent;
        }
    }
}
