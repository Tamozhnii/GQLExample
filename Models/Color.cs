using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace GQLExample.Models
{
    [GraphQLDescription("Цвета")]
    public class Color
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [GraphQLDescription("HEX значение цвета (например #fofofo)")]
        [Required]
        public string HEX { get; set; }
        public string Association { get; set; }
        [Required]
        public int BrightnessId { get; set; }
        [GraphQLDescription("Яркость")]
        public Brightness Brightness { get; set; }
        [Required]
        public int SaturationId { get; set; }
        [GraphQLDescription("Насыщенность")]
        public Saturation Saturation { get; set; }
        public ICollection<Shade> Shades { get; set; } = new List<Shade>();
    }
}