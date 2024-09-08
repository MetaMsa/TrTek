using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record EventsDto
    {
        public int Id { get; init; }

        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string? Name { get; init; }
        [Required(ErrorMessage = "Tarih alanı gereklidir.")]
        public DateTime FirstDate { get; init; }
        [Required(ErrorMessage = "Tarih alanı gereklidir.")]
        public DateTime LastDate { get; init; }
        [Required(ErrorMessage = "Resim alanı gereklidir.")]
        public string? Image { get; init; }
        [Required(ErrorMessage = "Ekleyen alanı gereklidir.")]
        public string? AddedBy { get; init; }
        [Required(ErrorMessage = "Eklenme tarihi alanı gereklidir.")]
        public DateTime AddedDate { get; init; }  
        [Required(ErrorMessage = "Aktiflik durumu alanı gereklidir.")]
        public bool ısActive { get; init;}
        [Required(ErrorMessage = "Kısa açıklama alanı gereklidir.")]
        public string? shortDescription { get; init;}
        [Required(ErrorMessage = "Uzun açıklama alanı gereklidir.")]
        public string? longDescription { get; init;}
    }   
}