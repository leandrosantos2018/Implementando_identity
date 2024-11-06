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
    // Configurações de senha
    options.Password.RequireDigit = false; // Não requer número
    options.Password.RequiredLength = 6; // Tamanho mínimo
    options.Password.RequireNonAlphanumeric = false; // Não requer caracteres especiais
    options.Password.RequireUppercase = false; // Não requer letra maiúscula
    options.Password.RequireLowercase = false; // Não requer letra minúscula
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
