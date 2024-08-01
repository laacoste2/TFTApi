namespace TeamFightTacticsAPI.Models
{
    public class Champion
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public int Price { get; set; }

        public Champion(string Name, string Class, int Price)
        {
            this.Name = Name;
            this.Class = Class;
            this.Price = Price;
        }
    }
}
