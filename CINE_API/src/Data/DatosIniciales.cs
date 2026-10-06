using CINE_API.Models;

namespace CINE_API.Data;

// PERSISTENCIA LOCAL ( EN LISTAS )
public static class DatosIniciales
{
    // INICIALIZAMOS VARIOS EN LISTAS LOS OBJETOS DE LAS CLASES CLIENTES , PELICULAS Y TICKETS
    //STATIC PARA USARLO DESDE OTRAS PARTES SIN INSTANCIAR LA CLASE DE NUEVO
    public static List<Cliente> Clientes =
    [
        new Cliente(1, "Estefano ochupe", "72451234", "ochuep34@correo.com"),
        new Cliente(2, "Andres Choqque", "70112233", "andres35@correo.com"),
        new Cliente(3, "Rodrigo tomayquispe", "75998877", "rodrigo39@correo.com")
    ];

    public static List<Pelicula> Peliculas =
    [
        new Pelicula(1, "Intensa-sinmente", "Animación", 90, "+8"),
        new Pelicula(2, "Dumbo 10", "Ciencia", 120, "+14"),
        new Pelicula(3, "Alien vs Perros", "Terror", 60, "+18")
    ];

    public static List<Ticket> Tickets =
    [
        new Ticket(1, 3, 1, new DateTime(2026, 10, 10, 16, 0, 0), "Sala 1", "F7", 15.70m),
        new Ticket(2, 1, 2, new DateTime(2026, 10, 10, 19, 30, 0), "Sala 3", "C4", 22.00m),
        new Ticket(3, 2, 3, new DateTime(2026, 10, 11, 21, 0, 0), "Sala 2", "H10", 18.00m)
    ];
}
