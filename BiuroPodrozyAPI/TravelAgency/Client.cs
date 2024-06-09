using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for client entities
	/// </summary>
	public class Client : Auditable
	{
		/// <summary>
		/// Get or set id of client
		/// </summary>
		[Key]
		public int IdClient { get; set; }

		/// <summary>
		/// Gets or sets client first name
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[MinLength(3, ErrorMessage = "Imie musi mieć conajmniej 3 znaki")]
		public required string FirstName { get; set; }

		/// <summary>
		/// Gets or sets client middle name
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[MinLength(3, ErrorMessage = "Drugie imie musi mieć conajmniej 3 znaki")]
		public string? MiddleName { get; set; } = String.Empty;

		/// <summary>
		/// Gets or sets client last name
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[MinLength(3, ErrorMessage = "Nazwisko musi mieć conajmniej 3 znaki")]
		public required string LastName { get; set; }

		/// <summary>
		/// Gets or sets client sex
		/// </summary>
		[Column(TypeName = "nvarchar(1)")]
		public required string Sex { get; set; }

		/// <summary>
		/// Gets or sets client birthday
		/// </summary>
		[Column(TypeName = "date")]
		[Range(typeof(DateOnly), "1900-01-01", "2024-01-01")]
		public required DateOnly Birthday { get; set; }

		/// <summary>
		/// Gets or sets client PESEL
		/// </summary>
		[Column(TypeName = "nvarchar(11)")]
		[MaxLength(11, ErrorMessage = "PESEL musi mieć conajmniej 11 znaków")]
		public required string PESEL { get; set; }

		/// <summary>
		/// Gets or sets client phone
		/// </summary>
		[Column(TypeName = "nvarchar(11)")]
		[Phone(ErrorMessage = "Nieprawidłowy numer telefonu")]
		public required string Phone { get; set; }

		/// <summary>
		/// Gets or sets client email
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
		public required string Email { get; set; }

		/// <summary>
		/// Gets or sets client address id
		/// </summary>
		[ForeignKey("Address")]
		public int IdAddress { get; set; }

		/// <summary>
		/// Gets or sets client address
		/// </summary>
		public Address? Address { get; set; }

		/// <summary>
		/// Gets or sets client account information id
		/// </summary>
		[ForeignKey("AccountInformation")]
		public int IdAccountInformation { get; set; }

		/// <summary>
		/// Gets or sets client account information
		/// </summary>
		public AccountInformation? AccountInformation { get; set; }
	}
}
