namespace AdoptiverseAPI.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public bool FosterProgram { get; set; }
        public int Rank { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
