
namespace InternshipPrograms.Domain.Entities
{
    public class Questions
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Choices { get; set; }
        public string MaxChoiceAllowed { get; set; }
        public bool EnbaleOtherOptions { get; set; } 
    }
}
