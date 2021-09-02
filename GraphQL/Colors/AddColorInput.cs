using System.Collections.Generic;

namespace GQLExample.GraphQL.Colors
{
    public record AddColorInput(string Name, string Association, int Brightness, int Saturation, string HEX, List<int> Shades);
}