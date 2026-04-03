using System;
using System.Collections.Generic;

namespace MyFirstApi.Data;

public partial class Producto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public int CategoriaId { get; set; }

    public int ProveedorId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Proveedor Proveedor { get; set; } = null!;
}
