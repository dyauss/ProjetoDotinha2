using Microsoft.AspNetCore.Mvc;
using ProjetoDotinha2.Models;
using ProjetoDotinha2.Repository;


namespace ProjetoDotinha2.Controllers
{
    public class HeroController : Controller
    {
        private readonly IHeroRepository _heroRepository;

        public HeroController(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = await _heroRepository.GetAllHeroes();
            return Ok(heroes);
        }
        public async Task<IActionResult> Index()
        {
            var heroes = await _heroRepository.GetAllHeroes();
            return View(heroes);
        }

    }
}
