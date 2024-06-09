namespace BiuroPodrozyAPI.DTOs
{
    public class HotelDTO
    {
        public int IdHotel { get; set; }
        public string HotelName { get; set; }
        public int HotelStars { get; set; }
        public decimal? HotelRating { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public decimal HotelPricePerUnit { get; set; }

        public int IdAddress { get; set; }
        public string Street { get; set; }
        public string HomeNr { get; set; }

        public int IdCity { get; set; }
        public string CityName { get; set; }

        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }

        public ICollection<string> Photos { get; set; }

    }
}
