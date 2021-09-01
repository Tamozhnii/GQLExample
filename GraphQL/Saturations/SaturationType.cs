using GQLExample.Models;
using HotChocolate.Types;
using HotChocolate;
using GQLExample.Data;
using System.Linq;

namespace GQLExample.GraphQL.Saturations
{
    public class SaturationType : ObjectType<Saturation>
    {
        protected override void Configure(IObjectTypeDescriptor<Saturation> descriptor)
        {
            descriptor.Description("Насыщенность цвета");

            descriptor
                .Field(s => s.Colors)
                .ResolveWith<Resolvers>(s => s.GetColor(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Цвета");

            descriptor.Field(s => s.Value).Description("Степень насыщенности на английском");
            descriptor.Field(s => s.LocalValue).Description("Степень насыщенности на русском");
        }

        private class Resolvers{
            public IQueryable<Color> GetColor(Saturation saturation, [ScopedService] AppDbContext context){
                return context.Colors.Where(c => c.SaturationId == saturation.Id);
            }
        }
    }
}