using ShareKernel.Core;
using ShareKernel.Rules;

namespace Pedidos.Domain.Model.Pedidos.ValueObjects
{
    public record NumeroPedido : ValueObject
    {
        public string Value { get; }

        public NumeroPedido(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            //TODO: validar el formato del numero
            Value = value;
        }


        public static implicit operator string(NumeroPedido value)
        {
            return value.Value;
        }

        public static implicit operator NumeroPedido(string value)
        {
            return new NumeroPedido(value);
        }



    }
}
