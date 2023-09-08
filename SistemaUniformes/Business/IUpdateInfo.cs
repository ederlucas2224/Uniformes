using SistemaUniformes.Models;

namespace SistemaUniformes.Business
{
    public interface IUpdateInfo
    {
        public Task<bool> UpdateEmpleado(Empleados empleado);

        public Task<bool> UpdateProducto(Productos producto);
    }
}
