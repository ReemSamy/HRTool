using HRTool.BL;
using HRTool.BL.Services;
using HRTool.DAL;
using HRTool.DAL.Repos.VacationRepo;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace HRTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var DbConnction = builder.Configuration.GetConnectionString("DBConnection");
            // Add services to the container.
            builder.Services.AddDbContext<HRContext>(options=>
            {
                options.UseSqlServer(DbConnction);
            });
            //builder.Services.AddControllers().AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            //});
            builder.Services.AddControllers();

            #region Employee Configuration
            builder.Services.AddScoped<IEmployeeRepo,EmployeeRepo>();   
            builder.Services.AddScoped<IEmployeeManager,EmployeeManager>();
            #endregion

            #region Vacation Configuration
            builder.Services.AddScoped<IVacationRepo, VacationRepo>();
            builder.Services.AddScoped<IVacationsManager, VacationManager>();
            #endregion

            builder.Services.AddSingleton<ICalculationServices, CalculationServices>(); 

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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