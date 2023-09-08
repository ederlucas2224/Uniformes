using System;
using System.Collections.Generic;

namespace SistemaUniformes.Models;

public partial class TablaPivote
{
    public int Id { get; set; }

    public int? IdEmpleado { get; set; }

    public int? Estatus { get; set; }
}
