using geo_service.Models.Dto;
using geo_service.Services.Clients.DaDataClient;
using geo_service.Services.Clients.OpenStreetMapClient;

namespace geo_service.Services
{
    public class GeoCodingService : IGeoCodingService
    {
        private readonly ILogger<GeoCodingService> _logger;
        private readonly OpenStreetMapClient _mapClient;
        DaDataClient _daDataClient;
        private readonly IConfiguration _config;

        public GeoCodingService(IConfiguration config, ILogger<GeoCodingService> logger, OpenStreetMapClient mapClient, DaDataClient daDataClient)
        {
            _logger = logger;
            _config = config;
            _mapClient = mapClient;
            _daDataClient = daDataClient;
        }

        public async Task<LocationDto> GetLocationByAddressAsync(AddressDto addressDto)
        {
            var result = await _mapClient.GetLocationByAddressAsync(addressDto.Country, addressDto.City, addressDto.Street);

            return new LocationDto()
            {
                 Latitude= result.Latitude,
                 Longitude= result.Longitude
            };
        }

        public async Task<List<AddressDto>> GetNearestAddressByLocationAsync(LocationDto locationDto)
        {
            var result = await _daDataClient.GetNearestAddressByLocationAsync(locationDto.Latitude, locationDto.Longitude);

            var address = new List<AddressDto>();

            foreach (var item in result.Suggestions)
            {
                address.Add(new AddressDto()
                {
                    Country = item.data.country,
                    City = item.data.city,
                    Street = item.data.street,
                    House = item.data.house,
                    Flat = item.data.flat
                });
            }

            return address;
        }
    }
}