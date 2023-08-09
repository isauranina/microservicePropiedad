using Propiedad.Domain.Model.Propiedades;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Repositories
{
    public interface IPropiedadRepository : IRepository<Propiedadd,Guid>
    {
        Task UpdateAsync(Propiedadd propiedad);

    }
}
