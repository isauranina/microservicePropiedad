using Property.Domain.Model.Propiedades;
using Property.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Repositories
{
    public interface IPropiedadRepository : IRepository<Propiedad,Guid>
    {
        Task<IEnumerable<Propiedad>> GetAllAsync();
        Task UpdateAsync(Propiedad propiedad);
   


    }
}
