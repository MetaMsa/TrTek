using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public string? Image { get; set; }
        public string? AddedBy { get; set; }
        public DateTime AddedDate { get; set; }  
        public bool isActive { get; set;}
        public string? shortDescription { get; set;}
        public string? longDescription { get; set;}
        public ICollection<LinkLine> LinkLines { get; set; }
    }   
}