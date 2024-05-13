using InternshipPrograms.Domain.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace InternshipPrograms.Application.Dtos
{
    public class UpdateProgramDetailDto
    {
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
    public class CreateProgramDetailDto
    { 
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
        public class ProgramDetailDto
    {
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
        public ProgramDetailDto(Program db)
        { 
            Id = db.Id; 
            Description = db.Description;
            Title = db.Title; 
            FirstName = db.FirstName;
            LastName = db.LastName;
            Email = db.Email;
            Phone = db.Phone;
            HidePhone = db.HidePhone;
            IsPhoneInternal = db.IsPhoneInternal;
            Nationality = db.Nationality;
            HideNationality = db.HideNationality;
            IsNationalityInternal = db.IsNationalityInternal;
            CurrentResidence = db.CurrentResidence;
            HideCurrentResidence = db.HideCurrentResidence;
            IsCurrentResidenceInternal = db.IsCurrentResidenceInternal;
            IDNumber = db.IDNumber;
            HideIDNumber = db.HideIDNumber;
            IsIDNumberInternal = db.IsIDNumberInternal;
            DOB = db.DOB;
            HideDOB = db.HideDOB;
            IsDOBInternal = db.IsDOBInternal;
            Gender = db.Gender;
            HideGender = db.HideGender;
            IsGenderInternal = db.IsGenderInternal;
        }
    }
}
