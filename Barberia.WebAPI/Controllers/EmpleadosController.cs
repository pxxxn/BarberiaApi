using Barberia.Application.Interfaces;
using Barberia.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Barberia.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadosController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetAll()
        {
            var empleados = await _empleadoService.GetAllAsync();
            return Ok(empleados);
        }

     
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetById(int id)
        {
            var empleado = await _empleadoService.GetByIdAsync(id);
            if (empleado == null)
                return NotFound(new { message = "Empleado no encontrado" });

            return Ok(empleado);
        }

  
        [HttpPost]
        public async Task<ActionResult<Empleado>> Create([FromBody] Empleado empleado)
        {
            var nuevo = await _empleadoService.CreateAsync(empleado);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.IdEmpleado }, nuevo);
        }

     
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.IdEmpleado)
                return BadRequest(new { message = "El ID del empleado no coincide." });

            var actualizado = await _empleadoService.UpdateAsync(empleado);
            if (!actualizado)
                return NotFound(new { message = "Empleado no encontrado." });

            return NoContent();
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _empleadoService.DeleteAsync(id);
            if (!eliminado)
                return NotFound(new { message = "Empleado no encontrado." });

            return NoContent();
        }
    }
}
