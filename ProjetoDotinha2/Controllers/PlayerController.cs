using Microsoft.AspNetCore.Mvc;
using ProjetoDotinha2.Enums;
using ProjetoDotinha2.Models;
using ProjetoDotinha2.Models.ViewModels;
using ProjetoDotinha2.Repository;
using ProjetoDotinha2.Services;
using System.ComponentModel;
using System.Reflection;
using System;
using System.Globalization;
namespace ProjetoDotinha2.Controllers
{

    public class PlayerController : Controller
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IHeroService _heroService;

        public PlayerController (IPlayerRepository playerRepository, IHeroService heroService)
        {
            _playerRepository = playerRepository;
            _heroService = heroService;
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
                var gameModes = Enum.GetValues(typeof(TipoPartida)).Cast<TipoPartida>().ToList();
                Console.WriteLine("response2: " + response.profile.personaname);

                ShowViewModel showViewModel = new ShowViewModel();
                List<HeroModel> heroes = await _heroService.GetHeroesAsync();
                
                Console.WriteLine("Teste: " + heroes.Count);

                showViewModel.Player = response;
                showViewModel.Heroes = heroes;
                showViewModel.TipoPartidas = gameModes;

                return View(showViewModel);
            }


        }

               
    }

}
