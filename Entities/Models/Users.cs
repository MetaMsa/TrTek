using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Entities.Models;

public class Users
{
    public int Id { get; set; }
    public string? userName { get; set; }
    [Required(ErrorMessage = "Soyisim gereklidir.")]
    public string? userSurname { get; set; }
    [Required(ErrorMessage = "E-posta gereklidir.")]
    public string? userEmail { get; set; }
    [Required(ErrorMessage = "Şifre gereklidir.")]
    public string? userPassword { get; set; }
    [Required(ErrorMessage = "Doğum tarihi gereklidir.")]
    public DateTime userBirthDate { get; set; }
    [Required(ErrorMessage = "Roller gereklidir.")]
    public List<String> Roles { get; set; } = new List<string>();
    public ICollection<LinkLine> LinkLines { get; set; }
}