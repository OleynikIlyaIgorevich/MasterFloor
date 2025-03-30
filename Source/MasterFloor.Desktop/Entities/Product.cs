using System;
using System.Collections.Generic;

namespace MasterFloor.Desktop.Entities;

public partial class Product
{
    public int Id { get; set; }

    public int ProductTypeId { get; set; }

    public string Title { get; set; } = null!;

    public string Articul { get; set; } = null!;

    public decimal MinimalPrice { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual ProductType ProductType { get; set; } = null!;
}
