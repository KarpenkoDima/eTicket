using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext appDbContext;
        public ActorsService(AppDbContext context)
        {
            appDbContext = context;
        }
        public void Add(Actor actor)
        {
            appDbContext.Actors.Add(actor);
            appDbContext.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var res = await appDbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);
            appDbContext.Remove(res);
            await appDbContext.SaveChangesAsync();
        }

        public async Task<Actor> GetById(int id)
        {
            var result = await appDbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task<Actor> Update(int id, Actor updateActor)
        {
            appDbContext.Update(updateActor);
            await appDbContext.SaveChangesAsync();
            return updateActor;
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await appDbContext.Actors.ToListAsync();
            return result;
        }
    }
}
