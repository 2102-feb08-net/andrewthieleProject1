using System;
using System.Collections.Generic;

namespace StoreApp.Library.Models
{
  public class Order
  {
    private int _id;
    private int _customerId;
    private DateTimeOffset _timeOfOrder;
    private int _locationId;

    private HashSet<Orderline> _ordereditems;
    public int Id
    {
      get => _id;
      set => _id = value;
    }

    public int CustomerId
    {
      get => _customerId;
      set => _customerId = value;
    }

    public DateTimeOffset TimeOfOrder
    {
      get => _timeOfOrder;
      set => _timeOfOrder = value;
    }
    public HashSet<Orderline> OrderItems
    {
      get => _ordereditems;
      set => _ordereditems = value;
    }

    public int LocationId
    {
      get => _locationId;
      set => _locationId = value;
    }

    public void AddOrderItem(Orderline orderedItem)
    {
      _ordereditems.Add(orderedItem);
    }

  }
}
