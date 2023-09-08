using System;
using System.Collections.Generic;

namespace SistemaUniformes.Models;

public partial class Productos
{
    public int IdProducto { get; set; }

    public string? Nombre { get; set; }

    public int? Cantidad { get; set; }

    public double? Costo { get; set; }

    public int? IdTipo { get; set; }

    public virtual Tipos? IdTipoNavigation { get; set; }

    public virtual ICollection<OrdenesEntrada> OrdenesEntrada { get; set; } = new List<OrdenesEntrada>();

    public virtual ICollection<OrdenesSalida> OrdenesSalida { get; set; } = new List<OrdenesSalida>();
}
