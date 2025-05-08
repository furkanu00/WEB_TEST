using WEB_TEST.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<PService>();
builder.Services.AddControllers();

// Swagger'ý etkinleþtir
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger her ortamda çalýþsýn
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WEB_TEST API v1");
    c.RoutePrefix = string.Empty; // Swagger UI ana sayfa olsun
});


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
