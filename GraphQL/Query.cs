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
        // [UseProjection] //Получать данные из дочерних и родительских сущностей
        public IQueryable<Shade> GetShade([ScopedService] AppDbContext context){
            return context.Shades;
        }

        [UseDbContext(typeof(AppDbContext))]
        // [UseProjection] //Получать данные из дочерних и родительских сущностей
        public IQueryable<Color> GetColor([ScopedService] AppDbContext context){
            return context.Colors;
        }
    }
}