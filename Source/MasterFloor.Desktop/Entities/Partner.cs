using System;
using System.Collections.Generic;

namespace MasterFloor.Desktop.Entities;

public partial class Partner
{
    public int Id { get; set; }

    public int PartnerTypeId { get; set; }

    public string Title { get; set; } = null!;

    public string DirectorLastname { get; set; } = null!;

    public string DirectorFirstname { get; set; } = null!;

    public string? DirectorMiddlename { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Inn { get; set; } = null!;

    public int Rate { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();

    public virtual PartnerType PartnerType { get; set; } = null!;
}
