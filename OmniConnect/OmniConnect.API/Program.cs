using OmniConnect.Aplicacao.Interfaces;
using OmniConnect.Aplicacao.Servicos;
using OmniConnect.Dominio.Interfaces.Repositorios;
using OmniConnect.Dominio.Interfaces.Servicos;
using OmniConnect.Infraestrutura.Repositorios;
using OmniConnect.Infraestrutura.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorioFake>();
builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
builder.Services.AddHttpClient<IViaCepServico, ViaCepServico>();

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
