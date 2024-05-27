using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TournamentAPI.Core.Entities;

namespace TournamentAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TournamentApiContext(
                serviceProvider.GetRequiredService<DbContextOptions<TournamentApiContext>>()))
            {
                if (context.Tournaments.Any())
                {
                    return;
                }

                var tournaments = new Tournament[]
                {
                    new Tournament
                    {
                        Title = "Spring Cup",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(10),
                        Games = new Game[]
                        {
                            new Game {Title = "Spring Cup", Time = DateTime.Now.AddHours(1).AddMinutes(30), TeamA = "Team Alfa", TeamB = "Team Beta", ScoreA = 1, ScoreB = 2 },
                            new Game {Title = "Spring Cup", Time = DateTime.Now.AddHours(2).AddMinutes(45), TeamA = "Team Red", TeamB = "Team Blue", ScoreA = 3, ScoreB = 1 }
                    }

                },
                    new Tournament
                    {
                        Title = "Autumn Cup",
                        StartDate = DateTime.Now.AddMonths(4),
                        EndDate = DateTime.Now.AddMonths(5),
                        Games = new Game[]
                        {
                            new Game {Title = "Autumn Cup", Time = DateTime.Now.AddMonths(6), TeamA = "Team Gamma", TeamB = "Team Lex", ScoreA = 0, ScoreB = 0 },
                            new Game {Title = "Autumn Cup", Time = DateTime.Now.AddMonths(7), TeamA = "Team Yellow", TeamB = "Team Green", ScoreA = 4, ScoreB = 2}
                        }
                    }

            };
                context.Tournaments.AddRange(tournaments);
                context.SaveChanges();
        }
        }
    }

}
