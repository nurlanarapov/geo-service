using geo_service.Models.Dto;
using geo_service.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace geo_service.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GeoController : ControllerBase
    {
        private readonly IGeoCodingService _geoCodingService;

        public GeoController( IGeoCodingService geoCodingService)
        {
            _geoCodingService = geoCodingService;
        }

        /// <summary>
        /// Получить локацию по адресу
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetLocationByAddress")]
        public async Task<IActionResult> GetLocationByAddress([FromQuery] AddressDto address)
        {
            var result = await _geoCodingService.GetLocationByAddressAsync(address);
            return Ok(result);
        }

        /// <summary>
        /// Получить по геопозиции ближайшие n адреса 
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetNearestAddressByLocation")]
        public IActionResult GetNearestAddressByLocation([FromQuery] LocationDto location)
        {
            var result = _geoCodingService.GetNearestAddressByLocationAsync(location);
            return Ok(result);
        }
    }
}