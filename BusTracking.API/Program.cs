using BusTracking.Core.ICommon;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using BusTracking.Infra.Common;
using BusTracking.Infra.Repository;
using BusTracking.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            builder.Services.AddScoped<IContactUsService, ContactUsService>();
            builder.Services.AddScoped<IPageContentService, PageContentService>();
            builder.Services.AddScoped<ITestimonialService, TestimonialService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IUpdateProfileService, UpdateProfileService>();


            

            //Repository
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IBusRepository, BusRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IChildRepository, ChildRepository>();
            builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
            builder.Services.AddScoped<IPageContentRepository, PageContentRepository>();
            builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<IUpdateProfileRepository, UpdateProfileRepository>();



            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is our secret key of the bus tracking system This is our secret key of the bus tracking system"))
            });


            builder.Services.AddCors(corsOptions =>

            {

                corsOptions.AddPolicy("policy",

                builder =>

                {

                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();

                });

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }




            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("policy");

            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
