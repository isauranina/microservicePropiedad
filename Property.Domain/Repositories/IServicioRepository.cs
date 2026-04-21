﻿using Property.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Property.Domain.Model.Servicio;

namespace Property.Domain.Repositories
{
    public interface IServicioRepository: IRepository<Servicio, Guid>
    {
        Task UpdateAsync(Servicio servicio);
        Task<IEnumerable<Servicio>> GetAllAsync(string? searchTerm = null);
    }
}
