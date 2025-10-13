using Barberia.Domain.Entities;

namespace Barberia.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> GetUsuariosAsync();
        Task<bool> ValidarUsuarioAsync(string nomUsuario, string contrasenia);
    }
}
