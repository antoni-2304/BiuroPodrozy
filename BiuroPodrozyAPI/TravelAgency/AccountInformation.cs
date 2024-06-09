using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for account information entities
	/// </summary>
	public class AccountInformation : Auditable
	{
		/// <summary>
		/// Gets or sets the id of the account information
		/// </summary>
		[Key]
		public int IdAccountInformation { get; set; }

		/// <summary>
		/// Gets or sets the login of the account
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[MinLength(8, ErrorMessage = "Login musi mieć conajmniej 8 znaków")]
		public required string Login { get; set; }

		/// <summary>
		/// Gets or sets the encoded password of the account
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		[MinLength(8, ErrorMessage = "Hasło musi mieć conajmniej 8 znaków")]
		public required string EncodedPassword { get; set; }

		/// <summary>
		/// Gets or sets the validity time of the password
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string PasswordValidityTime { get; set; }

		/// <summary>
		/// Gets or sets the clients of the account
		/// </summary>
		public ICollection<Client> Clients { get; set; } = new List<Client>();

		/// <summary>
		/// Gets or sets the employees of the account
		/// </summary>
		public ICollection<Employee> Employees { get; set; } = new List<Employee>();
	}
}
