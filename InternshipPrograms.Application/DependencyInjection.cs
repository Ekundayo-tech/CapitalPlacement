 
namespace InternshipPrograms.Application
{
    public static class DependencyInjection
    { 
        public static IServiceCollection AddApiServiceDependencies(this IServiceCollection services, IConfiguration configuration)
        {

             services.AddTransient<IProgramDetails, ProgramDetailsService>();
             services.AddTransient<ICandidateApplication, CandidateApplicationService>();
            services.AddTransient<IQuestion, QuestionsService>();

            return services;
        }
    }
}
