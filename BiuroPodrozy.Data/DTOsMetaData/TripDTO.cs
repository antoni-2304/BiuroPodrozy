using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(TripDTOMetaData))]
    public partial class TripDTO
    {
        public sealed class TripDTOMetaData
        {
            [Key]
            public int IdTrip { get; set; }

            [Required(ErrorMessage = "Nazwa wycieczki jest wymagana")]
            [Display(Name = "Nazwa wycieczki")]
            public required string TripName { get; set; }

            [Required(ErrorMessage = "Kod wycieczki jest wymagany")]
            [Display(Name = "Kod wycieczki")]
            public required string TripCode { get; set; }


            [Required(ErrorMessage = "Koszt wycieczki dla dorosłego jest wymagany")]
            [Display(Name = "Koszt wycieczki (dorosły)")]
            public required decimal TripCostPerAdult { get; set; }


            [Required(ErrorMessage = "Koszt wycieczki dla dziecka jest wymagany")]
            [Display(Name = "Koszt wycieczki (dziecko)")]
            public required decimal TripCostPerChild { get; set; }


            [Required(ErrorMessage = "Rodzaj wycieczki jest wymagany")]
            [Display(Name = "Rodzaj wycieczki")]
            [AllowedValues("Objazd", "Wypoczynek")]
            public required string TripType { get; set; }


            [Required(ErrorMessage = "Opis wycieczki jest wymagany")]
            [Display(Name = "Opis wycieczki")]
            public required string TripDescription { get; set; }


            [Display(Name = "Miasto docelowe wycieczki")]
            public string DestinationCityName { get; set; }


            [Display(Name = "Hotel docelowy")]
            public string HotelName { get; set; }


            [Display(Name = "Zdjęcia")]
            public ICollection<string>? Photos { get; set; }
        }
    }
}
