using SistemaUniformes.Models;

namespace SistemaUniformes.Business
{
    public interface IAccessInfo
    {
        public Task<List<Empleados>> GetAllEmpleados();

        public Task<Empleados> GetByIdEmpleado(int id);

        public Task<List<Grupos>> GetAllGrupos();

        public Task<List<Productos>> GetAllProductos();

        public Task<List<Tipos>> GetAllTipos();

        public Task<Productos> GetByIdProducto(int id);

        public Task<List<OrdenesEntrada>> GetAllOrdenesEntrada();

        public Task<List<OrdenesSalida>> GetAllOrdenesSalida();
    }
}
