﻿using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.ValueObjects;

public record CostoValue : ValueObject
{
    public decimal Value { get; init; }

    public CostoValue(decimal value)
    {
        if (value < 0)
        {
            throw new BussinessRuleValidationException("El costo no puede ser negativo");
        }

        Value = value;
    }

    public static implicit operator decimal(CostoValue costo) => costo.Value;

    public static implicit operator CostoValue(decimal value)
    {
        return new CostoValue(value);
    }
}