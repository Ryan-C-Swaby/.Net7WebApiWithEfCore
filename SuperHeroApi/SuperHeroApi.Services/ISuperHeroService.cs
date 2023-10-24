using SuperHeroApi.Models;

namespace SuperHeroApi.Services
{
    public interface ISuperHeroService
    {
        Task Add(SuperHero superHero);
        Task<List<SuperHero>> Delete(int id);
        Task<SuperHero?> Get(int id);
        Task<List<SuperHero>> GetAll();
        Task<List<SuperHero>> Update(SuperHero superHero);
    }
}