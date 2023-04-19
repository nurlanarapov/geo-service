using geo_service.Middlewares;
using System.Net;

namespace geo_service.Services.Clients.DaDataClient
{
    public class DaDataClient
    {
        private HttpClient _httpClient;
        public DaDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> GetNearestAddressByLocationAsync(double lat, double lon)
        {         
            var param = new Location()
            {
                 Latitude = lat,
                 Longitude = lon,
                 Count = 10,
                 RadiusMeters= 5000,
            };

            var response = await _httpClient.PostAsJsonAsync<Location>("/suggestions/api/4_1/rs/geolocate/address", param);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<Response>();

                if (result != null)
                    return result;
                else
                    throw new ApiException("Object is null", HttpStatusCode.InternalServerError);
            }

            throw new ApiException(response?.Content?.ReadAsStringAsync().Result ?? "InternalServerError", response?.StatusCode ?? HttpStatusCode.InternalServerError);
        }
    }
}
