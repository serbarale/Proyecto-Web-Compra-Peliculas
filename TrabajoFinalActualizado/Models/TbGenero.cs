using System;
using System.Collections.Generic;

namespace TrabajoFinalActualizado.Models;

public partial class TbGenero
{
    public int IdGenero { get; set; }

    public string NombreGenero { get; set; } = null!;

    public virtual ICollection<TbPelicula> TbPeliculas { get; set; } = new List<TbPelicula>();
}
