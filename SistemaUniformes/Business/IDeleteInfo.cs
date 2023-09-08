namespace SistemaUniformes.Business
{
    public interface IDeleteInfo
    {
        public Task<bool> EliminarEmpleado(int id);

        public Task<bool> EliminarProducto(int id);
    }
}
