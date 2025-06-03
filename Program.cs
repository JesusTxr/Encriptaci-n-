var builder = WebApplication.CreateBuilder(args);

// Agrega esta línea para registrar los controladores
builder.Services.AddControllers();

// Agrega Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra el servicio de cifrado
builder.Services.AddScoped<CipherService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Habilita Swagger en desarrollo
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
