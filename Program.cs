using Audaces.Controllers.Interfaces;
using Audaces.Domain;
using Microsoft.OpenApi.Models;
using Infra.Models;
using Infra.Interfaces;
using Infra.Repository;
using Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataBaseContext>(opt => opt.UseInMemoryDatabase("memoryDB"));
//builder.Services.AddDbContext<DataBaseContext>(opt => opt.UseSqlServer("Password=djKs5fQ$P7A6h8Aj; Persist Security Info=False;User ID=user_test;Initial Catalog=AUDACES_TESTE;Data Source=mssql.procart.net.br"));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Audaces", Version = "v1" });
            });

//builder.Services.AddScoped<DataBaseContext>();  
builder.Services.AddScoped<ICombinacoes, Combinacoes>();
builder.Services.AddScoped<ICombinacoesRepository, CombinacoesRepository>() ;



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI( c => {c.RoutePrefix = string.Empty; 
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1") ;});

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
