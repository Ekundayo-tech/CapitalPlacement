namespace InternshipPrograms.Application.Services.Interfaces
{
    public interface IProgramDetails
    {
        Task<IEnumerable<ProgramDetailDto>> GetAllAsync();
        Task<ProgramDetailDto> GetAsync(string id);
        Task<string> AddAsync(CreateProgramDetailDto item);
        Task<string> UpdateAsync(UpdateProgramDetailDto item);
        Task<string> DeleteAsync(string id);
    }
}
