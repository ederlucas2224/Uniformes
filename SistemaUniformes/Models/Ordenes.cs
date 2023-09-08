using System;
using System.Collections.Generic;

namespace SistemaUniformes.Models;

public partial class Ordenes
{
    public int IdOrden { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual ICollection<OrdenesEntrada> OrdenesEntrada { get; set; } = new List<OrdenesEntrada>();

    public virtual ICollection<OrdenesSalida> OrdenesSalida { get; set; } = new List<OrdenesSalida>();
}
