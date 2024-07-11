namespace ProjetoDotinha2.Models
{
    public class HeroModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string img { get; set; }
        public string icon { get; set; }
        public double str_gain { get; set; }
        public string localized_name { get; set; }

        public string primary_attr { get; set; }
        
        public string attack_type { get; set; }
    }
}
