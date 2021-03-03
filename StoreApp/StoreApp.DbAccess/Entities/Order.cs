using System;
using System.Collections.Generic;

#nullable disable

namespace StoreApp.DbAccess.Entities
{
  public partial class Order
  {
    public Order()
    {
      Orderitems = new HashSet<Orderitem>();
    }

    public int Id { get; set; }
    public int? CustomerId { get; set; }
    public DateTimeOffset TimeOfOrder { get; set; }
    public int? LocationId { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual Location Location { get; set; }
    public virtual ICollection<Orderitem> Orderitems { get; set; }
  }
}
