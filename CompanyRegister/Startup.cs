using CompanyRegister.Entities;
using CompanyRegister.MIddleware;
using CompanyRegister.Models;
using CompanyRegister.Models.Validators;
using CompanyRegister.Seeder;
using CompanyRegister.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRegister
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			var authenticationSettings = new AuthenticationSettings();

			services.AddSingleton(authenticationSettings);

			Configuration.GetSection("Authentication").Bind(authenticationSettings);

			services.AddAuthentication(option =>
			{
				option.DefaultAuthenticateScheme = "Bearer";
				option.DefaultScheme = "Bearer";
				option.DefaultChallengeScheme = "Bearer";
			}).AddJwtBearer(cfg =>
			{
				cfg.RequireHttpsMetadata = false;
				cfg.SaveToken = true;
				cfg.TokenValidationParameters = new TokenValidationParameters
				{
					ValidIssuer = authenticationSettings.JwtIssuer,
					ValidAudience = authenticationSettings.JwtIssuer,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
				};
			});
			services.AddAuthorization(options =>
			{
				options.AddPolicy("hasNationality", builder => builder.RequireClaim("Nationality"));
			});

			services.AddControllers().AddFluentValidation();
			services.AddControllers();
			services.AddScoped<CompanySeeder>();
			services.AddAutoMapper(this.GetType().Assembly);
			services.AddDbContext<CompanyDbContext>();
			services.AddScoped<IPersonService, PersonService>();
			services.AddScoped<ICompanyService, CompanyService>();
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<ErrorHandlingMiddleware>();
			services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
			services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
			services.AddSwaggerGen();


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CompanySeeder seeder)
		{
			seeder.Seed();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMiddleware<ErrorHandlingMiddleware>();

			app.UseAuthentication();

			app.UseHttpsRedirection();

			app.UseSwagger();

			app.UseSwaggerUI();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
