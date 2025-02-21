using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Habilitar CORS para Vue
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Puerto donde corre Vue (Vite usa 5173 por defecto)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

// Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FakeStore API",
        Version = "v1",
        Description = "API para gestionar productos en FakeStore",
        Contact = new OpenApiContact
        {
            Name = "Juan David Calderon",
            Email = "jdcd426@email.com",
        }
    });
});

var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowVueApp");

// Habilitar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FakeStore API v1");
        // c.RoutePrefix = "swagger"; // (Opcional) Solo si quieres cambiar la URL de Swagger
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
