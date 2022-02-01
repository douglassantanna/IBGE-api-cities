using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cities
{
    public class CitiesApi : ICities
    {
        HttpClient _httpClient;
        public CitiesApi(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<List<City>> Get()
        {
            var request = await _httpClient.GetAsync(_httpClient.BaseAddress);
            if(request.StatusCode == System.Net.HttpStatusCode.OK){
                string json = await request.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<City>>(json);
            }
            throw new Exception("ocorreu um erro");
        }

    }
}