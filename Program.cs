using StudentRelationApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentRelationApi.Data;



namespace StudentRelationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<StudentRelationApiContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("StudentRelationApiContext") ?? throw new InvalidOperationException("Connection string 'StudentRelationApiContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();

             builder.Services.AddDbContext<StudentRelationContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

          
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