using System.Threading.Tasks;
using GQLExample.Data;
using GQLExample.GraphQL.Colors;
using GQLExample.Models;
using HotChocolate;
using HotChocolate.Data;

namespace GQLExample.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddColorPayload> AddColorAsync(AddColorInput input, [ScopedService] AppDbContext context)
        {
            var color = new Color{
                Name = input.Name,
                Association = input.Association,
                BrightnessId = input.Brightness,
                SaturationId = input.Saturation,
                HEX = input.HEX
            };

            context.Colors.Add(color);
            await context.SaveChangesAsync();

            return new AddColorPayload(color);
        }
    }
}