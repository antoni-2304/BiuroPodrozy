using BiuroPodrozy.Data;

namespace BiuroPodrozy.PortalWWW.Models
{
	public class TripDetailsModel
	{
		private TripDTO? trip;
		private CityDTO? city;
		private HotelDTO? hotel;

		public TripDTO? Trip
		{
			get => trip;
			set => trip = value;
		}
		public CityDTO? City
		{
			get => city;
			set => city = value;
		}
		public HotelDTO? Hotel
		{
			get => hotel;
			set => hotel = value;
		}
	}
}
