namespace BiuroPodrozyAPI.DTOs
{
    public class CountryDTO
    {
        public int IdCountry { get; set; }
        public string CountryName { get; set; }
        public string AbbrCountryName { get; set; }
        public string Continent { get; set; }
        public int? Population { get; set; }
        public double? CountrySize { get; set; }
        public string PhoneCode { get; set; }
        public int IdCurrency { get; set; }
        public string CurrencyName { get; set; }
        public int IdLanguage { get; set; }
        public string LanguageName { get; set; }
        public int? IdCapitalCity { get; set; }
        public string CapitalCityName { get; set; }

        public ICollection<string> Photos { get; set; }
    }
}
