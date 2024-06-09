using BiuroPodrozyAPI.TravelAgency;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.CMS
{
	/// <summary>
	/// Model class for country photos entities
	/// </summary>
	public class CountryPhoto : Photo
	{
		/// <summary>
		/// Gets or sets the id of the country photo
		/// </summary>
		[Key]
		public int IdCountryPhoto { get; set; }


		/// <summary>
		/// Gets or sets the id of the country
		/// </summary>
		[ForeignKey("Country")]
		public int? IdCountry { get; set; }
		/// <summary>
		/// Gets or sets the country
		/// </summary>
		public Country? Country { get; set; }
	}
}
