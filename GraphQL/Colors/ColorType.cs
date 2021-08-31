using System.Linq;
using GQLExample.Data;
using GQLExample.Models;
using HotChocolate;
using HotChocolate.Types;

namespace GQLExample.GraphQL.Colors
{
    public class ColorType : ObjectType<Color>
    {
        protected override void Configure(IObjectTypeDescriptor<Color> descriptor)
        {
            descriptor.Description("Реестр цветов, их названия, HEX значения и описания");
            // descriptor.Field(p => p.Association).Ignore(); //Игнорирование поля
            descriptor
                .Field(p => p.Shades)
                .ResolveWith<Resolvers>(p => p.GetShades(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Оттенком какого(-их) из основных цветов является текущий цвет");

            descriptor
                .Field(p => p.Brightness)
                .ResolveWith<Resolvers>(p => p.GetBrightnesses(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Яркость цвета (яркий, средний и темный)");

            descriptor
                .Field(p => p.Saturation)
                .ResolveWith<Resolvers>(p => p.GetSaturations(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("Насыщенность цвета (от бледного к насыщенному)");

            descriptor.Field(p => p.HEX).Description("Значение цвета в HEX формате (например #f0f0f0)");
            descriptor.Field(p => p.Name).Description("Название цвета");
            descriptor.Field(p => p.Association).Description("С чем ассоциируется цвет, или его описание");
        }

        private class Resolvers
        {
            public IQueryable<Shade> GetShades(Color color, [ScopedService] AppDbContext context)
            {
                return context.Shades.Where(s => s.Colors.Contains(color));
            }
            public IQueryable<Brightness> GetBrightnesses(Brightness brightness, [ScopedService] AppDbContext context)
            {
                return context.Brightnesses.Where(b => b.Id == brightness.Id);
            }
            public IQueryable<Saturation> GetSaturations(Saturation saturation, [ScopedService] AppDbContext context)
            {
                return context.Saturations.Where(s => s.Id == saturation.Id);
            }
        }
    }
}