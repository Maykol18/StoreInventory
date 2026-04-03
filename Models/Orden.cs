using System;
using System.Collections.Generic;

namespace MyFirstApi.Data;

public partial class Orden
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public decimal Totalamount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
