using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for cities entities
	/// </summary>
	public class City : Auditable
	{
		/// <summary>
		/// Get or set id of city
		/// </summary>
		[Key]
		public int IdCity { get; set; }

		/// <summary>
		/// Get or set name of city
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string CityName { get; set; }

		/// <summary>
		/// Get or set postal code of city
		/// </summary>
		[Column(TypeName = "nvarchar(20)")]
		[RegularExpression(@"^[a-zA-Z0-9-]+$", ErrorMessage = "Nieprawidłowy format")]
		public required string PostalCode { get; set; }

		/// <summary>
		/// Get or set population of city
		/// </summary>
		public int? Population { get; set; }

		/// <summary>
		/// Get or set id of country
		/// </summary>
		public int IdCountry { get; set; }

		/// <summary>
		/// Get or set country
		/// </summary>
		public Country? Country { get; set; }

		/// <summary>
		/// Get or set addresses
		/// </summary>
		public ICollection<Address> Addresses { get; set; } = new List<Address>();

		/// <summary>
		/// Get or set reservations
		/// </summary>
		public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

		/// <summary>
		/// Get or set flights departing
		/// </summary>
		public ICollection<Flight> FlightsDep { get; set; } = new List<Flight>();

		/// <summary>
		/// Get or set flights arriving
		/// </summary>
		public ICollection<Flight> FlightsArr { get; set; } = new List<Flight>();

		/// <summary>
		/// Get or set trips
		/// </summary>
		public ICollection<Trip> Trips { get; set; } = new List<Trip>();

	}
}
