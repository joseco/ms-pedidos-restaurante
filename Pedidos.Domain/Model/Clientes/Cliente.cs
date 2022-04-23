using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;

namespace Pedidos.Domain.Model.Clientes
{
    public class Cliente : AggregateRoot<Guid>
    {
        public PersonNameValue NombreCompleto { get; set; }

        public Cliente(string nombreCompleto)
        {
            Id = Guid.NewGuid();
            NombreCompleto = nombreCompleto;
        }


    }
}
