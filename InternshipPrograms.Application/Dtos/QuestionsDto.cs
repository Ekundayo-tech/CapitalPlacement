using InternshipPrograms.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace InternshipPrograms.Application.Dtos
{

    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public T Data { get; set; }
        public int? StatusCode { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
    public class CreateQuestionsDto
    { 
        public string Name { get; set; }
        public string Type { get; set; }
        public string[]? Choices { get; set; }
        public string? MaxChoiceAllowed { get; set; }
        public bool EnbaleOtherOptions { get; set; }
    }
    public class UpdateQuestionsDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string[]? Choices { get; set; }
        public string? MaxChoiceAllowed { get; set; }
        public bool EnbaleOtherOptions { get; set; }
    }
        public class QuestionsDto
    { 
            public string Id { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            public string[] Choices { get; set; }
            public string MaxChoiceAllowed { get; set; }
            public bool EnbaleOtherOptions { get; set; }
        
        public QuestionsDto(Questions db)
        {
            Id = db.Id;
            Name = db.Name;
            Type = db.Type;
            Choices = !string.IsNullOrEmpty(db.Choices) ? db.Choices.Split(',').ToArray() : Array.Empty<string>();
            MaxChoiceAllowed = db.MaxChoiceAllowed; 
            EnbaleOtherOptions = db.EnbaleOtherOptions; 
        }
    }
}
