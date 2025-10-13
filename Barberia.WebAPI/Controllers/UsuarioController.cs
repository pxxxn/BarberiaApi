using Microsoft.AspNetCore.Mvc;
using Barberia.Application.Interfaces;
using Barberia.Domain.Entities;
using Barberia.Domain.DTOs;

namespace Barberia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetUsuarios()
        {
            var usuarios = await _usuarioService.GetUsuariosAsync();
            if (usuarios == null || !usuarios.Any())
                return NotFound("No se encontraron usuarios en la base de datos.");

            return Ok(usuarios);
        }
        [HttpPost("ValidarLogin")]
        public async Task<IActionResult> ValidarLogin([FromBody] LoginRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NomUsuario) || string.IsNullOrWhiteSpace(request.Contrasenia))
                return BadRequest("Usuario y contraseña son requeridos.");

            bool valido = await _usuarioService.ValidarUsuarioAsync(request.NomUsuario, request.Contrasenia);

            return Ok(valido);

        }
    }
}
