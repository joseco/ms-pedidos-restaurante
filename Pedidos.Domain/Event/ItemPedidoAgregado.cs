﻿using Pedidos.Domain.Model.ValueObjects;
using Pedidos.Domain.ValueObjects;
using ShareKernel.Core;
using System;

namespace Pedidos.Domain.Event
{
    public record ItemPedidoAgregado : DomainEvent
    {
        public Guid ProductoId { get; }
        public PrecioValue Precio { get; }
        public CantidadValue Cantidad { get; }

        public ItemPedidoAgregado(Guid productoId, PrecioValue precio, CantidadValue cantidad) : base(DateTime.Now)
        {
            ProductoId = productoId;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
