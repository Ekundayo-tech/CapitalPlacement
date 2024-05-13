 
namespace InternshipPrograms.Application.Services.Implementations
{
    public class ProgramDetailsService : IProgramDetails
    {
        private readonly DataContext context;
        private readonly IServiceProvider _provider;
        private readonly ILogger logger;
        private readonly IServiceScope scope;
        public ProgramDetailsService(IServiceProvider provider)
        {
            _provider = provider;
            scope = _provider.CreateScope();
            logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            context = scope.ServiceProvider.GetRequiredService<DataContext>();
        }

        public async Task<string> AddAsync(CreateProgramDetailDto entity)
        {
            try
            {
                Program program = new();

                program.Id = Guid.NewGuid().ToString();

                program.Title = entity.Title;
                program.Description = entity.Description;
                program.FirstName = entity.FirstName;
                program.LastName = entity.LastName;
                program.Email = entity.Email;
                program.Phone = entity.Phone;
                program.IsCurrentResidenceInternal = entity.IsCurrentResidenceInternal;
                program.HideCurrentResidence = entity.HideCurrentResidence;
                program.CurrentResidence = entity.CurrentResidence;
                program.HidePhone = entity.HidePhone;
                program.IsPhoneInternal = entity.IsPhoneInternal;
                program.DOB = entity.DOB;
                program.HideDOB = entity.HideDOB;
                program.IsDOBInternal = entity.IsDOBInternal;
                program.Gender = entity.Gender;
                program.HideGender = entity.HideGender;
                program.IsGenderInternal = entity.IsGenderInternal;
                program.Nationality = entity.Nationality;
                program.HideNationality = entity.HideNationality;
                program.IsNationalityInternal = entity.IsNationalityInternal;
                program.IDNumber = entity.IDNumber;
                program.HideIDNumber = entity.HideIDNumber;
                program.IsIDNumberInternal = entity.IsIDNumberInternal;

                await context.Program.AddAsync(program);
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
            var taskToRemove = context.Program.Find(id);
            if (taskToRemove != null)
            {
                context.Program.Remove(taskToRemove);
                context.SaveChanges();
                return await Task.FromResult("Deleted Sucessusfully");
            }
            return await Task.FromResult("An error Occured");
        }

        public async Task<IEnumerable<ProgramDetailDto>> GetAllAsync()
        {
            var project = await context.Program.AsNoTracking().Select(x => new ProgramDetailDto(x)).ToListAsync();
            return project;
        }

        public async Task<ProgramDetailDto> GetAsync(string id)
        {
            var res = await context.Program.AsNoTracking().Where(p => p.Id == id).Select(x => new ProgramDetailDto(x)).FirstOrDefaultAsync();
            return res;
        }

        public async Task<string> UpdateAsync(UpdateProgramDetailDto entity)
        {
            try
            { 
                var program = await context.Program.FirstOrDefaultAsync(x => x.Id == entity.Id);

                ArgumentNullException.ThrowIfNull(program);

                program.Title = entity.Title; 
                program.Description = entity.Description; 
                program.FirstName = entity.FirstName;
                program.LastName = entity.LastName;
                program.Email = entity.Email;
                program.Phone = entity.Phone;
                program.IsCurrentResidenceInternal = entity.IsCurrentResidenceInternal;
                program.HideCurrentResidence = entity.HideCurrentResidence;
                program.CurrentResidence = entity.CurrentResidence;
                program.HidePhone = entity.HidePhone; 
                program.IsPhoneInternal = entity.IsPhoneInternal; 
                program.DOB = entity.DOB;
                program.HideDOB = entity.HideDOB;
                program.IsDOBInternal = entity.IsDOBInternal;
                program.Gender = entity.Gender;
                program.HideGender = entity.HideGender;
                program.IsGenderInternal = entity.IsGenderInternal;
                program.Nationality = entity.Nationality;
                program.HideNationality = entity.HideNationality;
                program.IsNationalityInternal = entity.IsNationalityInternal;
                program.IDNumber = entity.IDNumber;
                program.HideIDNumber = entity.HideIDNumber;
                program.IsIDNumberInternal = entity.IsIDNumberInternal;
                 
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
