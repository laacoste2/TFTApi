using Microsoft.EntityFrameworkCore;
using TeamFightTacticsAPI.Data;
using TeamFightTacticsAPI.Dtos;
using TeamFightTacticsAPI.Models;

namespace TeamFightTacticsAPI.ExtensionMethod
{
    public static class Endpoints
    {
        public static async void AllEndpoints(this WebApplication app)
        {
            var route = app.MapGroup("champions");

            route.MapGet("", async (TeamFightTacticsContext context) =>
            {
                var champions = await context.Champions.ToListAsync();

                if (champions.Count < 1)
                {
                    return Results.NotFound();
                }

                return Results.Ok(champions!);
            });

            route.MapGet("{id}", async (Guid id, TeamFightTacticsContext context) =>
            {
                var champion = await context.Champions.SingleOrDefaultAsync(champion => champion.Id == id);

                if (champion == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(champion!);
            });

            route.MapPost("", async (PostChampionDto championDto, TeamFightTacticsContext context) =>
            {
                await context.Champions.AddAsync(new Champion(championDto.Name, championDto.Class, championDto.Price));
                await context.SaveChangesAsync();

                return Results.Ok();
            });

            route.MapPut("{id}", async (Guid id, PutChampionDto championDto,  TeamFightTacticsContext context) =>
            {
                var found = await context.Champions.SingleOrDefaultAsync(champion => champion.Id == id);

                if (found == null) 
                {
                    return Results.NotFound();
                }

                found.Name = championDto.Name;
                found.Class = championDto.Class;
                found.Price = championDto.Price;
                
                await context.SaveChangesAsync();

                return Results.Ok(found);
            });

            route.MapDelete("{id}", async (Guid id, TeamFightTacticsContext context) =>
            {
                var champion = context.Champions.Where(c => c.Id == id);

                if (champion == null)
                {
                    return Results.NotFound();
                }

                context.RemoveRange(champion);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
