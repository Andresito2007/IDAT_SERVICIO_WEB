using CINE_API.Middleware;
using CINE_API.Services;

// EL BUILDER ES EL QUE NOS PERMITE CONFIGURAR LA APP
var builder = WebApplication.CreateBuilder(args);

// AGREGAMOS LOS CONTROLADORES AL SERVIDOR
builder.Services.AddControllers();

// REGISTRAMOS EL SERVICIO : CUANDO ALGUIEN PIDA ITICKETSERVICE LE DAMOS TICKETSERVICE (INYECCION DE DEPENDENCIAS)
// SINGLETON = UNA SOLA INSTANCIA PA TODA LA APP , ASI LA LISTA EN MEMORIA NO SE PIERDE ENTRE PETICIONES (PATRON DE DISEÑO)
builder.Services.AddSingleton<ITicketService, TicketService>();

// REGISTRAMOS NUESTRO MANEJADORES DE ERRORES
builder.Services.AddExceptionHandler<ManejadorExcepciones>();
builder.Services.AddProblemDetails();

var app = builder.Build();


// PRENDE EL MIDDLEWARE DE ERRORES , VA PRIMERO PA ATRAPAR LOS ERRORES DE TODO LO QUE VIENE DESPUES
app.UseExceptionHandler();

app.UseHttpsRedirection(); // REDIRIGE DE HTTP A HTTPS

app.UseAuthorization();

app.MapControllers();

// LEVANTAMOS NUESTRO SERVIDOR
app.Run();

