using myMongoProject.Repositories;
using myMongoProject.Service;

var builder = WebApplication.CreateBuilder(args);

 
builder.Services.AddControllers();
builder.Services.AddScoped<IAnomaliaDiariaRepository, AnomaliaDiariaRepository>();
builder.Services.AddScoped<IAnomaliaDiariaService, AnomaliaDiariaService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
      builder => builder.WithOrigins(
          "http://localhost:5095", 
          "http://localhost:4201",
          "http://localhost:4201/diarias"
          )
      .AllowAnyHeader()
      .AllowAnyMethod()
       .AllowCredentials());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowSpecificOrigin");
app.MapControllers();
app.Run();
