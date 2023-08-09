using  Propiedad.Domain.Model.Transaciones;
using Restaurant.SharedKernel.Core;

namespace Propiedad.Domain.Repositories;

public interface ITransaccionRepository : IRepository<Transaccion, Guid>
{
    Task UpdateAsync(Transaccion transaccion);
}
