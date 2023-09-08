using System;
using System.Collections.Generic;

namespace SistemaUniformes.Models;

public partial class OrdenesSalida
{
    public int Id { get; set; }

    public int? IdOrden { get; set; }

    public int? Cantidad { get; set; }

    public int? IdProducto { get; set; }

    public int? IdEmpleado { get; set; }

    public virtual Empleados? IdEmpleadoNavigation { get; set; }

    public virtual Ordenes? IdOrdenNavigation { get; set; }

    public virtual Productos? IdProductoNavigation { get; set; }
}
