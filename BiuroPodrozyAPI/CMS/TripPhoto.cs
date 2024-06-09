using BiuroPodrozyAPI.TravelAgency;
using System.ComponentModel.DataAnnotations;

namespace BiuroPodrozyAPI.CMS
{
	/// <summary>
	/// Model class for trip photos entities
	/// </summary>
	public class TripPhoto : Photo
	{
		/// <summary>
		/// Gets or sets id of trip photo
		/// </summary>
		[Key]
		public int IdTripPhoto { get; set; }

		/// <summary>
		/// Gets or sets trip
		/// </summary>
		public ICollection<Trip> Trips { get; set; } = new List<Trip>();
	}
}
