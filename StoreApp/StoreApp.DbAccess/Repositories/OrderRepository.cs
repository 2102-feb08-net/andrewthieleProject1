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
    // public IEnumerable<StoreApp.DbAccess.Entities.Order> GetOrders()
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

    public StoreApp.Library.Models.Order GetOrderById(int id)
    {
      var query = _orders.Orders.Find(id);
      var items = _orders.Orderitems.Select(i => i.OrderId == id);
      var allItemsInOrder = new HashSet<Orderline>();
      foreach (var item in items)
      {
        var orderedItem = new Orderline();
      }

      return new Library.Models.Order
      {
        Id = query.Id,
        CustomerId = (int)query.CustomerId,
        TimeOfOrder = query.TimeOfOrder,
        OrderItems = allItemsInOrder,
        LocationId = (int)query.LocationId
      };

    }

    public List<StoreApp.Library.Models.Order> GetOrdersByCustomerId(int customerId)
    {
      var customerOrderHistory = new List<StoreApp.Library.Models.Order>();

      var ordersByCustomer = _orders.Orders
      .Include(o => o.Customer)
      .Include(o => o.Location)
      .Include(o => o.Orderitems)
        .ThenInclude(oi => oi.Product)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Quantity)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Id)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Product)
      //   .ThenInclude(p => p.Name)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Product)
      //   .ThenInclude(p => p.Price)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Quantity)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Product)
      .Where(o => o.CustomerId == customerId);
      // .GroupBy(o => o.CustomerId);


      var itemsInCustomerOrder = new HashSet<StoreApp.Library.Models.Orderline>();

      foreach (var order in ordersByCustomer)
      {
        foreach (var orderline in order.Orderitems)
        {
          itemsInCustomerOrder.Add(new StoreApp.Library.Models.Orderline
          {
            Id = orderline.Id,
            OrderId = (int)orderline.OrderId,
            ProductId = (int)orderline.ProductId,
            Quantity = orderline.Quantity

          });
        }
        customerOrderHistory.Add(new StoreApp.Library.Models.Order
        {

          Id = (int)order.Id,
          CustomerId = (int)order.CustomerId,
          TimeOfOrder = order.TimeOfOrder,
          LocationId = (int)order.LocationId,
          OrderItems = itemsInCustomerOrder
        });
      }

      return customerOrderHistory;
    }

    public List<StoreApp.Library.Models.Order>
    GetOrdersByLocationId(int locationId)
    {
      var locationOrderHistory = new List<StoreApp.Library.Models.Order>();

      var ordersByCustomer = _orders.Orders
      .Include(o => o.Customer)
      .Include(o => o.Location)
      .Include(o => o.Orderitems)
        .ThenInclude(oi => oi.Product)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Quantity)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Id)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Product)
      //   .ThenInclude(p => p.Name)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Product)
      //   .ThenInclude(p => p.Price)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Quantity)
      // .Include(o => o.Orderitems)
      //   .ThenInclude(oi => oi.Product)
      .Where(o => o.LocationId == locationId);
      // .GroupBy(o => o.CustomerId);


      var itemsInLocationOrder = new HashSet<StoreApp.Library.Models.Orderline>();

      foreach (var order in ordersByCustomer)
      {
        foreach (var orderline in order.Orderitems)
        {
          itemsInLocationOrder.Add(new StoreApp.Library.Models.Orderline
          {
            Id = orderline.Id,
            OrderId = (int)orderline.OrderId,
            ProductId = (int)orderline.ProductId,
            Quantity = orderline.Quantity

          });
        }
        locationOrderHistory.Add(new StoreApp.Library.Models.Order
        {

          Id = (int)order.Id,
          CustomerId = (int)order.CustomerId,
          TimeOfOrder = order.TimeOfOrder,
          LocationId = (int)order.LocationId,
          OrderItems = itemsInLocationOrder
        });
      }

      return locationOrderHistory;
    }

    public void AddOrder(StoreApp.Library.Models.Order order)
    {
      // order.OrderItems;

      var orderItems = new HashSet<StoreApp.DbAccess.Entities.Orderitem>();
      foreach (var orderLine in order.OrderItems)
      {
        orderItems.Add(new Orderitem
        {
          Id = orderLine.Id,
          OrderId = orderLine.OrderId,
          ProductId = orderLine.ProductId,
          Quantity = orderLine.Quantity
        });
      }


      _orders.Orders.Add(new StoreApp.DbAccess.Entities.Order
      {
        Id = (int)order.Id,
        CustomerId = order.CustomerId,
        TimeOfOrder = DateTimeOffset.Now,
        Orderitems = orderItems

      });
      _orders.SaveChanges();
    }

    public void Save()
    {
      _orders.SaveChanges();
    }

  }
}
