using SistemaUniformes.Models;

namespace SistemaUniformes.Business
{
    public interface IAddInfo
    {
        public Task<bool> AgregarEmpleado(Empleados empleado);

        public Task<bool> AgregarPivote(TablaPivote pivote);

        public Task<bool> AgregarOrdenSalida(List<string> ids, List<string> values);

        public Task<bool> AgregarProducto(Productos producto);

        public Task<bool> AgregarOrdenEntrada(List<string> ids, List<string> cantidades);
    }
}
