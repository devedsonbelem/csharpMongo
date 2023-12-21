using myMongoProject.Repositories;
using myMongoProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IAnomaliaDiariaRepository, AnomaliaDiariaRepository>();
builder.Services.AddScoped<IAnomaliaDiariaService, AnomaliaDiariaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();

app.Run();
