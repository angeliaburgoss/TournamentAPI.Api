﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentAPI.Core.Entities;
using TournamentAPI.Core.Repositories;

namespace TournamentAPI.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly TournamentApiContext _context;

        public GameRepository(TournamentApiContext context )
        {
            _context = context;
        }

        

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Games.AnyAsync(g => g.Id == id);
        }

        public void Add(Game game)
        {
            _context.Games.Add(game);
        }

        public void Update(Game game)
        {
            _context.Games.Update(game);
        }

        public void Remove(Game game)
        {
            _context.Games.Remove(game);
        }
    }
}
