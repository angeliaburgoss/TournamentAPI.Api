using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentAPI.Core.Entities;
using TournamentAPI.Core.Repositories;

namespace TournamentAPI.Data.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly TournamentApiContext _context;

        public TournamentRepository(TournamentApiContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            return await _context.Tournaments.ToListAsync();
        }

        public async Task<Tournament> GetAsync(int id)
        {
            return await _context.Tournaments.FindAsync(id);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Tournaments.AnyAsync(t => t.Id == id);
        }

        public void Add(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
        }

        public void Update(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
        }

        public void Remove(Tournament tournament)
        {
            _context.Tournaments.Remove(tournament);
        }
    }
}
