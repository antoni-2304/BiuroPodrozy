namespace BiuroPodrozyAPI.DTOs
{
    public class TripDTO
    {
        public int IdTrip { get; set; }

        public required string TripName { get; set; }
        public required string TripCode { get; set; }
        public required decimal TripCostPerAdult { get; set; }
        public required decimal TripCostPerChild { get; set; }
        public required string TripType { get; set; }
        public required string TripDescription { get; set; }
        public int IdDestinationCity { get; set; }
        public string DestinationCityName { get; set; }

        public int? IdHotel { get; set; }
        public string HotelName { get; set; }

        public ICollection<string> Photos { get; set; }
    }
}
