using ChaihanaForEmplyee.Controllers;
using ChaihanaForEmplyee.Services;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using SharedLibrary.DataBase_and_more;
using SharedLibrary.Repository.Default;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUnitOfWorkEmployee, UnitOfWorkEmployee>();
builder.Services.AddScoped<IUnitOfWorkCafe, UnitOfWorkCafe>();
builder.Services.AddScoped<RegistrationService>();

/*builder.Services.AddDbContext<WebDbForCafe>((sp, options) =>
{
	var dataSource = sp.GetKeyedService<NpgsqlDataSource>("WebDbForCafe");
	*//*var dataSource = sp.GetRequiredService<NpgsqlDataSource>();*//*
	options.UseNpgsql(dataSource);
});*/

builder.Services.AddDbContext<WebDbForEmployee>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("WebDbForEmployee")));

builder.Services.AddDbContext<WebDbForCafe>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("WebDbForCafe")));

var config = new TypeAdapterConfig();
new MappingConfig().Register(config);

builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, Mapper>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			ValidIssuer = AuthOptions.ISSUER,
			ValidAudience = AuthOptions.AUDIENCE,
			IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
		};
		options.Events = new JwtBearerEvents
		{
			OnMessageReceived = context =>
			{
				context.Token = context.Request.Cookies["jwt_token"];
				return Task.CompletedTask;
			}
		};
	});

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("admin", policy => policy.RequireRole("admin"));
    options.AddPolicy("manager", policy => policy.RequireRole("manager"));
    options.AddPolicy("waiter", policy => policy.RequireRole("waiter"));
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "Registration",
    pattern: "Employee/{action=Index}",
    defaults: new { controller = "Registration" });

app.Run();
