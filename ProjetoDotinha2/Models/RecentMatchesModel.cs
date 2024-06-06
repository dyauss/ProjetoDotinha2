namespace ProjetoDotinha2.Models
{
    public class RecentMatchesModel
    {
        public int match_id { get; set; }
        public int player_slot { get; set;}
        public bool radiant_win { get; set; }
        public int duration { get; set; }
        public int game_mode { get; set; }
        public int lobby_type { get; set; }
        public int hero_id { get; set; }
        public int start_time { get; set; }
        public string version { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int average_rank { get; set; }
        public int leaver_status { get; set; }
        public string party_size { get; set; }
        public int hero_variant { get; set; }

    }
}
                                                                                  