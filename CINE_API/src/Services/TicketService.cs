using CINE_API.Data;
using CINE_API.Dtos;
using CINE_API.Exceptions;
using CINE_API.Models;

namespace CINE_API.Services;

// NUESTRA LOGICA DE NEGOCIO , DEFINIMOS LAS OPERACIONES

// IMPLEMENTA ITICKETSERVICE , OSEA CUMPLE EL CONTRATO Y TIENE TODOS SUS METODOS
public class TicketService : ITicketService
{
      // TRAEMOS LA LISTA DE TICKETS DE NUESTRA DATA (PERSISTENCIA LOCAL)
    private List<Ticket> _tickets = DatosIniciales.Tickets;

    public List<Ticket> ObtenerTodos()
    {
        return _tickets;
    }
    public Ticket ObtenerPorId(int id)
    {
        // FIRSTORDEFAULT  (LINQ) BUSCA EL PRIMER ELEMENTO QUE CUMPLS LA CONDICION

        // EL ? PARA AVISAR QUE ESTA VARIABLE PUEDE SER NULL ( NO TENER NADA) ( SI NO PUSIERAMOS EL ? LO PASARIA CON TODO NULL)
        Ticket? ticket = _tickets.FirstOrDefault(t => t.Id == id);

        if (ticket == null) // PARA QUE DEVULVA EL NULL
        {
            throw new NoEncontradoException($"NO SE ECONTRO EL TICKET CON ID DE {id}");
        }

        return ticket;
    }
    public Ticket Crear(TicketRequestDto dto) // DTO DE TIPO TICKETREQUESTDTO DE LA CLASE TICKETREQUESTDTO
    {
        ValidarDatos(dto, idActual: 0);
        // EL ID Y EL ESTADO LOS PONEMOS POR DEFECTO
        // EL ID ES EL MAYOR QUE HAY + 1 (O 1 SI LA LISTA ESTA VACIA)
        Ticket nuevo = new Ticket{Id = _tickets.Count == 0 ? 1 : _tickets.Max(t => t.Id) + 1,Estado = "Activo"};

        CopiarDatos(dto, nuevo);

        _tickets.Add(nuevo);
        return nuevo;
    }
    public Ticket Actualizar(int id, TicketRequestDto dto)
    {
        Ticket ticket = ObtenerPorId(id);

        ValidarDatos(dto, idActual: id);
        CopiarDatos(dto, ticket);

        return ticket;
    }
    public void Eliminar(int id)
    {
        Ticket ticket = ObtenerPorId(id);
        _tickets.Remove(ticket);
    }

    // REGLAS DEL CINE QUE NO SE PUEDEN HACER CON ANOTACIONES DEL DTO (NECESITAN BUSCAR EN LA DATA)
    // PRIVATE PORQUE SOLO SE USA DENTRO DE ESTA CLASE
    private void ValidarDatos(TicketRequestDto dto, int idActual)
    {
        // ANY DEVUELVE TRUE SI SE CUMPLE LA CONDICION
        if (!DatosIniciales.Clientes.Any(c => c.Id == dto.ClienteId))
        {
            throw new ReglaNegocioException($"NO EXISTE EL CLIENTE CON ID {dto.ClienteId}");
        }

        if (!DatosIniciales.Peliculas.Any(p => p.Id == dto.PeliculaId))
        {
            throw new ReglaNegocioException($"NO EXISTE LA PELICULA CON ID   {dto.PeliculaId}");
        }
        // EL ASIENTO ESTA OCUPADO SI YA HAY UN TICKET ACTIVO CON LA MISMA PELICULA , FECHA , SALA Y ASIENTO
        // ORDINALIGNORECASE PA QUE "f7" Y "F7" SEAN IGUALES
        bool asientoOcupado = _tickets.Any(t =>
            t.Id != idActual &&
            t.Estado == "Activo" &&
            t.PeliculaId == dto.PeliculaId &&
            t.FechaFuncion == dto.FechaFuncion &&
            t.Sala.Equals(dto.Sala, StringComparison.OrdinalIgnoreCase) &&
            t.Asiento.Equals(dto.Asiento, StringComparison.OrdinalIgnoreCase));

        if (asientoOcupado)
        {
            throw new ConflictoException($"EL ASIENTO {dto.Asiento.ToUpper()} YA ESTA VENDIDO PARA OTRA FUNCION.");
        }
    }

    // LE LLEVA LOS DATOS DEL DTO ALA CLASE TICKET
    // STATIC PORQUE NO USA NADA DE LA CLASE , SOLO LO QUE LE PASAMOS
    private static void CopiarDatos(TicketRequestDto dto, Ticket ticket)
    {
        // A ESE TICKET NUEVO CON SU ID Y ESTADO LE TERMINAMOS DE PASARLE LOS DATOS DEL DTO
        ticket.ClienteId = dto.ClienteId;
        ticket.PeliculaId = dto.PeliculaId;
        ticket.FechaFuncion = dto.FechaFuncion!.Value;
        ticket.Sala = dto.Sala;
        ticket.Asiento = dto.Asiento.ToUpper(); // PASARL EN MAYUSCULA
        ticket.Precio = dto.Precio;
    }
}
