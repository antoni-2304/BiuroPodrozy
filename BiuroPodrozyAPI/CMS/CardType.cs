using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.CMS
{
	/// <summary>
	/// Model class for card type entities
	/// </summary>
	public class CardType : Auditable
	{
		/// <summary>
		/// Gets or sets card type id
		/// </summary>
		[Key]
		public int IdCardType { get; set; }

		/// <summary>
		/// Gets or sets card type name
		/// </summary>
		[Column(TypeName = "nvarchar(50)")]
		public required string CardTypeName { get; set; }

		/// <summary>
		/// Gets or sets card type description
		/// </summary>
		[Column(TypeName = "nvarchar(2000)")]
		public string CardTypeDescription { get; set; }
	}
}
