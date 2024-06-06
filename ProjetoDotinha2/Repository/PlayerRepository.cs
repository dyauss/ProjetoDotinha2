
using System.Text.Json;
using Newtonsoft.Json;
using ProjetoDotinha2.Models;

namespace ProjetoDotinha2.Repository
{
    public class PlayerRepository : IPlayerRepository
    {

        private readonly HttpClient _httpClient;

        public PlayerRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PlayerModel> GetPlayerById (int id)
        {
            var response = await _httpClient.GetAsync("https://api.opendota.com/api/players/" + id);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Capivara 4" + content.ToString());
    
            var player = JsonConvert.DeserializeObject<PlayerModel>(content);

            Console.WriteLine("Player Name: " + player.profile.personaname);

            return player;

        }


    }
}
