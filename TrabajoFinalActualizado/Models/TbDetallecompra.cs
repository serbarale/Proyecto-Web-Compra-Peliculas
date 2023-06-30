using System;
using System.Collections.Generic;

namespace TrabajoFinalActualizado.Models;

public partial class TbDetallecompra
{
    public int IdDetalle { get; set; }

    public int IdFactura { get; set; }

    public int IdPelicula { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal SubTotal { get; set; }

    public virtual TbFactura IdFacturaNavigation { get; set; } = null!;

    public virtual TbPelicula IdPeliculaNavigation { get; set; } = null!;
}
