using System.Linq;
using GQLExample.Data;
using GQLExample.Models;
using HotChocolate;

namespace GQLExample.GraphQL
{
    public class Query
    {
        public IQueryable<Shade> GetShade([Service] AppDbContext context){
            return context.Shades;
        }
    }
}