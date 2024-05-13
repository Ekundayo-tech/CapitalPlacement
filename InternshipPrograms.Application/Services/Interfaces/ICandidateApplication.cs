 
namespace InternshipPrograms.Application.Services.Interfaces
{
    public interface ICandidateApplication
    {
        Task<IEnumerable<CandidateApplicationDto>> GetAllAsync();
        Task<CandidateApplicationDto> GetAsync(string id);
        Task<string> AddAsync(CreateCandidateApplicationDto item);
        Task<string> UpdateAsync(UpdateCandidateApplicationDto item);
        Task<string> DeleteAsync(string id);
    }
}
