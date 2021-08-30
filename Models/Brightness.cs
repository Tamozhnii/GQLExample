using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GQLExample.Models
{
    public class Brightness
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string LocalValue { get; set; }
        public ICollection<Color> Colors { get; set; } = new List<Color>();
    }
    
}