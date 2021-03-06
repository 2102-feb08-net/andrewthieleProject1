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
  public class CustomerRepository// : ICustomerRepository
  {
    private readonly StoreProj0Context _customers;

    public CustomerRepository(StoreProj0Context customers)
    {
      _customers = customers;
    }

    public IEnumerable<StoreApp.Library.Models.Customer> GetCustomers()
    {
      var query = _customers.Customers;
      if (query != null)
      {
        return query.Select(c => new StoreApp.Library.Models.Customer
        {
          Id = c.Id,
          FirstName = c.FirstName,
          LastName = c.LastName,
          Balance = c.Balance
        }).ToList();
      }
      else
      {
        return new List<StoreApp.Library.Models.Customer>();
      }
    }

    public StoreApp.Library.Models.Customer GetCustomerById(int id)
    {
      return new Library.Models.Customer("Bob", "Jones");
    }
    public StoreApp.Library.Models.Customer SearchForFirst(string firstName, string lastName)
    {
      var query = _customers.Customers.Where(c => c.FirstName == firstName && c.LastName == lastName).First();

      if (query != null)
      {
        return new Library.Models.Customer
        {
          FirstName = query.FirstName,
          LastName = query.LastName,
          Balance = query.Balance
        };
      }
      else
      {
        // return new StoreApp.Library.Models.Customer(firstName, lastName);
        throw new Exception("Customer does not exist");
      }
    }

    public void AddCustomer(StoreApp.Library.Models.Customer customer)
    {
      _customers.Customers.Add(new StoreApp.DbAccess.Entities.Customer
      {
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        Balance = 0M
      });
    }

    public void Save()
    {
      _customers.SaveChanges();
    }

  }
}
