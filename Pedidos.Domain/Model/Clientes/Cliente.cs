using ShareKernel.Core;
using ShareKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
