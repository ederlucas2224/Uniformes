using System;
using System.Collections.Generic;

namespace SistemaUniformes.Models;

public partial class Empleados
{
    public int IdEmpleado { get; set; }

    public string? PrimerNombre { get; set; }

    public string? SegundoNombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public bool? Activo { get; set; }

    public int? IdGrupo { get; set; }

    public virtual Grupos? IdGrupoNavigation { get; set; }

    public virtual ICollection<OrdenesSalida> OrdenesSalida { get; set; } = new List<OrdenesSalida>();
}
