namespace InternshipPrograms.Application.Services.Implementations
{ 
    public class QuestionsService : IQuestion
    {
        private readonly DataContext context;
        private readonly IServiceProvider _provider;
        private readonly ILogger logger;
        private readonly IServiceScope scope;
        public QuestionsService(IServiceProvider provider)
        {
            _provider = provider;
            scope = _provider.CreateScope();
            logger = scope.ServiceProvider.GetRequiredService<ILogger>();
            context = scope.ServiceProvider.GetRequiredService<DataContext>();
        }

        public async Task<string> AddAsync(CreateQuestionsDto entity)
        {
            try
            {

                logger.Information($"Request:{entity}");
                if (entity.Choices.Count() > int.Parse(entity.MaxChoiceAllowed))
                {
                    return "Maximum choice exceeded";
                }
                 
                Questions question = new();
                question.Id = Guid.NewGuid().ToString();
                 
                question.Name = entity.Name;
                question.Type = entity.Type;
                question.Choices = string.Join(',',entity.Choices);
                question.MaxChoiceAllowed = entity.MaxChoiceAllowed; 
                question.EnbaleOtherOptions = entity.EnbaleOtherOptions; 
                

                await context.Questions.AddAsync(question);
                await context.SaveChangesAsync();

                return "saved successfully";
            }
            catch (Exception e)
            {
                logger.Error($"Exception:{e}");
                throw;
            }
        }

        public async Task<string> DeleteAsync(string id)
        {
            var taskToRemove = context.Questions.Find(id);

            logger.Information($"deleted: {taskToRemove}");
            if (taskToRemove != null)
            {
                context.Questions.Remove(taskToRemove);
                context.SaveChanges();
                return await Task.FromResult("deleted succesfully");
            }
            return await Task.FromResult("An error occured");
        }

        public async Task<IEnumerable<QuestionsDto>> GetAllAsync()
        {
            var project = await context.Questions.AsNoTracking().Select(x => new QuestionsDto(x)).ToListAsync();
            return project;
        }

        public async Task<QuestionsDto> GetAsync(string id)
        {
            var res = await context.Questions.Where(p => p.Id == id).AsNoTracking().Select(x => new QuestionsDto(x)).FirstOrDefaultAsync();

            logger.Information($"Response: {res}");
            return res;
        }

        public async Task<QuestionsDto> GetByTypeAsync(string type)
        {
            var res = await context.Questions.Where(p => p.Type == type).AsNoTracking().Select(x => new QuestionsDto(x)).FirstOrDefaultAsync();
            return res;
        }

        public async Task<string> UpdateAsync(UpdateQuestionsDto entity)
        {
            try
            {

                logger.Information($"Request: {entity}");
                var question = await context.Questions.FirstOrDefaultAsync(x => x.Id == entity.Id);

                ArgumentNullException.ThrowIfNull(question);


                question.Name = entity.Name;
                question.Type = entity.Type;
                question.Choices = string.Join(',', entity.Choices);
                question.MaxChoiceAllowed = entity.MaxChoiceAllowed;
                question.EnbaleOtherOptions = entity.EnbaleOtherOptions;


                await context.SaveChangesAsync();

                return "updated successfully";
            }
            catch (Exception e)
            {

                logger.Error($"Exception:{e}");
                return "An Error Occured";
            }
        }
    } 
}
