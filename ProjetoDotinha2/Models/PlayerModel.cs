using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjetoDotinha2.Models
{
    public class PlayerModel
    {
        [JsonPropertyName("rank_tier")]
        public string RankTier { get; set; }

        public int account_id { get; set; }

    }
}
