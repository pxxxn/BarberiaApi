using Barberia.Domain.Entities;

namespace Barberia.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllUsuariosAsync();
        Task<bool> ValidarUsuarioAsync(string nomUsuario, string contrasenia);
    }

}
