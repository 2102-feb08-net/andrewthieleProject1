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
    private readonly StoreProj0Context _customers;

    public OrderRepository(StoreProj0Context customers)
    {
      _customers = customers;
    }

    // public IEnumerable<StoreApp.Library.Models.Order> GetOrders()
    // {
    //   var query = _customers.Orders;
    //   if (query != null)
    //   {
    //     return query.Select(c => new StoreApp.Library.Models.Order
    //     {
    //       Id = c.Id,
    //       FirstName = c.FirstName,
    //       LastName = c.LastName,
    //       Balance = c.Balance
    //     }).ToList();
    //   }
    //   else
    //   {
    //     return new List<StoreApp.Library.Models.Order>();
    //   }
    // }

    //   public StoreApp.Library.Models.Order GetOrderById(int id)
    //   {
    //     return new Library.Models.Order("Bob", "Jones");
    //   }
    //   public StoreApp.Library.Models.Order GetOrderByFullName(string firstName, string lastName)
    //   {
    //     return new StoreApp.Library.Models.Order(firstName, lastName);
    //   }

    //   public void AddOrder(StoreApp.Library.Models.Order customer)
    //   {
    //     _customers.Orders.Add(new StoreApp.DbAccess.Entities.Order
    //     {
    //     });
    //   }

    //   public void Save()
    //   {
    //     _customers.SaveChanges();
    //   }

  }
}
