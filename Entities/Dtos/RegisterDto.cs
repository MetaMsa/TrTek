using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RegisterDto
    {
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string? userName { get; init; }

        [Required(ErrorMessage = "Soyisim zorunludur.")]
        public string? userSurname { get; init; }

        [Required(ErrorMessage = "E-posta zorunludur.")]
        public string? userEmail { get; init; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string? userPassword { get; init; }

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        public DateTime userBirthDate { get; init; }
    }
}