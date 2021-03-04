using System;

namespace StoreApp.Library.Models
{
  public class Order
  {
    public int id
    {
      get;
      set;
    }

    public DateTimeOffset TimeOfOrder
    {
      get;
      set;
    }

    public int CustomerId
    {
      get;
      set;
    }

    public int LocationId
    {
      get;
      set;
    }

  }
}
