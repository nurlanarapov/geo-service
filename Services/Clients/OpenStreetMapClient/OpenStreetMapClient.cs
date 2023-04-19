using geo_service.Middlewares;
using geo_service.Models.Dto;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;

namespace geo_service.Services.Clients.OpenStreetMapClient
{
    public class OpenStreetMapClient
    {
        private HttpClient _httpClient;
        public OpenStreetMapClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Location> GetLocationByAddressAsync(string country, string city, string street)
        {
            var response = await _httpClient.GetAsync($"/search?country={country}&city={city}&street={street}&format=json&limit=1");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<List<Location>>();

                if (result != null)
                    return result?.FirstOrDefault() ?? new Location();
                else
                    throw new ApiException("Object is null", HttpStatusCode.InternalServerError);
            }

            throw new ApiException(response?.Content?.ReadAsStringAsync().Result ?? "InternalServerError", response?.StatusCode ?? HttpStatusCode.InternalServerError);
        }
    }
}
