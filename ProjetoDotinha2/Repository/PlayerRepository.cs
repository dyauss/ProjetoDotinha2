
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

            var matchesResponse = await _httpClient.GetAsync("https://api.opendota.com/api/players/" + id + "/matches");
            matchesResponse.EnsureSuccessStatusCode();
            
            var content = await response.Content.ReadAsStringAsync();

            var matchesContent = await matchesResponse.Content.ReadAsStringAsync();

            Console.WriteLine("Capivara 4" + content.ToString());
    
            var player = JsonConvert.DeserializeObject<PlayerModel>(content);
            var matches = JsonConvert.DeserializeObject<List<RecentMatchesModel>>(matchesContent);
            
            Console.WriteLine("Player Name: " + player.profile.personaname);
            Console.WriteLine("Match id:" + matches[0].match_id);

            player.RecentMatches = matches;


            Console.WriteLine("Match id " + player.RecentMatches[1].match_id);
            return player;
        }

        


    }
}
