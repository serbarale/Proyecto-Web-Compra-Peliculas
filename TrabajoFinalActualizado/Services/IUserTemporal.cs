using TrabajoFinalActualizado.Models;

namespace TrabajoFinalActualizado.Services
{
    public interface IUserTemporal
    {
        void add(MemoryUser obj);
        IEnumerable<MemoryUser> GetAllTemporarySale();
        public void edit(MemoryUser obj);
        public IEnumerable<CambiarInfPersonal> GelAllTemporarySale();
        
        //public TbCliente GetClientes(int id);
        public string comprobarTarjeta(int codigo);
        public int obtenID();
    }
}
