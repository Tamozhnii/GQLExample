using System.Collections.Generic;

namespace GQLExample.GraphQL.Colors
{
    public record EditColorInput(int Id, string Name, string Association, int Brightness, int Saturation, string HEX, List<int> Shades);
}