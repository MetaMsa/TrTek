using System.ComponentModel.DataAnnotations;

namespace stajpro.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        public string? userEmail { get; set; }
        
        [Required(ErrorMessage = "Şifre gereklidir.")]
        public string? userPassword { get; set; }
        public bool isUserCreated { get; set; } = false;
    }   
}