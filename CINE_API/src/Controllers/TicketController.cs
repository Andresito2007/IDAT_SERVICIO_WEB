using CINE_API.Dtos;
using CINE_API.Models;
using CINE_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CINE_API.Controllers;

// El controlador solo recibe la petición, llama al servicio y responde.
// Los errores (404, 400, 409) los lanza el servicio y los atrapa
// el ManejadorExcepciones, por eso aquí no hay try/catch.
[ApiController]
[Route("api/tickets")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _service;

    // ASP.NET nos entrega el servicio automáticamente (inyección de dependencias).
    public TicketsController(ITicketService service)
    {
        _service = service;
    }

    // GET: api/tickets
    [HttpGet]
    public ActionResult<List<Ticket>> ObtenerTodos()
    {
        return Ok(_service.ObtenerTodos());
    }

    // GET: api/tickets/2
    [HttpGet("{id}")]
    public ActionResult<Ticket> ObtenerPorId(int id)
    {
        return Ok(_service.ObtenerPorId(id));
    }

    // POST: api/tickets
    // [ApiController] revisa las anotaciones del DTO antes de entrar al método.
    // Si algo está mal, responde 400 Bad Request automáticamente.
    [HttpPost]
    public ActionResult<Ticket> Crear(TicketRequestDto dto)
    {
        Ticket creado = _service.Crear(dto);

        // 201 Created + la ruta donde se puede consultar el ticket creado.
        return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
    }

    // PUT: api/tickets/2
    [HttpPut("{id}")]
    public ActionResult<Ticket> Actualizar(int id, TicketRequestDto dto)
    {
        return Ok(_service.Actualizar(id, dto));
    }

    // DELETE: api/tickets/2
    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        _service.Eliminar(id);

        // 204 No Content: se eliminó y no hay nada que devolver.
        return NoContent();
    }
}
