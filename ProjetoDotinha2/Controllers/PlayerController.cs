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
        public async Task<IActionResult> GetPlayerById(int id)
        {
            var player = await _playerRepository.GetPlayerById(id);
            return Ok(player);
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var player = await _playerRepository.GetPlayerById(193827172);
            return View(player);
        }

        [HttpPost]
        public async Task <IActionResult> Show(int account_id)
        {
            var response = await _playerRepository.GetPlayerById(account_id);

            if (response == null)
            {
                ViewData["notfound"] = "Não foi encontrado";
                return View();
            } else
            {
                Console.WriteLine(response);
                return View(response);
            }
        }
    }
}
