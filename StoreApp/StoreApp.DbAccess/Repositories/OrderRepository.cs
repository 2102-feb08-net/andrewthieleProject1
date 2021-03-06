using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Library.Interfaces;
using StoreApp.Library.Models;
using StoreApp.DbAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.DbAccess.Repositories
{
  public class OrderRepository// : IOrderRepository
  {
    private readonly StoreProj0Context _orders;

    public OrderRepository(StoreProj0Context orders)
    {
      _orders = orders;
    }

    public IEnumerable<StoreApp.Library.Models.Order> GetOrders()
    {
      var query = _orders.Orders;
      var orderlines = _orders.Orderitems;

      if (orderlines != null)
      {
        var orderline = new Orderline();
      }

      if (query != null)
      {
        HashSet<Orderline> itemsInOrder = new HashSet<Orderline>();
        return query.Select(o => new StoreApp.Library.Models.Order
        {
          Id = o.Id,
          CustomerId = (int)o.CustomerId,
          LocationId = (int)o.LocationId

        }).ToList();
      }
      else
      {
        return new List<StoreApp.Library.Models.Order>();
      }
    }

    // public StoreApp.Library.Models.Order GetOrderById(int id)
    // {
    //   return _orders.Orders.Select(o => o.Id = id);
    // }
    // public StoreApp.Library.Models.Order GetOrderByFullName(string firstName, string lastName)
    // {
    //   return new StoreApp.Library.Models.Order(firstName, lastName);
    // }

    // public void AddOrder(StoreApp.Library.Models.Order order)
    // {
    //   _orders.Orders.Add(new StoreApp.DbAccess.Entities.Order
    //   {

    //   });
    // }

    public void Save()
    {
      _orders.SaveChanges();
    }

  }
}
