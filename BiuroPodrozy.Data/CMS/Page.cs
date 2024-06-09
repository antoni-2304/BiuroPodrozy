using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BiuroPodrozy.Data
{
    [ModelMetadataType(typeof(PageMetaData))]
    public partial class Page : Auditable
    {
        public sealed class PageMetaData
        {
            [Key]
            public int IdPage { get; set; }


            [Required(ErrorMessage = "Tytuł strony jest wymagany")]
            [Display(Name = "Tytuł strony")]
            public required string PageTitle { get; set; }

            [Required(ErrorMessage = "Nazwa w menu nawigacyjnym jest wymagana")]
            [Display(Name = "Nazwa w menu nawigacyjnym")]
            public required string NavTitle { get; set; }

            [Required(ErrorMessage = "URL do strony jest waymagany")]
            [Display(Name = "URL do strony")]
            public required Uri PageIndexRelativeURL { get; set; }


            [Required(ErrorMessage = "Autor strony jest wymagany")]
            [Display(Name = "Autor")]
            public required string Author { get; set; }


            [Required(ErrorMessage = "Dostępność strony jest wymagana")]
            [Display(Name = "Dostępność strony")]
            [AllowedValues("Wszyscy", "Tylko zarejestrowani", "Tylko upoważnieni", "Nikt")]
            public required string AccessLevel { get; set; }


            [Display(Name = "Czy umieścić link do strony w menu nawigacyjnym?")]
            public required bool IncludeInNavbar { get; set; }
        }
    }
}