using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(CityDTOMetaData))]
    public partial class CityDTO
    {
        public sealed class CityDTOMetaData
        {
            [Key]
            public int IdCity { get; set; }

            [Required(ErrorMessage = "Nazwa miasta jest wymagana")]
            [Display(Name = "Nazwa miasta")]
            public required string CityName { get; set; }


            [Required(ErrorMessage = "Kod pocztowy jest wymagany")]
            [Display(Name = "Kod pocztowy")]
            [RegularExpression(@"^[a-zA-Z0-9-]+$", ErrorMessage = "Nieprawidłowy format")]
            public required string PostalCode { get; set; }


            [Display(Name = "Populacja")]
            public int? Population { get; set; }

            [Display(Name = "Nazwa kraju")]
            public string CountryName { get; set; }
        }
    }
}
