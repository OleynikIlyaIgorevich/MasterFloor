using System;
using System.Collections.Generic;

namespace MasterFloor.Desktop.Entities;

public partial class MaterialType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal RejectionRate { get; set; }
}
