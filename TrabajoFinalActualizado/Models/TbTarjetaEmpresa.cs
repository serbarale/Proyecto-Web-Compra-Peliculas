using System;
using System.Collections.Generic;

namespace TrabajoFinalActualizado.Models;

public partial class TbTarjetaEmpresa
{
    public int IdTarjeta { get; set; }

    public int IdCliente { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public decimal Saldo { get; set; }

    public int PuntosAcumulados { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public string? NumeroTarjeta { get; set; }
}
