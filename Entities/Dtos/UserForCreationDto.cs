using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserForCreationDto : UserDto
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre zorunludur.")]
        public string? userPassword { get; init; }
    }
}