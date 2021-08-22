using System.ComponentModel.DataAnnotations;

namespace GQLExample.Models
{
    public class Shade
    {
        [key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string HEX { get; set; }
    }
}