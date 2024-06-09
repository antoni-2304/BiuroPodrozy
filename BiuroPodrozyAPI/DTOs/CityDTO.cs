namespace BiuroPodrozyAPI.DTOs
{
    public class CityDTO
    {
        public int IdCity { get; set; }
        public string CityName { get; set; }
        public string PostalCode { get; set; }
        public int? Population { get; set; }
        public int IdCountry { get; set; }
        public string CountryName { get; set; }
    }
}
