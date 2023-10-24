using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;
using SuperHeroApi.Services;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;

        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var superHeroes = _superHeroService.GetAll();

            return Ok(superHeroes);
        }

        [HttpGet]
        [Route("get{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var superHero = _superHeroService.Get(id);

            if (superHero == null)
            {
                return NotFound($"No superherod found with id: {id}");
            }

            return Ok(superHero);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SuperHero newSuperHero)
        {
            _superHeroService.Add(newSuperHero);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(SuperHero superHeroUpdate)
        {
            _superHeroService.Update(superHeroUpdate);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _superHeroService.Delete(id);

            return Ok();
        }
    }
}
