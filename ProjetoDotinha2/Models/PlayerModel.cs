using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoDotinha2.Models
{
    public class PlayerModel
    {
        // Esse código Json abaixo não está funcionando
        [JsonPropertyName("rank_tier")]
        public int Id { get; set; }
        public int account_id { get; set; }
        public string rank_tier { get; set; }
        public Profile profile { get; set; }
        public List <RecentMatchesModel> RecentMatches { get; set; }

    }
}

