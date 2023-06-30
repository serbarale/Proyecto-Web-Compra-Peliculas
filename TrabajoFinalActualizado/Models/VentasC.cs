using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrabajoFinalActualizado.Models;

public partial class VentasC : DbContext
{
    public VentasC()
    {
    }

    public VentasC(DbContextOptions<VentasC> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAdministradore> TbAdministradores { get; set; }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbDetallecompra> TbDetallecompras { get; set; }

    public virtual DbSet<TbFactura> TbFacturas { get; set; }

    public virtual DbSet<TbGenero> TbGeneros { get; set; }

    public virtual DbSet<TbPelicula> TbPeliculas { get; set; }

    public virtual DbSet<TbTarjetaCliente> TbTarjetaClientes { get; set; }

    public virtual DbSet<TbTarjetaEmpresa> TbTarjetaEmpresas { get; set; }

    public virtual DbSet<TbTarjetaRecarga> TbTarjetaRecargas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-K4IG5VP\\SQLEXPRESS01;Initial Catalog=PELICULAS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAdministradore>(entity =>
        {
            entity.HasKey(e => e.IdAdministrador).HasName("PK_Administradores");

            entity.ToTable("TB_ADMINISTRADORES");

            entity.Property(e => e.IdAdministrador).HasColumnName("Id_Administrador");
            entity.Property(e => e.ApellidoAdministrador)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CorreoAdministrador)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NombreAdministrador)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PasswordAdministrador)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioAdmin)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_Cliente");

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.ApellidoCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.CorreoCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DistritoCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PasswordCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ProvinciaCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.TarjetaNuestraCliente)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioCliente)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbDetallecompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalle).HasName("PK_DetalleCompra");

            entity.ToTable("TB_DETALLECOMPRA");

            entity.Property(e => e.IdDetalle).HasColumnName("Id_Detalle");
            entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");
            entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Precio_Unitario");
            entity.Property(e => e.SubTotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Sub_Total");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.TbDetallecompras)
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompra_Factura");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.TbDetallecompras)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompra_Peliculas");
        });

        modelBuilder.Entity<TbFactura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK_Factura");

            entity.ToTable("TB_FACTURA");

            entity.Property(e => e.IdFactura).HasColumnName("Id_Factura");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("date")
                .HasColumnName("Fecha_Factura");
            entity.Property(e => e.FormaDePago)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IdAdministrador).HasColumnName("Id_Administrador");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdAdministradorNavigation).WithMany(p => p.TbFacturas)
                .HasForeignKey(d => d.IdAdministrador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Administradores");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbFacturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Cliente");
        });

        modelBuilder.Entity<TbGenero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK_Genero");

            entity.ToTable("TB_GENERO");

            entity.Property(e => e.IdGenero).HasColumnName("Id_Genero");
            entity.Property(e => e.NombreGenero)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbPelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula).HasName("PK_Peliculas");

            entity.ToTable("TB_PELICULAS");

            entity.Property(e => e.IdPelicula).HasColumnName("Id_Pelicula");
            entity.Property(e => e.FechaLanzamiento).HasColumnType("date");
            entity.Property(e => e.GeneroId).HasColumnName("Genero_Id");
            entity.Property(e => e.ImagenUrl).IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Sinopsis).HasColumnType("text");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Genero).WithMany(p => p.TbPeliculas)
                .HasForeignKey(d => d.GeneroId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Peliculas_Genero");
        });

        modelBuilder.Entity<TbTarjetaCliente>(entity =>
        {
            entity.HasKey(e => e.IdTarjetaC).HasName("PK_Tarjeta_Cliente");

            entity.ToTable("TB_TARJETA_CLIENTE");

            entity.Property(e => e.IdTarjetaC).HasColumnName("Id_TarjetaC");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaMovimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Movimiento");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.NumeroTarjeta)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Numero_Tarjeta");
            entity.Property(e => e.TipoTarjeta)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Tipo_Tarjeta");
        });

        modelBuilder.Entity<TbTarjetaEmpresa>(entity =>
        {
            entity.HasKey(e => e.IdTarjeta).HasName("PK_Tarjeta_Empresa");

            entity.ToTable("TB_TARJETA_EMPRESA");

            entity.Property(e => e.IdTarjeta).HasColumnName("Id_Tarjeta");
            entity.Property(e => e.FechaMovimiento)
                .HasColumnType("date")
                .HasColumnName("Fecha_Movimiento");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.NumeroTarjeta)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Numero_Tarjeta");
            entity.Property(e => e.PuntosAcumulados).HasColumnName("Puntos_Acumulados");
            entity.Property(e => e.Saldo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Tipo_Movimiento");
        });

        modelBuilder.Entity<TbTarjetaRecarga>(entity =>
        {
            entity.HasKey(e => e.IdTarjetaRecarga).HasName("PK_Tarjeta_Recargas");

            entity.ToTable("TB_TARJETA_RECARGAS");

            entity.Property(e => e.IdTarjetaRecarga).HasColumnName("Id_Tarjeta_Recarga");
            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FechaRecargar)
                .HasColumnType("date")
                .HasColumnName("Fecha_Recargar");
            entity.Property(e => e.FormaRecarga)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Forma_Recarga");
            entity.Property(e => e.IdTarjetaEmpresa).HasColumnName("Id_Tarjeta_Empresa");
            entity.Property(e => e.NumeroRecibo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Numero_Recibo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
