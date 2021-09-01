using GQLExample.Models;
using GQLExample.Data;
using HotChocolate.Types;
using HotChocolate;
using System.Linq;

namespace GQLExample.GraphQL.Brightnesses
{
    public class BrightnessType : ObjectType<Brightness>
    {
        protected override void Configure(IObjectTypeDescriptor<Brightness> descriptor){
            descriptor.Description("Яркость цвета");

            descriptor
                .Field(b => b.Colors)
                .ResolveWith<Resolvers>(b => b.GetColor(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Цвета");

            descriptor.Field(b => b.Value).Description("Степень яркости цвета на английском");
            descriptor.Field(b => b.LocalValue).Description("Степень яркости цвета на русском");
        }
        
        private class Resolvers{
            public IQueryable<Color> GetColor(Brightness brightness, [ScopedService] AppDbContext context){
                return context.Colors.Where(c => c.BrightnessId == brightness.Id);
            }
        }
    }
}