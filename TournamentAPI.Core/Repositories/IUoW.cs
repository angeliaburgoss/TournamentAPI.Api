using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentAPI.Core.Repositories
{
    public interface IUoW : IDisposable
    {
        ITournamentRepository Tournament {  get; }
        IGameRepository Game { get; }
        Task<int> CompleteAsync();
    }
}
