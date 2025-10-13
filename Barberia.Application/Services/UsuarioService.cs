using Barberia.Domain.Entities;
using Barberia.Application.Interfaces;

namespace Barberia.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            return await _usuarioRepository.GetAllUsuariosAsync();
        }
        public async Task<bool> ValidarUsuarioAsync(string nomUsuario, string contrasenia)
        {
            return await _usuarioRepository.ValidarUsuarioAsync(nomUsuario, contrasenia);
        }
    }
}
