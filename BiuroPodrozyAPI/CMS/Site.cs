using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.CMS
{
	/// <summary>
	/// Model class for site entities
	/// </summary>
	public class Site : Auditable
	{
		/// <summary>
		/// Get or set id of site
		/// </summary>
		[Key]
		public int IdSite { get; set; }

		/// <summary>
		/// Get or set title of site
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string Title { get; set; }

		/// <summary>
		/// Get or set description of site
		/// </summary>
		[Column(TypeName = "nvarchar(200)")]
		public required string Description { get; set; }

		/// <summary>
		/// Get or set author of site
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string Author { get; set; }

		/// <summary>
		/// Get or set tag of site
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string Tag { get; set; }

		/// <summary>
		/// Get or set logo of site
		/// </summary>
		[Column(TypeName = "nvarchar(100)")]
		public required Uri Logo { get; set; }
	}
}
