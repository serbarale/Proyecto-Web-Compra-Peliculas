using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public class DatosDelPagoRepository: IDatosDelPago
    {
        private List<DatosDelPago> lst = new List<DatosDelPago>();

        private List<TodasMisPeliculas> pelii = new List<TodasMisPeliculas>();

        VentasC conexion = new VentasC();

        public void add(DatosDelPago datosPago)
        {
            lst.Add(datosPago);
        }
        public void limpiarD()
        {
            lst.Clear();
        }
        public void limpiarTTT()
        {
            pelii.Clear();
        }
        public void guardarTarjeta(string tarjetaaa, decimal monto, int idPersona)
        {
            var objAModificar = lst.Where(tpro => tpro.tipoDeTarjetaPPagar == tarjetaaa).FirstOrDefault();
            if (objAModificar != null)
            {
                string gasto = "Gasto";
                int codigoPersona= idPersona;
                decimal tot = monto;
                //CALCULAR GASTOS
                int puntosA = 0;
                if(0<tot && tot<25)
                {
                    puntosA = 0;
                }
                else if(25<=tot && tot<50) 
                {
                    puntosA = 1;
                }
                else if (50 <= tot && tot < 75)
                {
                    puntosA = 2;
                }
                else if (75 <= tot && tot < 100)
                {
                    puntosA = 3;
                }
                else if (100 <= tot && tot < 125)
                {
                    puntosA = 4;
                }
                else if (125 <= tot && tot < 150)
                {
                    puntosA = 5;
                }
                else if (150 <= tot && tot < 175)
                {
                    puntosA = 6;
                }
                else
                {
                    puntosA = 7;
                }
                
                //FECHA DE REGISTRO
                string fecha_registroT = DateTime.Now.ToLongDateString();
                DateTime date2 = Convert.ToDateTime(fecha_registroT);


                if (tarjetaaa != "TARJETA DE LA EMPRESA")
                {
                    TbTarjetaCliente tbTarjetaCliente = new TbTarjetaCliente();
                    tbTarjetaCliente.IdCliente = codigoPersona;
                    tbTarjetaCliente.NumeroTarjeta = objAModificar.numeroTarjeta;
                    tbTarjetaCliente.TipoTarjeta = objAModificar.tipoDeTarjetaPPagar;
                    tbTarjetaCliente.Cantidad = (decimal)tot;
                    tbTarjetaCliente.FechaMovimiento = date2;

                    conexion.TbTarjetaClientes.Add(tbTarjetaCliente);
                    conexion.SaveChanges();
                }
                else
                {
                    var objetos = conexion.TbTarjetaEmpresas.Where(tpro => tpro.IdCliente == idPersona).FirstOrDefault();
                    TbTarjetaEmpresa tbTarjetaEmpresa = new TbTarjetaEmpresa();
                    tbTarjetaEmpresa.IdCliente = codigoPersona;
                    tbTarjetaEmpresa.TipoMovimiento = gasto;
                    tbTarjetaEmpresa.Saldo = (decimal)tot;
                    tbTarjetaEmpresa.PuntosAcumulados = puntosA;
                    tbTarjetaEmpresa.FechaMovimiento = date2;
                    tbTarjetaEmpresa.NumeroTarjeta = objetos.NumeroTarjeta;

                    conexion.TbTarjetaEmpresas.Add(tbTarjetaEmpresa);
                    conexion.SaveChanges();

                }

            }
        }
        public TbFactura guardarFactura(string tarjetaaa, decimal monto, int idPersona)
        {
            var objTarjetaT = lst.Where(tpro => tpro.tipoDeTarjetaPPagar == tarjetaaa).FirstOrDefault();
            
            int a = 2;
            int tipoT = 1;

            /*EN DESCUENTO VA A SER
            1 : COMPRA
            2 : REGALO*/

            //FECHA DE REGISTRO
            string fecha_registroT = DateTime.Now.ToLongDateString();
            DateTime date2 = Convert.ToDateTime(fecha_registroT);

            TbFactura tbFactura = new TbFactura();
            
            tbFactura.IdCliente = idPersona;
            tbFactura.IdAdministrador = a;
            tbFactura.FechaFactura = date2;
            tbFactura.Descuento = tipoT;
            tbFactura.Total = monto;
            tbFactura.FormaDePago = tarjetaaa;

            conexion.TbFacturas.Add(tbFactura);
            conexion.SaveChanges();

            return tbFactura;
        }

        public string idFacLargo(int idd)
        {
            if(idd <10)
            {
                return "0000" + idd;
            }
            else if (10<=idd && idd<100)
            {
                return "000" + idd;
            }
            else
            {
                return "00" + idd;
            }
        }

        public IEnumerable<TbFactura> GetAllFacturas(int identiC)
        {
            return conexion.TbFacturas.Where(detalle => detalle.IdCliente == identiC).ToList();

        }
        public IEnumerable<TbDetallecompra> GetAllDetallesFactura(int IDF)
        {
                return conexion.TbDetallecompras.Where(detalle => detalle.IdFactura == IDF).ToList();
            
        }
        public void guardarRecarga(TbTarjetaRecarga obj, int numeroTarjeta)
        {

            string NumR = "R-000";

            //FECHA RECARGA
            string fecha_registroT = DateTime.Now.ToLongDateString();
            DateTime date2 = Convert.ToDateTime(fecha_registroT);

            TbTarjetaRecarga aab = new TbTarjetaRecarga();
            //ME EQUIVOQUE Y COLOCAJE EL ID DEL CLIENTE ENVES DEL ID DE TARJETA PERO ES LO MISMO
            aab.IdTarjetaEmpresa = numeroTarjeta;
            aab.FormaRecarga = obj.FormaRecarga;
            aab.NumeroRecibo = NumR;
            aab.Cantidad=obj.Cantidad;
            aab.FechaRecargar = date2;
            conexion.TbTarjetaRecargas.Add(aab);
            conexion.SaveChanges();
        }

        public decimal sumaRecargas(int idDelCliente)
        {
            decimal sumaT1 = 0;
            var objetos = conexion.TbTarjetaRecargas.Where(tpro => tpro.IdTarjetaEmpresa == idDelCliente);
            foreach (var obj in objetos)
            {
                sumaT1 += obj.Cantidad;
            }
            decimal sumaT2 = 0;
            var objetos22 = conexion.TbFacturas.Where(tpro => tpro.IdCliente == idDelCliente && tpro.FormaDePago == "TARJETA DE LA EMPRESA");
            foreach (var obj2 in objetos22)
            {
                sumaT2 += (decimal)obj2.Total;
            }

            decimal total = (decimal)sumaT1 - sumaT2;


            return total;

        }
        public int sumaPuntos(int idCCC)
        {
            int sumaT4 = 0;
            var objetos = conexion.TbTarjetaEmpresas.Where(tpro => tpro.IdCliente == idCCC);
            foreach (var obj in objetos)
            {
                sumaT4 += obj.PuntosAcumulados;
            }
            return sumaT4;
        }
        public IEnumerable<TbTarjetaRecarga> GetAllRecargas(int iddCC)
        {
            return conexion.TbTarjetaRecargas.Where(detalle => detalle.IdTarjetaEmpresa == iddCC).ToList();

        }
        public void AgregarPeliculas(int iddCCC)
        {

            var objAModificar = conexion.TbFacturas.Where(tpro => tpro.IdCliente == iddCCC).ToList();

            foreach (var obj in objAModificar)
            {
                var objAModificar22 = conexion.TbDetallecompras.Where(taaa => taaa.IdFactura == obj.IdFactura).ToList();

                foreach (var obbbjj in objAModificar22)
                {
                    var objAModificar3333 = conexion.TbPeliculas.FirstOrDefault(tdis => tdis.IdPelicula == obbbjj.IdPelicula);

                    var objVER = pelii.FirstOrDefault(abnnn => abnnn.IdP == obbbjj.IdPelicula);

                    if (objVER != null)
                    {
                        int cant2 = objVER.cantidadP + obbbjj.Cantidad;
                        // El código ya existe, actualiza la cantidad 
                        objVER.cantidadP = cant2;
                    }
                    else
                    {
                        TodasMisPeliculas todasss = new TodasMisPeliculas();

                        todasss.IdP = objAModificar3333.IdPelicula;
                        todasss.nombreP = objAModificar3333.Titulo;
                        todasss.imagenP = objAModificar3333.ImagenUrl;
                        todasss.cantidadP = obbbjj.Cantidad;
                        pelii.Add(todasss);
                    }
                }
            }

        }
        public IEnumerable<TodasMisPeliculas> GelAllPells()
        {
            return pelii;
        }
    }
}
