 

namespace InternshipPrograms.Domain.Entities
{
    public  class CandidateApplication
    {
        [Key]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string YearOfGraduation { get; set; }
        public string AboutYourself { get; set; }
        public bool IsRejected { get; set; }
        public string MultipleChoice { get; set; }
        public string DateMovedToUK { get; set; }
        public string YearOfExperience { get; set; }
    }
}
