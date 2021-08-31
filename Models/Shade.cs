using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HotChocolate;

namespace GQLExample.Models
{
    [GraphQLDescription("Оттенок (цвет из базовых цветов)")]
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
        [GraphQLDescription("Цвета являющиеся оттенком базового цвета")]
        public ICollection<Color> Colors { get; set; } = new List<Color>();
    }
}