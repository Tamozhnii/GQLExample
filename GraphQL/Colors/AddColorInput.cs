using System.ComponentModel.DataAnnotations;

namespace GQLExample.GraphQL.Colors
{
    public record AddColorInput([Required] string Name, string Association, int Brightness, int Saturation, [Required] string HEX);
}