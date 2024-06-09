using System.ComponentModel.DataAnnotations;

namespace BiuroPodrozy.Data.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [EmailAddress(ErrorMessage = "Niepoprawny email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [MinLength(8, ErrorMessage = "Hasło musi mieć co najmniej 8 znaków")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[^\w\s]).+$", ErrorMessage = "Hasło musi zawierać co najmniej jedną literę, jedną cyfrę i jeden znak specjalny")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        [Compare(nameof(Password), ErrorMessage = "Hasła nie są takie same")]
        public string? RepeatPassword { get; set; }

    }
}
