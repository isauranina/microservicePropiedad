using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Propiedad.Domain.Model.Servicio;

namespace Propiedad.Domain.Repositories
{
    public interface IServicioRepository: IRepository<Servicio, Guid>
    {
        Task UpdateAsync(Servicio servicio);
    }
}
