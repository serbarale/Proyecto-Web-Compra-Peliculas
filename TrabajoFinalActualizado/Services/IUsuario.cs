using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public interface IUsuario
    {
        bool compararUsuario(MemoryUser obj);
        bool ValidarAdmin(TbAdministradore objAdmin);
        public void add(int codigo);
        public TbTarjetaEmpresa GetTarjetaEmpresa(int codigo);
        public void editDetails(int codigo);
        public TbCliente editarClientes(int codigo);
        public void editandoLosDatos(TbCliente obj);
       


    }
}
