using SistemaUniformes.Data;
using SistemaUniformes.Models;

namespace SistemaUniformes.Business
{
    public class AccessInfo : IAccessInfo
    {
        private readonly Context context;

        public AccessInfo(Context context)
        {
            this.context = context;
        }

        public async Task<List<Empleados>> GetAllEmpleados()
        {
            try
            {
                var result = this.context.Empleados.Where(x => x.Activo.Equals(true)).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Grupos>> GetAllGrupos()
        {
            var result = this.context.Grupos.ToList();
            return result;
        }

        public async Task<Empleados> GetByIdEmpleado(int id)
        {
            try
            {
                var result = this.context.Empleados.Where(x => x.IdEmpleado.Equals(id)).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Productos>> GetAllProductos()
        {
            try
            {
                var result = this.context.Productos.ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Tipos>> GetAllTipos()
        {
            try
            {
                var result = this.context.Tipos.ToList();
                return result;
            }catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Productos> GetByIdProducto(int id)
        {
            try
            {
                var result = this.context.Productos.Where(x => x.IdProducto.Equals(id)).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<OrdenesEntrada>> GetAllOrdenesEntrada()
        {
            try
            {
                var result = this.context.OrdenesEntrada.ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<OrdenesSalida>> GetAllOrdenesSalida()
        {
            try
            {
                var result = this.context.OrdenesSalida.ToList();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
