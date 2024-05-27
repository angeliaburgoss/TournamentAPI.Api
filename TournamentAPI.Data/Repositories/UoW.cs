using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentAPI.Core.Repositories;

namespace TournamentAPI.Data.Repositories
{
    public class UoW : IUoW
    {
        private readonly TournamentApiContext _context;
        public ITournamentRepository Tournament {  get; private set; }
        public IGameRepository Game { get; private set; }

        public UoW(TournamentApiContext context)
        {
            _context = context;
            Tournament = new TournamentRepository(_context);
            Game = new GameRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
