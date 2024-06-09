using BiuroPodrozyAPI.CMS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for employees entities
	/// </summary>
	public class Employee : Auditable
	{
		/// <summary>
		/// Gets or sets id of employee
		/// </summary>
		[Key]
		public int IdEmployee { get; set; }

		/// <summary>
		/// Gets or sets first name of employee
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[MinLength(3, ErrorMessage = "Imie musi mieć conajmniej 3 znaki")]
		public required string FirstName { get; set; }

		/// <summary>
		/// Gets or sets middle name of employee
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[MinLength(3, ErrorMessage = "Drugie imie musi mieć conajmniej 3 znaki")]
		public string? MiddleName { get; set; } = String.Empty;

		/// <summary>
		/// Gets or sets last name of employee
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[MinLength(3, ErrorMessage = "Nazwisko musi mieć conajmniej 3 znaki")]
		public required string LastName { get; set; }

		/// <summary>
		/// Gets or sets sex of employee
		/// </summary>
		[Column(TypeName = "nvarchar(1)")]
		public required string Sex { get; set; }

		/// <summary>
		/// Gets or sets birthday of employee
		/// </summary>
		[Column(TypeName = "date")]
		[Range(typeof(DateOnly), "1900-01-01", "2024-01-01")]
		public required DateOnly Birthday { get; set; }

		/// <summary>
		/// Gets or sets PESEL of employee
		/// </summary>
		[Column(TypeName = "nvarchar(11)")]
		[MaxLength(11, ErrorMessage = "PESEL musi mieć conajmniej 11 znaków")]
		public required string PESEL { get; set; }

		/// <summary>
		/// Gets or sets phone number of employee
		/// </summary>
		[Column(TypeName = "nvarchar(11)")]
		[Phone(ErrorMessage = "Nieprawidłowy numer telefonu")]
		public required string Phone { get; set; }

		/// <summary>
		/// Gets or sets email of employee
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[EmailAddress(ErrorMessage = "Nieprawidłowy adres e-mail")]
		public required string Email { get; set; }

		/// <summary>
		/// Gets or sets id address of employee
		/// </summary>
		[ForeignKey("Address")]
		public int IdAddress { get; set; }

		/// <summary>
		/// Gets or sets address of employee
		/// </summary>
		public Address? Address { get; set; }

		/// <summary>
		/// Gets or sets id account information of employee
		/// </summary>
		[ForeignKey("AccountInformation")]
		public int IdAccountInformation { get; set; }

		/// <summary>
		/// Gets or sets account information of employee
		/// </summary>
		public AccountInformation? AccountInformation { get; set; }

		/// <summary>
		/// Gets or sets cards made by employee
		/// </summary>
		public ICollection<Card> Cards { get; set; } = new List<Card>();
	}
}
