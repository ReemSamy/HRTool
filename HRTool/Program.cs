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
            #region Register Context
            builder.Services.AddDbContext<HRContext>(options=>
            {
                options.UseSqlServer(DbConnction);
            });
            #endregion

            builder.Services.AddControllers();

            #region Handle Enum 
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            #endregion

            #region Employee Configuration
            builder.Services.AddScoped<IEmployeeRepo,EmployeeRepo>();   
            builder.Services.AddScoped<IEmployeeManager,EmployeeManager>();
            #endregion

            #region Vacation Configuration
            builder.Services.AddScoped<IVacationRepo, VacationRepo>();
            builder.Services.AddScoped<IVacationsManager, VacationManager>();
            #endregion

            #region Caluclation Service Configuration

            builder.Services.AddSingleton<ICalculationServices, CalculationServices>();
            #endregion

            #region Handle Integration with Front-End

            builder.Services.AddCors(o =>
            {
                o.AddPolicy("all", p =>
                {
                    p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            #endregion

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

            app.UseCors("all");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}