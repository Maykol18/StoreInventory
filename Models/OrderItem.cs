using System;
using System.Collections.Generic;

namespace MyFirstApi.Data;

public partial class OrderItem
{
    public int Id { get; set; }

    public int Orderid { get; set; }

    public int Productid { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual Orden Order { get; set; } = null!;

    public virtual Producto Product { get; set; } = null!;
}
