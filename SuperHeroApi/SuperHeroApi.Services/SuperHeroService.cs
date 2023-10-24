using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;
using SuperHeroApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroApi.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context) 
        {
            _context = context;
        }

        public async Task<List<SuperHero>> GetAll()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<SuperHero?> Get(int id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);

            return superHero;
        }

        public async Task Add(SuperHero superHero)
        {
            await _context.SuperHeroes.AddAsync(superHero);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SuperHero>> Update(SuperHero superHero)
        {
            _context.SuperHeroes.Update(superHero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> Delete(int id)
        {
            var superHero = await _context.SuperHeroes.FindAsync(id);

            if(superHero == null)
            {
                throw new Exception($"Error removing super hero. No super hero found for id: {id}");
            }

            _context.Remove(superHero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
