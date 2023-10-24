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
            var superHeroes = await _superHeroService.GetAll();

            return Ok(superHeroes);
        }

        [HttpGet]
        [Route("get{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var superHero = await _superHeroService.Get(id);

            if (superHero == null)
            {
                return NotFound($"No superherod found with id: {id}");
            }

            return Ok(superHero);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(SuperHero newSuperHero)
        {
            await _superHeroService.Add(newSuperHero);

            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(SuperHero superHeroUpdate)
        {
            var superHeroes = await _superHeroService.Update(superHeroUpdate);

            return Ok(superHeroes);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var superHeroes = await _superHeroService.Delete(id);

            return Ok(superHeroes);
        }
    }
}
