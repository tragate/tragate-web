using System.IO;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Tragate.UI.BuildingBlocks.ApiClient
{
    public class RestClient : IRestClient
    {
        private readonly HttpClient _httpClient;
        public RestClient()
        {
            _httpClient = new HttpClient();
        }

        public T Delete<T>(string uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            var response = _httpClient.DeleteAsync(requestMessage.RequestUri).Result;
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public T Get<T>(string uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            var response = _httpClient.GetAsync(requestMessage.RequestUri).Result;
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public T Patch<T>(string uri, object item)
        {
            var requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), uri);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8,
                "application/json");
            var response = _httpClient.SendAsync(requestMessage).Result;
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public T Patch<T>(string uri)
        {
            var requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), uri);         
            var response = _httpClient.SendAsync(requestMessage).Result;
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public T Post<T>(string uri, object item)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
            var response = _httpClient.SendAsync(requestMessage).Result;
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public T PostMultipartContent<T>(string uri, IFormFile file)
        {
            byte[] data;
            using (var br = new BinaryReader(file.OpenReadStream()))
                data = br.ReadBytes((int)file.OpenReadStream().Length);

            ByteArrayContent bytes = new ByteArrayContent(data);
            MultipartFormDataContent multiContent = new MultipartFormDataContent();
            multiContent.Add(bytes, "files", file.FileName);

            var response = _httpClient.PostAsync(uri, multiContent).Result;            
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
        
        public T Put<T>(string uri, object item)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri);
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
            var response = _httpClient.SendAsync(requestMessage).Result;
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
    }
}