namespace CINE_API.Dtos;

// FORMATO UNICO PARA LAS RESPUESTAS DE ERROR ( DTO DE SALIDA)
public class ErrorResponse
{
    public int Estado { get; set; }            
    public string Error { get; set; } = "";    
    public string Mensaje { get; set; } = ""; 
    public string Ruta { get; set; } = "";    
    public DateTime Fecha { get; set; } = DateTime.Now;

    // CUANDO HAY FALLAS EN LAS VALIDACIONES DE LOS CAMPOS
    public Dictionary<string, string[]>? Errores { get; set; }
}
