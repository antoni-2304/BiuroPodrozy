using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for languages entities
	/// </summary>
	public partial class Language : Auditable
	{
		/// <summary>
		/// Gets or sets the id of the language
		/// </summary>
		[Key]
		public int IdLanguage { get; set; }

		/// <summary>
		/// Gets or sets the name of the language
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string LanguageName { get; set; }

		/// <summary>
		/// Gets or sets the abbreviation of the language
		/// </summary>
		[Column(TypeName = "nvarchar(10)")]
		public required string AbbrLanguageName { get; set; }

		/// <summary>
		/// Gets or sets the countries that use this language
		/// </summary>
		public ICollection<Country> Countries { get; set; } = new List<Country>();

	}
}
