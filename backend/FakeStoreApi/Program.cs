var builder = WebApplication.CreateBuilder(args);

// Agrega servicios para controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// Habilita controladores
app.UseAuthorization();
app.MapControllers();

app.Run();
