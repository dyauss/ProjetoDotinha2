using ProjetoDotinha2.Enums;

namespace ProjetoDotinha2.Models.ViewModels
{
    public class ShowViewModel
    {
        public List<HeroModel> Heroes { get; set; }
        public PlayerModel Player { get; set; }
        public List<TipoPartida> TipoPartidas { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<RecentMatchesModel> PagedMatches { get; set; }
    }
}