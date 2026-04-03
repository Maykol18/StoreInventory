using System;
using System.Collections.Generic;

namespace MyFirstApi.Data;

public partial class Categoria
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
