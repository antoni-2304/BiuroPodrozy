using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(CurrencyMetaData))]
    public partial class Currency : Auditable
    {
        public sealed class CurrencyMetaData
        {
            [Key]
            public int IdCurrency { get; set; }


            [Required(ErrorMessage = "Nazwa waluty jest wymagana")]
            [Display(Name = "Nazwa waluty")]
            [Column(TypeName = "nvarchar(50)")]
            public required string CurrencyName { get; set; }


            [Required(ErrorMessage = "Symbol waluty jest wymagany")]
            [Display(Name = "Symbol waluty")]
            [Column(TypeName = "nvarchar(3)")]
            public required string CurrencySymbol { get; set; }


            [Required(ErrorMessage = "Skrót nazwy waluty jest wymagany")]
            [Display(Name = "Skrót nazwy waluty")]
            [Column(TypeName = "nvarchar(3)")]
            [MinLength(3, ErrorMessage = "Skrót nazwy waluty musi mieć co najmniej 3 znaki")]
            public required string AbbrCurrency { get; set; }
        }
    }
}