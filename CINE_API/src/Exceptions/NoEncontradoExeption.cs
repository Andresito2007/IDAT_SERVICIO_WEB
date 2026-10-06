namespace CINE_API.Exceptions;


// EXCEPCION PERSONALIZADA PA CUANDO BUSCAMOS ALGO QUE NO EXISTE 
// HEREDA DE EXCEPTION PA PODER LANZARLA CON THROW
public class NoEncontradoException : Exception
{   
     // RECIBE EL MENSAJE Y SE LO PASA AL PADRE (EXCEPTION) CON BASE
    public NoEncontradoException(string mensaje) : base(mensaje) { }
}
