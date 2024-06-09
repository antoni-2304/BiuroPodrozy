using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for flight entities
	/// </summary>
	public class Flight : Auditable
	{
		/// <summary>
		/// Gets or sets id of flight
		/// </summary>
		[Key]
		public int IdFlight { get; set; }

		/// <summary>
		/// Gets or sets flight number
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string FlightNumber { get; set; }

		/// <summary>
		/// Gets or sets id of departure city
		/// </summary>
		public int IdDepartureCity { get; set; }

		/// <summary>
		/// Gets or sets departure city
		/// </summary>
		public City? DepartureCity { get; set; }

		/// <summary>
		/// Gets or sets departure time
		/// </summary>
		[Column(TypeName = "datetime")]
		public required DateTime DepartureTime { get; set; }

		/// <summary>
		/// Gets or sets id of arrival city
		/// </summary>
		public int IdArrivalCity { get; set; }

		/// <summary>
		/// Gets or sets arrival city
		/// </summary>
		public City? ArrivalCity { get; set; }

		/// <summary>
		/// Gets or sets arrival time
		/// </summary>
		[Column(TypeName = "datetime")]
		public required DateTime ArrivalTime { get; set; }

		/// <summary>
		/// Gets or sets flight status
		/// </summary>
		public required string FlightStatus { get; set; }

		/// <summary>
		/// Gets or sets flight price per unit
		/// </summary>
		[Column(TypeName = "money")]
		public decimal FlightPricePerUnit { get; set; }

		/// <summary>
		/// Gets or sets reservations for this departure flight
		/// </summary>
		public ICollection<Reservation> ReservationsDep { get; set; } = new List<Reservation>();

		/// <summary>
		/// Gets or sets reservations for this arrival flight
		/// </summary>
		public ICollection<Reservation> ReservationsArr { get; set; } = new List<Reservation>();
	}
}
