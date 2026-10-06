namespace CINE_API.Models;

// Película que se proyecta en el cine.
public class Pelicula
{
    public int Id { get; set; }
    public string Titulo { get; set; } = "";
    public string Genero { get; set; } = "";
    public int DuracionMin { get; set; }
    public string Clasificacion { get; set; } = ""; // APT, +14, +18

    public Pelicula() { }

    public Pelicula(int id, string titulo, string genero, int duracionMin, string clasificacion)
    {
        Id = id;
        Titulo = titulo;
        Genero = genero;
        DuracionMin = duracionMin;
        Clasificacion = clasificacion;
    }
}
