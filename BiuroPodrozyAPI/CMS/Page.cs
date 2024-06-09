using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.CMS
{
	/// <summary>
	/// Model class for pages entities
	/// </summary>
	public class Page : Auditable
	{
		/// <summary>
		/// Get or set id of page
		/// </summary>
		[Key]
		public int IdPage { get; set; }

		/// <summary>
		/// Get or set title of page
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string PageTitle { get; set; }

		/// <summary>
		/// Get or set nav title of page
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string NavTitle { get; set; }

		/// <summary>
		/// Get or set relative url of page
		/// </summary>
		[Column(TypeName = "nvarchar(100)")]
		public required Uri PageIndexRelativeURL { get; set; }

		/// <summary>
		/// Get or set author of page
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string Author { get; set; }

		/// <summary>
		/// Get or set access level of page
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string AccessLevel { get; set; }

		/// <summary>
		/// Get or set whether page should be included in navbar
		/// </summary>
		public required bool IncludeInNavbar { get; set; }
	}
}
