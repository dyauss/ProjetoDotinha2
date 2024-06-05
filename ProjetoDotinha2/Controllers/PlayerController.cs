using Microsoft.AspNetCore.Mvc;
using ProjetoDotinha2.Models;
using ProjetoDotinha2.Repository;

namespace ProjetoDotinha2.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;


        public PlayerController (IPlayerRepository playerRepository )
        {
            _playerRepository = playerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetPlayerById(string id)
        {
            var player = await _playerRepository.GetPlayerById(id);
            return Ok(player);
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var player = await _playerRepository.GetPlayerById("193827172");
            return View(player);
        }

        [HttpPost]
        public async Task <IActionResult> Show(string account_id)
        {
            Console.WriteLine("alo" + account_id);

            var player = await _playerRepository.GetPlayerById("193827172");

            return View(player);
        }
    }
}
