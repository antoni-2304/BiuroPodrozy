using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for reservations entities
	/// </summary>
	public class Reservation : Auditable
	{
		/// <summary>
		/// Gets or sets id of reservation
		/// </summary>
		[Key]
		public int IdReservation { get; set; }

		/// <summary>
		/// Gets or sets reservation code
		/// </summary>
		[Column(TypeName = "nvarchar(25)")]
		public required string ReservationCode { get; set; }

		/// <summary>
		/// Gets or sets reservation type
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string ReservationType { get; set; }

		/// <summary>
		/// Gets or sets attendee count
		/// </summary>
		[Range(1, 100, ErrorMessage = "Ilość uczestników musi zawierać się w przedziale 1-100")]
		public int AttendeeCount { get; set; }

		/// <summary>
		/// Gets or sets id of departure flight
		/// </summary>
		public int IdDepartureFlight { get; set; }

		/// <summary>
		/// Gets or sets departure flight
		/// </summary>
		public Flight? DepartureFlight { get; set; }

		/// <summary>
		/// Gets or sets id of arrival flight
		/// </summary>
		public int IdArrivalFlight { get; set; }

		/// <summary>
		/// Gets or sets arrival flight
		/// </summary>
		public Flight? ArrivalFlight { get; set; }

		/// <summary>
		/// Gets or sets id of hotel
		/// </summary>
		[ForeignKey("Hotel")]
		public int IdHotel { get; set; }

		/// <summary>
		/// Gets or sets hotel
		/// </summary>
		public Hotel? Hotel { get; set; }

		/// <summary>
		/// Gets or sets additional info for reservation
		/// </summary>
		[Column(TypeName = "nvarchar(200)")]
		public string? AdditionalInfo { get; set; } = String.Empty;

		/// <summary>
		/// Gets or sets payment due date
		/// </summary>
		[Column(TypeName = "datetime")]
		public required DateTime PaymentDate { get; set; }

		/// <summary>
		/// Gets or sets payment amount
		/// </summary>
		[Column(TypeName = "money")]
		public required decimal PaymentAmount { get; set; }

		/// <summary>
		/// Gets or sets id of trip
		/// </summary>
		[ForeignKey("Trip")]
		public int IdTrip { get; set; }

		/// <summary>
		/// Gets or sets trip
		/// </summary>
		public Trip? Trip { get; set; }

		/// <summary>
		/// Gets or sets services for reservation
		/// </summary>
		public ICollection<Service> Services { get; set; } = new List<Service>();

	}
}
