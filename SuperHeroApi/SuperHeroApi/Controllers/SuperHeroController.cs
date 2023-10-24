using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> _superHeroes = new List<SuperHero>()
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


        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_superHeroes);
        }

        [HttpGet]
        [Route("get{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var superHero = _superHeroes.Where(x => x.Id == id).FirstOrDefault();

            if (superHero == null)
            {
                return NotFound($"No superherod found with id: {id}");
            }

            return Ok(superHero);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SuperHero newSuperHero)
        {
            int? maxSuperHeroId = _superHeroes.Max(x => x.Id) + 1;

            newSuperHero.Id = maxSuperHeroId;

            _superHeroes.Add(newSuperHero);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SuperHero superHeroUpdate)
        {
            var superHero = _superHeroes.Where(x => x.Id == superHeroUpdate.Id).FirstOrDefault();

            if(superHero == null)
            {
                return NotFound($"No hero found with id {superHeroUpdate.Id}");
            }

            if (superHero != null)
            {
                superHero.Name = superHeroUpdate.Name;
                superHero.FirstName = superHeroUpdate.FirstName;
                superHero.LastName = superHeroUpdate.LastName;
                superHero.Place= superHeroUpdate.Place;
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var superHero = _superHeroes.Where(x => x.Id!= id).FirstOrDefault();

            if (superHero == null)
            {
                return BadRequest($"No super hero found with id: {id}");
            }

            _superHeroes.Remove(superHero);

            return Ok();
        }
    }
}
