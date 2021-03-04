using System;

namespace StoreApp.Library.Models
{
  public class Orderline
  {

    public int Id
    {
      get;
      set;
    }

    public int OrderId
    {
      get;
      set;
    }

    public int ProductId
    {
      get;
      set;
    }

    public int quantity
    {
      get;
      set;
    }

  }
}
