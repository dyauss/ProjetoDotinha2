using Microsoft.AspNetCore.Mvc;
using ProjetoDotinha2.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProjetoDotinha2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string teste = "SuperTeste";

        static HttpClient client = new HttpClient();
        static async Task<List<HeroModel>> GetHeroes(string path)
        {
            List<HeroModel> heroes = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if(response.IsSuccessStatusCode)
            {
                heroes = await response.Content.ReadAsAsync<List<HeroModel>>();
            }
            return heroes;
        }

        static async Task<Team> GetTeam(string path)
        {
            Team team = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                team = await response.Content.ReadAsAsync<Team>();
            }
            return team;
        }



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Team team = await GetTeam("https://api.opendota.com/api/teams/2586976");
            List<HeroModel> heroes = await GetHeroes("https://api.opendota.com/api/heroes");

            ViewData["teste"] = team.name;
            return View(heroes);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
