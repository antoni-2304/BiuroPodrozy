using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(PhotoMetaData))]
    public partial class Photo : Auditable
    {
        internal sealed class PhotoMetaData
        {
            [Display(Name = "Ścieżka do zdjęcia")]
            [Column(TypeName = "nvarchar(1000)")]
            [Url]
            public Uri PhotoPath { get; set; }
        }
    }
}