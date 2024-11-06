using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsuarioApi.Data;
using UsuarioApi.Models;
using UsuarioApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Contexto>
    (opts =>
    {
        opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

builder.Services.AddIdentity<Usuario,IdentityRole>()
    .AddEntityFrameworkStores<Contexto>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<UsuarioServices>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Configura��es de senha
    options.Password.RequireDigit = false; // N�o requer n�mero
    options.Password.RequiredLength = 6; // Tamanho m�nimo
    options.Password.RequireNonAlphanumeric = false; // N�o requer caracteres especiais
    options.Password.RequireUppercase = false; // N�o requer letra mai�scula
    options.Password.RequireLowercase = false; // N�o requer letra min�scula
});

builder.Services.AddControllers();
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
