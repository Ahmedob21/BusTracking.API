using BusTracking.Core.ICommon;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using BusTracking.Infra.Common;
using BusTracking.Infra.Repository;
using BusTracking.Infra.Service;

namespace BusTracking.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddScoped<IDbContext, DbContext>();







            //Service
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IBusService, BusService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IChildService, ChildService>();





            //Repository
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IBusRepository, BusRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IChildRepository, ChildRepository>();








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
