using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Property.SharedKernel.Core;

namespace Property.Domain.ValueObjects;

    public record EsVerificadoValue : ValueObject
    {
        public decimal Value { get; init; }



    }

