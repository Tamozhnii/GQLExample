using System.Collections.Generic;
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
            List<Shade> ShadesColor = new List<Shade>();
            input.Shades.ForEach(s => ShadesColor.Add(context.Shades.Find(s)));

            Color color = new(){
                Name = input.Name,
                Association = input.Association,
                BrightnessId = input.Brightness,
                SaturationId = input.Saturation,
                HEX = input.HEX,
                Shades = ShadesColor
            };

            context.Colors.Add(color);
            await context.SaveChangesAsync();

            return new AddColorPayload(color);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<EditColorPayload> EditColorAsync(EditColorInput input, [ScopedService] AppDbContext context)
        {
            Color color = context.Colors.Find(input.Id);
            List<Shade> ShadesColor = new();
            input.Shades.ForEach(s => ShadesColor.Add(context.Shades.Find(s)));

            if(color != null){
                color.Name = input.Name != null ? input.Name : color.Name;
                color.Association = input.Association != null ? input.Association : color.Association;
                color.BrightnessId = input.Brightness;
                color.SaturationId = input.Saturation;
                color.HEX = input.HEX != null ? input.HEX : color.HEX;
                color.Shades = input.Shades != null ? ShadesColor : color.Shades;
            }

            context.Colors.Update(color);
            await context.SaveChangesAsync();

            return new EditColorPayload(color);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<DeleteColorPayload> DeleteColorAsync(DeleteColorInput input, [ScopedService] AppDbContext context)
        {
            Color color = context.Colors.Find(input.ColorId);
            context.Colors.Remove(color);
            await context.SaveChangesAsync();

            return new DeleteColorPayload(color);
        }
    }
}