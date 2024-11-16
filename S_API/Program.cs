using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using S_BLL.BL;
using S_BLL.Model;
using S_DAL.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Action<DbContextOptionsBuilder> optionsAction = (DbContextOptionsBuilder options) =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<UserContext>(optionsAction);
builder.Services.AddDbContext<RequestToConnectContext>(optionsAction);
builder.Services.AddScoped<ServerConfig>((serviceProvider) =>
    new ServerConfig(serviceProvider.GetService<IConfiguration>()["PathToServerConfig"]));
builder.Services.AddScoped<JoinToServerBl>();
builder.Services.AddScoped<AuthenticateUserBl>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();