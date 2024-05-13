using InternshipPrograms.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace InternshipPrograms.Application.Dtos
{
    public class UpdateCandidateApplicationDto
    {
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
        public string[] MultipleChoice { get; set; }
        public string DateMovedToUK { get; set; }
        public string YearOfExperience { get; set; }
    }
    public class CreateCandidateApplicationDto
    {
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
        public string[] MultipleChoice { get; set; }
        public string DateMovedToUK { get; set; }
        public string YearOfExperience { get; set; }
    }
        public class CandidateApplicationDto
    {
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
    
        public CandidateApplicationDto(CandidateApplication db)
        {
            Id = db.Id;
            FirstName = db.FirstName;
            LastName = db.LastName;
            Phone = db.Phone;
            Email = db.Email;
            Nationality = db.Nationality;
            IDNumber = db.IDNumber;
            Gender = db.Gender;
            DOB = db.DOB;
            CurrentResidence = db.CurrentResidence;
            IsRejected = db.IsRejected;
            MultipleChoice = db.MultipleChoice;
            DateMovedToUK = db.DateMovedToUK;
            YearOfExperience = db.YearOfExperience;
            AboutYourself = db.AboutYourself;
            YearOfGraduation = db.YearOfGraduation;
        }
    }
}
