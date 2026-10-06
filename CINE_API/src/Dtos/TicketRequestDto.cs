// USAMOS  ESTA BIBLIOTECA PARA VALIDAR LOS DATOS QUE NOS LLEGA DE LA PETICION
using System.ComponentModel.DataAnnotations;

namespace CINE_API.Dtos;

// DTO ( EL DATA TRANSFER OBJECT) PARA PODER TRANSPORTAR DATOS DEL CLIENTE Y NUESTRA API , TAMBIEN PARA VALIDAR LOS DATOS
public class TicketRequestDto
{
    //EL ID DEBE ESTAR DESDE EL 1 HASTA EL MAXIMO POSTIVO SINO MUESTRA EL ERROR
    [Range(1, int.MaxValue, ErrorMessage = "EL ID DEL CLIENTE ES OBLIGATORIO Y DEBE SER MAYOR A 0")]
    public int ClienteId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "EL ID DE LA PELÍCULA ES OBLIGATORIO Y DEBE SER MAYOR A 0")]
    public int PeliculaId { get; set; }

    // REQUIRED PARA QUE EL CAMPO SEA OBLIGATORIO
    [Required(ErrorMessage = "LA FECHA DE LA FUNCIÓN ES OBLIGATORIA")]
    public DateTime? FechaFuncion { get; set; }

    [Required(ErrorMessage = "LA SALA ES OBLIGATORIA")]

    // STRINGLENGTH PARA QUE EL CAMPO TENGA UN MAXIMO Y MINIMO DE CARACTERES
    [StringLength(20, MinimumLength = 3, ErrorMessage = "LA SALA DEBE TENER ENTRE 3 Y 20 CARACTERES")]
    public string Sala { get; set; } = "";

    // REGULAR EXPRESSION PARA EL FORMATO DEL ASIENTO DESDE A-L Y DE NUMERO 1-20
    [Required(ErrorMessage = "EL ASIENTO ES OBLIGATORIO.")]
    [RegularExpression("^[A-La-l]([1-9]|1[0-9]|20)$", ErrorMessage = "EL ASIENTO DEBE TENER UNA FILA (A-L) Y UN NÚMERO (1-20). EJEMPLO: F7.")]
    public string Asiento { get; set; } = "";

    // RANGO DEL PRECIO
    [Range(5, 50, ErrorMessage = "EL PRECIO DEBE ESTAR ENTRE 5 Y 50 SOLES.")]
    public decimal Precio { get; set; }
}
