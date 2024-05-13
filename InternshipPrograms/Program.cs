 

namespace InternshipPrograms
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Host.UseSerilog((context, config) =>
            {
                config.Enrich.FromLogContext()
                    .WriteTo.Console()
                    .ReadFrom.Configuration(context.Configuration);
            });

            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(); 
            builder.Services.AddApiServiceDependencies(builder.Configuration);
            builder.Services.AddDataDependencies(builder.Configuration); 

       

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                bool _ensureCreated = false;
                if (!_ensureCreated)
                {
                    try
                    {
                        DataContext dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
                        dbContext.Database.EnsureCreated();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                    _ensureCreated = true;
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}