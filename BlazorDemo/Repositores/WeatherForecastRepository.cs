using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorDemo.Models;
using BlazorDemo.Pages;

namespace BlazorDemo.Repositores
{
    public class WeatherForecastRepository
    {
        private readonly HttpClient _client;
        public WeatherForecastRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task<List<WeatherForecast>> GetForecasts()
        {
            var response = await _client.GetAsync("weatherforecast");
            var content = await response.Content.ReadAsStringAsync();
            var forecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return forecasts;
        }
    }
}
