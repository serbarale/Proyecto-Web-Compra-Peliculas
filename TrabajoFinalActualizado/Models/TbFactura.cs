using System;
using System.Collections.Generic;

namespace TrabajoFinalActualizado.Models;

public partial class TbFactura
{
    public int IdFactura { get; set; }

    public int IdCliente { get; set; }

    public int IdAdministrador { get; set; }

    public DateTime FechaFactura { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? Total { get; set; }

    public string? FormaDePago { get; set; }

    public virtual TbAdministradore IdAdministradorNavigation { get; set; } = null!;

    public virtual TbCliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<TbDetallecompra> TbDetallecompras { get; set; } = new List<TbDetallecompra>();
}
