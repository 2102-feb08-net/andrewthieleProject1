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

    public List<StoreApp.Library.Models.Order> GetOrders()
    {
      var orders = new List<StoreApp.Library.Models.Order>();

      var orderquery = _orders.Orders
      .Include(o => o.Customer)
      .Include(o => o.Location)
      .Include(o => o.Orderitems)
        .ThenInclude(oi => oi.Product)
      .ToList();

      foreach (var order in orderquery)
      {
        var itemsOrdered = new HashSet<Orderline>();
        foreach (var orderedItem in order.Orderitems)
        {
          var product = new Library.Models.Product(orderedItem.Product.Name, orderedItem.Product.Description, (decimal)orderedItem.Product.Price);

          itemsOrdered.Add(new Library.Models.Orderline
          {
            Id = orderedItem.Id,
            OrderId = (int)orderedItem.OrderId,
            Product = product,
            Quantity = orderedItem.Quantity
          });
        }
        orders.Add(new Library.Models.Order
        {
          Id = order.Id,
          CustomerId = (int)order.CustomerId,
          TimeOfOrder = order.TimeOfOrder,
          LocationId = (int)order.LocationId,
          OrderItems = itemsOrdered
        });
      }

      return orders;

    }

    public StoreApp.Library.Models.Order GetOrderById(int id)
    {
      var order = new StoreApp.Library.Models.Order();
      var query = _orders.Orders
      .Find(id);
      var items = _orders.Orderitems.Where(oi => oi.OrderId == id).ToList();
      var allItemsInOrder = new HashSet<Orderline>();
      foreach (var item in items)
      {
        var product = new StoreApp.Library.Models.Product(item.Product.Name, item.Product.Description, (decimal)item.Product.Price);
        allItemsInOrder.Add(new Orderline
        {
          Id = item.Id,
          OrderId = (int)item.OrderId,
          Quantity = item.Quantity,
          Product = product
        });
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
      .Where(o => o.CustomerId == customerId);

      foreach (var order in ordersByCustomer)
      {
        var itemsInCustomerOrder = new HashSet<StoreApp.Library.Models.Orderline>();

        foreach (var orderline in order.Orderitems)
        {
          var product = new StoreApp.Library.Models.Product(orderline.Product.Name, orderline.Product.Description, (decimal)orderline.Product.Price);

          itemsInCustomerOrder.Add(new StoreApp.Library.Models.Orderline
          {
            Id = orderline.Id,
            OrderId = (int)orderline.OrderId,
            Product = product,
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

      var ordersByLocation = _orders.Orders
      .Include(o => o.Customer)
      .Include(o => o.Location)
      .Include(o => o.Orderitems)
        .ThenInclude(oi => oi.Product)
      .Where(o => o.LocationId == locationId);

      foreach (var order in ordersByLocation)
      {
        var itemsInLocationOrder = new HashSet<StoreApp.Library.Models.Orderline>();

        foreach (var orderline in order.Orderitems)
        {
          var product = new StoreApp.Library.Models.Product(orderline.Product.Name, orderline.Product.Description, (decimal)orderline.Product.Price);

          itemsInLocationOrder.Add(new StoreApp.Library.Models.Orderline
          {
            Id = orderline.Id,
            OrderId = (int)orderline.OrderId,
            Product = product,
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
        orderItems.Add(new StoreApp.DbAccess.Entities.Orderitem
        {
          ProductId = orderLine.ProductId,
          Quantity = orderLine.Quantity
        });
      }
      _orders.Orders.Add(new StoreApp.DbAccess.Entities.Order
      {
        CustomerId = order.CustomerId,
        TimeOfOrder = DateTimeOffset.Now,
        Orderitems = orderItems,
        LocationId = order.LocationId
      });
    }

    public void Save()
    {
      _orders.SaveChanges();
    }

  }
}