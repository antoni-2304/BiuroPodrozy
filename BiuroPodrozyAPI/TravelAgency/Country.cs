using BiuroPodrozyAPI.CMS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for countries entities
	/// </summary>
	public class Country : Auditable
	{
		/// <summary>
		/// Gets or sets the id of the country
		/// </summary>
		[Key]
		public int IdCountry { get; set; }

		/// <summary>
		/// Gets or sets the name of the country
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string CountryName { get; set; }

		/// <summary>
		/// Gets or sets the abbreviation of the country
		/// </summary>
		[Column(TypeName = "nvarchar(3)")]
		[MaxLength(3, ErrorMessage = "Skrót nazwy kraju nie może być dłuższy niż 3 znaki")]
		public required string AbbrCountryName { get; set; }

		/// <summary>
		/// Gets or sets the continent of the country
		/// </summary>
		[Column(TypeName = "nvarchar(25)")]
		public required string Continent { get; set; }

		/// <summary>
		/// Gets or sets the population of the country
		/// </summary>
		public int? Population { get; set; }

		/// <summary>
		/// Gets or sets the size of the country
		/// </summary>
		[Range(0, Double.MaxValue, ErrorMessage = "Powierzchnia kraju musi być dodatnia")]
		public double? CountrySize { get; set; }

		/// <summary>
		/// Gets or sets the phone code of the country
		/// </summary>
		[Column(TypeName = "nvarchar(3)")]
		[RegularExpression(@"^[0-9]{2,3}$", ErrorMessage = "Nieprawidłowy format")]
		public required string PhoneCode { get; set; }

		/// <summary>
		/// Gets or sets the currency id of the country
		/// </summary>
		[ForeignKey("Currency")]
		public int IdCurrency { get; set; }

		/// <summary>
		/// Gets or sets the currency of the country
		/// </summary>
		public Currency? Currency { get; set; }

		/// <summary>
		/// Gets or sets the language id of the country
		/// </summary>
		[ForeignKey("Language")]
		public int IdLanguage { get; set; }

		/// <summary>
		/// Gets or sets the language of the country
		/// </summary>
		public Language? Language { get; set; }

		/// <summary>
		/// Gets or sets the capital city id of the country
		/// </summary>
		public int? IdCapitalCity { get; set; }

		/// <summary>
		/// Gets or sets the capital city of the country
		/// </summary>
		public City? CapitalCity { get; set; }

		/// <summary>
		/// Gets or sets the cities of the country
		/// </summary>
		public ICollection<City> Cities { get; set; } = new List<City>();

		/// <summary>
		/// Gets or sets the photos of the country
		/// </summary>
		public ICollection<CountryPhoto> CountryPhotos { get; set; } = new List<CountryPhoto>();
	}
}
