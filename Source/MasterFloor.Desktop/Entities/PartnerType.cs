using System;
using System.Collections.Generic;

namespace MasterFloor.Desktop.Entities;

public partial class PartnerType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
