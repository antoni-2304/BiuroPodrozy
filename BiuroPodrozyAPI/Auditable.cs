using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozyAPI
{
	/// <summary>
	/// Abstract class for all auditable entities
	/// </summary>
	public abstract class Auditable
	{
		/// <summary>
		/// Id of the user who created the record
		/// </summary>
		[Display(Name = "Identyfikator twórcy rekordu")]
		public int? WhoCreateId { get; set; }

		/// <summary>
		/// Creation time of the record
		/// </summary>
		[Display(Name = "Czas stworzenia rekordu")]
		[Column(TypeName = "datetime")]
		public DateTime? CreationTime { get; set; }


		/// <summary>
		/// Id of the user who last modified the record
		/// </summary>
		[Display(Name = "Identyfikator osoby, która zmodyfikowała rekord")]
		public int? LastModificationId { get; set; }


		/// <summary>
		/// Last modification time of the record
		/// </summary>
		[Display(Name = "Czas modyfikacji rekordu")]
		[Column(TypeName = "datetime")]
		public DateTime? LastModificationTime { get; set; }


		/// <summary>
		/// Id of the user who soft deleted the record
		/// </summary>
		[Display(Name = "Identyfikator osoby, która usunęła rekord")]
		public int? DeletionId { get; set; }


		/// <summary>
		/// Deletion time of the record
		/// </summary>
		[Display(Name = "Identyfikator usunięcia rekordu")]
		[Column(TypeName = "datetime")]
		public DateTime? DeletionTime { get; set; }


		/// <summary>
		/// Whether the record is valid (isn't soft deleted)
		/// </summary>
		[Display(Name = "Czy jest aktywny?")]
		public bool? IsValid { get; set; }


		/// <summary>
		/// Additional description of the record
		/// </summary>
		[Display(Name = "Uwagi dodatkowe")]
		[Column(TypeName = "nvarchar(200)")]
		public string? AuditDescription { get; set; } = string.Empty;
	}
}
