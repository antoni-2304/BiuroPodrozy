using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.CMS
{
	/// <summary>
	/// Abstract class for all photos entities
	/// </summary>
	public abstract class Photo : Auditable
	{
		/// <summary>
		/// Get or set photo path
		/// </summary>
		[Column(TypeName = "nvarchar(1000)")]
		[Url]
		public Uri PhotoPath { get; set; }
	}
}
