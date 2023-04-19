using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace geo_service.Models.Dto
{
    /// <summary>
    /// Локация
    /// </summary>
    public class LocationDto
    {
        public LocationDto() { }

        /// <summary>
        /// Широта
        /// </summary>
        [Required]
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        [Required]
        public double Longitude { get; set; }
    }
}
