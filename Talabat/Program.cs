using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Talabat.Core.Entitise;
using Talabat.Core.Repositories.Contrect;
using Talabat.Helpers;
using Talabat.Repository;

namespace Talabat
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                
            } );
           //builder.Services.AddScoped<IGenericRepositorty<Product>, GenericRepository<Product>>();
           //builder.Services.AddScoped<IGenericRepositorty<ProductBrand>, GenericRepository<ProductBrand>>();
           //builder.Services.AddScoped<IGenericRepositorty<ProductCategory>, GenericRepository<ProductCategory>>();
          
            builder.Services.AddScoped(typeof(IGenericRepositorty<>), typeof(GenericRepository<>));
            // Register AutoMapper  Services

            builder.Services.AddAutoMapper(typeof(MappingProfiles));

            var app = builder.Build();

           using var scope= app.Services.CreateScope();
           var services= scope.ServiceProvider;
           var _dbcontext =services.GetRequiredService<StoreContext>();
           var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await _dbcontext.Database.MigrateAsync(); //Update Datebase 
                await StoreContextSeed.SeedAsync(_dbcontext); // Data Saad 
            }
            catch (Exception Ex)
            {
                var logger =loggerFactory.CreateLogger<Program>();
                logger.LogError(Ex,"An Error Occurred During Migration (*_*) !!! ");
            }
           

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
