using Barberia.Application.Interfaces;
using Barberia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barberia.Application.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoService(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _empleadoRepository.GetAllAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _empleadoRepository.GetByIdAsync(id);
        }

        public async Task<Empleado> CreateAsync(Empleado empleado)
        {
            await _empleadoRepository.AddAsync(empleado);
            return empleado;
        }

        public async Task<bool> UpdateAsync(Empleado empleado)
        {
            await _empleadoRepository.UpdateAsync(empleado);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _empleadoRepository.DeleteAsync(id);
            return true;
        }

    }
}
