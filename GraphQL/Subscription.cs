using GQLExample.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GQLExample.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Color OnColorUpdate([EventMessage] Color color) => color;
    }
}