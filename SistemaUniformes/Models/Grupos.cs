using System;
using System.Collections.Generic;

namespace SistemaUniformes.Models;

public partial class Grupos
{
    public int IdGrupo { get; set; }

    public string? Nombre { get; set; }

    public int? IdTipo { get; set; }

    public virtual ICollection<Empleados> Empleados { get; set; } = new List<Empleados>();

    public virtual Tipos? IdTipoNavigation { get; set; }
}
