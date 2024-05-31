using ProjetoDotinha2.Models;

namespace ProjetoDotinha2.Repository
{
    public interface IHeroRepository
    {
        Task<List<HeroModel>> GetAllHeroes();
    }
}
