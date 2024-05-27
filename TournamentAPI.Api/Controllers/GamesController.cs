using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournamentAPI.Core.Entities;
using TournamentAPI.Core.Repositories;
using TournamentAPI.Data;

namespace TournamentAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IUoW _uow;

        public GamesController(IUoW uow)
        {
            _uow = uow;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            var game = await _uow.Game.GetAllAsync();
            return Ok(game);
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _uow.Game.GetAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGame(int id, Game game)
        {
            if (id != game.Id)
            {
                return BadRequest();
            }

            _uow.Game.Update(game);

            try
            {
                await _uow.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _uow.Game.AnyAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game game)
        {
            _uow.Game.Add(game);
            await _uow.CompleteAsync();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _uow.Game.GetAsync(id);
            if (game == null)
            {
                return NotFound();
            }

            _uow.Game.Remove(game);
            await _uow.CompleteAsync();

            return NoContent();
        }

     
    }
}
