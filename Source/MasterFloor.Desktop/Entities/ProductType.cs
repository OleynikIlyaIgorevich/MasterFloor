using System;
using System.Collections.Generic;

namespace MasterFloor.Desktop.Entities;

public partial class ProductType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal ProductTypeFactor { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
