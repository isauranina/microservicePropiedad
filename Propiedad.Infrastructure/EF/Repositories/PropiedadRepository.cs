using Microsoft.EntityFrameworkCore;
using Propiedad.Domain.Model.Propiedades;
using Propiedad.Domain.Model.Transaciones;
using Propiedad.Domain.Repositories;
using Propiedad.Infrastructure.EF.Contexts;

namespace Propiedad.Infrastructure.EF.Repositories;

internal class PropiedadRepository : IPropiedadRepository
{
    public readonly DbSet<Propiedadd> _propiedades;
    public PropiedadRepository(WriteDbContext context)
    {
        _propiedades = context.Propiedad;
    }
    public async Task CreateAsync(Propiedadd obj)
    {
        await _propiedades.AddAsync(obj);
    }
    public async Task<Propiedadd?> FindByIdAsync(Guid id)
    {
        return await _propiedades.Include("_propiedades")
            .SingleOrDefaultAsync(x => x.Id == id);
    }
    public Task UpdateAsync(Propiedadd propiedad)
    {
        _propiedades.Update(propiedad);

        return Task.CompletedTask;
    }

}

