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
using X.PagedList;
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

        [HttpGet]
        public async Task <IActionResult> Show(int account_id, int page = 1)
        {
           
            var player = await _playerRepository.GetPlayerById(account_id);

            if (player == null)
            {
                ViewData["notfound"] = "Não foi encontrado";
                return View();
            } else
            {
                var gameModes = Enum.GetValues(typeof(TipoPartida)).Cast<TipoPartida>().ToList();
                List<HeroModel> heroes = await _heroService.GetHeroesAsync();

                int pageSize = 10;
                var totalMatches = player.RecentMatches.Count;
                var totalPages = (int)Math.Ceiling(totalMatches / (double)pageSize);

                var matches = player.RecentMatches
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                ShowViewModel showViewModel = new ShowViewModel();
                showViewModel.Player = player;
                showViewModel.Heroes = heroes;
                showViewModel.TipoPartidas = gameModes;
                showViewModel.CurrentPage = page;
                showViewModel.TotalPages = totalPages;
                showViewModel.PagedMatches = matches;


                return View(showViewModel);
            }


        }

               
    }

}
