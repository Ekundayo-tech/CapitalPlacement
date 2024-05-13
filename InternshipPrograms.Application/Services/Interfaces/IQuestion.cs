namespace InternshipPrograms.Application.Services.Interfaces
{
    public interface IQuestion
    {
        Task<IEnumerable<QuestionsDto>> GetAllAsync();
        Task<QuestionsDto> GetAsync(string id);
        Task<QuestionsDto> GetByTypeAsync(string type);
        Task<string> AddAsync(CreateQuestionsDto item);
        Task<string> UpdateAsync(UpdateQuestionsDto item);
        Task<string> DeleteAsync(string id);
    }
}
