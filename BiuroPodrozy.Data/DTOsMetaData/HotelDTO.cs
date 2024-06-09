using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(HotelDTOMetaData))]
    public partial class HotelDTO
    {
        public sealed class HotelDTOMetaData
        {
            [Key]
            public int IdHotel { get; set; }


            [Required(ErrorMessage = "Nazwa hotelu jest wymagana")]
            [Display(Name = "Nazwa hotelu")]
            public required string HotelName { get; set; }


            [Required(ErrorMessage = "Liczba gwiazdek hotelu jest wymagana")]
            [Display(Name = "Liczba gwiazdek hotelu")]
            [Range(0, 5, ErrorMessage = "Liczba gwiazdek hotelu musi zawierać się w przedziale od 0 do 5")]
            public int HotelStars { get; set; }


            [Display(Name = "Ocena hotelu")]
            [Range(0, 5, ErrorMessage = "Ocena hotelu musi zawierać się w przedziale od 0 do 5")]
            public decimal? HotelRating { get; set; }


            [Required(ErrorMessage = "Numer telefonu jest wymagany")]
            [Display(Name = "Numer telefonu")]
            [Phone(ErrorMessage = "Nieprawidłowy numer telefonu")]
            public required string Phone { get; set; }

            [Required(ErrorMessage = "Adres e-mail jest wymagany")]
            [Display(Name = "Adres e-mail")]
            [EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
            public required string Email { get; set; }


            [Display(Name = "Opis hotelu")]
            public string? Description { get; set; }


            [Required(ErrorMessage = "Kwota za jeden pokój jest wymagana")]
            [Display(Name = "Kwota za jeden pokój")]
            public decimal HotelPricePerUnit { get; set; }


            [Required(ErrorMessage = "Nazwa ulicy jest wymagana")]
            [Display(Name = "Nazwa ulicy")]
            public required string Street { get; set; }


            [Required(ErrorMessage = "Numer budynku jest wymagany")]
            [Display(Name = "Numer budynku")]
            public required string HomeNr { get; set; }


            [Display(Name = "Nazwa miasta")]
            public string CityName { get; set; }


            [Display(Name = "Szerokość geograficzna")]
            public decimal? Latitude { get; set; }


            [Display(Name = "Długość geograficzna")]
            public decimal? Longitude { get; set; }


            [Display(Name = "Zdjęcia")]
            public ICollection<string> Photos { get; set; }
        }

    }
}
