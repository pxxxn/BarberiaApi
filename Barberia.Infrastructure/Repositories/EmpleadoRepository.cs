using Barberia.Application.Interfaces;
using Barberia.Domain.Entities;
using Barberia.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Barberia.Infrastructure.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly BarberiaDbContext _context;

        public EmpleadoRepository(BarberiaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Empleados.ToListAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Empleados.FindAsync(id);
        }

        public async Task AddAsync(Empleado empleado)
        {
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
