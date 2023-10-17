using SIRIUS.Rapor.Entity.Abstract;
using System;
using System.Collections.Generic;

namespace SIRIUS.Rapor.Entity.Concrete;

public partial class EkoHedefT : IEntity
{
    public int Id { get; set; }

    public string? Aciklama { get; set; }

    public decimal? Hedef { get; set; }
}
