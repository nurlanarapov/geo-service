using System.ComponentModel.DataAnnotations;

namespace geo_service.Models.Dto
{
    /// <summary>
    /// DTO Адреса
    /// </summary>
    public class AddressDto
    {
        public AddressDto()
        {

        }

        /// <summary>
        /// Страна
        /// </summary>
        [Required]
        public string Country { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Улица
        /// </summary>
        [Required]
        public string Street { get; set; }

        /// <summary>
        /// Дом
        /// </summary>
        [Required]
        public string House { get; set; }

        /// <summary>
        /// Квартира
        /// </summary>
        [Required]
        public string Flat { get; set; }
    }
}
