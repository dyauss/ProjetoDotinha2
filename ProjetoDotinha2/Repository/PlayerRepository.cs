
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
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
                var matchesResponse = await _httpClient.GetAsync("https://api.opendota.com/api/players/" + id + "/matches?significant=0");
                matchesResponse.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var recentMatchesContent = await matchesResponse.Content.ReadAsStringAsync();

                Console.WriteLine("Capivara 4" + content.ToString());

                var player = JsonConvert.DeserializeObject<PlayerModel>(content);
                var recentMatches = JsonConvert.DeserializeObject<List<RecentMatchesModel>>(recentMatchesContent);

                List<HeroModel> heroes = await _heroService.GetHeroesAsync();
                foreach (RecentMatchesModel recentMatch in recentMatches)
                {
                    var response1 = await _httpClient.GetAsync("https://api.opendota.com/api/matches/" + recentMatch.match_id);
                    var matchContent = await response1.Content.ReadAsStringAsync();
                    var match = JsonConvert.DeserializeObject<MatchModel>(matchContent); 


                    Console.WriteLine("Gold = " + match.patch);
                    //Console.WriteLine("match: " + match.hero_id);
                    HeroModel result = heroes.Find(x => x.Id == recentMatch.hero_id);
                    if (recentMatch.hero_id == 0)
                    {
                        recentMatch.hero_name = "Partida desconsiderada";
                    } else
                    {
                        //Console.WriteLine("nome do heroi: " + result.localized_name);
                        recentMatch.hero_name = result.localized_name;
                        recentMatch.hero_image = result.img;
                    }

                }

                Console.WriteLine("Player Name: " + player.profile.personaname);
                Console.WriteLine("Match id:" + recentMatches[0].match_id);
                Console.WriteLine("Hero name da match:" + recentMatches[0].hero_name);
               

                player.RecentMatches = recentMatches;


                Console.WriteLine("Match id " + player.RecentMatches[1].match_id);
                

                return player;
            } else
            {
                return null;
            }
        }
    }
}
