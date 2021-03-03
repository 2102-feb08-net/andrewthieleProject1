using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess.Entities
{
  public partial class Product
  {
    public Product()
    {
      Inventories = new HashSet<Inventory>();
      Orderitems = new HashSet<Orderitem>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal? Price { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; }
    public virtual ICollection<Orderitem> Orderitems { get; set; }
  }
}
