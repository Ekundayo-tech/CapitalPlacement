using InternshipPrograms.Application.Dtos;
using InternshipPrograms.Application.Services.Interfaces;
using InternshipPrograms.Domain.Entities;
 

namespace InternshipPrograms.Application.Services.Implementations
{
    public class CandidateApplicationService : ICandidateApplication
    {
        private readonly DataContext context;
        private readonly IServiceProvider _provider;
        private readonly ILogger logger;
        private readonly IServiceScope scope;
        public CandidateApplicationService(IServiceProvider provider)
        { 
            _provider = provider;
            scope = _provider.CreateScope(); 
            logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            context = scope.ServiceProvider.GetRequiredService<DataContext>();
        } 
        public async Task<string> AddAsync(CreateCandidateApplicationDto entity)
        { 
            try
            {
                CandidateApplication candidate = new();
                candidate.Id = Guid.NewGuid().ToString();
                candidate.FirstName = entity.FirstName;
                candidate.LastName = entity.LastName;
                candidate.Phone = entity.Phone; 
                candidate.Gender = entity.Gender; 
                candidate.Nationality = entity.Nationality; 
                candidate.DOB = entity.DOB; 
                candidate.IDNumber = entity.IDNumber; 
                candidate.CurrentResidence = entity.CurrentResidence; 
                candidate.MultipleChoice = string.Join(',', entity.MultipleChoice); 
                candidate.DateMovedToUK = entity.DateMovedToUK; 
                candidate.YearOfExperience = entity.YearOfExperience; 
                candidate.YearOfGraduation = entity.YearOfExperience; 
                candidate.YearOfExperience = entity.YearOfExperience; 

                await context.CandidateApplication.AddAsync(candidate);
                await context.SaveChangesAsync();

                return "saved successfully";
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<string> DeleteAsync(string id)
        {
            var taskToRemove = context.CandidateApplication.Find(id);
            if (taskToRemove != null)
            {
                context.CandidateApplication.Remove(taskToRemove);
                context.SaveChanges();
                return await Task.FromResult("deleted successfully");
            }
            return await Task.FromResult("an error occured");
        }

        public async Task<IEnumerable<CandidateApplicationDto>> GetAllAsync()
        {
            var project = await context.CandidateApplication.AsNoTracking().Select(x => new CandidateApplicationDto(x)).ToListAsync();
            return project;
        }

        public async Task<CandidateApplicationDto> GetAsync(string id)
        {
            var res = await context.CandidateApplication.Where(p => p.Id == id).AsNoTracking().Select(x => new CandidateApplicationDto(x)).FirstOrDefaultAsync();
            return res;
        }

        public async Task<string> UpdateAsync(UpdateCandidateApplicationDto entity)
        {
            try
            { 
                var candidate = await context.CandidateApplication.FirstOrDefaultAsync(x => x.Id == entity.Id);
                ArgumentNullException.ThrowIfNull(candidate);


                candidate.FirstName = entity.FirstName;
                candidate.LastName = entity.LastName;
                candidate.Phone = entity.Phone;
                candidate.Gender = entity.Gender;
                candidate.Nationality = entity.Nationality;
                candidate.DOB = entity.DOB;
                candidate.IDNumber = entity.IDNumber;
                candidate.CurrentResidence = entity.CurrentResidence;
                candidate.MultipleChoice = string.Join(',', entity.MultipleChoice);
                candidate.DateMovedToUK = entity.DateMovedToUK;
                candidate.YearOfExperience = entity.YearOfExperience;
                candidate.YearOfGraduation = entity.YearOfExperience;
                candidate.YearOfExperience = entity.YearOfExperience;

                await context.SaveChangesAsync();

                return "updated successfully";
            }
            catch (Exception e)
            {
                throw;
            }
        }
    } 
}
