using BiuroPodrozyAPI.CMS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for hotel entities
	/// </summary>
	public class Hotel : Auditable
	{
		/// <summary>
		/// Gets or sets hotel id
		/// </summary>
		[Key]
		public int IdHotel { get; set; }

		/// <summary>
		/// Gets or sets hotel name
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string HotelName { get; set; }

		/// <summary>
		/// Gets or sets hotel stars
		/// </summary>
		[Range(0, 5, ErrorMessage = "Liczba gwiazdek hotelu musi zawierać się w przedziale od 0 do 5")]
		public int HotelStars { get; set; }

		/// <summary>
		/// Gets or sets hotel rating
		/// </summary>
		[Range(0, 5, ErrorMessage = "Ocena hotelu musi zawierać się w przedziale od 0 do 5")]
		public decimal? HotelRating { get; set; }

		/// <summary>
		/// Gets or sets hotel address id
		/// </summary>
		[ForeignKey("Address")]
		public int IdAddress { get; set; }

		/// <summary>
		/// Gets or sets hotel address
		/// </summary>
		public required Address Address { get; set; }

		/// <summary>
		/// Gets or sets hotel phone
		/// </summary>
		[Column(TypeName = "nvarchar(11)")]
		[Phone(ErrorMessage = "Nieprawidłowy numer telefonu")]
		public required string Phone { get; set; }

		/// <summary>
		/// Gets or sets hotel email
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
		public required string Email { get; set; }

		/// <summary>
		/// Gets or sets hotel description
		/// </summary>
		[Column(TypeName = "nvarchar(2000)")]
		public string? Description { get; set; }

		/// <summary>
		/// Gets or sets hotel price per unit
		/// </summary>
		[Column(TypeName = "money")]
		public decimal HotelPricePerUnit { get; set; }

		/// <summary>
		/// Gets or sets reservations for this hotel
		/// </summary>
		public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

		/// <summary>
		/// Gets or sets photos of this hotel
		/// </summary>
		public ICollection<HotelPhoto> Photos { get; set; } = new List<HotelPhoto>();

		/// <summary>
		/// Gets or sets trips for this hotel
		/// </summary>
		public ICollection<Trip> Trips { get; set; } = new List<Trip>();

	}
}
