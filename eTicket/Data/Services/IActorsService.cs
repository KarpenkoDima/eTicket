using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        void Add(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor updateActor);
        Task DeleteAsync(int id);
    }
}
