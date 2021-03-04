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

    // public StoreApp.Library.Models.Customer GetCustomerById(int id)
    // {
    //   return
    // }
    // public StoreApp.Library.Models.Customer GetCustomerByFullName(string firstName, string lastName)
    // {
    //   return new StoreApp.Library.Models.Customer(firstName, lastName);
    // }

    // public void AddCustomer(string firstName, string LastName)
    // {
    //   _customers.Add();
    // }

    // public void Save()
    // {
    //   _customers.SaveChanges();
    // }

  }
}
