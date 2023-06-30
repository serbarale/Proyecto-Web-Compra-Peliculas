using System;
using System.Collections.Generic;

namespace TrabajoFinalActualizado.Models;

public partial class TbCliente
{
    public int IdCliente { get; set; }

    public string NombreCliente { get; set; } = null!;

    public string ApellidoCliente { get; set; } = null!;

    public string CorreoCliente { get; set; } = null!;

    public string UsuarioCliente { get; set; } = null!;

    public string PasswordCliente { get; set; } = null!;

    public string? DireccionCliente { get; set; }

    public string? DistritoCliente { get; set; }

    public string? ProvinciaCliente { get; set; }

    public string? TarjetaNuestraCliente { get; set; }

    public virtual ICollection<TbFactura> TbFacturas { get; set; } = new List<TbFactura>();
}
