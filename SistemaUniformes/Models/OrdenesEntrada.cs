using System;
using System.Collections.Generic;

namespace SistemaUniformes.Models;

public partial class OrdenesEntrada
{
    public int Id { get; set; }

    public int? IdOrden { get; set; }

    public int? Cantidad { get; set; }

    public int? IdProducto { get; set; }

    public virtual Ordenes? IdOrdenNavigation { get; set; }

    public virtual Productos? IdProductoNavigation { get; set; }
}
