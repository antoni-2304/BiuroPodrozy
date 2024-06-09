using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(SiteMetaData))]
    public partial class Site : Auditable
    {
        internal sealed class SiteMetaData
        {
            [Key]
            public int IdSite { get; set; }


            [Required(ErrorMessage = "Tytuł strony jest wymagany")]
            [Display(Name = "Tytuł strony")]
            [Column(TypeName = "nvarchar(50)")]
            public required string Title { get; set; }


            [Required(ErrorMessage = "Opis strony jest wymagany")]
            [Display(Name = "Tytuł strony")]
            [Column(TypeName = "nvarchar(200)")]
            public required string Description { get; set; }


            [Required(ErrorMessage = "Autor strony jest wymagany")]
            [Display(Name = "Autor")]
            [Column(TypeName = "nvarchar(50)")]
            public required string Author { get; set; }


            [Required(ErrorMessage = "Kategoria strony jest wymagana")]
            [Display(Name = "Kategoria strony")]
            [Column(TypeName = "nvarchar(50)")]
            public required string Tag { get; set; }


            [Required(ErrorMessage = "URL loga jest wymagany")]
            [Display(Name = "URL loga")]
            [Column(TypeName = "nvarchar(100)")]

            public required Uri Logo { get; set; }
        }
    }
}
