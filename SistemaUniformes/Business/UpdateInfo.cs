using SistemaUniformes.Data;
using SistemaUniformes.Models;

namespace SistemaUniformes.Business
{
    public class UpdateInfo : IUpdateInfo
    {
        private readonly Context context;

        public UpdateInfo(Context context)
        {
            this.context = context;
        }

        public async Task<bool> UpdateEmpleado(Empleados empleado)
        {
            try
            {
                if (empleado.IdGrupo == null)
                {
                    //No cambio el grupo
                    var emp = this.context.Empleados.Where(x => x.IdEmpleado.Equals(empleado.IdEmpleado)).FirstOrDefault();
                    if (empleado.SegundoNombre == null)
                    {
                        emp.SegundoNombre = "";
                    }
                    else
                    {
                        emp.SegundoNombre = empleado.SegundoNombre;
                    }
                    emp.PrimerNombre = empleado.PrimerNombre;
                    emp.ApellidoPaterno = empleado.ApellidoPaterno;
                    emp.ApellidoMaterno = empleado.ApellidoMaterno;
                    emp.IdEmpleado = empleado.IdEmpleado;
                    this.context.Empleados.Update(emp);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    var emp = this.context.Empleados.Where(x => x.IdEmpleado.Equals(empleado.IdEmpleado)).FirstOrDefault();

                    if (empleado.SegundoNombre == null)
                    {
                        emp.SegundoNombre = "";
                    }
                    else
                        emp.SegundoNombre = empleado.SegundoNombre;
                    emp.PrimerNombre = empleado.PrimerNombre;
                    emp.ApellidoPaterno = empleado.ApellidoPaterno;
                    emp.ApellidoMaterno = empleado.ApellidoMaterno;
                    emp.IdGrupo = empleado.IdGrupo;
                    emp.IdEmpleado = empleado.IdEmpleado;
                    this.context.Empleados.Update(emp);
                    this.context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProducto(Productos producto)
        {
            try
            {
                if (producto.IdTipo == null)
                {
                    //No cambio el tipo
                    var emp = this.context.Productos.Where(x => x.IdProducto.Equals(producto.IdProducto)).FirstOrDefault();
                    emp.Nombre = producto.Nombre;
                    emp.Cantidad = producto.Cantidad;
                    emp.Costo = producto.Costo;
                    emp.IdProducto = producto.IdProducto;
                    this.context.Productos.Update(emp);
                    this.context.SaveChanges();
                    return true;
                }
                else
                {
                    var emp = this.context.Productos.Where(x => x.IdProducto.Equals(producto.IdProducto)).FirstOrDefault();
                    emp.IdTipo = producto.IdTipo;
                    emp.Nombre = producto.Nombre;
                    emp.Cantidad = producto.Cantidad;
                    emp.Costo = producto.Costo;
                    emp.IdProducto = producto.IdProducto;
                    this.context.Productos.Update(emp);
                    this.context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
