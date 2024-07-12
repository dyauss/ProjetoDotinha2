using ProjetoDotinha2.Enums;

namespace ProjetoDotinha2.Models.ViewModels
{
    public class ShowViewModel
    {
        public List<HeroModel> Heroes { get; set; }
        public PlayerModel Player { get; set; }

        public List<TipoPartida> TipoPartidas { get; set; }
    }
}