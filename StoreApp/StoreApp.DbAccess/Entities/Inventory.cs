using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess.Entities
{
  public partial class Inventory
  {
    public int Id { get; set; }
    public int? LocationId { get; set; }
    public int? ProductId { get; set; }
    public int InStock { get; set; }

    public virtual Location Location { get; set; }
    public virtual Product Product { get; set; }
  }
}
