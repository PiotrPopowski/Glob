using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Glob.Infrastructure.Services
{
    public class HttpClientWrapper
    {
        private static HttpClient httpClient;

        static HttpClientWrapper()
        {
            httpClient = new HttpClient();
        }

        public static void Authenticate(string token)
        {
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        
        public static async Task<T> PostAsync<T>(string requestUri, IRequest content) where T: class
        {
            var json = JsonConvert.SerializeObject(content);
            var result = await httpClient.PostAsync(requestUri, new StringContent(json, Encoding.UTF8, "application/json"));
            var stringResult = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResult);
        }

        public static async Task<HttpResponseMessage> PostAsync(string requestUri, IRequest content)
        {
            var json = JsonConvert.SerializeObject(content);
            return await httpClient.PostAsync(requestUri, new StringContent(json, Encoding.UTF8, "application/json"));
        }
        public static async Task<HttpResponseMessage> PostAsync(string requestUri, string content)
        {
            return await httpClient.PostAsync(requestUri, new StringContent(content, Encoding.UTF8, "application/json"));
        }

        public static async Task<T> GetAsync<T>(string requestUri) where T: class
        {
            var result = await httpClient.GetAsync(requestUri);
            var stringResult = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(stringResult);
        }

        public static async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await httpClient.GetAsync(requestUri);
        }

    }
}
