namespace webMvc.Models
{
    public class AnimalViewModel
    {
        public Guid IdAnimal { get; set; }
        public string NomeAnimal { get; set; }
        public string Especie { get; set; }
        public string Porte { get; set; }
        public int IdadeEstimada { get; set; }
        public string Status { get; set; }
    }
}
