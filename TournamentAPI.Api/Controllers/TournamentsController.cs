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
    public class TournamentsController : ControllerBase
    {
        private readonly IUoW _uow;

        public TournamentsController(IUoW uow)
        {
            _uow = uow;
        }

        // GET: api/Tournaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tournament>>> GetTournaments()
        {
            var tournament = await _uow.Tournament.GetAllAsync();
            return Ok(tournament);
        }

        // GET: api/Tournaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetTournament(int id)
        {
            var tournament = await _uow.Tournament.GetAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }

            return Ok(tournament);
        }

        // PUT: api/Tournaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTournament(int id, Tournament tournament)
        {
            if (id != tournament.Id)
            {
                return BadRequest();
            }

            _uow.Tournament.Update(tournament);

            try
            {
                await _uow.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _uow.Tournament.AnyAsync(id))
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

        // POST: api/Tournaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tournament>> PostTournament(Tournament tournament)
        {
            _uow.Tournament.Add(tournament);
            await _uow.CompleteAsync();

            return CreatedAtAction(nameof(GetTournament), new { id = tournament.Id }, tournament);
        }

        // DELETE: api/Tournaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTournament(int id)
        {
            var tournament = await _uow.Tournament.GetAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }

            _uow.Tournament.Remove(tournament);
            await _uow.CompleteAsync();

            return NoContent();
        }

      
    }
}
