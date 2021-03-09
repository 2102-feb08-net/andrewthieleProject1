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
  /// <summary>
  /// Customer repository to get all customer info
  /// </summary>
  public class CustomerRepository// : ICustomerRepository
  {
    private readonly StoreProj0Context _customers;

    public CustomerRepository(StoreProj0Context customers)
    {
      _customers = customers;
    }
    /// <summary>
    /// Gets all customers and returns them as a list
    /// </summary>
    /// <returns></returns>
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
    /// <summary>
    /// Gets Customer by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public StoreApp.Library.Models.Customer GetCustomerById(int id)
    {
      var query = _customers.Customers.Find(id);
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
        throw new Exception("Customer does not exist");
      }
    }
    /// <summary>
    /// Gets Customer from their first name and last name
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <returns></returns>
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
        return new StoreApp.Library.Models.Customer(firstName, lastName);
        // throw new Exception("Customer does not exist");
      }
    }
    /// <summary>
    /// Adds a customer
    /// </summary>
    /// <param name="customer"></param>
    public void AddCustomer(StoreApp.Library.Models.Customer customer)
    {
      _customers.Customers.Add(new StoreApp.DbAccess.Entities.Customer
      {
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        Balance = 0M
      });
    }
    /// <summary>
    /// Updates Customer Balance
    /// </summary>
    /// <param name="id"></param>
    /// <param name="ammound"></param>
    public void UpdateCustomerBalance(int id, decimal ammound)
    {
      var customerBalance = _customers.Customers.Find(id);
      customerBalance.Balance += ammound;
    }
    /// <summary>
    /// Saves ammendments to database
    /// </summary>
    public void Save()
    {
      _customers.SaveChanges();
    }

  }
}
