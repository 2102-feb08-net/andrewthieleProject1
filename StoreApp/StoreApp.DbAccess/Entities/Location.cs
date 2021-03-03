using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess.Entities
{
  public partial class Location
  {
    public Location()
    {
      Inventories = new HashSet<Inventory>();
      Orders = new HashSet<Order>();
    }

    public int Id { get; set; }
    public string Code { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
  }
}
