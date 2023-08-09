using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.SharedKernel.Core;

namespace Propiedad.Domain.ValueObjects;

    public record EsVerificadoValue : ValueObject
    {
        public decimal Value { get; init; }



    }

