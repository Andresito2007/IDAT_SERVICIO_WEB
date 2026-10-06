namespace CINE_API.Models;

// Entrada que compra un cliente para ver una película.
public class Ticket
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public int PeliculaId { get; set; }
    public DateTime FechaFuncion { get; set; }
    public string Sala { get; set; } = "";
    public string Asiento { get; set; } = "";   // Ejemplo: "F7"
    public decimal Precio { get; set; }
    public string Estado { get; set; } = "Activo"; // Activo o Cancelado

    public Ticket() { }

    public Ticket(int id, int clienteId, int peliculaId, DateTime fechaFuncion,
                  string sala, string asiento, decimal precio)
    {
        Id = id;
        ClienteId = clienteId;
        PeliculaId = peliculaId;
        FechaFuncion = fechaFuncion;
        Sala = sala;
        Asiento = asiento;
        Precio = precio;
    }
}
