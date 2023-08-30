namespace AdoptiverseAPI.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public bool Adoptable { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public Shelter Shelter { get; set; }
    }
}
