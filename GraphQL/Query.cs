using System.Linq;
using GQLExample.Data;
using GQLExample.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GQLExample.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Shade> GetShade([ScopedService] AppDbContext context){
            return context.Shades;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]

        public IQueryable<Color> GetColor([ScopedService] AppDbContext context){
            return context.Colors;
        }
    }
}