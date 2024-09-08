using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPasswordDto : UserDto
    {
        public string? userName { get; init; }
        public string? userSurname { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        public string? userPassword { get; init; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre onayı gereklidir.")]
        [Compare("userPassword", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string? ConfirmPassword { get; init; }
    }
}