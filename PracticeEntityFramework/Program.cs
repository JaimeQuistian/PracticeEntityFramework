using Microsoft.EntityFrameworkCore;
using PracticeEntityFramework.Data;
using PracticeEntityFramework.Interface;

/*
    Configurar la inyecci�n de dependencias y prepara la aplicaci�n para ejecutarse.
*/

// builder almacena la configuraci�n de la aplicaci�n y los servicios que se agregar�n al contenedor de DI (Dependency Injection es un patr�n de dise�o que permite la creaci�n de objetos dependientes de una forma m�s flexible)
var builder = WebApplication.CreateBuilder(args);

// Configurar la conexi�n con la base de datos 
// buldier.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); hace referencia a la cadena de conexi�n que se encuentra en el archivo appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    // Configurar el manejo de errores de la base de datos por medio de la opci�n EnableRetryOnFailure
    sqlServerOptionsAction: sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure( // Habilita la reintentos en caso de fallos
            maxRetryCount: 5, // N�mero m�ximo de reintentos
            maxRetryDelay: TimeSpan.FromSeconds(30),// Tiempo m�ximo de retraso
            errorNumbersToAdd: null); // N�meros de error a los que se les aplicar� el reintentos
    }));

// Agregar el repositorio de ubicaciones al contenedor de DI
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

// Agregar los controladores al contenedor de DI
// Add services to the container.

builder.Services.AddControllers(); // Agrega los controladores al contenedor de DI
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Agrega la documentaci�n de la API
builder.Services.AddSwaggerGen(); // Agrega la generaci�n de la documentaci�n de la API

// Agregar la configuraci�n de la aplicaci�n
// Build the app and configure the HTTP request pipeline.
var app = builder.Build(); // Construye la aplicaci�n

// Configurar el punto final de la API
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) // Si el entorno es de desarrollo se agrega la documentaci�n de la API por medio de Swagger y SwaggerUI
{
    app.UseSwagger(); // Swagger es una herramienta que permite documentar APIs de forma sencilla 
    app.UseSwaggerUI(); // SwaggerUI es una interfaz gr�fica que permite visualizar la documentaci�n de la API
}

app.UseHttpsRedirection(); // Redirige las solicitudes HTTP a HTTPS

app.UseAuthorization(); // Habilita la autorizaci�n

app.MapControllers(); // Mapea los controladores (Mapea se refiere a la asignaci�n de una URL a un recurso)

app.Run(); // Ejecuta la aplicaci�n
