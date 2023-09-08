using System;
using System.Collections.Generic;

namespace SistemaUniformes.Models;

public partial class Tipos
{
    public int IdTipo { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Grupos> Grupos { get; set; } = new List<Grupos>();

    public virtual ICollection<Productos> Productos { get; set; } = new List<Productos>();
}
