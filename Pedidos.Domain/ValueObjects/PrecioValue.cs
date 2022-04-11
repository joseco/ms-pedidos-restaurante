using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Domain.ValueObjects
{
    public record PrecioValue
    {
        public decimal Value { get; }
        public PrecioValue(decimal value)
        {
            if(value < 0)
            {
                throw new BussinessRuleValidationException("Price value cannot be negative");
            }
            Value = value;
        }

        public static implicit operator decimal(PrecioValue value)
        {
            return value.Value;
        }

        public static implicit operator PrecioValue(decimal value)
        {
            return new PrecioValue(value);
        }


    }
}
