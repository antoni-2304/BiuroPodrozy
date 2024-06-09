using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for currencies entities
	/// </summary>
	public class Currency : Auditable
	{
		/// <summary>
		/// Get or set id of currency
		/// </summary>
		[Key]
		public int IdCurrency { get; set; }

		/// <summary>
		/// Get or set name of currency
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string CurrencyName { get; set; }

		/// <summary>
		/// Get or set symbol of currency
		/// </summary>
		[Column(TypeName = "nvarchar(3)")]
		public required string CurrencySymbol { get; set; }

		/// <summary>
		/// Get or set abbreviation of currency
		/// </summary>
		[Column(TypeName = "nvarchar(3)")]
		[MinLength(3, ErrorMessage = "Skrót nazwy waluty musi mieć co najmniej 3 znaki")]
		public required string AbbrCurrency { get; set; }

		/// <summary>
		/// Get or set list of countries that use this currency
		/// </summary>
		public ICollection<Country> Countries { get; set; } = new List<Country>();
	}
}
