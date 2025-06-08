namespace webMvc.Models
{
    public class AdocaoViewModel
    {
        public Guid IdAdocao { get; set; }
        public Guid IdPessoa { get; set; }
        public Guid IdAnimal { get; set; }
        public DateTime DataAdocao { get; set; }
        public string TipoAdocao { get; set; }
    }
}
