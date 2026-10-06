namespace CINE_API.Models;

// CREAMOS LA CLASE CLIENTE (ENTIDAD)
public class Cliente
{
     // PROPIEDADEES
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Dni { get; set; } = "";
    public string Email { get; set; } = "";

    // CONSTRUCTOR PARA PODER INICIALIZAR OBJETOS
    public Cliente() { }

    public Cliente(int id, string nombre, string dni, string email)
    {
        Id = id;
        Nombre = nombre;
        Dni = dni;
        Email = email;
    }
}
