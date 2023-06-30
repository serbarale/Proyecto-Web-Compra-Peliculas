using Microsoft.VisualBasic;
using System.Collections.Generic;
using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public class UsuarioRepository : IUsuario
    {
        private VentasC conexion = new VentasC();
        
        bool IUsuario.compararUsuario(MemoryUser obj)
        {
            var objComparar = (from tusu in conexion.TbClientes
                               where
                               tusu.UsuarioCliente == obj.UserName &&
                               tusu.PasswordCliente == obj.Password
                               select tusu).FirstOrDefault();

            if (objComparar != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidarAdmin(TbAdministradore objAdmin)
        {
            var objEncontrado = (from tbadm in conexion.TbAdministradores
                                 where tbadm.UsuarioAdmin == objAdmin.UsuarioAdmin
                                 && tbadm.PasswordAdministrador == objAdmin.PasswordAdministrador
                                 select tbadm).FirstOrDefault();

            if (objEncontrado != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void add(int codigo)
        {
            var objComparar = (from tusu in conexion.TbClientes
                               where tusu.IdCliente == codigo
                               select tusu).FirstOrDefault();
            int idT = objComparar.IdCliente;
            string tipoMovimientoT = "REGISTRO";
            float saldoT = 0;
            int puntos_acumuladosT = 0;
            string fecha_registroT = DateTime.Now.ToLongDateString();
            DateTime date2= Convert.ToDateTime(fecha_registroT);

            //TARJETA
            Random random = new Random();
            int number;
            number=random.Next(10000, 100000);

            string name1 = objComparar.ApellidoCliente;
            string name2 = objComparar.NombreCliente;

            string name3 = name1.Substring(0, 2);
            string name4 = name2.Substring(0, 2);

            string numeroTajerta=name3+number+name4;

            TbTarjetaEmpresa tbTarjetaEmpresa = new TbTarjetaEmpresa();

            tbTarjetaEmpresa.IdCliente = idT;
            tbTarjetaEmpresa.TipoMovimiento = tipoMovimientoT;
            tbTarjetaEmpresa.Saldo = (decimal)saldoT;
            tbTarjetaEmpresa.PuntosAcumulados = puntos_acumuladosT;
            tbTarjetaEmpresa.FechaMovimiento = date2;
            tbTarjetaEmpresa.NumeroTarjeta = numeroTajerta;
            conexion.TbTarjetaEmpresas.Add(tbTarjetaEmpresa);
            conexion.SaveChanges();
        }
        public TbTarjetaEmpresa GetTarjetaEmpresa(int codigo)
        {
            var objEncontrado = (from tpro in conexion.TbTarjetaEmpresas
                                 where tpro.IdCliente == codigo
                                 select tpro).FirstOrDefault();//LINQ
            return objEncontrado;
        }
        public void editDetails(int codigo)
        {
            var objAModificar = (from tdis in conexion.TbClientes
                                 where tdis.IdCliente == codigo
                                 select tdis).FirstOrDefault();
            string tarjeta = "SI";
            if (objAModificar != null)
            {
                objAModificar.TarjetaNuestraCliente = tarjeta;
            }
            conexion.SaveChanges();
        }

        public TbCliente editarClientes(int codigo)
        {
            var objEncontrado = (from tdis in conexion.TbClientes
                                 where tdis.IdCliente == codigo
                                 select tdis).Single();
            return objEncontrado;
        }

        public void editandoLosDatos(TbCliente obj)
        {
            var objAModificar = (from tdis in conexion.TbClientes
                                 where tdis.IdCliente == obj.IdCliente
                                 select tdis).FirstOrDefault();
            if (objAModificar != null)
            {
                objAModificar.NombreCliente = obj.NombreCliente;
                objAModificar.ApellidoCliente = obj.ApellidoCliente;
                objAModificar.DireccionCliente = obj.DireccionCliente;
                objAModificar.ProvinciaCliente = obj.ProvinciaCliente;
                objAModificar.DistritoCliente = obj.DistritoCliente;
                objAModificar.CorreoCliente= obj.CorreoCliente;
            }
            conexion.SaveChanges();
            
        }

        
    }
}
