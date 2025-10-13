using Barberia.Domain.Entities;
using Barberia.Application.Interfaces;
using Barberia.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Barberia.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BarberiaDbContext _context;

        public UsuarioRepository(BarberiaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<bool> ValidarUsuarioAsync(string nomUsuario, string contrasenia)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NomUsuario == nomUsuario && u.Contrasenia == contrasenia);

            return usuario != null;
        }
    }
}
