using ProjetoDotinha2.Models;

namespace ProjetoDotinha2.Repository
{
    public interface IPlayerRepository
    {
        Task<PlayerModel> GetPlayerById(int id);

    }
}
