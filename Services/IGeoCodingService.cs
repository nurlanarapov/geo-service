using geo_service.Models.Dto;

namespace geo_service.Services
{
    public interface IGeoCodingService
    {
        /// <summary>
        /// Получить локацию по адресу
        /// </summary>
        /// <param name="addressDto"></param>
        /// <returns></returns>
        Task<LocationDto> GetLocationByAddressAsync(AddressDto addressDto);

        /// <summary>
        /// Получить по геопозиции ближайшие n адреса 
        /// </summary>
        /// <param name="locationDto"></param>
        /// <returns></returns>
        Task<List<AddressDto>> GetNearestAddressByLocationAsync(LocationDto locationDto);
    }
}