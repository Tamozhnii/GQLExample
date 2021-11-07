using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GQLExample.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string HEX { get; set; }
        public string Association { get; set; }
        [Required]
        public int BrightnessId { get; set; }
        public Brightness Brightness { get; set; }
        [Required]
        public int SaturationId { get; set; }
        public Saturation Saturation { get; set; }
        public ICollection<Shade> Shades { get; set; } = new List<Shade>();
    }
}