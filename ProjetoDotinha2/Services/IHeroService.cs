using ProjetoDotinha2.Models;

namespace ProjetoDotinha2.Services
{
    public interface IHeroService
    {
        Task<List<HeroModel>> GetHeroesAsync();
        List<HeroModel> GetHeroes();
    }
}
