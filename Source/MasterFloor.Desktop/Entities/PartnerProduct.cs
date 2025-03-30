using System;
using System.Collections.Generic;

namespace MasterFloor.Desktop.Entities;

public partial class PartnerProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int PartnerId { get; set; }

    public decimal SellPrice { get; set; }

    public DateOnly SellAt { get; set; }

    public virtual Partner Partner { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
