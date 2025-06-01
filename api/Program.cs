using data.Context;
using Microsoft.EntityFrameworkCore;
using service.Service;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<AdocaoService>();
builder.Services.AddScoped<AnimalService>();
builder.Services.AddScoped<LocalService>();
builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<ReportService>();
builder.Services.AddScoped<SensorService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("conn")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "FindMyPet API",
        Version = "v1",
        Description = "API do FindMyPet, uma plataforma de adocao de animais em situações de tragedias",
        Contact = new OpenApiContact
        {
            Name = "Pedro Novais",
            Url = new Uri("https://www.linkedin.com/in/pedroonovais/")
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v2/swagger.json", "FindMyPet API v1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
