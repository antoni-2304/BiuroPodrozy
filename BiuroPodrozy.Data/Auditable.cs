using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(AuditableMetaData))]
    public partial class Auditable
    {
        internal sealed class AuditableMetaData
        {
            [Display(Name = "Identyfikator twórcy rekordu")]
            public int? WhoCreateId { get; set; }

            [Display(Name = "Czas stworzenia rekordu")]
            [Column(TypeName = "datetime")]
            public DateTime? CreationTime { get; set; }

            [Display(Name = "Identyfikator osoby, która zmodyfikowała rekord")]
            public int? LastModificationId { get; set; }

            [Display(Name = "Czas modyfikacji rekordu")]
            [Column(TypeName = "datetime")]
            public DateTime? LastModificationTime { get; set; }

            [Display(Name = "Identyfikator osoby, która usunęła rekord")]
            public int? DeletionId { get; set; }

            [Display(Name = "Identyfikator usunięcia rekordu")]
            [Column(TypeName = "datetime")]
            public DateTime? DeletionTime { get; set; }

            [Display(Name = "Czy jest aktywny?")]
            public bool? IsValid { get; set; }

            [Display(Name = "Uwagi dodatkowe")]
            [Column(TypeName = "nvarchar(200)")]
            public string? AuditDescription { get; set; } = string.Empty;
        }
    }
}
