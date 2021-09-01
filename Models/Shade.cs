using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GQLExample.Models
{
    public class Shade
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LocalName { get; set; }
        [Required]
        public string HEX { get; set; }
        public ICollection<Color> Colors { get; set; } = new List<Color>();
    }
}