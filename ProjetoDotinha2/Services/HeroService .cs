using ProjetoDotinha2.Models;

namespace ProjetoDotinha2.Services
{
    public class HeroService : IHeroService
    {
        private List<HeroModel> _heroes;
        private readonly HttpClient _client;

        public HeroService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<HeroModel>> GetHeroesAsync()
        {
            if (_heroes == null)
            {
                HttpResponseMessage response = await _client.GetAsync("https://api.opendota.com/api/heroes");
                if (response.IsSuccessStatusCode)
                {
                    _heroes = await response.Content.ReadAsAsync<List<HeroModel>>();

                    Console.WriteLine("qtd: " + _heroes.Count);
                }
            }
            return _heroes;
        }

        public List<HeroModel> GetHeroes()
        {
            return _heroes;
        }

        public void GetHeroById(int id)
        {
            List<HeroModel> heroes = GetHeroes();
        }
    }
}
