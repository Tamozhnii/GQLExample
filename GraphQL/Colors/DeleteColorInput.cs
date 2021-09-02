using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GQLExample.GraphQL.Colors
{
    public record DeleteColorInput([Required]int ColorId);
}