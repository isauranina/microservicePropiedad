﻿using Microsoft.EntityFrameworkCore;
using Property.Domain.Model.Propiedades;
using Property.Domain.Repositories;
using Property.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PropiedadEntity = Property.Domain.Model.Propiedades.Propiedad;

namespace Property.Infrastructure.EF.Repositories
{
    internal class PropiedadRepository : IPropiedadRepository
    {
        private readonly WriteDbContext _context;

        public PropiedadRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(PropiedadEntity obj)
        {
            await _context.Propiedad.AddAsync(obj);
        }

        public async Task<PropiedadEntity?> FindByIdAsync(Guid id)
        {
            return await _context.Propiedad
                .Include("_servicios")
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<PropiedadEntity>> GetAllAsync()
        {
            return await _context.Propiedad
                .Include("_servicios")
                .ToListAsync();
        }

        public Task UpdateAsync(PropiedadEntity propiedad)
        {
            _context.Propiedad.Update(propiedad);
            return Task.CompletedTask;
        }
    }
}