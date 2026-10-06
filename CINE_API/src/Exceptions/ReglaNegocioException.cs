namespace CINE_API.Exceptions;

// EXCEPCION PERSONALIZADA PA CUANDO NO SE CUMPLE UNA LOGICA ESTABLECIDA 
// HEREDA DE EXCEPTION PA PODER LANZARLA CON THROW
public class ReglaNegocioException : Exception
{
    // RECIBE EL MENSAJE Y SE LO PASA AL PADRE (EXCEPTION) CON BASE
    public ReglaNegocioException(string mensaje) : base(mensaje) { }
}
