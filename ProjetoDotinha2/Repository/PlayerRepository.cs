
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using ProjetoDotinha2.Models;
using ProjetoDotinha2.Services;

namespace ProjetoDotinha2.Repository
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IHeroService _heroService;

        public PlayerRepository(HttpClient httpClient, IHeroService heroService)
        {
            _httpClient = httpClient;
            _heroService = heroService;
        }

        public async Task<PlayerModel> GetPlayerById (int id)
        {
            var response = await _httpClient.GetAsync("https://api.opendota.com/api/players/" + id);

            if (response.IsSuccessStatusCode)
            {
                var matchesResponse = await _httpClient.GetAsync("https://api.opendota.com/api/players/" + id + "/matches");
                matchesResponse.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                var matchesContent = await matchesResponse.Content.ReadAsStringAsync();

                Console.WriteLine("Capivara 4" + content.ToString());

                var player = JsonConvert.DeserializeObject<PlayerModel>(content);
                var matches = JsonConvert.DeserializeObject<List<RecentMatchesModel>>(matchesContent);

                List<HeroModel> heroes = await _heroService.GetHeroesAsync();
                foreach (RecentMatchesModel match in matches)
                {
                    //Console.WriteLine("match: " + match.hero_id);
                    HeroModel result = heroes.Find(x => x.Id == match.hero_id);
                    //Console.WriteLine("nome do heroi: " + result.localized_name);
                    match.hero_name = result.localized_name;
                    match.hero_image = result.img;                
                                                            
                }


                Console.WriteLine("Player Name: " + player.profile.personaname);
                Console.WriteLine("Match id:" + matches[0].match_id);
                Console.WriteLine("Hero name da match:" + matches[0].hero_name);

                player.RecentMatches = matches;


                Console.WriteLine("Match id " + player.RecentMatches[1].match_id);
                

                return player;
            } else
            {
                return null;
            }
        }
    }
}
