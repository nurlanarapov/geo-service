using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace geo_service.Services.Clients.DaDataClient
{
    public class Location
    {

        /// <summary>
        /// Широта
        /// </summary>
        [JsonPropertyName("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        [JsonPropertyName("lon")]
        public double Longitude { get; set; }

        /// <summary>
        /// Количество ближайших точек
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }

        /// <summary>
        /// Радиус в метрах
        /// </summary>
        [JsonPropertyName("radius_meters")]
        public double RadiusMeters { get; set; }
    }
}
