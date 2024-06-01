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

        public async Task <IActionResult> Index()
        {
            var player = await _playerRepository.GetPlayerById("215584921");
            return View(player);
        }

       /* [HttpPost]
        public IActionResult Search (PlayerModel player)
        {

        } */

    }
}
