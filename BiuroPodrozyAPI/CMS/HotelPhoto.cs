using BiuroPodrozyAPI.TravelAgency;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.CMS
{
	/// <summary>
	/// Model class for hotel photos entities
	/// </summary>
	public class HotelPhoto : Photo
	{
		/// <summary>
		/// Gets or sets the id of the hotel photo
		/// </summary>
		[Key]
		public int IdHotelPhoto { get; set; }

		/// <summary>
		/// Gets or sets the id of the hotel
		/// </summary>
		[ForeignKey("Hotel")]
		public int IdHotel { get; set; }
		/// <summary>
		/// Gets or sets the hotel
		/// </summary>
		public Hotel? Hotel { get; set; }
	}
}
