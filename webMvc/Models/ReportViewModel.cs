namespace webMvc.Models
{
    public class ReportViewModel
    {
        public Guid IdReport { get; set; }
        public Guid IdPessoa { get; set; }
        public Guid IdAnimal { get; set; }
        public Guid IdLocal { get; set; }
        public Guid IdSensor { get; set; }
        public DateTime DataReport { get; set; }
        public string DescricaoLocal { get; set; }
        public string StatusReport { get; set; }
    }

}
