using SistemaUniformes.Data;

namespace SistemaUniformes.Business
{
    public class DeleteInfo : IDeleteInfo
    {
        private readonly Context context;

        public DeleteInfo(Context context)
        {
            this.context = context;
        }
        public async Task<bool> EliminarEmpleado(int id)
        {
            try
            {
                var resu = this.context.Empleados.Where(x => x.IdEmpleado.Equals(id)).FirstOrDefault();
                if (resu != null)
                {
                    resu.Activo = false;
                    this.context.Empleados.Update(resu);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EliminarProducto(int id)
        {
            try
            {
                var resu = this.context.Productos.Where(x => x.IdProducto.Equals(id)).FirstOrDefault();
                if (resu != null)
                {
                    this.context.Productos.Remove(resu);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
