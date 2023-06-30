using Microsoft.Identity.Client;
using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public class UserTemporalRepository : IUserTemporal
    {
        private VentasC conexion = new VentasC();   

        private List<MemoryUser> lst = new List<MemoryUser>();

        private CambiarInfPersonal aab = new CambiarInfPersonal();

        private List<CambiarInfPersonal> aav = new List<CambiarInfPersonal>();
        public void add(MemoryUser obj)
        {
            lst.Clear();
            lst.Add(obj);
        }

        public void edit(MemoryUser obj)
        {
            var objEncontrado = (from tinf in conexion.TbClientes
                                 where tinf.UsuarioCliente == obj.UserName
                                 select tinf).FirstOrDefault();
            if (objEncontrado == null) 
            {

            }
            else
            {
                aav.Clear();
                aab.IdPersonal = objEncontrado.IdCliente;
                aab.usuarioPersonal = objEncontrado.UsuarioCliente;
                aab.nombrePersonal = objEncontrado.NombreCliente;
                aab.apellidoPersonal = objEncontrado.ApellidoCliente;
                aab.direccionPersonal = objEncontrado.DireccionCliente;
                aab.provinciaPersonal = objEncontrado.ProvinciaCliente;
                aab.distritoPersonal = objEncontrado.DistritoCliente;
                aab.correoPersonal = objEncontrado.CorreoCliente;
                aav.Add(aab);
            }

        }
        public int obtenID()
        {
            int codigoPersona = 0;
            for (int i = 0; i < aav.Count; i++)
            {
                codigoPersona = aav[i].IdPersonal;
            }
            return codigoPersona;
        }
        public IEnumerable<CambiarInfPersonal> GelAllTemporarySale()
        {
            return aav;
        }

        public IEnumerable<MemoryUser> GetAllTemporarySale()
        {
            return lst;
        }
        public string comprobarTarjeta(int codigo)
        {
            string a = "NO";
            string b = "SI";
            var objEncontrado = (from tinf in conexion.TbTarjetaEmpresas
                                 where tinf.IdCliente == codigo
                                 select tinf).FirstOrDefault();
            if(objEncontrado == null)
            {
                return a;
            }
            else
            {
                return b;
            }
        }
        
    }
}
