using BiuroPodrozyAPI.TravelAgency;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI.CMS
{
	/// <summary>
	/// Model class for card entity 
	/// </summary>
	public class Card : Auditable
	{
		[Key]
		public int IdCard { get; set; }

		/// <summary>
		/// Gets or sets the name of the card.
		/// </summary>
		[Column(TypeName = "nvarchar(100)")]
		public required string CardTitle { get; set; }

		/// <summary>
		/// Gets or sets the description of the card.
		/// </summary>
		[Column(TypeName = "nvarchar(2000)")]
		public string? CardDescription { get; set; }

		/// <summary>
		/// Gets or sets the URL of the thumbnail image.
		/// </summary>
		[Column(TypeName = "nvarchar(200)")]
		public required string ThumbnailURL { get; set; }

		/// <summary>
		/// Gets or sets the publish date of the card.
		/// </summary>
		public DateTime? PublishDate { get; set; }


		/// <summary>
		/// Gets or sets the id of the card type.
		/// </summary>
		[ForeignKey("CardType")]
		public int IdCardType { get; set; }
		/// <summary>
		/// Gets or sets the card type.
		/// </summary>
		public CardType? CardType { get; set; }

		/// <summary>
		/// Gets or sets the id of the author.
		/// </summary>
		[ForeignKey("Author")]
		public int IdAuthor { get; set; }

		/// <summary>
		/// Gets or sets the author.
		/// </summary>
		public Employee? Author { get; set; }

	}
}
