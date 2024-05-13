
namespace InternshipPrograms.Domain.Entities
{ 
    public class Program
    {
        [Key] 
        public string Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsPhoneInternal { get; set; }
        public bool HidePhone { get; set; }
        public string Nationality { get; set; }
        public bool IsNationalityInternal { get; set; }
        public bool HideNationality { get; set; }
        public string CurrentResidence { get; set; }
        public bool IsCurrentResidenceInternal { get; set; }
        public bool HideCurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public bool IsIDNumberInternal { get; set; }
        public bool HideIDNumber { get; set; }
        public string DOB { get; set; }
        public bool IsDOBInternal { get; set; }
        public bool HideDOB { get; set; }
        public string Gender { get; set; }
        public bool IsGenderInternal { get; set; }
        public bool HideGender { get; set; }
    }
}
