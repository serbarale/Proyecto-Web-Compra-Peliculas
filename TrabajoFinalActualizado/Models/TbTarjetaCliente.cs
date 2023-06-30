using System;
using System.Collections.Generic;

namespace TrabajoFinalActualizado.Models;

public partial class TbTarjetaCliente
{
    public int IdTarjetaC { get; set; }

    public int IdCliente { get; set; }

    public string NumeroTarjeta { get; set; } = null!;

    public string TipoTarjeta { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public DateTime FechaMovimiento { get; set; }
}
