using System;
using System.Collections.Generic;

namespace TrabajoFinalActualizado.Models;

public partial class TbTarjetaRecarga
{
    public int IdTarjetaRecarga { get; set; }

    public int IdTarjetaEmpresa { get; set; }

    public string FormaRecarga { get; set; } = null!;

    public string NumeroRecibo { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public DateTime FechaRecargar { get; set; }
}
