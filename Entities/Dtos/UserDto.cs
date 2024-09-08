using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserDto
    {
        public int userId { get; init; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="İsim zorunludur.")]
        public String? UserName { get; init; }
        
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Soyisim zorunludur.")]
        public String? UserSurname { get; init; }
        
        [DataType(DataType.EmailAddress)]
        public String? userEmail { get; init; }
        
        [DataType(DataType.DateTime)]
        public DateTime userBirthDate { get; init; }

        public List<String> Roles { get; set; } = new List<string>();
    }
}