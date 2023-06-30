using System;
using System.Collections.Generic;

namespace TrabajoFinalActualizado.Models;

public partial class TbPelicula
{
    public int IdPelicula { get; set; }

    public string Titulo { get; set; } = null!;

    public int GeneroId { get; set; }

    public int? Duracion { get; set; }

    public string? Sinopsis { get; set; }

    public DateTime? FechaLanzamiento { get; set; }

    public decimal Precio { get; set; }

    public string? ImagenUrl { get; set; }

    public virtual TbGenero Genero { get; set; } = null!;

    public virtual ICollection<TbDetallecompra> TbDetallecompras { get; set; } = new List<TbDetallecompra>();
}
