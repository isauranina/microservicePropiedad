﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.Items.Command.CrearItem
{
    public class CrearItemCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }

    }
}
