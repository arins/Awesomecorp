using Awesomecorp.Integration.Datasource.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Awesomecorp.Integration.Datasource
{
    public interface IAwesomeCorpDatasource
    {
        public Task<GetSubscriberResponse> GetSubscribers();
    }

    public class AwesomeCorpDatasource : IAwesomeCorpDatasource
    {
        public JsonSerializerOptions JsonSerializerOptions { get; }

        public AwesomeCorpDatasource()
        {
            JsonSerializerOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            
        }

        public AwesomeCorpDatasource(JsonSerializerOptions options)
        {
            JsonSerializerOptions = options;

        }


        public async Task<GetSubscriberResponse> GetSubscribers()
        {
            return await GetDeserilizedAsync(await GetSubscribersStream());
        }

        public async Task<Stream> GetSubscribersStream()
        {
            var client = new HttpClient();
            var stream = await client.GetStreamAsync("https://awesomecorp.relationbrand.com/api/GetSubscribers");
            return stream;
        }


        public async Task<GetSubscriberResponse> GetDeserilizedAsync(Stream stream)
        {
            return await JsonSerializer.DeserializeAsync<GetSubscriberResponse>(stream, JsonSerializerOptions);
        }
    }
}
