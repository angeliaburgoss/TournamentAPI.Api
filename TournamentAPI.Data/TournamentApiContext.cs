using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentAPI.Core.Entities;

namespace TournamentAPI.Data
{
    public class TournamentApiContext :DbContext
    {
        public TournamentApiContext(DbContextOptions<TournamentApiContext> options)
            :base(options)
        {
           // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Tournament> Tournaments { get; set; } = default!;
        public DbSet<Game> Games { get; set; } = default!;
    }
}
