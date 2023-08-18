using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace ConsumoAPI.Models
{
    public class API
    {

        private readonly HttpClient _httpClient;
        public API(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> SolicitudHTTP<T>(string apiUrl)
        {

            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);


            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var contentjson = JsonConvert.DeserializeObject<T>(content);
                return contentjson;
            }

            return default;
        }


    }
}
