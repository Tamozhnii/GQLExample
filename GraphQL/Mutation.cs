using System.Collections.Generic;
using System.Threading.Tasks;
using GQLExample.Data;
using GQLExample.GraphQL.Colors;
using GQLExample.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using HotChocolate.Subscriptions;
using System.Threading;

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
        public async Task<EditColorPayload> EditColorAsync(
            EditColorInput input, 
            [ScopedService] AppDbContext context, 
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
        )
        {
            Color color = context.Colors.Find(input.Id);
            
            color.Name = input.Name != null ? input.Name : color.Name;
            color.Association = input.Association != null ? input.Association : color.Association;
            color.BrightnessId = input.Brightness;
            color.SaturationId = input.Saturation;
            color.HEX = input.HEX != null ? input.HEX : color.HEX;
            if(input.Shades != null){
                input.Shades.ForEach(s => {
                        Shade shade = context.Shades.Find(s);
                        if(color.Shades.Where(sh => sh.Id == s).Count() == 0){
                            color.Shades.Add(shade);  
                        }
                    });
            }

            await context.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnColorUpdate), color, cancellationToken);

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