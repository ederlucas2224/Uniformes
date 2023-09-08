using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaUniformes.Data;
using SistemaUniformes.Models;

namespace SistemaUniformes.Business
{
    public class AddInfo : IAddInfo
    {
        private readonly Context context;

        public AddInfo(Context context)
        {
            this.context = context;
        }

        public async Task<bool> AgregarEmpleado(Empleados empleado)
        {
            try
            {
                this.context.Empleados.Add(empleado);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AgregarPivote(TablaPivote pivote)
        {
            try
            {
                this.context.TablaPivotes.Add(pivote);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AgregarOrdenSalida(List<string> ids,List<string> cantidades)
        {
            try
            {
                List<Productos> productos = new List<Productos>();

                for(int u = 0; u < ids.Count() -1; u++)
                {
                    productos.Add(this.context.Productos.Where(x => x.IdProducto.Equals(int.Parse(ids[u]))).FirstOrDefault());
                }
                Ordenes ordenes = new Ordenes();
                ordenes.Fecha = DateTime.UtcNow.AddHours(-6);
                this.context.Ordenes.Add(ordenes);
                this.context.SaveChanges();

                var idOrden = ordenes.IdOrden;

                for (int i = 0; i < productos.Count(); i++)
                {
                    OrdenesSalida producto1 = new OrdenesSalida();
                    producto1.IdOrden = idOrden;
                    producto1.Cantidad = int.Parse(cantidades[i]);
                    producto1.IdProducto = productos[i].IdProducto;
                    producto1.IdEmpleado = this.context.TablaPivotes.Where(z => z.Estatus.Equals(1)).Select(x => x.IdEmpleado).FirstOrDefault();
                    this.context.OrdenesSalida.Add(producto1);
                    this.context.SaveChanges();

                    productos[i].Cantidad = productos[i].Cantidad - int.Parse(cantidades[i]);
                    this.context.Productos.Update(productos[i]);
                    this.context.SaveChanges();
                }

                var resu = this.context.TablaPivotes.Where(x => x.Estatus.Equals(1)).FirstOrDefault();
                resu.Estatus = 2;
                this.context.TablaPivotes.Update(resu);
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AgregarProducto(Productos producto)
        {
            try
            {
                this.context.Productos.Add(producto);
                this.context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AgregarOrdenEntrada(List<string> ids, List<string> cantidades)
        {
            try
            {
                List<Productos> productos = new List<Productos>();

                for (int u = 0; u < ids.Count() - 1; u++)
                {
                    productos.Add(this.context.Productos.Where(x => x.IdProducto.Equals(int.Parse(ids[u]))).FirstOrDefault());
                }
                Ordenes ordenes = new Ordenes();
                ordenes.Fecha = DateTime.UtcNow.AddHours(-6);
                this.context.Ordenes.Add(ordenes);
                this.context.SaveChanges();

                var idOrden = ordenes.IdOrden;

                for (int i = 0; i < productos.Count(); i++)
                {
                    OrdenesEntrada producto1 = new OrdenesEntrada();
                    producto1.IdOrden = idOrden;
                    producto1.Cantidad = int.Parse(cantidades[i]);
                    producto1.IdProducto = productos[i].IdProducto;
                    this.context.OrdenesEntrada.Add(producto1);
                    this.context.SaveChanges();

                    productos[i].Cantidad = productos[i].Cantidad + int.Parse(cantidades[i]);
                    this.context.Productos.Update(productos[i]);
                    this.context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
