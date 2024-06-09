using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.TravelAgency
{
	/// <summary>
	/// Model class for address entities
	/// </summary>
	public class Address : Auditable
	{
		/// <summary>
		/// Get or set id of address 
		/// </summary>
		[Key]
		public int IdAddress { get; set; }

		/// <summary>
		/// Get or set street
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string Street { get; set; }

		/// <summary>
		/// Gets or sets home number
		/// </summary>
		[Column(TypeName = "nvarchar(10)")]
		public required string HomeNr { get; set; }

		/// <summary>
		/// Gets or sets apartment number
		/// </summary>
		[Column(TypeName = "nvarchar(10)")]
		public string? ApartmentNr { get; set; } = String.Empty;

		/// <summary>
		/// Gets or sets latitude
		/// </summary>
		[Column(TypeName = "decimal(8,6)")]
		public decimal? Latitude { get; set; }

		/// <summary>
		/// Gets or sets longitude
		/// </summary>
		[Column(TypeName = "decimal(9,6)")]
		public decimal? Longitude { get; set; }

		/// <summary>
		/// Gets or sets id of city
		/// </summary>
		[ForeignKey("City")]
		public int IdCity { get; set; }

		/// <summary>
		/// Gets or sets city
		/// </summary>
		public City? City { get; set; }

		/// <summary>
		/// Gets or sets hotel
		/// </summary>
		public Hotel? Hotel { get; set; }

		/// <summary>
		/// Gets or sets clients
		/// </summary>
		public ICollection<Client> Clients { get; set; } = new List<Client>();
	}
}
