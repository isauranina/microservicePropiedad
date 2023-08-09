using Microsoft.EntityFrameworkCore;
using Propiedad.Domain.Model.Servicio;
using Propiedad.Domain.Repositories;
using Propiedad.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.Repositories
{
    internal class ServicioRepository: IServicioRepository       
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
            return await _context.Servicio.
                SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Servicio servicio)
        {
            _context.Servicio.Update(servicio);
            return Task.CompletedTask;
        }

    }
}
