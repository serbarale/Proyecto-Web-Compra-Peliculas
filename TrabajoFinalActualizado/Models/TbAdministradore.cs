using System;
using System.Collections.Generic;

namespace TrabajoFinalActualizado.Models;

public partial class TbAdministradore
{
    public int IdAdministrador { get; set; }

    public string NombreAdministrador { get; set; } = null!;

    public string ApellidoAdministrador { get; set; } = null!;

    public string CorreoAdministrador { get; set; } = null!;

    public string UsuarioAdmin { get; set; } = null!;

    public string PasswordAdministrador { get; set; } = null!;

    public virtual ICollection<TbFactura> TbFacturas { get; set; } = new List<TbFactura>();
}
