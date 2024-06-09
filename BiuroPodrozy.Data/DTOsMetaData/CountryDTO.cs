using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(CountryDTOMetaData))]
    public partial class CountryDTO
    {
        public sealed class CountryDTOMetaData
        {
            [Key]
            public int IdCountry { get; set; }


            [Required(ErrorMessage = "Nazwa kraju jest wymagana")]
            [Display(Name = "Nazwa kraju")]
            public required string CountryName { get; set; }


            [Required(ErrorMessage = "Skrót nazwy kraju jest wymagany")]
            [Display(Name = "Skrót nazwy kraju")]
            [MaxLength(3, ErrorMessage = "Skrót nazwy kraju nie może być dłuższy niż 3 znaki")]
            public required string AbbrCountryName { get; set; }


            [Required(ErrorMessage = "Kontynent jest wymagany")]
            [Display(Name = "Kontynent")]
            [AllowedValues("Europa", "Azja", "Afryka", "Australia i Oceania", "Ameryka Północna", "Ameryka Południowa")]
            public required string Continent { get; set; }


            [Display(Name = "Populacja")]
            public int? Population { get; set; }


            [Display(Name = "Powierzchnia kraju (km²)")]
            [Range(0, Double.MaxValue, ErrorMessage = "Powierzchnia kraju musi być dodatnia")]
            public double? CountrySize { get; set; }


            [Required(ErrorMessage = "Kod kierunkowy jest wymagany")]
            [Display(Name = "Kod kierunkowy")]
            [RegularExpression(@"^[0-9]{2,3}$", ErrorMessage = "Nieprawidłowy format")]
            public required string PhoneCode { get; set; }


            [Display(Name = "Główna waluta")]
            public string CurrencyName { get; set; }


            [Display(Name = "Główny język")]
            public string LanguageName { get; set; }


            [Display(Name = "Stolica")]
            public string CapitalCityName { get; set; }


            [Display(Name = "Zdjęcia")]
            public ICollection<string> Photos { get; set; }
        }
    }
}
