﻿using eTicket.Models;
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> GetById(int id)
        {
            var result = await appDbContext.Actors.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public Actor Update(int id, Actor updateActor)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Actor>> GetAll()
        {
            var result = await appDbContext.Actors.ToListAsync();
            return result;
        }
    }
}
