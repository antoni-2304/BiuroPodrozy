using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(LanguageMetaData))]
    public partial class Language : Auditable
    {
        public sealed class LanguageMetaData
        {
            [Key]
            public int IdLanguage { get; set; }

            [Required(ErrorMessage = "Nazwa języka jest wymagana")]
            [Display(Name = "Nazwa języka")]
            [Column(TypeName = "nvarchar(50)")]
            public required string LanguageName { get; set; }


            [Required(ErrorMessage = "Skrót nazwy języka jest wymagany")]
            [Display(Name = "Skrót nazwy języka")]
            [Column(TypeName = "nvarchar(10)")]
            public required string AbbrLanguageName { get; set; }
        }
    }
}
