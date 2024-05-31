
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjetoDotinha2.Models;

namespace ProjetoDotinha2.Repository
{
    public class HeroRepository : IHeroRepository
    {
        private readonly HttpClient _httpClient;

        public HeroRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<HeroModel>> GetAllHeroes()
        {
            var response = await _httpClient.GetAsync("https://api.opendota.com/api/heroStats");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var heroes = JsonConvert.DeserializeObject<List<HeroModel>>(content);

            return heroes;
        }
    }
}
