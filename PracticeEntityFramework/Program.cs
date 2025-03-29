using Microsoft.EntityFrameworkCore;
using PracticeEntityFramework.Data;
using PracticeEntityFramework.Interface;

/*
    Configurar la inyección de dependencias y prepara la aplicación para ejecutarse.
*/

// builder almacena la configuración de la aplicación y los servicios que se agregarán al contenedor de DI (Dependency Injection es un patrón de diseño que permite la creación de objetos dependientes de una forma más flexible)
var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión con la base de datos 
// buldier.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); hace referencia a la cadena de conexión que se encuentra en el archivo appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    // Configurar el manejo de errores de la base de datos por medio de la opción EnableRetryOnFailure
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure( // Habilita la reintentos en caso de fallos
            maxRetryCount: 5, // Número máximo de reintentos
            maxRetryDelay: TimeSpan.FromSeconds(30),// Tiempo máximo de retraso
            errorNumbersToAdd: null); // Números de error a los que se les aplicará el reintentos
    }));

// Agregar el repositorio de ubicaciones al contenedor de DI
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

// Agregar los controladores al contenedor de DI
// Add services to the container.

builder.Services.AddControllers(); // Agrega los controladores al contenedor de DI
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Agrega la documentación de la API
builder.Services.AddSwaggerGen(); // Agrega la generación de la documentación de la API

// Agregar la configuración de la aplicación
// Build the app and configure the HTTP request pipeline.
var app = builder.Build(); // Construye la aplicación

// Configurar el punto final de la API
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Si el entorno es de desarrollo se agrega la documentación de la API por medio de Swagger y SwaggerUI
{
    app.UseSwagger(); // Swagger es una herramienta que permite documentar APIs de forma sencilla 
    app.UseSwaggerUI(); // SwaggerUI es una interfaz gráfica que permite visualizar la documentación de la API
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS

app.UseAuthorization(); // Habilita la autorización

app.MapControllers(); // Mapea los controladores (Mapea se refiere a la asignación de una URL a un recurso)

app.Run(); // Ejecuta la aplicación
