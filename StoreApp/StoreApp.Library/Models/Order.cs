using System;
using System.Collections.Generic;

namespace StoreApp.Library.Models
{
  public class Order
  {
    private int _id;
    private int _customerId;
    public Customer _customer;
    public DateTimeOffset _timeOfOrder;
    private int _locationId;
    public Location _location;

    public HashSet<Orderline> _ordereditems;

    public Order() { }
    public Order(Customer customer, DateTimeOffset timeOfOrder, Location location, HashSet<Orderline> orderedItems)
    {
      Customer = customer;
      TimeOfOrder = timeOfOrder;
      Location = location;
      OrderItems = orderedItems;
    }
    public Order(int customerId, DateTimeOffset timeOfOrder, int locationId)
    {
      _customerId = customerId;
      _timeOfOrder = timeOfOrder;
      _locationId = locationId;
    }
    public Order(int customerId, DateTimeOffset timeOfOrder, int locationId, HashSet<Orderline> orderedItems)
    {
      _customerId = customerId;
      _timeOfOrder = timeOfOrder;
      _locationId = locationId;
      _ordereditems = orderedItems;
    }
    public Order(int id, int customerId, DateTimeOffset timeOfOrder, int locationId)
    {
      _id = id;
      _customerId = customerId;
      _timeOfOrder = timeOfOrder;
      _locationId = locationId;
    }
    public Order(int id, int customerId, DateTimeOffset timeOfOrder, int locationId, HashSet<Orderline> orderedItems)
    {
      _id = id;
      _customerId = customerId;
      _timeOfOrder = timeOfOrder;
      _locationId = locationId;
      _ordereditems = orderedItems;
    }
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

    public Customer Customer
    {
      get => _customer;
      set => _customer = value;
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

    public Location Location
    {
      get => _location;
      set => _location = value;
    }
    /// <summary>
    /// Adds an ordered item to the order
    /// </summary>
    /// <param name="orderedItem"></param>
    public void AddOrderItem(Orderline orderedItem)
    {
      _ordereditems.Add(orderedItem);
    }
    /// <summary>
    /// Checks if Order object holds a valid customerId from database
    /// </summary>
    /// <returns></returns>
    public bool HasValidCustomerId()
    {
      return _customerId > 0;
    }
    /// <summary>
    /// Checks if Ordr Object holds a valid LocadionId from database
    /// </summary>
    /// <returns></returns>
    public bool HasValidLocationId()
    {
      return _locationId > 0;
    }
    /// <summary>
    /// Returns number of items in an order
    /// </summary>
    /// <returns></returns>
    public bool OrderHasItems()
    {
      return _ordereditems.Count > 0;
    }
    /// <summary>
    /// Checks if Order Object holds valid id from database
    /// </summary>
    /// <returns></returns>
    public bool HasValidOrderId()
    {
      return _id > 0;
    }

  }
}
