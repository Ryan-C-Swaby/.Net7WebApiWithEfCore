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
        private List<SuperHero> _superHeroes { get; set; }

        public SuperHeroService()
        {
            _superHeroes = new List<SuperHero>()
            {
                new SuperHero()
                {
                    Id = 1,
                    Name = $"Batman",
                    FirstName = "Bruce",
                    LastName = "Wayne",
                    Place = "Gotham"
                },
                new SuperHero()
                {
                    Id = 2,
                    Name = "Superman",
                    FirstName = "Clark",
                    LastName = "Kent",
                    Place = "Metropolis"
                }
            };
        }

        public List<SuperHero> GetAll()
        {
            return _superHeroes;
        }

        public SuperHero? Get(int id)
        {
            return _superHeroes.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Add(SuperHero superHero)
        {
            int nextId = (_superHeroes.Max(x => x.Id) ?? 0) + 1;

            superHero.Id = nextId;

            _superHeroes.Add(superHero);
        }

        public void Update(SuperHero superHeroUpdate)
        {
            var superHero = _superHeroes.Where(x => x.Id == superHeroUpdate.Id).FirstOrDefault();

            if(superHero == null) 
            {
                throw new Exception($"Error updating super hero. Id: {superHeroUpdate.Id} not found.");
            }

            if (superHero != null)
            {
                superHero.Name = superHeroUpdate.Name;
                superHero.FirstName = superHeroUpdate.FirstName;
                superHero.LastName = superHeroUpdate.LastName;
                superHero.Place = superHeroUpdate.Place;
            }
        }

        public void Delete(int id)
        {
            var superHero = _superHeroes.Where(x =>x.Id == id).FirstOrDefault();   
            
            if(superHero == null)
            {
                throw new Exception($"Error deleting super hero. No superhero found with id: {id}");
            }

            _superHeroes.Remove(superHero);
        }
    }
}
