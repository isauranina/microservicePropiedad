﻿﻿﻿using Microsoft.EntityFrameworkCore;
using Property.Domain.Model.Servicio;
using Property.Domain.Repositories;
using Property.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Property.Infrastructure.EF.Repositories
{
    internal class ServicioRepository : IServicioRepository
    {
        private readonly WriteDbContext _context;

        public ServicioRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Servicio obj)
        {
            await _context.Servicio.AddAsync(obj);
        }

        public async Task<Servicio?> FindByIdAsync(Guid id)
        {
            return await _context.Servicio.FindAsync(id);
        }

        public async Task<IEnumerable<Servicio>> GetAllAsync(string? searchTerm = null)
        {
            var query = _context.Servicio.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(s => s.Descripcion.Contains(searchTerm));
            }

            return await query.ToListAsync();
        }

        public Task UpdateAsync(Servicio servicio)
        {
            _context.Servicio.Update(servicio);
            return Task.CompletedTask;
        }
    }
}