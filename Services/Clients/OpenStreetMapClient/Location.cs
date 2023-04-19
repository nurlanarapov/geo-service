using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace geo_service.Services.Clients.OpenStreetMapClient
{
    public class Location
    {
        public Location() { }

        /// <summary>
        /// Широта
        /// </summary>
        [Required]
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        [Required]
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }
    }
}
