using System.Linq;
using GQLExample.Data;
using GQLExample.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GQLExample.GraphQL.Shades
{
    public class ShadeType : ObjectType<Shade>
    {
        protected override void Configure(IObjectTypeDescriptor<Shade> descriptor){
            descriptor.Description("Оттенок (цвет из базовых цветов)");

            descriptor
                .Field(s => s.Colors)
                .ResolveWith<Resolvers>(s => s.GetColor(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Цвета являющиеся оттенком базового цвета");

            descriptor.Field(s => s.Name).Description("Наименование базового цвета на английском");
            descriptor.Field(s => s.LocalName).Description("Наименование базового цвета на русском");
            descriptor.Field(s => s.HEX).Description("Значение цвета в HEX формате (например #f0f0f0)");
        }
        
        private class Resolvers{
            public IQueryable<Color> GetColor(Shade shade, [ScopedService] AppDbContext context){
                return context.Colors.Where(c => c.Shades.Contains(shade));
            }
        }
    }
}